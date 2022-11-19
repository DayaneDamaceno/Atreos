using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
