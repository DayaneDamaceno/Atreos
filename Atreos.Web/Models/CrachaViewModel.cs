using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class CrachaViewModel : PadraoViewModel
    {

        public AlunoViewModel Aluno{ get; set; }
        public string HexaDec{ get; set; }
        public CrachaViewModel()
        {
            Aluno = new AlunoViewModel();
        }
    }
}
