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
        {
            Response.Redirect(Page.Request.Path, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*
         * Pre:
         * Post: Metodo de redireccion a la edición de Marcas
         */
        private void editRedirect(String id)
        {  // redireccion a edit
            if(id != null && id != "") { 
                Response.Redirect("EditConcesionarioMarca?id=" + id, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        /*
         * Pre:
         * Post: Metodo el cual es llamado al ejecutar un RowCommand el cual realiza differentes acciones
         * ya sea borrar marcas o editar marcas.
         */
        protected void concesionarioTabla_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            /*
             * Pre:
             * Post: (deleteMarca) seccion la cual borra una Marca seleccionada
             */
            if (e.CommandName == "deleteVehiculoMarca")                     // si pulsar delete
            {
                int index = Convert.ToInt32(e.CommandArgument);             // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];   // Obtenemos row
                TableCell vehiculoID = selectedRow.Cells[0];                // Obtenemos id de vehiculo 0 = ID
                string id = vehiculoID.Text;                                // Obtenemos string con id
                int idInt = Convert.ToInt32(id);
                Marcas marcas = dbRep.Marcas.SingleOrDefault(x => x.id_marca == idInt);
                dbRep.Marcas.DeleteOnSubmit(marcas);
                dbRep.SubmitChanges();
                reload();
            }
            /*
             * Pre:
             * Post: (editVehiculoMarca) seccion la cual redirige al usuario al formulario de edicion
             */
            else if (e.CommandName == "editVehiculoMarca")                  // si pulsar edit
            {
                int index = Convert.ToInt32(e.CommandArgument);             // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];   // Obtenemos row
                TableCell marcaID = selectedRow.Cells[0];                // Obtenemos id de vehiculo 0 = ID
                string id = marcaID.Text;                                // Obtenemos string con id
                editRedirect(id);
            }
        }
    }
}