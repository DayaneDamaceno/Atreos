using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected string Tabela { get; set; }
        protected virtual string SqlSelect { get; set; }
        protected virtual string SqlInsert { get; set; }
        protected virtual string SqlUpdate { get; set; }
        protected virtual string SqlDelete { get; set; }
        protected virtual string SqlSelectId { get; set; }
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);
        public List<T> List()
        {
            HelperDAO list = new HelperDAO();

            DataTable tabela;

            tabela = list.SQLComandoQuerySP(SqlSelect, new SqlParameter[] { new SqlParameter("@id", "0") });

            List<T> jogos = new List<T>();


            foreach (DataRow registro in tabela.Rows)
            {
                jogos.Add(MontaModel(registro));
            }

            return jogos;

        }
        public T CapturarId(int id)
        {
            HelperDAO list = new HelperDAO();

            DataTable tabela = list.SQLComandoQuerySP(SqlSelectId, new SqlParameter[] { new SqlParameter("@id", id) });

            if (tabela.Rows.Count > 0)
            {
                return MontaModel(tabela.Rows[0]);
            }

            return null;
        }
        public void Cadastrar(T model)
        {
            HelperDAO inserir = new HelperDAO();
            inserir.SQLComandoNoQuerySP(SqlInsert, CriaParametros(model));
        }
        public void Atualizar(T model)
        {
            HelperDAO atualizar = new HelperDAO();
            atualizar.SQLComandoNoQuerySP(SqlUpdate, CriaParametros(model));
        }
        public void Deletar(int id)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("id", id);

            HelperDAO deletar = new HelperDAO();

            deletar.SQLComandoNoQuerySP(SqlDelete, p);
        }
    }
}
