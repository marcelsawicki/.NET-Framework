using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ZALOGOWANY"] != null) { LabelLogin.Text = "" + Session["ZALOGOWANY"]; }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //Core.PolaczDB.DodajUzytkownika();
        OleDbConnection Polaczenie = new OleDbConnection();
        Polaczenie.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;data source=|DataDirectory|\\sklep.mdb";
        Polaczenie.Open();
        OleDbCommand polecenieSQL = new OleDbCommand("INSERT INTO [produkt]([nazwa],[opis],[foto],[cena],[kategoriaID]) VALUES ('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + DropDownList1.Text + "')", Polaczenie);
        polecenieSQL.ExecuteNonQuery();

        Polaczenie.Close();
        Response.Redirect("PodziekowanieRejestracja.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        HttpPostedFile file1 = this.FileUpload1.PostedFile;
        if ((file1 != null) && (file1.ContentLength > 0))
        {
            string fileName = System.IO.Path.GetFileName(file1.FileName);
            string saveLocation = Server.MapPath("images\\" + fileName);
            try
            {
                file1.SaveAs(saveLocation);
                this.Label1.Text = "Plik został zapisany na serwerze";
            }
            catch (Exception ex)
            {
                this.Label1.Text = "Wystąpił błąd: " + ex.Message;
            }
        }
        else
        {
            this.Label1.Text = "Nie podałeś lokalizacji pliku na dysku, lub plik ten jest nieprawidłowy";
        }        
    }
}