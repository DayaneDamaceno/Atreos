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
    public class AlunoController : PadraoController<AlunoViewModel>
    {
        public override IActionResult Index()
        {
            AlunoDAO listar = new AlunoDAO();
            
            return View(listar.List());
        }
        
        public IActionResult Cadastrar(AlunoViewModel aluno)
        {
            ValidaDados(aluno);

            if (!ModelState.IsValid)
            {
                return View("Cadastro", aluno);
            }
            else
            {
                if (aluno.Imagem != null)
                {
                    aluno.ImagemEmByte = ConvertImageToByte(aluno.Imagem);
                }
                AlunoDAO cadastrar = new AlunoDAO();
                cadastrar.Cadastrar(aluno);
                return View("Index", cadastrar.List());
            }

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
            ValidaDados(aluno);

            if (!ModelState.IsValid)
            {
                return View("Editar", aluno);
            }
            else
            {
                if (aluno.Imagem != null)
                {
                    aluno.ImagemEmByte = ConvertImageToByte(aluno.Imagem);
                }
                var salvar = new AlunoDAO();
                salvar.Atualizar(aluno);

                return View("Index", salvar.List());
            }
        }
        public IActionResult Deletar(int id)
        {
            AlunoDAO deletar = new AlunoDAO();
            deletar.Deletar(id);

            return View("Index", deletar.List());
        }
        protected override void ValidaDados(AlunoViewModel aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (aluno.RA == null || aluno.RA.Length != 9)
                ModelState.AddModelError("RA", "O RA deve ter 9 caracteres númericos.");
            try
            {
                int i = Convert.ToInt32(aluno.RA);
            }catch
            {
                ModelState.AddModelError("RA", "O RA deve ser um número.");
            }
                
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
