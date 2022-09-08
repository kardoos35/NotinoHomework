using Microsoft.AspNetCore.Mvc;
using NotinoHomework.Application.Models;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Consumes("application/xml", "application/json")]
        public IActionResult SaveData([FromBody] Document document)
        {
            if (Request.Headers.TryGetValue("Content-Type", out var contentType))
            {
                _fileService.SaveData(document, contentType);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetFile(string fileName)
        {
            if (Request.Headers.TryGetValue("Content-Type", out var contentType))
            {
                return Ok(_fileService.GetDocument(fileName, contentType));
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteFile(string filePath)
        {
            _fileService.DeleteDocument(filePath);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFile([FromBody] Document document, string target)
        {
            if (Request.Headers.TryGetValue("Content-Type", out var contentType))
            {
                _fileService.UpdateDocument(document, contentType);
                return Ok();
            }

            return BadRequest();
        }
    }
}
