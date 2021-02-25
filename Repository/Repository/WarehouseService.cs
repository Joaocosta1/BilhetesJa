using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Repository.Exception;
using Repository.Interface;

namespace Repository.Repository
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ApplicationContext _context;

        public WarehouseService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Warehouse>> GetAsync(int eventId, int limit = 10, int page = 0) => await _context
            .Warehouses.Where(w => w.EventId == eventId).Skip(page * limit).Take(limit).ToListAsync();

        public async Task<ICollection<Warehouse>> GetAsync(Event @event, int limit = 10, int page = 0) =>
            await GetAsync(@event.Id, limit, page);

        public async Task<ICollection<Warehouse>> GetAllAsync(int eventId) =>
            await _context.Warehouses.Where(w => w.EventId == eventId).ToListAsync();

        public async Task<ICollection<Warehouse>> GetAllAsync(Event @event) => await GetAllAsync(@event.Id);

        public async Task<Warehouse> FindByIdAsync(int id) =>
            await _context.Warehouses.Where(w => w.Id == id).FirstOrDefaultAsync();

        public async Task<int> CountAsync(int eventId) => await _context.Warehouses.Where(w => w.EventId == eventId).CountAsync();
        
        public async Task<int> CountAsync(Event @event) => await CountAsync(@event.Id);

        public async Task<int> CountPagesAsync(int eventId, int limit = 10) => (await _context.Warehouses.Where(w => w.Id == eventId).CountAsync()) / limit;

        public async Task<int> CountPagesAsync(Event @event, int limit = 10) => await CountPagesAsync(@event.Id, limit);
        public async Task MoveStock(ICollection<WarehouseTransaction> transactions, bool transactionOwner = true, bool saveChanges = true)

        public async Task <ICollection> 
        {
            try
            {
                foreach (var warehouseTransaction in transactions)
                {
                    var warehouseProduct = await _context.WarehouseProducts.FirstOrDefaultAsync(wp =>
                        wp.ProductId == warehouseTransaction.ProductId &&
                        wp.WarehouseId == warehouseTransaction.WarehouseId);

                    if (warehouseProduct == null)
                    {
                        warehouseProduct = new WarehouseProduct(warehouseTransaction.WarehouseId, warehouseTransaction.ProductId, warehouseTransaction.Amount);
                        _context.Add(warehouseProduct);
                    }
                    else
                    {
                        warehouseProduct.Amount += (warehouseTransaction.Type == WarehouseTransactionType.In
                            ? warehouseTransaction.Amount
                            : warehouseTransaction.Amount * -1);

                        if (warehouseProduct.Amount < 0)
                            throw new WarehouseDoesNotHaveEnoughProductsException();
                        
                        _context.Attach(warehouseProduct);
                    }
                    
                    _context.Add(warehouseTransaction);
                }

                if(saveChanges)
                    await _context.SaveChangesAsync();
                
            }
            catch (System.Exception)
            {
                throw;
                // TODO: Handle error
            }
        }

        public async Task SaveAsync(Warehouse warehouse)
        {
            if (warehouse.Id == 0)
            {
                _context.Warehouses.Add(warehouse);
            }
            else
            {
                var entityEntry = _context.Warehouses.Attach(warehouse);
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(o => o.EventId).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Warehouse warehouse)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}