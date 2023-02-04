using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONCESIONARIO_PROYECTO.BBDD;

namespace CONCESIONARIO_PROYECTO
{
    public partial class Concesionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            concesionarioTabla.DataSource = from Vehiculos in dbRep.Vehiculos
                                            join Modelos in dbRep.Modelos on Vehiculos.id_modelo equals Modelos.id_modelo
                                            join Marcas in dbRep.Marcas on Modelos.id_marca equals Marcas.id_marca
                                            select new { Vehiculos.nombre, Modelos.motor, nombreMarca = Marcas.nombre };

            concesionarioTabla.DataBind();
        }
    }
}