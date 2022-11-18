using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
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