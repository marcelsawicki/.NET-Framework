<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Book_Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        Imię:    
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        <br />
        E-mail:
        <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
        <br />
        Treść:
        <asp:TextBox ID="TextBox3" runat="server" Width="787px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Zostaw wiadomość." />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Komunikat."></asp:Label>
        <br />
        
        <asp:Xml ID="Xml1" runat="server" DocumentSource="~/ksiega.xml" TransformSource="~/ksiega.xslt"></asp:Xml>
    
    </div>
    </form>
</body>
</html>
