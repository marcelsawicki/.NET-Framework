<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="kalkulator2.aspx.cs" Inherits="Kalkulator.kalkulator2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
<br />
<br />
<asp:TextBox ID="TextBox21" runat="server" Width="140px"></asp:TextBox>
<asp:TextBox ID="TextBox22" runat="server" Width="141px"></asp:TextBox>
<br />
<asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="Potega" />
<br />
<asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="Wartosc Bezwzgledna" />
<br />
<br />
<br />
<asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>

</asp:Content>
