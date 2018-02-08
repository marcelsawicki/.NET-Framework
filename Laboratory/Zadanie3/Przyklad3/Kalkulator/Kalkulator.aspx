<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kalkulator.aspx.cs" Inherits="Kalkulator.Kalkulator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

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

</asp:Content>
