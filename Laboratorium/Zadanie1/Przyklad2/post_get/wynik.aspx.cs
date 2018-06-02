using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace post_get
{
    public partial class wynik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // GET

            if (Request.Params["login"] != null)
                Label1.Text = Request.Params["login"];

            if (Request.Params["haslo"] != null)
                Label2.Text = Request.Params["haslo"];

           // Label1.Text = Request.Form["TextBox1"];
           // Label2.Text = Request.Form["TextBox2"];
        }
    }
}