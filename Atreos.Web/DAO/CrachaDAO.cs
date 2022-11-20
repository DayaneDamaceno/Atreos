using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class CrachaDAO : PadraoDAO<CrachaViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Cracha";
        protected override string SqlInsert { get; set; } = "spInsert_Cracha";
        protected override string SqlUpdate { get; set; } = "spUpdate_Cracha";
        protected override string SqlDelete { get; set; } = "spDelete_Cracha";
        protected override string SqlSelectId { get; set; } = "spSelect_Cracha";
        protected override SqlParameter[] CriaParametros(CrachaViewModel cracha)
        {
            SqlParameter[] p = new SqlParameter[3];
            
            p[0] = new SqlParameter("id", cracha.Id);
            p[1] = new SqlParameter("id_aluno", cracha.Aluno.Id);
            p[2] = new SqlParameter("cod_hexaDec", cracha.HexaDec);
            
            return p;
            
        }

        protected override CrachaViewModel MontaModel(DataRow registro)
        {
            CrachaViewModel itemCracha = new CrachaViewModel();

            AlunoViewModel itemAluno = new AlunoViewModel();

            itemAluno.Id = Convert.ToInt32(registro["id_aluno"]);
            itemAluno.RA = registro["ra"].ToString();
            itemAluno.Nome = registro["nome"].ToString();

            itemCracha.Id = Convert.ToInt32(registro["id_cracha"]);
            itemCracha.HexaDec = registro["cod_hexaDec"].ToString();
            itemCracha.Aluno = itemAluno;

            return itemCracha;
        }
    }
}
