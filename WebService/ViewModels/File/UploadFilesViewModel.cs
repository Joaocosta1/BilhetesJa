using Microsoft.AspNetCore.Http;

namespace WebService.ViewModels.File
{
    public class UploadFilesViewModel
    {
        public IFormFile[] Files { get; set; }
    }
}