using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("securty-level-count")]
        public int UserSecurityLevelCount(string level)
        {
            return _linqService.UserSecurityLevelCount(level);
        }
    }
}
