using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Controllers
{
    public class Atreos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alunos()
        {
            return View();
        }

        public IActionResult CadastroAluno()
        {
            return View();
        }

        public IActionResult CadastroCracha()
        {
            return View();
        }
    }
}
