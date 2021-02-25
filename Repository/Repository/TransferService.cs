using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repository
{
    public class TransferService : ITransferService
    {
        private readonly ApplicationContext _context;
        private readonly IWarehouseService _warehouseService;

        public TransferService(ApplicationContext context, IWarehouseService warehouseService)
        {
            _context = context;
            _warehouseService = warehouseService;
        }

        public async Task SaveAsync(Transfer transfer)
        {
            if (transfer.Id == 0)
            {
                transfer.CreatedDate = DateTime.Now;
                _context.Add(transfer);
            }
            else
            {
                var dbTransfer = await FindByIdAsync(transfer.Id);
                var transferItems = new TransferItem[transfer.Items.Count];
                transfer.Items.CopyTo(transferItems, 0);
                dbTransfer.Items.Clear();

                await _context.SaveChangesAsync();
                
                dbTransfer.UpdatedDate = DateTime.Now;
                var entityEntry = _context.Entry(dbTransfer);
                entityEntry.State = EntityState.Modified;
                dbTransfer.Items = transferItems;
                dbTransfer.WarehouseDestinyId = transfer.WarehouseDestinyId;
                dbTransfer.WarehouseOriginId = transfer.WarehouseOriginId;
                entityEntry.Property(p => p.EventId).IsModified = false;
                entityEntry.Property(p => p.CreatorId).IsModified = false;
                entityEntry.Property(p => p.CreatedDate).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Process(Transfer transfer)
        {
            using (var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                try
                {
                    var itemsToRemoveFromWarehouse = transfer.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.Out, WarehouseId = transfer.WarehouseOriginId,
                        })
                        .ToList();
                    
                    var itemsToAddToWarehouse = transfer.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.In, WarehouseId = transfer.WarehouseDestinyId,
                        })
                        .ToList();

                    var itemsToChangeOnWarehouse = itemsToAddToWarehouse.Concat(itemsToRemoveFromWarehouse).ToList();

                    await _warehouseService.MoveStock(itemsToChangeOnWarehouse, false);

                    transfer.ProcessingDate = DateTime.Now;
                    transfer.State = TransferState.Processed;
                    await SaveAsync(transfer);
                    
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    // TODO: Handle failure
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task Process(int transferId)
        {
            var transfer = await FindByIdAsync(transferId);
            await Process(transfer);
        }

        public async Task Cancel(Transfer transfer)
        {
            using (var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                try
                {
                    var itemsToAddToWarehouse = transfer.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.In, WarehouseId = transfer.WarehouseOriginId,
                        })
                        .ToList();
                    
                    var itemsToRemoveFromWarehouse = transfer.Items.Select(receiptItem => new WarehouseTransaction()
                        {
                            Amount = receiptItem.Amount, ProductId = receiptItem.ProductId, Type = WarehouseTransactionType.Out, WarehouseId = transfer.WarehouseDestinyId,
                        })
                        .ToList();

                    var itemsToChangeOnWarehouse = itemsToAddToWarehouse.Concat(itemsToRemoveFromWarehouse).ToList();

                    await _warehouseService.MoveStock(itemsToChangeOnWarehouse, false);

                    transfer.CancellationDate = DateTime.Now;
                    transfer.State = TransferState.Cancelled;
                    await SaveAsync(transfer);
                    
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    // TODO: Handle failure
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task Cancel(int transferId)
        {
            var transfer = await FindByIdAsync(transferId);
            await Cancel(transfer);
        }

        public Task<Transfer> FindByIdAsync(int transferId) =>
            _context.Transfers.FirstOrDefaultAsync(t => t.Id == transferId);

        public Task<List<Transfer>> GetAsync(int eventId, int limit, int page) => _context.Transfers
            .Where(t => t.EventId == eventId).Skip(page * limit).Take(limit).ToListAsync();

        public Task<int> CountAsync() => _context.Transfers.CountAsync();

        public async Task<int> CountPagesAsync(int limit = 10) => await CountAsync() / limit;
    }
}