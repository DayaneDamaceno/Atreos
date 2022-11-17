using Microsoft.AspNetCore.Mvc;

namespace Atreos.Controllers
{
  public class DashboardController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return View();
    }
  }
}