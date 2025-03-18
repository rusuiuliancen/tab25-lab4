using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("where-clause")]
        public IEnumerable<MyClass> WhereClause(string value)
        {
            return _linqService.GetObjectsWhereClause(value);
        }

        [HttpGet("select-property")]
        public IEnumerable<string> SelectProperty()
        {
            return _linqService.GetPropertyValues();
        }

        [HttpGet("count-elements")]
        public int CountElements()
        {
            return _linqService.CountElements();
        }

        [HttpGet("where-join")]
        public IEnumerable<string> WhereJoin()
        {
            return _linqService.WhereJoin();
        }
    }
}
