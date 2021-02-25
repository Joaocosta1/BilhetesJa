using System.IO;
using System.Threading.Tasks;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using TinifyAPI;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
            Tinify.Key = "HGGx9fRx4grwTNTlm7TVkprqwCFCPxVw";
        }

        public async Task SaveFile(string path, IFormFile formFile)
        {
            var filePath = Path.Combine(path, formFile.FileName);
            var fileStream = new MemoryStream();
            await formFile.CopyToAsync(fileStream);
            var compressedImage = await Tinify.FromBuffer(fileStream.ToArray()).ToBuffer();

            using (var directoryStream = new FileStream(filePath, FileMode.Create))
            {
                await directoryStream.WriteAsync(compressedImage);
            }
        }
    }
}