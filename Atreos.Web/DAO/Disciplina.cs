using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class Disciplina : PadraoDAO<DisciplinaViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Disciplina";
        protected override string SqlInsert { get; set; } = "spInsert_Disciplina";
        protected override string SqlUpdate { get; set; } = "spUpdate_Disciplina";
        protected override string SqlDelete { get; set; } = "spDelete_Disciplina";
        protected override string SqlSelectId { get; set; } = "spSelect_Disciplina";
        protected override SqlParameter[] CriaParametros(DisciplinaViewModel disciplina)
        {
            SqlParameter[] p = new SqlParameter[6];

            p[0] = new SqlParameter("id", disciplina.Id);
            p[1] = new SqlParameter("id_professor", disciplina.Professor.Id);
            p[2] = new SqlParameter("nome", disciplina.Nome);
            p[3] = new SqlParameter("horario", disciplina.Horario);
            p[4] = new SqlParameter("diaSemana", disciplina.DiaSemana);
            p[5] = new SqlParameter("totalAulas", disciplina.TotalAulas);

            return p;

        }

        protected override DisciplinaViewModel MontaModel(DataRow registro)
        {
            DisciplinaViewModel itemDisciplina = new DisciplinaViewModel();

            itemDisciplina.Id = Convert.ToInt32(registro["id_disciplina"]);
            itemDisciplina.Professor.Id = Convert.ToInt32(registro["id_professor"]);
            itemDisciplina.Nome = registro["nome"].ToString();
            itemDisciplina.Horario = Convert.ToDateTime(registro["horario"]);
            itemDisciplina.DiaSemana = registro["diaSemana"].ToString();
            itemDisciplina.TotalAulas= Convert.ToInt32(registro["totalAulas"]);




            return itemDisciplina;
        }
    }
}
