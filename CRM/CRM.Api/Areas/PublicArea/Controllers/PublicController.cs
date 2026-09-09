using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Api.Areas.PublicArea.Controllers
{
    [Area("PublicArea")]
    [DisplayName("Public Controller")]
    [Route("api/{area}/{controller}")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from public Area");
        }
        
    }
}
