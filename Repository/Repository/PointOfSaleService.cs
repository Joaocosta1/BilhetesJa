using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;


namespace Repository.Repository
{
    public class PointOfSaleService : IPointOfSaleService
    {

        private readonly ApplicationContext _context;

        public PointOfSaleService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PointOfSale>> GetAllAsync() => await _context.PointOfSales.ToListAsync();

        public async Task<PointOfSale> FindByIdAsync(int id) =>
            await _context.PointOfSales.Where(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<ICollection<PointOfSale>> GetAllAsync(string pointofsaleName) =>
            await _context.PointOfSales.Where(p => p.Name == pointofsaleName).ToListAsync();


        public async Task<ICollection<PointOfSale>> GetAllAsync(Event @event) => await GetAllAsync(@event.Id);

        public async Task<ICollection<PointOfSale>> GetAllAsync(int eventId) =>
            await _context.PointOfSales.Where(p => p.EventId == eventId).ToListAsync();

        public async Task SaveAsync(PointOfSale pointofsale)
        {
            if (pointofsale.Id == 0)
            {
                _context.PointOfSales.Add(pointofsale);
                pointofsale.CreatedDate = DateTime.Now;
            }
            else
            {
                var entityEntry = _context.PointOfSales.Attach(pointofsale);
                pointofsale.UpdatedDate = DateTime.Now;
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(o => o.EventId).IsModified = false;
                entityEntry.Property(o => o.CreatorId).IsModified = false;
                entityEntry.Property(o => o.CreatedDate).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<PointOfSale>> GetAsync(int eventId, int limit = 10, int page = 0) => await _context
            .PointOfSales.Where(w => w.EventId == eventId).Skip(page * limit).Take(limit).ToListAsync();

        public async Task<int> CountAsync(int eventId) => await _context.PointOfSales.Where(w => w.EventId == eventId).CountAsync();

        public async Task<int> CountPagesAsync(int eventId, int limit = 10) => (await _context.PointOfSales.Where(w => w.Id == eventId).CountAsync()) / limit;
    }
}