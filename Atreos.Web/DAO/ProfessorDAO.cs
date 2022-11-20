using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class ProfessorDAO : PadraoDAO<ProfessorViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Professor";
        protected override string SqlInsert { get; set; } = "spInsert_Professor";
        protected override string SqlUpdate { get; set; } = "spUpdate_Professor";
        protected override string SqlDelete { get; set; } = "spDelete_Professor";
        protected override string SqlSelectId { get; set; } = "spSelect_Professor";
        protected override SqlParameter[] CriaParametros(ProfessorViewModel professor)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("id_professor", professor.Id);
            p[1] = new SqlParameter("nome", professor.Nome);
            return p;
        }

        protected override ProfessorViewModel MontaModel(DataRow registro)
        {
            ProfessorViewModel itemProfessor = new ProfessorViewModel();

            itemProfessor.Id = Convert.ToInt32(registro["id_professor"]);
            itemProfessor.Nome = registro["nome"].ToString();

            return itemProfessor;
        }
    }
}
