using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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

        [HttpGet("duo")]
        public string TwoParams(int p1, int p2)
        {
            Func<int, int, string> myLambda = (param1, param2) => param1.ToString() + param2.ToString();
            return myLambda(p1, p2);
        }

        [HttpGet("unused")]
        public string UnusedParam(string p1, string p2, string p3)
        {
            Func<string, string, string, string> mylambda = (param1, param2, _) =>
                                                        string.Join(", ", [param1, param2]);

            return mylambda(p1, p2, p3);
        }

        [HttpGet("default")]
        public int DefaultParams(int v, int incBy)
        {
            var myLambda = int (int value, int incrementBy = 1) =>
            {
                if(incrementBy % 2 == 0)
                {
                    return (value + incrementBy) * 10; 
                }
                return value + incrementBy;
            };

            return myLambda(v, incBy);
        }
    }
}
