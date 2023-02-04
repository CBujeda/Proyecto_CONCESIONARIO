using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONCESIONARIO_PROYECTO
{
    public partial class Concesionario : System.Web.UI.Page
    {
        public void CreateDatabase()
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            if (!db.DatabaseExists())
            {
                //db.DeleteDatabase();
                db.CreateDatabase();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateDatabase();
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            concesionarioTabla.DataSource = from Vehiculos in dbRep.Vehiculos
                                            join Modelos in dbRep.Modelos on Vehiculos.id_modelo equals Modelos.id_modelo
                                            join Marcas in dbRep.Marcas on Modelos.id_marca equals Marcas.id_marca
                                            select new {idVehiculo = Vehiculos.id_vehiculo,
                                                        nombreVehiculo = Vehiculos.nombre,
                                                        tipoVehiculo = Vehiculos.tipo,
                                                        Modelos.modelo,
                                                        Modelos.motor,
                                                        nombreMarca = Marcas.nombre,
                                                        Marcas.pais, 
                                                        anno = Marcas.anno_creacion};
            concesionarioTabla.DataBind();
        }

    }
}