using Atreos.Web.DAO;
using Atreos.Web.Models;
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
        public IActionResult Cadastrar(ProfessorViewModel prof)
        {
            ProfessorDAO cadastrar = new ProfessorDAO();
            cadastrar.Cadastrar(prof);
            return View("Index", cadastrar.List());
        }
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }
        public IActionResult Editar(int id)
        {
            ProfessorDAO recuperar = new ProfessorDAO();

            return View(recuperar.CapturarId(id));
        }

        public IActionResult Salvar(ProfessorViewModel prof)
        {
            ProfessorDAO salvar = new ProfessorDAO();
            salvar.Atualizar(prof);

            return View("Index", salvar.List());
        }
    }
}
