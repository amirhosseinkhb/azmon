using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackAutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
