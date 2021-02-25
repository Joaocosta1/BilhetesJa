using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Repository
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly ApplicationContext _context;

        public PaymentTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PaymentType>> GetAllAsync(int eventId) =>
            await _context.PaymentTypes.Where(pt => pt.EventId == eventId).ToListAsync();

        public async Task<ICollection<PaymentType>> GetAllAsync(Event @event) => await GetAllAsync(@event.Id);
        
        public async Task<ICollection<PaymentType>> GetAsync(int limit, int page) =>
            await _context.PaymentTypes.Skip(limit * page).Take(limit).ToListAsync();

        public async Task<ICollection<PaymentType>> GetAsync(int eventId, int limit, int page) =>
            await _context.PaymentTypes.Where(pt => pt.EventId == eventId).Skip(limit * page).Take(limit).ToListAsync();

        public async Task<ICollection<PaymentType>> GetAsync(Event @event, int limit, int page) =>
            await GetAsync(@event.Id, limit, page);

        public async Task<PaymentType> FindByIdAsync(int paymentTypeId) =>
            await _context.PaymentTypes.Where(pt => pt.Id == paymentTypeId).FirstOrDefaultAsync();

        public async Task<int> CountAsync() =>
            await _context.PaymentTypes.CountAsync();
        public async Task<int> CountAsync(int eventId) =>
            await _context.PaymentTypes.Where(pt => pt.EventId == eventId).CountAsync();

        public async Task<int> CountAsync(Event @event) => await CountAsync(@event.Id);
        
        public async Task<int> CountPagesAsync(int limit) =>
            (await _context.PaymentTypes.CountAsync()) / limit;

        public async Task<int> CountPagesAsync(int eventId, int limit) =>
            (await _context.PaymentTypes.Where(pt => pt.EventId == eventId).CountAsync()) / limit;

        public async Task<int> CountPagesAsync(Event @event, int limit) => await CountPagesAsync(@event.Id, limit);

        public async Task SaveAsync(PaymentType paymentType)
        {
            if (paymentType.Id == 0)
            {
                _context.PaymentTypes.Add(paymentType);
            }
            else
            {
                var entityEntry = _context.PaymentTypes.Attach(paymentType);
                entityEntry.State = EntityState.Modified;
                entityEntry.Property(o => o.EventId).IsModified = false;
            }

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(PaymentType paymentType)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int paymentTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}