using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Atreos.Web.Models;

namespace Atreos.Web.DAO
{
  public class DashboardDAO
  {
    public DateTime? ObterMediaDoHorárioDeEntradaSemestral()
    {
      var helperDao = new HelperDAO();
      DateTime resultado = new DateTime();
      var sql =
          $"SELECT CONVERT(CHAR(5),DATEADD(second,AVG(DATEDIFF(second, 0, convert(varchar, data_presenca, 108) )),0),108) AS 'horario' FROM  Presenca";
      var resultadoTable = helperDao.SqlComandoQuery(sql);

      if (resultadoTable.Rows.Count <= 0)
        return null;
      foreach (DataRow registro in resultadoTable.Rows)
      {
        resultado = Convert.ToDateTime(registro["horario"]);
      }

      return resultado;
    }

    public List<PresencaPorDiaNoMesViewModel> ObterPresencaPorDiaNoMes()
    {
      var helperDao = new HelperDAO();
      var resultado = new List<PresencaPorDiaNoMesViewModel>();
      var sql =
          $"SELECT COUNT(*) AS 'total', CAST(Presenca.data_presenca AS date) AS 'dia' FROM Presenca GROUP BY CAST(Presenca.data_presenca AS date)";
      var resultadoTable = helperDao.SqlComandoQuery(sql);

      if (resultadoTable.Rows.Count <= 0)
        return null;
      foreach (DataRow registro in resultadoTable.Rows)
      {
        var item = new PresencaPorDiaNoMesViewModel()
        {
            Total = Convert.ToInt32(registro["total"]),
            Dia = Convert.ToDateTime(registro["dia"])
        };
        resultado.Add(item);
      }

      return resultado;
    }
    public List<FrequenciaPorDisciplinaViewModel> FrequenciaPorDisciplina()
    {
      var helperDao = new HelperDAO();
      var resultado = new List<FrequenciaPorDisciplinaViewModel>();
      var sql =
          $"SELECT " +
          "(SELECT COUNT(Disciplina.nome) " +
          "FROM Presenca, Disciplina " +
          "WHERE Presenca.id_disciplina = Disciplina.id_disciplina AND  Disciplina.id_disciplina = dic.id_disciplina " +
          "GROUP BY Disciplina.nome) / CAST(dic.totalAulas AS FlOAT) AS 'total' , dic.nome as 'disciplina'" +
          "FROM Disciplina as dic";
      
      var resultadoTable = helperDao.SqlComandoQuery(sql);

      if (resultadoTable.Rows.Count <= 0)
        return null;
      foreach (DataRow registro in resultadoTable.Rows)
      {
        var item = new FrequenciaPorDisciplinaViewModel()
        {
            Porcentagem = Convert.ToDecimal(registro["total"]),
            NomeDisciplina = registro["disciplina"].ToString()
        };
        
        resultado.Add(item);
      }

      return resultado;
    }
  }
}