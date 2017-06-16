using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rejestracja : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ZALOGOWANY"] != null) { LabelLogin.Text = "" + Session["ZALOGOWANY"]; }
    }

    protected void ButtonREJESTRACJA2_Click(object sender, EventArgs e)
    {
        //Core.PolaczDB.DodajUzytkownika();
        OleDbConnection Polaczenie = new OleDbConnection();
        Polaczenie.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=|DataDirectory|\\sklep.mdb";
        Polaczenie.Open();
        OleDbCommand polecenieSQL = new OleDbCommand("INSERT INTO [uzytkownik]([login],[haslo],[imieNazwisko],[email]) VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "')", Polaczenie);
        polecenieSQL.ExecuteNonQuery();

        Polaczenie.Close();
        Response.Redirect("PodziekowanieRejestracja.aspx");
    }
}