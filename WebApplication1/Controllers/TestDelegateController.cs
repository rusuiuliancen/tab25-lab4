using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Delegate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("intro")]
        public string Introduction(string name)
        {
            var callback = _delegateService.UpperValue;

            return _delegateService.Greeting(name, callback);
        }
    }
}
