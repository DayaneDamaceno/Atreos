using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class DisciplinaViewModel : PadraoViewModel
    {
        public ProfessorViewModel Professor { get; set; }
        public string Nome { get; set; }
        public DateTime Horario { get; set; }
        public string DiaSemana{ get; set; }
        public int TotalAulas{ get; set; }
    }
}
