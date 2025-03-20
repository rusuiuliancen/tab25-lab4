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

        [HttpGet("select-users")]
        public IEnumerable<User> GetUsers(string securityLevel)
        {
            return UserStorage.Users.Where(user => user.SecurityLevel == securityLevel);
        }

        [HttpGet("user-name")]
        public IEnumerable<string> GetUsername (string securityLevel)
        {
            var usernames =
               from user in UserStorage.Users
               where user.SecurityLevel == securityLevel
               select user.Username;

            return usernames;
        }

    }
}
