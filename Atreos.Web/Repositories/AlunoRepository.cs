using System;
using System.Data;
using System.Data.SqlClient;
using Atreos.Web.Models;

namespace Atreos.Web.Repositories
{
  public class AlunoRepository : PadraoRepository<AlunoViewModel>
  {
    protected override void SetTabela()
    {
      Tabela = "alunos";
    }
    
    protected override SqlParameter[] CriaParametros(AlunoViewModel model)
    {
      var p = new SqlParameter[]
      {
          new("id_aluno", model.Id),
          new("id_turma", model.IdTurma),
          new("nome", model.Nome)
      };
      return p;
    }

    protected override AlunoViewModel MontaModel(DataRow registro)
    {
      var aluno = new AlunoViewModel()
      {
          Id = Convert.ToInt32(registro["id_aluno"]),
          IdTurma = Convert.ToInt32(registro["id_turma"]),
          Nome = registro["nome"].ToString()
      };

      return aluno;
    }

  }
}