using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IWarehouseService
    {
        Task<ICollection<Warehouse>> GetAllAsync(int eventId);
        Task<ICollection<Warehouse>> GetAllAsync(Event @event);
        Task<ICollection<Warehouse>> GetAsync(int eventId, int limit = 10, int page = 0);
        Task<ICollection<Warehouse>> GetAsync(Event @event, int limit = 10, int page = 0);
        Task<Warehouse> FindByIdAsync(int warehouseId);
        Task SaveAsync(Warehouse warehouse);
        Task DeleteAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
        Task<int> CountAsync(int eventId);
        Task<int> CountAsync(Event @event);
        Task<int> CountPagesAsync(int eventId, int limit = 10);
        Task<int> CountPagesAsync(Event @event, int limit = 10);
        Task MoveStock(ICollection<WarehouseTransaction> transactions, bool transactionOwner = true, bool saveChanges = true);
    }
}