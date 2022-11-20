using Atreos.Web.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            ProfessorDAO listar = new ProfessorDAO();

            return View(listar.List());
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
    }
}
