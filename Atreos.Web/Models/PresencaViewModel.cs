using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class PresencaViewModel : PadraoViewModel
    {
        public AlunoViewModel Aluno { get; set; }
        public Disciplina_TurmaViewModel DisciplinaTurma { get; set; }
        public TotemViewModel Totem{ get; set; }
        public DateTime Horario { get; set; }
    }
}
