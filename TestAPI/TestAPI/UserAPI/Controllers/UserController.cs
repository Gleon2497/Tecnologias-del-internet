using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDomain;
using UserBussiness;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IConfiguration Configuration;

        public UserController(ILogger<UserController> logger, IConfiguration config)
        {
            _logger = logger;
            Configuration = config;
        }

        [HttpGet("GetUser")]

        public User GetUser() 
        {
            UserB userB = new UserB();
            User user = new User();
            user = userB.getUser();

            return user;
        }

    }
}
