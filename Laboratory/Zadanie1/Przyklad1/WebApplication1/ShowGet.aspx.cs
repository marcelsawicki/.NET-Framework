using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ShowGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string haslo = string.Empty;
            string login = string.Empty;
            string login_praw = "radek";
            string haslo_praw = "Haslo12";
            if (Request.Params["login"] != null){}
                
                haslo = Request.Params["haslo"];
                login = Request.Params["login"];
                if (haslo == haslo_praw && login == login_praw)
                {
                    Label2.Text = Request.Params["login"];
                    Label4.Text = Request.Params["haslo"];
                }
                else
                {
                    Label1.Visible = false;
                    Label3.Visible = false;
                    Label2.Visible = false;
                    Label4.Text = "Nieprawidłowy login lub hasło";
                }
        }
        }
    }