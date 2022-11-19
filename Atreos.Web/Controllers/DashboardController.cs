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

      var totemRepository = new TotemRepository();
      var totens = await totemRepository.GetAllTotems();
      return View();
    }
  }
}