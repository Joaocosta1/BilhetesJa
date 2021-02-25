using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
   public interface IProductGroupService
    {
        Task<ICollection<ProductGroup>> GetAllAsync();
        Task<ICollection<ProductGroup>> GetAsync(int eventId, int limit = 10, int page = 0);
        Task<ProductGroup> FindByIdAsync(int pointofsaleId);
        Task<ICollection<ProductGroup>> GetAllAsync(string productgroupName);
        Task SaveAsync(ProductGroup @productgroup);
        Task<ICollection<ProductGroup>> GetAllAsync(Event @event);
        Task<ICollection<ProductGroup>> GetAllAsync(int eventId);
        Task<int> CountAsync(int eventId);
        Task<int> CountPagesAsync(int eventId, int limit = 10);
    }
}
