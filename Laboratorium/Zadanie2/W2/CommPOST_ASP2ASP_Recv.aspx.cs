using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W2
{
    public partial class CommPOST_ASP2ASP_Recv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//            if (Request.Params["TextBoxImie"] != null)
//                LabelImie.Text = Request.Params["TextBoxImie"];
//            if (Request.Params["TextBoxNazwisko"] != null)
//                LabelNazwisko.Text = Request.Params["TextBoxNazwisko"];
            if (Request.Params["TextBoxImie"] != null)
                LabelImie.Text = Request.Params["TextBoxImie"];
            if (Request.Params["TextBoxNazwisko"] != null)
                LabelNazwisko.Text = Request.Params["TextBoxNazwisko"];
            if (Request.QueryString["TextBoxImie"] != null)
                LabelImie2.Text = Request.QueryString["TextBoxImie"];
            if (Request.QueryString["TextBoxNazwisko"] != null)
                LabelNazwisko2.Text = Request.QueryString["TextBoxNazwisko"];
            if (Request.Form["TextBoxImie"] != null)
                LabelImie3.Text = Request.Form["TextBoxImie"];
            if (Request.Form["TextBoxNazwisko"] != null)
                LabelNazwisko3.Text = Request.Form["TextBoxNazwisko"];

        }
    }
}