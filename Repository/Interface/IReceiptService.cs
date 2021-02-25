using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IReceiptService : IPaginable
    {
        Task<List<Receipt>> GetAsync(int eventId, int limit = 10, int page = 0);
        Task<List<Receipt>> GetAsync(Event @event, int limit = 10, int page = 0);
        Task<Receipt> FindByIdAsync(int productId);
        Task SaveAsync(Receipt receipt, bool bypassProcessCheck = false);
        Task ProcessAsync(Receipt receipt);
        Task ProcessAsync(int receiptId);
        Task CancelAsync(Receipt receipt);
        Task CancelAsync(int receiptId);
    }
}