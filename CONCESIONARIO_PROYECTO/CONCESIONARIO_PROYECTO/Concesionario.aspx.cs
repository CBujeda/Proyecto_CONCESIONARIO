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
        private void reload()
        { // Recargamos pagina
            Response.Redirect(Page.Request.Path, false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void concesionarioTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "deleteVehiculo")   // si pulsar delete
            {
                int index = Convert.ToInt32(e.CommandArgument); // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];// Obtenemos row
                TableCell facturaID = selectedRow.Cells[0];     // Obtenemos id de factura 0 = ID
                string id = facturaID.Text;                // Obtenemos string con id
                int idInt = Convert.ToInt32(id);
                System.Diagnostics.Debug.Write(idInt + "\n");
                Vehiculos vehiculo = dbRep.Vehiculos.SingleOrDefault(x => x.id_vehiculo == idInt);
                dbRep.Vehiculos.DeleteOnSubmit(vehiculo);
                dbRep.SubmitChanges();
                reload();
            }
            else if (e.CommandName == "editVehiculo") // si pulsar edit
            {
                int index = Convert.ToInt32(e.CommandArgument); // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];// Obtenemos row
                TableCell facturaID = selectedRow.Cells[0];     // Obtenemos id de factura 0 = ID
                string id = facturaID.Text;                // Obtenemos string con id
            }
        }
    }
}