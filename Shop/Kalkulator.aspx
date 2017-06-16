<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Kalkulator.aspx.cs" Inherits="Galeria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;" ForeColor="Red" BackColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
<br />
<br />
<asp:TextBox ID="TextBox1" runat="server" Width="140px"></asp:TextBox>
<asp:TextBox ID="TextBox2" runat="server" Width="141px"></asp:TextBox>
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dodaj" />
<br />
<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Odejmij" />
<br />
<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Mnóż" />
<br />
<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Dziel" />
<br />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
    </p>
</asp:Content>

