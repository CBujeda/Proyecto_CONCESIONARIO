using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONCESIONARIO_PROYECTO
{
    public partial class ConcesionarioMarca : System.Web.UI.Page
    {

        /*
         * Pre:
         * Post: Metodo el cual al cargar la pagina mustra una tabla con los diferentes vehiculos y
         *       sus respectivas especificaciones.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            concesionarioTabla.DataSource = from Marcas in dbRep.Marcas
                                            select Marcas;
            concesionarioTabla.DataBind();
        }

        /*
         * Pre:
         * Post: Metodo el cual recarga la pagina.
         */
        private void reload()
        { // Recargamos pagina
            Response.Redirect(Page.Request.Path, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*
         * Pre:
         * Post: MEtodo de redireccion a la edición
         */
        private void editRedirect(String id)
        {  // redireccion a edit
            if(id != null && id != "") { 
                Response.Redirect("editConcesionarioMarca?id=" + id, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        /*
         * Pre:
         * Post: Metodo el cual es llamado al ejecutar un RowCommand el cual realiza differentes acciones
         */
        protected void concesionarioTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            /*
             * Pre:
             * Post: (deleteMarca) seccion la cual borra una Marca seleccionada
             */
            if (e.CommandName == "deleteVehiculoMarca")   // si pulsar delete
            {
                int index = Convert.ToInt32(e.CommandArgument); // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];// Obtenemos row
                TableCell vehiculoID = selectedRow.Cells[0];     // Obtenemos id de vehiculo 0 = ID
                string id = vehiculoID.Text;                // Obtenemos string con id
                int idInt = Convert.ToInt32(id);
                Marcas vehiculo = dbRep.Marcas.SingleOrDefault(x => x.id_marca == idInt);
                dbRep.Marcas.DeleteOnSubmit(vehiculo);
                dbRep.SubmitChanges();
                reload();
            }
            /*
             * Pre:
             * Post: (editVehiculo) seccion la cual redirige al usuario alformulario de edicion
             */
            else if (e.CommandName == "editVehiculoModelo") // si pulsar edit
            {
                int index = Convert.ToInt32(e.CommandArgument); // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];// Obtenemos row
                TableCell vehiculoID = selectedRow.Cells[0];     // Obtenemos id de vehiculo 0 = ID
                string id = vehiculoID.Text;                // Obtenemos string con id
                editRedirect(id);
            }
        }
    }
}