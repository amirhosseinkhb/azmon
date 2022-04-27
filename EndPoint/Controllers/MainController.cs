using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
