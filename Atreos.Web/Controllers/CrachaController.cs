using Atreos.Web.DAO;
using Atreos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atreos.Web.Controllers
{
  public class CrachaController : Controller
  {
    // GET
        public IActionResult Index()
        {
            CrachaDAO listar = new CrachaDAO();
            List<CrachaViewModel> lista = listar.List();

            return View("Cadastros", lista);
        }
        public IActionResult Cadastrando()
        {
                return View("Associar");
        }
        public IActionResult Associar(CrachaViewModel cracha)
        {
            var ra = new AlunoDAO();
            var aluno = ra.CapturarRa(cracha.Aluno.RA);

            var cadastrar = new CrachaDAO();

            if (aluno != null)
            {
                cracha.Aluno.Id = aluno.Id;
                cadastrar.Cadastrar(cracha);

            }

            
            return View("Cadastros", cadastrar.List());
        }
        public IActionResult Editar(int id)
        {
            var cracha = new CrachaViewModel();

            var editar= new CrachaDAO();
            cracha = editar.CapturarId(id);

            var capturar = new AlunoDAO();
            cracha.Aluno = capturar.CapturarId(cracha.Aluno.Id); 
            
            return View("Editar", cracha);
        }

        public IActionResult Salvar(CrachaViewModel cracha)
        {
            AlunoDAO ra = new AlunoDAO();
            AlunoViewModel aluno = ra.CapturarRa(cracha.Aluno.RA);

            CrachaDAO atualizar = new CrachaDAO();

            if (aluno != null)
            {
                cracha.Aluno.Id = aluno.Id;
                atualizar.Atualizar(cracha);

            }


            return View("Cadastros", atualizar.List());
        }

        public IActionResult Deletar(int id)
        {
            CrachaDAO deletar = new CrachaDAO();
            deletar.Deletar(id);

            return View("Index", deletar.List());
        }

    }
}