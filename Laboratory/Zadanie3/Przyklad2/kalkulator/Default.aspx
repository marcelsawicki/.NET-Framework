<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="kalkulator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
    
        Kalkulator:<br />
        <br />
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="69px" Height="18px">0</asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="+" Width="21px" />
        <asp:Button ID="Button2" runat="server" Text="-" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="*" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="/" OnClick="Button4_Click" />
        <asp:TextBox ID="TextBox2" runat="server" Width="68px" Height="19px">0</asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="      =   "></asp:Label>
        <asp:Label ID="Label2" runat="server">0</asp:Label>
        <br />
        <br />
        ----------------------------------------------------------------------------<br />
        <br />
        Zaawansowany Kalkulator:<br />
        <br />
        Liczba:&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="72px">0</asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Do potęgi : "></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Width="66px" >1</asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="   =    " style="margin-left: 34px" OnClick="Button5_Click" />
        <asp:Label ID="Label6" runat="server" Text="0"></asp:Label>
        <br />
        Pierwiastek kwadratowy liczby
        <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 12px" Width="64px">0</asp:TextBox>
        <asp:Button ID="Button6" runat="server" Text="   =    " style="margin-left: 35px" OnClick="Button6_Click" />
        <asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
        <br />
        Wartośc bezwzględna liczby
        <asp:TextBox ID="TextBox6" runat="server" style="margin-left: 30px" Width="62px">0</asp:TextBox>
        <asp:Button ID="Button7" runat="server" Text="   =    " style="margin-left: 38px" Width="54px" OnClick="Button7_Click" />
        <asp:Label ID="Label13" runat="server" Text="0"></asp:Label>
        <br />
        <br />
        ------------------------------------------------------------------------------<br />
        <br />
        Kalkulator Ekonomiczny:
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Okres oszczędzania (miesiące) :"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" style="margin-left: 20px">0</asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Oprocentowanie (skala roczna):"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" style="margin-left: 19px">0</asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Kapitalizacja (miesiące)"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" style="margin-left: 68px" >0</asp:TextBox>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Wkład"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server" style="margin-left: 171px">0</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" Text="Button" OnClick="Button8_Click" />
        <asp:TextBox ID="TextBox11" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
    </form>
</body>
</html>

