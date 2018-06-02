using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zad1
{
    public partial class wynikowa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["TextBox1"] != null)
                TextBox1.Text = Request.Params["TextBox1"];

            if (Request.Params["TextBox2"] != null)
                TextBox2.Text = Request.Params["TextBox2"];

            if (Request.Params["TextBox4"] != null)
                TextBox4.Text = Request.Params["TextBox4"];

            if (Request.Params["DropDownList1"] != null)
                TextBox5.Text = Request.Params["DropDownList1"];

            if (Request.Params["TextBox5"] != null)
                TextBox6.Text = Request.Params["TextBox5"];

            if (Request.Params["TextBox6"] != null)
                TextBox7.Text = Request.Params["TextBox6"];

            if (Request.Params["DropDownList1"] != null)
                TextBox8.Text = Request.Params["DropDownList1"];
        }
    }
}