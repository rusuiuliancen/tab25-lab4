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
        public string Condition(string name, bool isUpper)
        {
            MyDelegate upperDelegate = _delegateService.UpperValue;

            Func<string, string> lowerDelegate = (param1) => param1.ToLower();

            if (isUpper)
            {
                Func<string, string> upDel = (param1) => upperDelegate(param1);
                return _delegateService.Greeting(name, upDel);
            } else
            {
                return _delegateService.Greeting(name, lowerDelegate);
            }
        }

        [HttpGet("multi")]
        public string Multi(string value)
        {
            MyDelegate myDelegate = _delegateService.UpperValue;
            myDelegate += _delegateService.LowerValue;

            Func<string, string> myDel = (param1) => myDelegate(param1);

            return _delegateService.Greeting(value, myDel);
        }
    }
}
