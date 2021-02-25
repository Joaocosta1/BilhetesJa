using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface ITransferService
    {
        Task SaveAsync(Transfer transfer);
        Task Process(Transfer transfer);
        Task Process(int transferId);
        Task Cancel(Transfer transfer);
        Task Cancel(int transferId);
        Task<Transfer> FindByIdAsync(int transferId);
        Task<List<Transfer>> GetAsync(int eventId, int limit, int page);
        Task<int> CountAsync();
        Task<int> CountPagesAsync(int limit = 10);
    }
}