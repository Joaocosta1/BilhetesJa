using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repository
{
    public class ProductGroupService : IProductGroupService
    {

        private readonly ApplicationContext _context;

        public ProductGroupService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ProductGroup>> GetAllAsync() => await _context.ProductGroups.ToListAsync();

        public async Task<ProductGroup> FindByIdAsync(int id) =>
            await _context.ProductGroups.Where(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<ICollection<ProductGroup>> GetAllAsync(string productgroupName) =>
            await _context.ProductGroups.Where(p => p.Name == productgroupName).ToListAsync();

         public async Task<ICollection<ProductGroup>> GetAllAsync(Event @event) => await GetAllAsync(@event.Id);

        public async Task<ICollection<ProductGroup>> GetAllAsync(int eventId) =>
            await _context.ProductGroups.Where(p => p.EventId == eventId).ToListAsync();

        public async Task SaveAsync(ProductGroup productgroup)
        {
            if (productgroup.Id == 0)
            {
                _context.ProductGroups.Add(productgroup);
                productgroup.CreatedDate = DateTime.Now;
            }
            else
            {
                var entityEntry = _context.ProductGroups.Attach(productgroup);
                productgroup.UpdatedDate = DateTime.Now;
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(o => o.EventId).IsModified = false;
                entityEntry.Property(o => o.CreatorId).IsModified = false;
                entityEntry.Property(o => o.CreatedDate).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ProductGroup>> GetAsync(int eventId, int limit = 10, int page = 0) => await _context
             .ProductGroups.Where(w => w.EventId == eventId).Skip(page * limit).Take(limit).ToListAsync();

        public async Task<int> CountAsync(int eventId) => await _context.ProductGroups.Where(w => w.EventId == eventId).CountAsync();

        public async Task<int> CountPagesAsync(int eventId, int limit = 10) => (await _context.ProductGroups.Where(w => w.Id == eventId).CountAsync()) / limit;

    }
}