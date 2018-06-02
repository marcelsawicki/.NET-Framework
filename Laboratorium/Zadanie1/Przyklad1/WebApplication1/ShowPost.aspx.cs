using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ShowPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login = string.Empty;
            string haslo = string.Empty;
            string haslo_praw = "Haslo12";
            string login_praw = "radek";
            login = Request.Form["TextBox1"].ToString();
            haslo = Request.Form["TextBox2"].ToString();

            if (haslo == haslo_praw && login == login_praw)
            {
                Label2.Text = login;
                Label3.Text = haslo;
            }
            else
            {
                Label1.Visible = false;
                Label2.Visible = false;
                Label4.Visible = false;
                Label3.Text = "Nieprawidłowy login lub hasło";
            }
        }
    }
}