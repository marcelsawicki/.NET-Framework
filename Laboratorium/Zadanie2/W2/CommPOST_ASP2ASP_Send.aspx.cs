using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2
{
    public partial class CommPOST_ASP2ASP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CommPOST_ASP2ASP_Recv.aspx?imie=" + TextBoxImie.Text + "&nazwisko=" + TextBoxNazwisko.Text);
        }
    }
}