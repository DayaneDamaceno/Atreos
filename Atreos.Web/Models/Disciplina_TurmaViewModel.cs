using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class Disciplina_TurmaViewModel : PadraoViewModel
    {
        public DisciplinaViewModel Disciplina { get; set; }
        public TurmaViewModel Turma { get; set; }
        public ProfessorViewModel Professor { get; set; }
        public DateTime Horario { get; set; }
    }
}
