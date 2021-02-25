using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IEventService
    {
        Task<ICollection<Event>> GetAllAsync();
        Task<ICollection<Event>> GetAsync(int limit = 10, int page = 0);
        Task<Event> FindByIdAsync(int id);
        Task SaveAsync(Event @event);
        Task DeleteAsync(Event @event);
        Task DeleteAsync(int eventId);
        Task<int> CountAsync();
        Task<int> CountPagesAsync(int limit = 10);
    }
}