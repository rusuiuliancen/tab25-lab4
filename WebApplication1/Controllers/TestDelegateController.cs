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

        // a.
        [HttpGet("insert-method")]
        public string InsertMethod(string value)
        {
            Func<string, string> callback = _delegateService.LowerValue;
            return _delegateService.Greeting(value, callback);
        }

        // b.
        [HttpGet("conditional-execution")]
        public string ConditionalExecution(string value, bool useUpper)
        {
            Func<string, string> callback = useUpper ? _delegateService.UpperValue : _delegateService.LowerValue;
            return _delegateService.Greeting(value, callback);
        }

        // c.
        [HttpGet("consecutive-calls")]
        public string ConsecutiveCalls(string value)
        {
            Func<string, string> callback1 = _delegateService.UpperValue;
            Func<string, string> callback2 = s => s.ToLower();

            string result1 = _delegateService.Greeting(value, callback1);
            string result2 = _delegateService.Greeting(result1, callback2);

            return result2;
        }
    }
}
