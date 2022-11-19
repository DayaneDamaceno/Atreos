using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class Conexao
    {
        public SqlConnection GetConexao()
        {
            string banco = "Server=localhost;Database=SQL;Trusted_Connection=True;";
            //login = "Data Source=atum.database.windows.net; Database=SQL; user id=atumm; password=";

            SqlConnection con = new SqlConnection(banco);
            con.Open();

            return con;
        }
    }
}
