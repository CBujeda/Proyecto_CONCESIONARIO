using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONCESIONARIO_PROYECTO.BBDD;

namespace CONCESIONARIO_PROYECTO
{
    public partial class Concesionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                using (var db = new Concesionario())
                {
                    var q =
                        from c in db.Concesionario
                        select c;

                    foreach (var c in q)
                        Console.WriteLine(c.ContactName);
                }
            }
        }
    }
}