using System.IO;
using System.Threading.Tasks;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebService.ViewModels.File;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IFileService fileService, IHostingEnvironment hostingEnvironment)
        {
            _fileService = fileService;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [HttpPost]
        public async Task<IActionResult> CompressImage([FromForm] UploadFilesViewModel vm)
        {
            var mainPath = Directory.GetCurrentDirectory();
            foreach (var formFile in vm.Files)
            {
                await _fileService.SaveFile(mainPath, formFile);
            }

            return Ok();
        }
    }
}