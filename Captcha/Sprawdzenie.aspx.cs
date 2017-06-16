using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sprawdzenie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["Captcha"] != null)
            Label1.Text = Request.Params["Captcha"];
            Label2.Text = Session["Password"].ToString();
            if (Label1.Text == Label2.Text) { Label3.Text = "Wprowadzono poprawne Captcha!"; }
            else { Label3.Text = "Wprowadzono nie poprawne Captcha!"; }
    }
}