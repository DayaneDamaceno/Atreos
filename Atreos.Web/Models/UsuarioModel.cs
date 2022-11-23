using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.Models
{
    public class UsuarioModel
    {
        public int ID { get; set;  }
        public string Nome { get; set; }
        public string LoginUser { get; set; }
        public string Senha { get; set; }

    }
}
