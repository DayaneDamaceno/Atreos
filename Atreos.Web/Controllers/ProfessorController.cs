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
            ValidaDados(prof);

            if (!ModelState.IsValid)
            {
                return View("Cadastro", prof);
            }
            else
            {
                ProfessorDAO cadastrar = new ProfessorDAO();
                cadastrar.Cadastrar(prof);
                return View("Index", cadastrar.List());
            }
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
            ValidaDados(prof);

            if (!ModelState.IsValid)
            {
                return View("Editar", prof);
            }
            else
            {
                ProfessorDAO salvar = new ProfessorDAO();
                salvar.Atualizar(prof);

                return View("Index", salvar.List());
            }
        }

        public IActionResult Deletar(int id)
        {
            ProfessorDAO deletar = new ProfessorDAO();
            deletar.Deletar(id);

            return View("Index", deletar.List());
        }

        protected void ValidaDados(ProfessorViewModel prof)
        {
            if (string.IsNullOrEmpty(prof.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
        }
    }
}
