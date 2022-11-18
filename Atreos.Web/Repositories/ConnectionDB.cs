using System.Data.SqlClient;

namespace Atreos.Web.Repositories
{
  public static class ConnectionDB
  {
    /// <summary>
    /// Método Estático que retorna um conexao aberta com o BD
    /// </summary>
    /// <returns>Conexão aberta</returns>
    public static SqlConnection GetConnection()
    {
      //string strCon = "Data Source=LOCALHOST; Database=ProvaN2; user id=sa; password=123456";
      const string stringConnection = "Data Source=CTS1C100637;Initial Catalog=Atreos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      var connection = new SqlConnection(stringConnection);
      connection.Open();
      return connection;
    }
  }
}