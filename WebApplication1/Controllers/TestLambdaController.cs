using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;
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

        [HttpGet("two-param")]
        public string TwoParams(int param1, int param2)
        {
            var concatenanteLambda = string (int p1, int p2) => p1.ToString() + p2.ToString();
            return concatenanteLambda(param1, param2);
        }

        [HttpGet("unused-param")]
        public string UnusedParam(string param1, string param2, string param3)
        {
            Func<string, string, string, string> unusedLambda = (p1, p2, _) => string.Join(",", [p1, p2]);
            return unusedLambda(param1, param2, param3);
        }

        [HttpPost("default-value")]
        public List<int> DefaultPram(List<int> list)
        {
            var sortLambda = List<int> (List<int> array, bool desc = false) =>
            {
                if (desc)
                {
                    array.Sort();
                    array.Reverse();
                    return array;
                }
                array.Sort();
                return array;
            };

            return sortLambda(list);
        }
    }
}
