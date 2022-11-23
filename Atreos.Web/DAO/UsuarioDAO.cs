using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class UsuarioDAO
    {
        public UsuarioModel ValidarUsuario(UsuarioModel usuario)
        {
            var helperDao = new HelperDAO();
            var resultado = new UsuarioModel();
            var sql =
                $"SELECT LoginUser AS 'login', Senha AS 'senha' FROM Usuario WHERE login = {usuario.LoginUser} AND senha = {usuario.Senha};";
            var resultadoTable = helperDao.SqlComandoQuery(sql);

            if (resultadoTable.Rows.Count <= 0)
                return null;
            foreach (DataRow registro in resultadoTable.Rows)
            {
                var item = new UsuarioModel()
                {
                    Nome = registro["login"].ToString(),
                    Senha = registro["senha"].ToString()
                };
            }

            return resultado;
        }
    }

}
