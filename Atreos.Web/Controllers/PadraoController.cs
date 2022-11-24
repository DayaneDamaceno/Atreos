using Atreos.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Controllers
{
    public abstract class PadraoController<T> : Controller
    {
        public abstract IActionResult Index();
        protected abstract void ValidaDados(T cracha);
    }
}
