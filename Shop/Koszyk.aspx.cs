using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

public partial class Koszyk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //bardzo ważne żeby to było, tworze koszyk w sesji
        if (Session["MyBucket"] == null) Session["MyBucket"] = new Core.Bucket(); 
        if (Session["ZALOGOWANY"] != null) { LabelLogin.Text = "" + Session["ZALOGOWANY"]; }

        Core.Bucket k = (Core.Bucket)Session["MyBucket"];
        //int wKoszyku = k.IlePozycji();

        if(Request["action"]=="add" && Request["product"]!=null)
        {
           Core.Produkt dodawanyProdukt = Core.PolaczDB.ZnajdzProdukt(Int32.Parse(Request["product"]));
            k.dodaj(new PozycjaZamowienia(dodawanyProdukt));
        }

        else if (Request["action"] == "del" && Request["product"]!= null)
        {
            Core.Produkt dodawanyProdukt = Core.PolaczDB.ZnajdzProdukt(Int32.Parse(Request["product"]));
            k.zdejmij(new PozycjaZamowienia(dodawanyProdukt));
        }

        else if (Request["action"] == "remove" && Request["product"]!= null)
        {
            Core.Produkt dodawanyProdukt = Core.PolaczDB.ZnajdzProdukt(Int32.Parse(Request["product"]));
            k.usun(new PozycjaZamowienia(dodawanyProdukt));
        }

        if (Request["action"] == "zamow" && Request["userID"] != null)
        {

            int mojUserID = Int32.Parse(Request["userID"]);
                    DateTime dt = DateTime.Now;
                    String.Format("{0:d-M-yyyy-hh-mm-ss}", dt); // "9.3.2008 16:05:07" - german (de-DE)
                    String pomocnicza = dt.ToString();
            k.ZlozZamowienie(mojUserID.ToString(),pomocnicza, Session["ZALOGOWANY"].ToString());
            Response.Redirect("Podziekowanie.aspx");
        }

        if (Request["action"] != null) Response.Redirect(this.Request.ServerVariables["HTTP_REFERER"]);
        k.ShowBucket(TKoszyk);

    }
    //Część kodu sprawdzająca czy użytkownik może się zalogować


    protected void ButtonZamowienie_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Zamowienie.aspx");
    }
}