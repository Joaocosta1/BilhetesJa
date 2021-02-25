using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.Exception;
using Repository.Interface;

namespace Repository.Repository
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationContext _context;
        private readonly IWarehouseService _warehouseService;

        public ReceiptService(ApplicationContext context, IWarehouseService warehouseService)
        {
            _context = context;
            _warehouseService = warehouseService;
        }

        public Task<List<Receipt>> GetAsync(int eventId, int limit = 10, int page = 0) => _context.Receipts
            .Where(r => r.EventId == eventId).Skip(limit * page).Take(limit).ToListAsync();

        public Task<List<Receipt>> GetAsync(Event @event, int limit = 10, int page = 0) =>
            GetAsync(@event.Id, limit, page);

        public Task<Receipt> FindByIdAsync(int receiptId) =>
            _context.Receipts.FirstOrDefaultAsync(r => r.Id == receiptId);

        public async Task SaveAsync(Receipt receipt, bool bypassProcessCheck = false)
        {
            if (receipt.Id == 0)
            {
                receipt.CreatedDate = DateTime.Now;
                var entityEntry = _context.Add(receipt);
            }
            else
            {
                if(receipt.State != ReceiptState.New && !bypassProcessCheck)
                    throw new ReceiptIsNotNewException();
                
                var dbReceipt = await FindByIdAsync(receipt.Id);
                var receiptItems = new ReceiptItem[receipt.Items.Count];
                receipt.Items.CopyTo(receiptItems, 0);
                dbReceipt.Items.Clear();

                await _context.SaveChangesAsync();
                
                dbReceipt.UpdatedDate = DateTime.Now;
                var entityEntry = _context.Entry(dbReceipt);
                entityEntry.State = EntityState.Modified;
                dbReceipt.Items = receiptItems;
                entityEntry.Property(p => p.EventId).IsModified = false;
                entityEntry.Property(p => p.CreatorId).IsModified = false;
                entityEntry.Property(p => p.CreatedDate).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        private bool SameProducts(IEnumerable<ReceiptItem> lri1, ICollection<ReceiptItem>lri2) => lri1.Any(item => !lri2.Any(c => SameProductInLists(item, c)));

        private bool SameProductInLists(ReceiptItem ri1, ReceiptItem ri2) => ((ri1.Amount.Equals(ri2.Amount)) && (ri1.ProductId.Equals(ri2.ProductId)));

        public async Task ProcessAsync(Receipt receipt)
        {
            if(receipt.State != ReceiptState.New)
                throw new ReceiptIsNotNewException();
            
            using (var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                try
                {
                    var itemsToAddOnWarehouse = receipt.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.In, WarehouseId = receipt.WarehouseId,
                        })
                        .ToList();

                    await _warehouseService.MoveStock(itemsToAddOnWarehouse, false);

                    receipt.ProcessingDate = DateTime.Now;
                    receipt.State = ReceiptState.Processed;
                    await SaveAsync(receipt, true);
                    
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    // ignored
                    // TODO: Handle failure
                }
            }
        }

        public async Task CancelAsync(Receipt receipt)
        {
            if(receipt.State != ReceiptState.Processed)
                throw new ReceiptIsNotNewException();
            
            using (var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                try
                {
                    var itemsToRemoveFromWarehouse = receipt.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.Out, WarehouseId = receipt.WarehouseId,
                        })
                        .ToList();

                    await _warehouseService.MoveStock(itemsToRemoveFromWarehouse, false);

                    receipt.CancellationDate = DateTime.Now;
                    receipt.State = ReceiptState.Cancelled;
                    await SaveAsync(receipt, true);
                    
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    // ignored
                    // TODO: Handle failure
                }
            }
        }
        
        public async Task ProcessAsync(int receiptId)
        {
            var receipt = await FindByIdAsync(receiptId);
            await ProcessAsync(receipt);
        }

        public async Task CancelAsync(int receiptId)
        {
            var receipt = await FindByIdAsync(receiptId);
            await CancelAsync(receipt);
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountPagesAsync(int limit = 10)
        {
            throw new NotImplementedException();
        }
    }
}