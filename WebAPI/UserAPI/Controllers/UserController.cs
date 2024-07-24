using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserBusiness;
using UserDomain;
namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            UserB userBusiness = new UserB();
            User user = new User();
            user = userBusiness.getUser();

            return user;
        }

        [HttpGet("GetUsersDB")]
        public IEnumerable<User> GetUsersDB()
        {
            UserB userBusiness = new UserB();
            return userBusiness.getUsersDB(Configuration.GetConnectionString("DefaultConnection"));

        }

        [HttpPost("CreateUser")]
        public IEnumerable<User> CreateUserDB(User user)
        {
            UserB userBusiness = new UserB();
            userBusiness.createUser(user, Configuration.GetConnectionString("DefaultConnection"));
            return userBusiness.getUsersDB(Configuration.GetConnectionString("DefaultConnection"));

        }

        [HttpPost("UpdateUser")]
        public IEnumerable<User> UpdateUserDB(User user)
        {
            UserB userBusiness = new UserB();
            userBusiness.updateUser(user, Configuration.GetConnectionString("DefaultConnection"));
            return userBusiness.getUsersDB(Configuration.GetConnectionString("DefaultConnection"));

        }

        [HttpPost("DeleteUser")]
        public IEnumerable<User> DeleteUserDB(String userName)
        {
            UserB userBusiness = new UserB();
            userBusiness.deleteUser(userName, Configuration.GetConnectionString("DefaultConnection"));
            return userBusiness.getUsersDB(Configuration.GetConnectionString("DefaultConnection"));

        }
    }
}