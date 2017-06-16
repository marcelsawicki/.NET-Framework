using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  // don't forget to include this in your code
  // using System.Drawing; // using System.Drawing.Imaging;


   // We load an existing bitmap
   Bitmap oCanvas = (Bitmap)Bitmap.FromFile( Server.MapPath("Images\\example.jpg"));
   Graphics g = Graphics.FromImage(oCanvas);

   // We render some text
   Font f1 = new Font("Arial Black",4);
   g.DrawString("x Point 1", f1,Brushes.Red ,122,70);

   // We render the current score
   Font f2 = new Font("Arial Black",4);
   Rectangle r = new Rectangle(0,0,oCanvas.Width,oCanvas.Height);
   StringFormat sf = new StringFormat();
   sf.Alignment = StringAlignment.Far;
   sf.LineAlignment = StringAlignment.Far;
   g.DrawString("x Poin 2", f2,Brushes.Green,60,110);

   // We render the copyright at a 90 degree angle
   Font f3 = new Font("Arial Black",4);
   g.DrawString("x Point 3", f3,Brushes.Blue,213,70);
   // We render the copyright at a 90 degree angle
   g.DrawString("x Point 4", f3, Brushes.Black, 80, 80);

   // Now, we only need to send it to the client
   Response.ContentType = "image/jpeg";
   oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
   Response.End();

   // Cleanup
   g.Dispose();
   oCanvas.Dispose();
   f1.Dispose();
   f2.Dispose();
   f3.Dispose();
   sf.Dispose();
    }
}