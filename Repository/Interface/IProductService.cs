using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync(int eventId);
        Task<List<Product>> GetAllAsync(Event @event);
        Task<List<Product>> GetAsync(int eventId, int limit = 10, int page = 0);
        Task<List<Product>> GetAsync(Event @event, int limit = 10, int page = 0);
        Task<Product> FindByIdAsync(int productId);
        Task SaveAsync(Product product);
        void CalculateApportionment(Product product);
        Task DeleteAsync(Product product);
        Task DeleteAsync(int productId);
        Task<int> CountAsync(int eventId);
        Task<int> CountAsync(Event @event);
        Task<int> CountPagesAsync(int eventId, int limit = 10);
        Task<int> CountPagesAsync(Event @event, int limit = 10);
    }
}