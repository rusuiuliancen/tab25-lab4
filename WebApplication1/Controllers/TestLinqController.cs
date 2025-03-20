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

        [HttpGet("linq-where")]
        public List<User> FilterUsers(string level)
        {
            return UserStorage.Users.Where(u => u.SecurityLevel == level).ToList();
        }

        [HttpGet("linq-string")]
        public IEnumerable<string> GetUsernamesByLevel(string level)
        {
            var usernames =
                from user in UserStorage.Users
                where user.SecurityLevel == level
                select user.Username;

            return usernames;
        }
    }
}
