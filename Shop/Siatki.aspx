<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Siatki.aspx.cs" Inherits="Siatki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT produktID, nazwa, opis, foto, cena, kategoriaID FROM produkt WHERE (kategoriaID = 7)"></asp:SqlDataSource>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="produktID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Both" RepeatColumns="4">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <ItemTemplate>
            <!--
            produktID:
            <asp:Label ID="produktIDLabel" runat="server" Text='<%# Eval("produktID") %>' />
            <br />
            -->
            <!-- Nazwa: -->
            <b>
            <asp:Label ID="nazwaLabel" runat="server" Text='<%# Eval("nazwa") %>' />
            </b>
            <br />
            Opis:
            <asp:Label ID="opisLabel" runat="server" Text='<%# Eval("opis") %>' />
            <br />
            <!--
            foto:
            <asp:Label ID="fotoLabel" runat="server" Text='<%# Eval("foto") %>' />
            <br />
            -->
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("foto","{0}") %>' /><br />
            Cena:
            <asp:Label ID="cenaLabel" runat="server" Text='<%# Eval("cena") %>' />&nbsp; zł &nbsp;
            <!--
            kategoriaID:
            <asp:Label ID="kategoriaIDLabel" runat="server" Text='<%# Eval("kategoriaID") %>' />
            <br />
            -->
            <asp:HyperLink ID="HyperLink1" runat="server" 
          NavigateUrl='<%# Eval("produktID", "Koszyk.aspx?action=add&product={0}") %>'
          Text="Do Koszyka!">
             </asp:HyperLink>
            <br />
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    </asp:DataList>
</asp:Content>

