using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> UrlData([FromQuery] string url)
        {
            var result = await _dataService.GetData(url);
            return Ok(result);
        }
    }
}
