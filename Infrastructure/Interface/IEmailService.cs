using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IEmailService
    {
        Task SendAsync();
    }
}