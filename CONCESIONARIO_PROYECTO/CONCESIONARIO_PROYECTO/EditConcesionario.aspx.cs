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
            ConcesionarioRepositoryDataContext dbRep = new ConcesionarioRepositoryDataContext();
            List <Modelos>concesionarioTabla = dbRep.Modelos.ToList();
            
            for (int i =0; i<concesionarioTabla.Count; i++)
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
            Vehiculos v = new Vehiculos {
                    nombre = nombreVehiculo.Text,
                    tipo = tipoVehiculo.Text,
                    id_modelo = result,
            };
            db.Vehiculos.InsertOnSubmit(v);
            db.SubmitChanges();
            volver();
        }
    }
}