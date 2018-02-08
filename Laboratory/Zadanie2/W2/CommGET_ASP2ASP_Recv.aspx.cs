using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2
{
    public partial class CommGET_ASP2ASP_Recv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["imie"] != null)
                LabelImie.Text = Request.Params["imie"];
            if (Request.Params["nazwisko"] != null)
                LabelNazwisko.Text = Request.Params["nazwisko"];
            if (Request.QueryString["imie"] != null)
                LabelImie2.Text = Request.QueryString["imie"];
            if (Request.QueryString["nazwisko"] != null)
                LabelNazwisko2.Text = Request.QueryString["nazwisko"];
            if (Request.Form["imie"] != null)
                LabelImie3.Text = Request.Form["imie"];
            if (Request.Form["nazwisko"] != null)
                LabelNazwisko3.Text = Request.Form["nazwisko"];
        }
    }
}