using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{
    public partial class InsertConcesionarioModelo : System.Web.UI.Page
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
                List<Marcas> concesionarioTabla = dbRep.Marcas.ToList();
                newMarca.Items.Insert(0, new ListItem("Selecciónar Marca", "-1"));
                for (int i = 0; i < concesionarioTabla.Count; i++)
                {
                    newMarca.Items.Insert(1, new ListItem(concesionarioTabla[i].nombre, concesionarioTabla[i].id_marca.ToString()));
                }
            }
        }

        /*
         * Pre:
         * Post: Metodo el cual nos redirigira la la ventana principal.
         */
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/ConcesionarioModelo.aspx", false);
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
            String input = newMarca.SelectedValue;
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
                Modelos v = new Modelos
                {
                    modelo = nombreSTR,
                    motor = tipoSTR,
                    id_marca = result,
                };
                db.Modelos.InsertOnSubmit(v); // Insercción
                db.SubmitChanges(); //Actualización de la BBDD
                volver();
            }
            else {
                System.Diagnostics.Debug.Write("[INFO] No se insertaron datos debido a que estos no fueron validos" + "\n");
            }
        }
    }
}