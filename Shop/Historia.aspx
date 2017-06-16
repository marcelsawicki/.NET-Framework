<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Historia.aspx.cs" Inherits="Pomoc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Przeglądanie i zarządzanie zamówieniami: 
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [nr_zamowienia], [kto], [czas], [zaplacono], [wyslano] FROM [obsluga] WHERE kto=?">
        <SelectParameters>
            <asp:SessionParameter Name="?" SessionField="ZALOGOWANY" />
        </SelectParameters>
    </asp:SqlDataSource>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="nr_zamowienia" HeaderText="Numer zamówienia" SortExpression="nr_zamowienia" />
            <asp:BoundField DataField="kto" HeaderText="Imię i Nazwisko" SortExpression="kto" />
            <asp:BoundField DataField="czas" HeaderText="Data zamówienia" SortExpression="czas" />
            <asp:BoundField DataField="zaplacono" HeaderText="Zapłacono" SortExpression="zaplacono" />
            <asp:BoundField DataField="wyslano" HeaderText="Wysłano" SortExpression="wyslano" />
            <asp:HyperLinkField DataNavigateUrlFields="nr_zamowienia" DataNavigateUrlFormatString="DetaleHistoria.aspx?Podglad={0}" DataTextField="nr_zamowienia" HeaderText="Podgląd" SortExpression="nr_zamowienia" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

    <br />

    <br />
    <br />

   
</asp:Content>

