using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
  public class DisciplinaController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return View("Cadastro");
    }
  }
}