using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Form["ctl00$TBLogin"] != null)
        {
            //TBLogin.Text = Request.Form["ctl00$TBLogin"];
            //TBPassword.Text = Request.Form["ctl00$TBPassword"];
        }
        else { TBLogin.Text = "brak - cos jest nie tak"; };
        
        if (Request.QueryString["action"] == "logout")
        {
            //TBLogin.Text = "wylogowano";
            //TBPassword.Text = "wylogowano";
            Session.Remove("ZALOGOWANY");
        }
        
    }

    //Część kodu sprawdzająca czy użytkownik może się zalogować

    protected void FVUzytkownik_DataBound(object sender, EventArgs e) 
    {
        if (FVUzytkownik.Row != null)
        {
            LZalogowanyJako.Text = "Jesteś zalogowany!";
            Session["ZALOGOWANY"] = Request.Form["ctl00$TBLogin"];
            if(Session["ZALOGOWANY"]!=null){LabelLogin.Text = ""+Session["ZALOGOWANY"];}
            //dodalem to od siebie, zeby pokazal czy ktos jest adminem
            if (LabelLogin.Text == "admin")
            { LabelAdmin.Text = "Jesteś Administratorem!"; HyperLinkAdmin.Visible = true; }
            else { LabelAdmin.Text = "Zapraszamy do zakupów!"; };
            
        }
        else
        {
            //LZalogowanyJako.Text = "Nie jesteś zalogowany!";
        }
    }
}