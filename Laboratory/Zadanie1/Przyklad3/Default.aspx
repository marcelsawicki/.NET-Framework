<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="zad1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="POST">
    <div>
    
    </div>
        Imie :
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Wypełnij pole !!!">Podaj imie !!!</asp:RequiredFieldValidator>
        <br />
        <br />
        Nazwisko :
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Podaj nazwisko !!!">Podaj nazwisko !!!</asp:RequiredFieldValidator>
        <br />
        <br />
        Data urodzenia :
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="Data urodzenia !!!">Data urodzenia !!!</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$">Błędny format !!! (rrrr-mm-dd)</asp:RegularExpressionValidator>
        <br />
        <br />
        Adres email :
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="Adres email !!!">Adres email !!!</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Błędny format !!!</asp:RegularExpressionValidator>
        <br />
        <br />
        Hasło : <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="Hasło !!!">Hasło !!!</asp:RequiredFieldValidator>
        <br />
        <br />
        Wiek : <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>0 - 25</asp:ListItem>
            <asp:ListItem>26 - 50</asp:ListItem>
            <asp:ListItem>51 - 75</asp:ListItem>
            <asp:ListItem>76 - 100</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Opinia :
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="58px" TextMode="MultiLine" Width="215px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox2" ErrorMessage="Wypełnij pole !!!">Wypełnij pole !!!</asp:RequiredFieldValidator>
        <br />
        <br />
        Akceptacja : <asp:CheckBox ID="CheckBox1" runat="server" />
        <br />
&nbsp;<p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" PostBackUrl="~/wynikowa.aspx"/>
        </p>
    </form>
</body>
</html>
