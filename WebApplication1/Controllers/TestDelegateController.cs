using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Delegate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        delegate string MyDelegate(string value);

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

        [HttpGet("condition")]
        public string Condition(string name, bool isUpperCase)
        {
            MyDelegate upperDelegate = _delegateService.UpperValue;
            Func<string, string> lowerDelegate = v => v.ToLower();

            if (isUpperCase)
            {
                Func<string, string> myDelegate = (string value) => upperDelegate(value);
                return _delegateService.Greeting(name, myDelegate);
            } else
            {
                return _delegateService.Greeting(name, lowerDelegate);
            }
        }

        [HttpGet("multi")]
        public string Multi(string name)
        {
            MyDelegate myDelegate = _delegateService.UpperValue;
            myDelegate += _delegateService.LowerValue;

            Func<string, string> del = (value) => myDelegate(value);

            return _delegateService.Greeting(name, del);
        }
    }
}
