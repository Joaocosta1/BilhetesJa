using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
   public interface IPointOfSaleService
    {
        Task<ICollection<PointOfSale>> GetAllAsync();
        Task<ICollection<PointOfSale>> GetAsync(int eventId, int limit = 10, int page = 0);
        Task<PointOfSale> FindByIdAsync(int pointofsaleId);
        Task<ICollection<PointOfSale>> GetAllAsync(string pointofsaleName);
        Task SaveAsync(PointOfSale @pointofsale);
        Task<ICollection<PointOfSale>> GetAllAsync(Event @event);
        Task<ICollection<PointOfSale>> GetAllAsync(int eventId);
        Task<int> CountAsync(int eventId);
        Task<int> CountPagesAsync(int eventId, int limit = 10);
    }
}
