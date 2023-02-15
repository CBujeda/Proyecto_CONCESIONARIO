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
                newIdModelo.Text = id;
                ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
                Modelos modelos = dbRep.Modelos.SingleOrDefault(x => x.id_modelo == idInt);
                newNombreModelo.Text = modelos.modelo;
                newMotor.Text = modelos.motor;
                List<Marcas> concesionarioTabla = dbRep.Marcas.ToList();                            // Obtenemos una lista de modelos
                Marcas marca = dbRep.Marcas.SingleOrDefault(x => x.id_marca == modelos.id_marca);   // Buscamos el modelo correspondiente
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
         * Post: Metodo el cual es llamado al clicar en la actualizacion del Modelo
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
                idvehic = Int32.Parse(newIdModelo.Text);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }

            String nombreModelo = newNombreModelo.Text;
            String motor = newMotor.Text;

            if (nombreModelo.Length >= 3 &&
                motor.Length >= 3 &&
                nombreModelo.Length <= 100 &&
                motor.Length <= 100

                )    // Verificación de datos
            {
                System.Diagnostics.Debug.WriteLine(idvehic);
                Modelos modelo = db.Modelos.FirstOrDefault(x => x.id_modelo == idvehic);    // Busqueda del modelo en memoria
                modelo.id_modelo = idvehic;
                modelo.modelo = nombreModelo;
                modelo.motor = motor;
                modelo.id_marca = result;
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
                infoLabel.Text = "[INFO] No se insertaron datos debido a que estos no fueron validos \n" +
                                "Nombre Size: " + nombreModelo.Length + "\n" +
                                "Motor Size: " + motor.Length;
            }
        }
    }
}