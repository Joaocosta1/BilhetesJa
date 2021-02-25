using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Interface
{
    public interface IFileService
    {
        Task SaveFile(string path, IFormFile formFile);
    }
}