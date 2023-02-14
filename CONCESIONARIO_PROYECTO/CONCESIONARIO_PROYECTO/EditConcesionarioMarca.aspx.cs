using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CONCESIONARIO_PROYECTO
{

    public partial class EditConcesionarioMarca : System.Web.UI.Page
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
                Marcas modelos = dbRep.Marcas.SingleOrDefault(x => x.id_marca == idInt);
                newNombreVehiculo.Text = modelos.nombre;
                newTipoVehiculo.Text = modelos.pais;
                newMarcaFecha.Text = modelos.anno_creacion.ToString(); /// AERREGLAR

            }
        }

        /*
         * Pre:
         * Post: Metodo de redireccion la ventana principal.
         */
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/ConcesionarioMarca.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*
         * Pre:
         * Post: Metodo el cual es llamado al clicar en la actualizacion del vehiculo
         */
        protected void newActualizar_Click(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            int idvehic = 1;
            try
            {
                idvehic = Int32.Parse(newIdVehiculo.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse ");
            }

            String nombreVehiculo = newNombreVehiculo.Text;
            String tipoVehiculo = newTipoVehiculo.Text;
            DateTime dt = DateTime.Parse(newMarcaFecha.Text);
            System.Diagnostics.Debug.WriteLine(idvehic);
            Marcas vehiculo = db.Marcas.FirstOrDefault(x => x.id_marca == idvehic);    // Buesqueda del vehiculo en memoria
            vehiculo.id_marca = idvehic;
            vehiculo.nombre = nombreVehiculo;
            vehiculo.pais = tipoVehiculo;
            vehiculo.anno_creacion = dt;
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