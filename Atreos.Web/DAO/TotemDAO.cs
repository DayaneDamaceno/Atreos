using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class TotemDAO : PadraoDAO<TotemViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Totem";
        protected override string SqlInsert { get; set; } = "spInsert_Totem);";
        protected override string SqlUpdate { get; set; } = "spUpdate_Totem";
        protected override string SqlDelete { get; set; } = "spDelete_Totem";
        protected override string SqlSelectId { get; set; } = "spSelect_Totem";
        protected override SqlParameter[] CriaParametros(TotemViewModel totem)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("id_totem", totem.Id);
            p[1] = new SqlParameter("nome", totem.Nome);
            return p;
        }

        protected override TotemViewModel MontaModel(DataRow registro)
        {
            TotemViewModel itemTotem = new TotemViewModel();

            itemTotem.Id = Convert.ToInt32(registro["id_totem"]);
            itemTotem.Nome = registro["nome"].ToString();

            return itemTotem;
        }
    }
}
