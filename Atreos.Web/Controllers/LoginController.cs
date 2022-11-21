using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string nome, string senha)
        {
            return View();
        }
    }
}
