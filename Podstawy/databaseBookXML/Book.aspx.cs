using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Book_Book : System.Web.UI.Page
{
    private void AddXmlContent(XmlDocument doc, XmlElement element, string tag, string value)
    {
        XmlElement newElement = doc.CreateElement(tag);
        XmlText text = doc.CreateTextNode(value);
        element.AppendChild(newElement);
        newElement.AppendChild(text);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != String.Empty && TextBox2.Text != String.Empty && TextBox3.Text != String.Empty)
        {
            XmlDocument document = new XmlDocument();
            document.Load(Server.MapPath("ksiega.xml"));
            XmlElement newElement;
            newElement = document.CreateElement("guest");
            document.DocumentElement.PrependChild(newElement);
            AddXmlContent(document, newElement, "name", TextBox1.Text);
            AddXmlContent(document, newElement, "e-mail", TextBox2.Text);
            AddXmlContent(document, newElement, "data", DateTime.Now.ToString());
            AddXmlContent(document, newElement, "comment", TextBox3.Text);
            document.Save(Server.MapPath("ksiega.xml"));
            Response.Redirect("Book.aspx");
        }
        else
        {
            Label1.Text = "Nie wprowadzono żadnych danych";
        }
    }
}