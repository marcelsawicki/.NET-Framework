<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styl1.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Font-Size="Large">
            Strona logowania</asp:Panel>
         <asp:Panel ID="Panel2" CssClass="panel_login" runat="server">

             <asp:Panel ID="Panel3" CssClass="login" runat="server">
                 <asp:Label ID="Label1" CssClass="label" runat="server" Text="Login:"></asp:Label>
                 <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                 
                 </asp:Panel>
             <asp:Panel ID="Panel4" CssClass="haslo" runat="server">
                 <asp:Label ID="Label2" CssClass="label" runat="server" Text="Hasło:"></asp:Label>
                 <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" TextMode="Password"></asp:TextBox>
            
                 </asp:Panel>
             <asp:Button ID="Button1" runat="server" Text="GET" OnClick="Button1_Click" />
             <asp:Button ID="Button2" runat="server" Text="POST" PostBackUrl="ShowPost.aspx"/>
        </asp:Panel>
    </div>
        
    </form>
</body>
</html>
