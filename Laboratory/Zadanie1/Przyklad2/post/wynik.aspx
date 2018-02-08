<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wynik.aspx.cs" Inherits="post.wynik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
    
        Przesłane dane<br />
        </div>

        Login :&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        Hasło :&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
    
    </form>
</body>
</html>
