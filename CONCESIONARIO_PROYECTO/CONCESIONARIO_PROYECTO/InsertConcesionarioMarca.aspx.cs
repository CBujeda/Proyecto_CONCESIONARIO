using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{
    public partial class InsertConcesionarioMarca : System.Web.UI.Page
    {

        /*
         * Pre:
         * Post: Metodo de carga el cual obtendra los datos de los modelos y los desplegara en un DropdownList
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        /*
         * Pre:
         * Post: Metodo el cual nos redirigira la la ventana principal.
         */
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/ConcesionarioMarca.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /**
         * Pre:
         * Post: Metodo el cual es llamado al clicar en el botor para gradar los datos
         *       dicho metodo guardara los datos en caso de que estos sean validos
         */
        protected void newActualizar_Click(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            String nombreSTR = nombreVehiculo.Text;
            String tipoSTR = tipoVehiculo.Text;
            String fecha_str = newMarcaDate.Text;
            
            if ( nombreSTR.Length >= 3 && tipoSTR.Length >= 3 && fecha_str.Length == 10)    // Verificación de datos
            {
                DateTime dt = DateTime.Parse(fecha_str);
                Marcas v = new Marcas
                {
                    nombre = nombreSTR,
                    pais = tipoSTR,
                    anno_creacion = dt,
                };
                db.Marcas.InsertOnSubmit(v); // Insercción
                db.SubmitChanges(); //Actualización de la BBDD
                volver();
            }
            else {
                System.Diagnostics.Debug.Write("[INFO] No se insertaron datos debido a que estos no fueron validos" + "\n");
            }
        }
    }
}