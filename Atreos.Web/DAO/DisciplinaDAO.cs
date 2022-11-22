using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class DisciplinaDAO : PadraoDAO<DisciplinaViewModel>
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

        public DisciplinaViewModel ObterDisciplinaAtual()
        {
            // var now = new TimeSpan(22, 30, 45);
            var now = DateTime.Now.TimeOfDay;
            var startFirstClass = TimeSpan.Parse("19:00:00.000");
            var endFirstClass = TimeSpan.Parse("20:55:00.000");
            var startSecondClass = TimeSpan.Parse("21:05:00.000");
            var endSecondClass = TimeSpan.Parse("22:45:00.000");

            // var startFirstClass = TimeSpan.Parse("13:00:00.000");
            // var endFirstClass = TimeSpan.Parse("19:00:00.000");
            // var startSecondClass = TimeSpan.Parse("21:05:00.000");
            // var endSecondClass = TimeSpan.Parse("22:45:00.000");
            
            var nowIsFirstClass = now > startFirstClass && now < endFirstClass;
            var nowIsSecondClass = now > startSecondClass && now < endSecondClass;
            if (nowIsFirstClass)
            {
                return ObterDisciplina(startFirstClass, endFirstClass);
            }
            if (nowIsSecondClass)
            {
                return ObterDisciplina(startSecondClass, endSecondClass);
            }

            return null;

        }

        private DisciplinaViewModel ObterDisciplina(TimeSpan startTime, TimeSpan endTime)
        {
            var helperDao = new HelperDAO();

            var sql = $"select * from Disciplina " +
                      $"where horario  BETWEEN '{startTime}'AND '{endTime}'";
            var disciplina = helperDao.SqlComandoQuery(sql);

            return disciplina.Rows.Count > 0 ? MontaModel(disciplina.Rows[0]) : null;
        }
    }
}
