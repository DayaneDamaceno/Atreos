using System.Data;
using System.Data.SqlClient;

namespace Atreos.Web.Repositories
{
  public static class HelperRepository
  {
    public static void ExecutaSQL(string sql, SqlParameter[] parametros)
    {
      using var conexao = ConnectionDB.GetConnection();
      using var comando = new SqlCommand(sql, conexao);
      comando.Parameters.AddRange(parametros);
      comando.ExecuteNonQuery();
    }
    public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
    {
      using var conexao = ConnectionDB.GetConnection();
      using var adapter = new SqlDataAdapter(sql, conexao);
      if (parametros != null)
        adapter.SelectCommand.Parameters.AddRange(parametros);
      var tableTemp = new DataTable();
      adapter.Fill(tableTemp);
      conexao.Close();
      return tableTemp;
    }
    
    public static void ExecutaProc(string nomeProc, SqlParameter[] parametros)
    {
      using var conexao = ConnectionDB.GetConnection();
      using var comando = new SqlCommand(nomeProc, conexao);
      comando.CommandType = CommandType.StoredProcedure;
      if (parametros != null)
        comando.Parameters.AddRange(parametros);
      comando.ExecuteNonQuery();
      conexao.Close();
    }
    
    public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
    {
      using var conexao = ConnectionDB.GetConnection();
      using var adapter = new SqlDataAdapter(nomeProc, conexao);
      
      if (parametros != null)
        adapter.SelectCommand.Parameters.AddRange(parametros);
      
      adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
      var tabela = new DataTable();
      
      adapter.Fill(tabela);
      conexao.Close();
      return tabela;
    }

  }
}