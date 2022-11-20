using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class PresencaViewModel : PadraoViewModel
    {
        public DisciplinaViewModel Disciplina { get; set; }
        public AlunoViewModel Aluno { get; set; }
        public TotemViewModel Totem{ get; set; }
        public DateTime DataPresenca { get; set; }
        
        public PresencaViewModel()
        {
            Disciplina = new DisciplinaViewModel();
            Aluno = new AlunoViewModel();
            Totem = new TotemViewModel();
        }
    }
}
