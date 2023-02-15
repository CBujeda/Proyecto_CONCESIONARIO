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
                newIdMarca.Text = id;
                ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
                Marcas modelos = dbRep.Marcas.SingleOrDefault(x => x.id_marca == idInt);
                if(modelos != null){ 
                    newNombreMarca.Text = modelos.nombre;
                    newPais.Text = modelos.pais;
                    DateTime dt = DateTime.Parse(modelos.anno_creacion.ToString());
                    String datf = dt.ToString("yyyy-MM-dd"); //"2023-02-15"
                    System.Diagnostics.Debug.WriteLine(datf);
                    newMarcaFecha.Text = datf;
                }

            }
        }

        /*
         * Pre:
         * Post: Metodo de redireccion la ventana principal.
         */
        private void volver()
        {
            Response.Redirect("/ConcesionarioMarca.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /*
         * Pre:
         * Post: Metodo el cual es llamado al clicar en la actualizacion de la Marca
         */
        protected void newActualizar_Click(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            int idvehic = 1;
            try
            {
                idvehic = Int32.Parse(newIdMarca.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse ");
            }

            String nombreMarca = newNombreMarca.Text;
            String pais = newPais.Text;
            String fecha_str = newMarcaFecha.Text;
            if (nombreMarca.Length >= 3 && 
                pais.Length >= 3 &&
                nombreMarca.Length <= 100 &&
                pais.Length <= 100 &&
                fecha_str.Length == 10)
            { // Verificación de datos
                DateTime dt = DateTime.Parse(fecha_str);
                System.Diagnostics.Debug.WriteLine(idvehic);
                Marcas vehiculo = db.Marcas.FirstOrDefault(x => x.id_marca == idvehic);               // Buesqueda de Marca en memoria
                vehiculo.id_marca = idvehic;
                vehiculo.nombre = nombreMarca;
                vehiculo.pais = pais;
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
            else {
                infoLabel.Text = "[INFO] No se insertaron los datos debido a que estos no son validos \n" +
                                "Nombre Size: " + nombreMarca.Length + "\n" +
                                "Pais Size: " + pais.Length + "\n" +
                                "Fecha: " + fecha_str;
            }
        }
    }
}