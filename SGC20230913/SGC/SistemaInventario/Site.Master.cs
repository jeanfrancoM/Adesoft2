using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace SistemaInventario
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static bool KeepActiveSession()
        {
            if (HttpContext.Current.Session["datos"] == null | Convert.ToInt32(HttpContext.Current.Session["CodUsuario"]) == 0)
                return false;
            else
                return true;
        }

    }
}
