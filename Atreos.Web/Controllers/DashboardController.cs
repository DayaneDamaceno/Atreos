using System.Threading.Tasks;
using Atreos.Infra.Helix;
using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
  public class DashboardController : Controller
  {
    // GET
    public async Task<IActionResult> Index()
    {
      
      return View();
    }
  }
}