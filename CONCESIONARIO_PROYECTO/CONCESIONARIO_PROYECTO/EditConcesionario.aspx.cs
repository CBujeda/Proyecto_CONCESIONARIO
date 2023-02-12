using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{

    public partial class EditConcesionario : System.Web.UI.Page
    {
        /*
         * Pre:
         * Post: Metodo con el cual al cargar la pantalla principal inserta los datos
         *       por pantalla.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = "";
                try
                {
                    id = Request.QueryString["id"];
                   
                }
                catch (Exception)
                {
                    id = "-1";
                    volver();
                }
                if (id == "" || id == " " || id == null)    //Saltamos errores
                {
                    volver();
                    id = "1";
                }
                int idInt = Convert.ToInt32(id);
                newIdVehiculo.Text = id;
                ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
                Vehiculos vehiculo = dbRep.Vehiculos.SingleOrDefault(x => x.id_vehiculo == idInt);
                newNombreVehiculo.Text = vehiculo.nombre;
                newTipoVehiculo.Text = vehiculo.tipo;
                List<Modelos> concesionarioTabla = dbRep.Modelos.ToList();  // Obtenemos una lista de modelos
                Modelos modelo = dbRep.Modelos.SingleOrDefault(x => x.id_modelo == vehiculo.id_modelo); // Buscamos el modelo correspondiente
                newModelo.Items.Insert(0, new ListItem(modelo.modelo, vehiculo.id_modelo.ToString()));
                for (int i = 0; i < concesionarioTabla.Count; i++)
                {
                    if (concesionarioTabla[i].id_modelo != modelo.id_modelo)
                    {
                        newModelo.Items.Insert(1, new ListItem(concesionarioTabla[i].modelo, concesionarioTabla[i].id_modelo.ToString()));
                    }
                }
            }
        }

        /*
         * Pre:
         * Post: Metodo de redireccion la ventana principal.
         */
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/Concesionario.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*
         * Pre:
         * Post: Metodo el cual es llamado al clicar en la actualizacion del vehiculo
         */
        protected void newActualizar_Click(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            int result = 1;
            int idvehic = 1;
            string input = newModelo.SelectedValue;
            try
            {
                result = Int32.Parse(input);
                idvehic = Int32.Parse(newIdVehiculo.Text);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }

            String nombreVehiculo = newNombreVehiculo.Text;
            String tipoVehiculo = newTipoVehiculo.Text;
            Vehiculos vehiculo = db.Vehiculos.FirstOrDefault(x => x.id_vehiculo == idvehic);    // Buesqueda del vehiculo en memoria
            vehiculo.id_vehiculo = idvehic;
            vehiculo.nombre = nombreVehiculo;
            vehiculo.tipo = tipoVehiculo;
            vehiculo.id_modelo = result;
            try
            {
                db.SubmitChanges(); // Enviamos datos
            }
            catch (Exception r)
            {
                Console.WriteLine(r);
            }
            volver();
        }
    }
}