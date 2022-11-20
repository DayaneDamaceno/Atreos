using Atreos.Web.DAO;
using Atreos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            AlunoDAO listar = new AlunoDAO();
            
            return View(listar.List());
        }
        
        public IActionResult Cadastrar(AlunoViewModel aluno)
        {
            AlunoDAO cadastrar = new AlunoDAO();
            cadastrar.Cadastrar(aluno);
            return View("Index", cadastrar.List());
        }
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }
        public IActionResult Editar(int id)
        {
            var recuperar = new AlunoDAO();
            
            return View(recuperar.CapturarId(id));
        }
        public IActionResult Salvar(AlunoViewModel aluno)
        {
            var salvar = new AlunoDAO();
            salvar.Atualizar(aluno);

            return View("Index", salvar.List());
        }
        public IActionResult Deletar(int id)
        {
            AlunoDAO deletar = new AlunoDAO();
            deletar.Deletar(id);

            return View("Index", deletar.List());
        }
    }
}
