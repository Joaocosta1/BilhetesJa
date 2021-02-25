using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repository
{
    public class EventService : IEventService
    {
        private readonly ApplicationContext _context;

        public EventService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Event>> GetAllAsync() => await _context.Events.ToListAsync();

        public async Task<ICollection<Event>> GetAsync(int limit = 10, int page = 0) =>
            await _context.Events.OrderByDescending(o => o.CreatedDate).Skip(limit * page).Take(limit).ToListAsync();

        public async Task<Event> FindByIdAsync(int id) =>
            await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<int> CountAsync() => await _context.Events.CountAsync();

        public async Task<int> CountPagesAsync(int limit = 10) => (await CountAsync()) / limit;
        
        public async Task SaveAsync(Event @event)
        {
            if (@event.Id == 0)
            {
                _context.Events.Add(@event);
                @event.CreatedDate = DateTime.Now;
            }
            else
            {
                var entityEntry = _context.Events.Attach(@event);
                @event.UpdatedDate = DateTime.Now;
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(o => o.CreatorId).IsModified = false;
                entityEntry.Property(o => o.CreatedDate).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Event @event)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int eventId)
        {
            throw new System.NotImplementedException();
        }
    }
}