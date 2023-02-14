using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONCESIONARIO_PROYECTO
{
    public partial class ConcesionarioModelo : System.Web.UI.Page
    {
        /*
         * Pre:
         * Post: Metodo el cual verifica si la bbd esta creada y en caso de que no lo este la crea
         */

        /*
         * Pre:
         * Post: Metodo el cual al cargar la pagina mustra una tabla con los diferentes vehiculos y
         *       sus respectivas especificaciones.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            concesionarioTabla.DataSource = from Modelos in dbRep.Modelos
                                            join Marcas in dbRep.Marcas on Modelos.id_marca equals Marcas.id_marca
                                            select new {
                                                id_modelo  = Modelos.id_modelo,
                                                modelo = Modelos.modelo,
                                                motor = Modelos.motor,
                                                id_marca = Modelos.id_marca,
                                                nombre_marca = Marcas.nombre
                                            
                                            };

                                            
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
                Response.Redirect("editConcesionarioModelo?id=" + id, false);
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
             * Post: (deleteVehiculo) seccion la cual borra un vehiculo seleccionado
             */
            if (e.CommandName == "deleteVehiculoModelo")   // si pulsar delete
            {
                int index = Convert.ToInt32(e.CommandArgument); // Obtenemos id del row
                GridViewRow selectedRow = concesionarioTabla.Rows[index];// Obtenemos row
                TableCell vehiculoID = selectedRow.Cells[0];     // Obtenemos id de vehiculo 0 = ID
                string id = vehiculoID.Text;                // Obtenemos string con id
                int idInt = Convert.ToInt32(id);
                Modelos vehiculo = dbRep.Modelos.SingleOrDefault(x => x.id_modelo == idInt);
                dbRep.Modelos.DeleteOnSubmit(vehiculo);
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