using Microsoft.AspNetCore.Mvc;

namespace Atreos.Controllers
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