using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class AlunoDAO : PadraoDAO<AlunoViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Aluno";
        protected override string SqlInsert { get; set; } = "spInsert_Aluno);";
        protected override string SqlUpdate { get; set; } = "spUpdate_Aluno";
        protected override string SqlDelete { get; set; } = "spDelete_Aluno";
        protected override string SqlSelectId { get; set; } = "spSelect_Aluno";
        protected override SqlParameter[] CriaParametros(AlunoViewModel aluno)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("id_aluno", aluno.Id);
            p[1] = new SqlParameter("nome", aluno.Nome);
            return p;
        }

        protected override AlunoViewModel MontaModel(DataRow registro)
        {
            AlunoViewModel itemAluno = new AlunoViewModel();

            itemAluno.Id = Convert.ToInt32(registro["id_aluno"]);
            itemAluno.Nome = registro["nome"].ToString();


            return itemAluno;
        }
        
    }
}
