<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="DetaleHistoria1.aspx.cs" Inherits="Pomoc"%>

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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [obsluga] WHERE ([nr_zamowienia] = ?) AND ([kto] = ?)">
        <SelectParameters>
            <asp:QueryStringParameter Name="nr_zamowienia" QueryStringField="Podglad" Type="Int32" />
            <asp:SessionParameter Name="?" SessionField="ZALOGOWANY" />
        </SelectParameters>
    </asp:SqlDataSource>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Identyfikator" DataSourceID="SqlDataSource1" CellPadding="4" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="nr_zamowienia" HeaderText="Numer zamówienia" SortExpression="nr_zamowienia" />
            <asp:BoundField DataField="kto" HeaderText="Imię i Nazwisko" SortExpression="kto" />
            <asp:BoundField DataField="czas" HeaderText="Data zamówienia" SortExpression="czas" />
            <asp:BoundField DataField="elementy" HeaderText="Zamówione produkty" SortExpression="elementy" />
            <asp:BoundField DataField="zaplacono" HeaderText="Zaplacono" SortExpression="zaplacono" />
            <asp:BoundField DataField="wyslano" HeaderText="Wyslano" SortExpression="wyslano" />
        </Columns>
        <EditRowStyle HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

    <br />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Historia.aspx">Powrót do przeglądania historii zamówień.</asp:LinkButton>
   
</asp:Content>

