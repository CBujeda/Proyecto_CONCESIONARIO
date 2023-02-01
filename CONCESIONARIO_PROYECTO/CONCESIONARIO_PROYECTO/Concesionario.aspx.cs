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
                ConcesionarioRepository cr = new ConcesionarioRepository();
                cr.CreateBBDD("server=localhost;Port=3306;uid=root;pwd=root;database=concesionario");
            }
        }
    }
}