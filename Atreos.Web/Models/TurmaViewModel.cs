using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class TurmaViewModel : PadraoViewModel
    {
        public CursoViewModel Curso { get; set; }
        public string Semestre { get; set; }
    }
}
