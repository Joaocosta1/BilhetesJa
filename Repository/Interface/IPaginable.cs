using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPaginable
    {
        Task<int> CountAsync();
        Task<int> CountPagesAsync(int limit = 10);
    }
}