using Microsoft.AspNetCore.Mvc;
using black.steel.langley.Domain.Catalog;

namespace black.steel.langley.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("hello world.");
        }
    }
}