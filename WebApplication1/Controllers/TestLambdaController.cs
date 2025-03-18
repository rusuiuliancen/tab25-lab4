using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Services.Lambda;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("try-parse-number")]
        public string TryParseNumber(string value)
        {
            return _lambdaService.TryParseNumber(value) ? "Number" : "Not number";
        }

        // a.i. Lambda expression with no parameters
        [HttpGet("no-params")]
        public string NoParams()
        {
            Func<string> noParams = () => "No parameters";
            return noParams();
        }

        // a.ii. Lambda expression with one parameter
        [HttpGet("one-param")]
        public string OneParam(string value)
        {
            Func<string, string> oneParam = v => $"One parameter: {v}";
            return oneParam(value);
        }

        // a.iii. Lambda expression with two parameters
        [HttpGet("two-params")]
        public string TwoParams(string value1, string value2)
        {
            Func<string, string, string> twoParams = (v1, v2) => $"Two parameters: {v1}, {v2}";
            return twoParams(value1, value2);
        }

        // a.iv. Lambda expression with unused parameters
        [HttpGet("unused-params")]
        public string UnusedParams(string value1, string value2)
        {
            Func<string, string, string> unusedParams = (v1, v2) => "Unused parameters";
            return unusedParams(value1, value2);
        }

        // a.v. Lambda expression with default parameter values
        [HttpGet("default-params")]
        public string DefaultParams(string value1, string value2 = "default")
        {
            Func<string, string, string> defaultParams = (v1, v2) => $"Default parameters: {v1}, {v2}";
            return defaultParams(value1, value2);
        }

        // a.vi. Lambda expression with tuple as parameter
        [HttpGet("tuple-param")]
        public string TupleParam(string value1, string value2)
        {
            Func<(string, string), string> tupleParam = t => $"Tuple parameter: {t.Item1}, {t.Item2}";
            return tupleParam((value1, value2));
        }

        // b. Lambda expression in an asynchronous context
        [HttpGet("async-lambda")]
        public async Task<string> AsyncLambda(string value)
        {
            Func<string, Task<string>> asyncLambda = async v =>
            {
                await Task.Delay(1000);
                return $"Async lambda: {v}";
            };

            return await asyncLambda(value);
        }
    }
}
