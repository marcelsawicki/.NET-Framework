<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommPOST_ASP2ASP_Recv.aspx.cs" Inherits="W2.CommPOST_ASP2ASP_Recv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>W2 - komunikacja POST ASP -> ASP (recv)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Text="Request.Params[]:"></asp:Label>
        <br />
    
        <asp:Label ID="LabelImie" runat="server" Text="Imie"></asp:Label>
        <br />
        <asp:Label ID="LabelNazwisko" runat="server" Text="Nazwisko"></asp:Label>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="Request.QueryString[]:"></asp:Label>
        <br />
    
        <asp:Label ID="LabelImie2" runat="server" Text="Imie"></asp:Label>
        <br />
        <asp:Label ID="LabelNazwisko2" runat="server" Text="Nazwisko"></asp:Label>
    
        <br />
        <asp:Label ID="Label4" runat="server" Text="Request.Form[]:"></asp:Label>
        <br />
    
        <asp:Label ID="LabelImie3" runat="server" Text="Imie"></asp:Label>
        <br />
        <asp:Label ID="LabelNazwisko3" runat="server" Text="Nazwisko"></asp:Label>
    
        <br />
    
    </div>
    </form>
</body>
</html>
