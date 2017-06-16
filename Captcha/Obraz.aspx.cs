using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Obraz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't forget to include this in your code
        // using System.Drawing; // using System.Drawing.Imaging;

        // We load an existing bitmap 
        Bitmap oCanvas = (Bitmap)Bitmap.FromFile(Server.MapPath("Images\\Image1.jpg"));
        //Graphics g = Graphics.FromImage(oCanvas);

        // We generate a new bitmap and // draw an ellipse on it

        //Bitmap oCanvas = new Bitmap(200, 150);
        Graphics g = Graphics.FromImage(oCanvas);
        //g.Clear(Color.White);
        //g.DrawRectangle(Pens.Green, 10, 10, 150, 100);

        Font f = new Font("Microsoft Sans Serif", 14);
        StringBuilder sb = new StringBuilder();
        Random r = new Random();
        for (int i = 0; i < 5; i++)
        {
            char letter = ((char)('a' + r.Next('z' - 'a')));
            sb.Append(letter);
        }
        Session["Password"] = sb.ToString();
        g.DrawString(sb.ToString(), f, Brushes.White, 40, 10);

        // Now, we only need to send it // to the client
        Response.ContentType = "image/jpeg";
        oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
        Response.End();

        // Cleanup
        g.Dispose();
        oCanvas.Dispose();
    }
}