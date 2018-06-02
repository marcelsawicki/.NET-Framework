<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mapa.aspx.cs" Inherits="Mapa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Mapy/dungeon.JPG" OnClick="Napisz"/><br />
        <asp:Label ID="Label1" runat="server" Text="Proszę kliknąć w na mapie miejsce do którego chciałbyś się udać."></asp:Label>
    </div>
    </form>
</body>
</html>
