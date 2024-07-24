using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebAppV2.Models;
using WebAppV2.Repository;

namespace WebAppV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            
            UserAPI repository = new UserAPI();
            String result = "";
            result = await repository.GetUsersRequestAsync();

            List<User> oUsers = new List<User>();
            oUsers = (List<User>)JsonConvert.DeserializeObject(result, typeof(List<User>));
            ViewBag.NameUser = "Gabriel Piedrahita";


            return View(oUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(string Name)

        {
            string UserName=Name;
            UserAPI repository = new UserAPI();
            String result = "";
            result = await repository.CreateUserRequestAsync();
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}