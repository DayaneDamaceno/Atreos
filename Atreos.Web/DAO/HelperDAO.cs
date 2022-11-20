using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class HelperDAO
    {
        /*
        public void SqlComandoNoQuery(string queryString, SqlParameter[] parametros)
        {
            Conexao con = new Conexao();

            var sessao = con.GetConexao();

            using (SqlCommand comando = new SqlCommand(queryString, sessao))
            {
                comando.Parameters.AddRange(parametros);
                comando.ExecuteNonQuery();
            }

            sessao.Close();
        }

       

        public DataTable SqlComandoQuery(string queryString, SqlParameter[] parametros)
        {
            Conexao con = new Conexao();

            var sessao = con.GetConexao();

            DataTable tabela = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, sessao))
            {
                adapter.SelectCommand.Parameters.AddRange(parametros);
                adapter.Fill(tabela);
            }

            sessao.Close();

            return tabela;
        }
        */
        public DataTable SqlComandoQuery(string queryString)
        {
            var con = new Conexao();

            var sessao = con.GetConexao();

            var tabela = new DataTable();

            using (var adapter = new SqlDataAdapter(queryString, sessao))
            {
                adapter.Fill(tabela);
            }

            sessao.Close();

            return tabela;
        }
        public void SQLComandoNoQuerySP(string queryString, SqlParameter[] parametros)
        {
            Conexao con = new Conexao();
            var sessao = con.GetConexao();

            DataTable tabela = new DataTable();

            using (SqlCommand comando = new SqlCommand(queryString, sessao))
            {
                comando.Parameters.AddRange(parametros);
                comando.CommandType = CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
            }

            sessao.Close();
        }
        
        public DataTable SQLComandoQuerySP(string queryString)
        {
            Conexao con = new Conexao();
            var sessao = con.GetConexao();

            DataTable tabela = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, sessao))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(tabela);
            }

            sessao.Close();

            return tabela;
        }

        public DataTable SQLComandoQuerySP(string queryString, SqlParameter[] parametros)
        {
            Conexao con = new Conexao();
            var sessao = con.GetConexao();

            DataTable tabela = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, sessao))
            {
                adapter.SelectCommand.Parameters.AddRange(parametros);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(tabela);
            }

            sessao.Close();

            return tabela;  
        }
    }
}
