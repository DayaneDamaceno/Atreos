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
        protected override string SqlInsert { get; set; } = "spInsert_Cracha);";
        protected override string SqlUpdate { get; set; } = "spUpdate_Cracha";
        protected override string SqlDelete { get; set; } = "spDelete_Cracha";
        protected override string SqlSelectId { get; set; } = "spSelect_Cracha";
        protected override SqlParameter[] CriaParametros(CrachaViewModel cracha)
        {
            SqlParameter[] p = new SqlParameter[3];
            
            p[0] = new SqlParameter("id_cracha", cracha.Id);
            p[1] = new SqlParameter("id_aluno", cracha.Aluno.Id);
            p[2] = new SqlParameter("cod_hexaDec", cracha.HexaDec);
            
            return p;
            
        }

        protected override CrachaViewModel MontaModel(DataRow registro)
        {
            var itemCracha = new CrachaViewModel();

            itemCracha.Id = Convert.ToInt32(registro["id_cracha"]);
            itemCracha.HexaDec = registro["cod_hexaDec"].ToString();
            itemCracha.Aluno.Id = Convert.ToInt32(registro["id_aluno"]);


            return itemCracha;
        }
        
        public List<CrachaViewModel> ObterAlunosComPresencaPendente(List<string> crachas)
        {
            var helperDao = new HelperDAO();
            var alunos = new List<CrachaViewModel>();

            var sql = $"select * from Cracha where cod_hexaDec in ('{string.Join("','", crachas)}')";
            var alunosTable = helperDao.SqlComandoQuery(sql);

            if (alunosTable.Rows.Count <= 0) return null;
            
            alunos.AddRange(from DataRow registro in alunosTable.Rows select MontaModel(registro));
            return alunos;
        }
    }
}
