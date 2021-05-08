using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRChat.Web.Hubs;
using SignalRChat.Web.Models;
using System.Diagnostics;

namespace SignalRChat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ChatViewModel model)
        {
            if (ChatHub.UserNamesMap.ContainsValue(model.UserName))
            {
                ModelState.AddModelError(string.Empty, "User name already in use.");
            }

            if (ModelState.IsValid)
            {
                return View("ChatPage", model.UserName);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
