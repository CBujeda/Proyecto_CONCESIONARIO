 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONCESIONARIO_PROYECTO
{
    public partial class InsertConcesionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        }
    }
}