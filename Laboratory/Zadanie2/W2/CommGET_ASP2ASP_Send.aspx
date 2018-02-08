<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommGET_ASP2ASP_Send.aspx.cs" Inherits="W2.CommGET_ASP2ASP_Send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxImie" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxNazwisko" runat="server"></asp:TextBox>
    
    </div>
        <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="Button" />
    </form>
</body>
</html>
