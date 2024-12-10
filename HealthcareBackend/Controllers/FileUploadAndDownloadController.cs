using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthCareTestingLabPortel.Controllers
{
    
    public class FileUploadAndDownloadController : ControllerBase
    {

        [HttpPost]
        [Route("SaveFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UploadFile(IFormFile file, int RecordId, System.Threading.CancellationToken cancellationToken)
        //public static System.Threading.Tasks.Task<byte[]> UploadFile(string path, System.Threading.CancellationToken cancellationToken = default);
        {
            var result = await writeFile(file, RecordId);
            return Ok(new
            {
                Message = ($"Updated Successfully {result} !!")
            });
        }

        // GET: api/<FileUploadAndDownloadController>
        [HttpGet("DownLoadFile")]

        public async Task<IActionResult> DownloadFile(string NameFile)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", NameFile);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
        private async Task<string> writeFile(IFormFile file, int RecordId)
        {
            string fileName = "";
            try
            {
                //var extension='.'+ file.FileName.Split('.')[file.FileName.Split('.').Length-1];
                //fileName = DateTime.Now.Ticks + extension;
                fileName = "Reports" + RecordId + ".docx";
                
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");
                if (!Directory.Exists(pathBuilt))
                {
                Directory.CreateDirectory(pathBuilt);
                }
               
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                await file.CopyToAsync(stream);
                }
                
            }
            catch (Exception)
            {
            }
            return fileName;
        }        
    }
}

       
       
        
