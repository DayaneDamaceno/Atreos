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
            const string banco = "Server=atum.database.windows.net;uid=atumm;pwd=1bfd02c92*;database=SQL";
            var con = new SqlConnection(banco);
            con.Open();

            return con;
        }
    }
}
