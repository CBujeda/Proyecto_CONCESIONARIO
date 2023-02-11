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
        private string idVehiculo;




        protected void Page_Load(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = Request.QueryString["id"];
            }
            catch (Exception)
            {
                id = "-1";
            }
            int idInt = Convert.ToInt32(id);
            newIdVehiculo.Text = id;
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            Vehiculos vehiculo = dbRep.Vehiculos.SingleOrDefault(x => x.id_vehiculo == idInt);
            newNombreVehiculo.Text = vehiculo.nombre;
            newTipoVehiculo.Text = vehiculo.tipo;
            List<Modelos> concesionarioTabla = dbRep.Modelos.ToList();

            for (int i = 0; i < concesionarioTabla.Count; i++)
            {
                newModelo.Items.Insert(0, new ListItem(concesionarioTabla[i].modelo, concesionarioTabla[i].id_modelo.ToString()));
            }
        }
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/Concesionario.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void newActualizar_Click(object sender, EventArgs e)
        {
            ConcesionarioRepositoryDataContext db = new ConcesionarioRepositoryDataContext();
            int result = 1;
            string input = newModelo.SelectedValue;
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
                nombre = newNombreVehiculo.Text,
                tipo = newTipoVehiculo.Text,
                id_modelo = result,
            };
            db.Vehiculos.InsertOnSubmit(v);
            db.SubmitChanges();
            volver();
        }
    }
}