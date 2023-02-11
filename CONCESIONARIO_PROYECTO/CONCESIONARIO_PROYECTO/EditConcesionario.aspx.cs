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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                Modelos modelo = dbRep.Modelos.SingleOrDefault(x => x.id_modelo == vehiculo.id_modelo);
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
        private void volver()
        { // Recargamos pagina
            Response.Redirect("/Concesionario.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
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
            //Problemas ...
            //System.Diagnostics.Debug.Write(idvehic + "\n");
            String nombreVehiculo = newNombreVehiculo.Text;
            String tipoVehiculo = newTipoVehiculo.Text;
            Vehiculos vehiculo = db.Vehiculos.FirstOrDefault(x => x.id_vehiculo == idvehic);
            vehiculo.id_vehiculo = idvehic;
            vehiculo.nombre = nombreVehiculo;
            vehiculo.tipo = tipoVehiculo;
            vehiculo.id_modelo = result;

            System.Diagnostics.Debug.Write(
                vehiculo.id_vehiculo + "\n" +
                vehiculo.nombre + "\n" +
                vehiculo.tipo + "\n" +
                vehiculo.Modelos.id_modelo + "\n");

            System.Diagnostics.Debug.Write(
                idvehic + "\n" +
                nombreVehiculo + "\n" +
                tipoVehiculo + "\n" +
                result + "\n");

            //var query = from Vehiculos in db.Vehiculos
            //            where Vehiculos.id_vehiculo == idvehic
            //            select Vehiculos;
            //foreach (Vehiculos vehiculo in query)
            //{
            //    vehiculo.id_vehiculo = idvehic;
            //    vehiculo.nombre = newNombreVehiculo.Text;
            //    vehiculo.tipo = newTipoVehiculo.Text;
            //    vehiculo.id_modelo = result;
            //}

            try
            {
                db.SubmitChanges();
            }
            catch (Exception r)
            {
                Console.WriteLine(r);
            }
            volver();
        }
    }
}