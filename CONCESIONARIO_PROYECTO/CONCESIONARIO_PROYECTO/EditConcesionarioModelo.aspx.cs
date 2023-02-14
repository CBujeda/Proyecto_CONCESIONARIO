using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{

    public partial class EditConcesionarioModelo : System.Web.UI.Page
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
                Modelos modelos = dbRep.Modelos.SingleOrDefault(x => x.id_modelo == idInt);
                newNombreVehiculo.Text = modelos.modelo;
                newTipoVehiculo.Text = modelos.motor;
                List<Marcas> concesionarioTabla = dbRep.Marcas.ToList();  // Obtenemos una lista de modelos
                Marcas marca = dbRep.Marcas.SingleOrDefault(x => x.id_marca == modelos.id_marca); // Buscamos el modelo correspondiente
                newMarca.Items.Insert(0, new ListItem(marca.nombre, modelos.id_marca.ToString()));
                for (int i = 0; i < concesionarioTabla.Count; i++)
                {
                    if (concesionarioTabla[i].id_marca != marca.id_marca)
                    {
                        newMarca.Items.Insert(1, new ListItem(concesionarioTabla[i].nombre, concesionarioTabla[i].id_marca.ToString()));
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
            Response.Redirect("/ConcesionarioModelo.aspx", false);
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
            string input = newMarca.SelectedValue;
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
            System.Diagnostics.Debug.WriteLine(idvehic);
            Modelos vehiculo = db.Modelos.FirstOrDefault(x => x.id_modelo == idvehic);    // Buesqueda del vehiculo en memoria
            vehiculo.id_modelo = idvehic;
            vehiculo.modelo = nombreVehiculo;
            vehiculo.motor = tipoVehiculo;
            vehiculo.id_marca = result;
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