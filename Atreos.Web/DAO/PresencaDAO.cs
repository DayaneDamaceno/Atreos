using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
  public class PresencaDAO : PadraoDAO<PresencaViewModel>
  {
    protected override string SqlSelect { get; set; } = "spSelect_Presenca";
    protected override string SqlInsert { get; set; } = "spInsert_Presenca";
    protected override string SqlUpdate { get; set; } = "spUpdate_Presenca";
    protected override string SqlDelete { get; set; } = "spDelete_Presenca";
    protected override string SqlSelectId { get; set; } = "spSelect_Presenca";

    protected override SqlParameter[] CriaParametros(PresencaViewModel presenca)
    {
      SqlParameter[] p = new SqlParameter[4];

      p[0] = new SqlParameter("id_disciplina", presenca.Disciplina.Id);
      p[1] = new SqlParameter("id_aluno", presenca.Aluno.Id);
      p[2] = new SqlParameter("id_totem", presenca.Totem.Id);
      p[3] = new SqlParameter("data_presenca", presenca.DataPresenca);
      return p;
    }

    protected override PresencaViewModel MontaModel(DataRow registro)
    {
      PresencaViewModel itemPresenca = new PresencaViewModel();

      itemPresenca.Id = Convert.ToInt32(registro["id_presenca"]);
      itemPresenca.Disciplina.Id = Convert.ToInt32(registro["id_disciplina"]);
      itemPresenca.Aluno.Id = Convert.ToInt32(registro["id_aluno"]);
      itemPresenca.Totem.Id = Convert.ToInt32(registro["id_totem"]);
      itemPresenca.DataPresenca = Convert.ToDateTime(registro["data_presenca"]);


      return itemPresenca;
    }

    public PresencaViewModel ObterUltimaPresenca()
    {
      var helperDao = new HelperDAO();

      var presenca = helperDao
          .SqlComandoQuery("select top(1) * " +
                           "from Presenca order by data_presenca desc");

      return presenca.Rows.Count > 0 ? MontaModel(presenca.Rows[0]) : null;
    }
  }
}