using Microsoft.AspNetCore.Mvc;

namespace Atreos.Controllers
{
  public class LoginController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return View();
    }
  }
}