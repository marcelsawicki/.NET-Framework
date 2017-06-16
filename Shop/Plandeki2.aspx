<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Plandeki2.aspx.cs" Inherits="Plandeki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT produktID, nazwa, opis, foto, cena, kategoriaID FROM produkt WHERE (kategoriaID = 3)"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="produktID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="produktID" HeaderText="produktID" InsertVisible="False" ReadOnly="True" SortExpression="produktID" />
            <asp:BoundField DataField="nazwa" HeaderText="nazwa" SortExpression="nazwa" />
            <asp:BoundField DataField="opis" HeaderText="opis" SortExpression="opis" />
            <asp:BoundField DataField="foto" HeaderText="foto" SortExpression="foto" />
            <asp:BoundField DataField="cena" HeaderText="cena" SortExpression="cena" />
            <asp:BoundField DataField="kategoriaID" HeaderText="kategoriaID" SortExpression="kategoriaID" />

        </Columns>
    </asp:GridView>
    <br />

</asp:Content>

