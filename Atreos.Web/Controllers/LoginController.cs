using Atreos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Atreos.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entrar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(usuario.LoginUser == "EduRos" && usuario.Senha == "senha123")
                    {
                        return RedirectToAction("Index", "Aluno");
                    }
                    TempData["MessageError"] = $"Login e/ou Senha inválido(s)";
                }
                return View("Index");
            }
            catch
            {
                TempData["MessageError"] = $"Login ou Senha inválidos";
                return RedirectToAction("Index");
            }
        }
    }
}
