<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Szukaj.aspx.cs" Inherits="Szukaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        Proszę wpisać nazwę szukanego produktu i kliknąć przycisk "Szukaj".<br />
        <br />
        <asp:TextBox ID="Szukane" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Szukaj" PostBackUrl="~/Szukaj.aspx" /><br />
        <br />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand='SELECT * FROM [produkt] WHERE ([Nazwa] LIKE &#039;%&#039; + ? + &#039;%&#039;)'>
        <SelectParameters>
            <asp:ControlParameter ControlID="Szukane" Name="Nazwa" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="produktID" DataSourceID="SqlDataSource1">
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
    </asp:DataList>
</asp:Content>