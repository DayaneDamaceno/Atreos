using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
  public class CrachaController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return View("Cadastro");
    }
  }
}