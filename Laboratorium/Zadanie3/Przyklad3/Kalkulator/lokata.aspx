<%@ Page Title="Lokata" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="lokata.aspx.cs" Inherits="Kalkulator.lokata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    M - okres oszczedzania, miesiące<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<br />
O - oprocentowanie roczne, %<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<br />
K - kapitalizacja, miesiące<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<br />
W - wkład, zł<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Oblicz" />
<br />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
   <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>

</asp:Content>
