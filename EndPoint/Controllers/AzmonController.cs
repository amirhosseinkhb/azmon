using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    public class AzmonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}