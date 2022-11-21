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
    protected override string SqlInsert { get; set; } = "spInsert_Aluno";
    protected override string SqlUpdate { get; set; } = "spUpdate_Aluno";
    protected override string SqlDelete { get; set; } = "spDelete_Aluno";
    protected override string SqlSelectId { get; set; } = "spSelect_Aluno";

    protected override SqlParameter[] CriaParametros(AlunoViewModel aluno)
    {
      var size = aluno.ImagemEmByte != null ? 4 : 3;

      var p = new SqlParameter[size];

      p[0] = new SqlParameter("id", aluno.Id);
      p[1] = new SqlParameter("ra", aluno.RA);
      p[2] = new SqlParameter("nome", aluno.Nome);
      if (aluno.ImagemEmByte != null)
      {
        p[3] = new SqlParameter("foto", aluno.ImagemEmByte);
      }

      return p;
    }

    public AlunoViewModel CapturarRa(string ra)
    {
      HelperDAO list = new HelperDAO();

      DataTable tabela = list.SQLComandoQuerySP("spSelect_RA", new SqlParameter[] { new SqlParameter("@ra", ra) });

      if (tabela.Rows.Count > 0)
      {
        return MontaModel(tabela.Rows[0]);
      }

      return null;
    }

    protected override AlunoViewModel MontaModel(DataRow registro)
    {
      var itemAluno = new AlunoViewModel();

      itemAluno.Id = Convert.ToInt32(registro["id_aluno"]);
      itemAluno.RA = registro["ra"].ToString();
      itemAluno.Nome = registro["nome"].ToString();
      if (registro["foto"] != DBNull.Value)
        itemAluno.ImagemEmByte = registro["foto"] as byte[];


      return itemAluno;
    }
  }
}