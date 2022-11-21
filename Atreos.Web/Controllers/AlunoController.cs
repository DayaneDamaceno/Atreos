using Atreos.Web.DAO;
using Atreos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
            if (aluno.Imagem != null)
            {
                aluno.ImagemEmByte = ConvertImageToByte(aluno.Imagem);
            }
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
            if (aluno.Imagem != null)
            {
                aluno.ImagemEmByte = ConvertImageToByte(aluno.Imagem);
            }
            var salvar = new AlunoDAO();
            salvar.Atualizar(aluno);
            return View("Index", salvar.List());
        }
        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }
    }
}
