using Microsoft.AspNetCore.Mvc;
using NotinoHomework.Application.Factories.Interfaces;
using NotinoHomework.Application.Models;

namespace NotinoHomework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IConvertorFactory _convertorFactory;

        public ConverterController(IConvertorFactory convertorFactory)
        {
            _convertorFactory = convertorFactory;
        }

        [HttpPost]
        [Consumes("application/xml", "application/json")]
        public IActionResult Convert([FromBody] Document document)
        {
            if (Request.Headers.TryGetValue("Accept", out var acceptValue))
            {
                var service = _convertorFactory.GetService(acceptValue.ToString());
                var result = service.Serialize(document);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
