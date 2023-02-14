using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{
    public partial class InsertConcesionario : System.Web.UI.Page
    {

        /*
         * Pre:
         * Post: Metodo de carga el cual obtendra los datos de los modelos y los desplegara en un DropdownList
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
                List<Modelos> concesionarioTabla = dbRep.Modelos.ToList();
                newModelo.Items.Insert(0, new ListItem("Selecciónar Modelo", "-1"));
                for (int i = 0; i < concesionarioTabla.Count; i++)
                {
                    newModelo.Items.Insert(1, new ListItem(concesionarioTabla[i].modelo, concesionarioTabla[i].id_modelo.ToString()));
                }
            }
        }

        /*
         * Pre:
         * Post: Metodo el cual nos redirigira la la ventana principal.
         */
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/Concesionario.aspx", false);
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
            int result = 1;
            String input = newModelo.SelectedValue;
            String nombreSTR = nombreVehiculo.Text;
            String tipoSTR = tipoVehiculo.Text;
            if (!input.Equals("-1") && nombreSTR.Length >= 3 && tipoSTR.Length >= 3)    // Verificación de datos
            {
                try
                {
                    result = Int32.Parse(input);
                    Console.WriteLine(result);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                }
                Vehiculos v = new Vehiculos
                {
                    nombre = nombreSTR,
                    tipo = tipoSTR,
                    id_modelo = result,
                };
                db.Vehiculos.InsertOnSubmit(v); // Insercción
                db.SubmitChanges();             //Actualización de la BBDD
                volver();
            }
            else {
                System.Diagnostics.Debug.Write("[INFO] No se insertaron datos debido a que estos no fueron validos" + "\n");
            }
        }
    }
}