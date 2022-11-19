using Atreos.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atreos.Web.DAO
{
    public class FotoDAO : PadraoDAO<FotoViewModel>
    {
        protected override string SqlSelect { get; set; } = "spSelect_Foto";
        protected override string SqlInsert { get; set; } = "spInsert_Foto);";
        protected override string SqlUpdate { get; set; } = "spUpdate_Foto";
        protected override string SqlDelete { get; set; } = "spDelete_Foto";
        protected override string SqlSelectId { get; set; } = "spSelect_Foto";
        protected override SqlParameter[] CriaParametros(FotoViewModel foto)
        {
            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("id_foto", foto.Id);
            p[1] = new SqlParameter("id_aluno", foto.Aluno.Id);
            p[2] = new SqlParameter("foto", foto.ImagemEmByte);

            return p;

        }

        protected override FotoViewModel MontaModel(DataRow registro)
        {
            FotoViewModel itemFoto = new FotoViewModel();

            itemFoto.Id = Convert.ToInt32(registro["id_foto"]);
            itemFoto.Aluno.Id = Convert.ToInt32(registro["id_aluno"]);
            //itemFoto.Foto = Convert.ToSByte["foto"];

            return itemFoto;
        }
    }
  
}
