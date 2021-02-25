using System.Threading.Tasks;
using Domain.Entity;

namespace Repository.Interface
{
    public interface ISaleService
    {
        Task SaveAsync(Sale sale);
    }
}