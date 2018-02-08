<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommPOST_ASP2ASP_Send.aspx.cs" Inherits="W2.CommPOST_ASP2ASP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>W2 - komunikacja POST ASP -> ASP (send)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxImie" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxNazwisko" runat="server"></asp:TextBox>
    
    </div>
        <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="Send" PostBackUrl="~/CommPOST_ASP2ASP_Recv.aspx" />
    </form>
</body>
</html>
