using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IPaymentTypeService : IPaginable
    {
        Task<ICollection<PaymentType>> GetAllAsync(int eventId);
        Task<ICollection<PaymentType>> GetAllAsync(Event @event);
        Task<ICollection<PaymentType>> GetAsync(int eventId, int limit, int page);
        Task<ICollection<PaymentType>> GetAsync(int limit, int page);
        Task<ICollection<PaymentType>> GetAsync(Event @event, int limit, int page);
        Task<PaymentType> FindByIdAsync(int paymentTypeId);
        Task SaveAsync(PaymentType paymentType);
        Task DeleteAsync(PaymentType paymentType);
        Task DeleteAsync(int paymentTypeId);
        Task<int> CountAsync(int eventId);
        Task<int> CountPagesAsync(int eventId, int limit);
        Task<int> CountPagesAsync(Event @event, int limit);
    }
}