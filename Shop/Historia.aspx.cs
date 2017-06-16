using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pomoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ZALOGOWANY"] != null) { LabelLogin.Text = "" + Session["ZALOGOWANY"]; }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/Kalkulator.aspx");
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}