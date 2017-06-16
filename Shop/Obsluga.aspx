<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Obsluga.aspx.cs" Inherits="Pomoc"%>

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
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Proszę wprowadzić szukane wyrażenie i nacisnąć przycisk &quot;Filtr po imieniu i nazwisku&quot;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="450px"></asp:TextBox>
            </td>
            <td>
    <asp:Button ID="Button1" runat="server" Text="Filtr po imieniu i nazwisku" OnClick="Button1_Click" PostBackUrl="~/Obsluga.aspx" />

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [nr_zamowienia], [kto], uzytkownik.imieNazwisko, [czas], [zaplacono], [wyslano] FROM [obsluga], [uzytkownik] WHERE obsluga.kto=uzytkownik.login AND uzytkownik.imieNazwisko=?">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="?" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" CellSpacing="1" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="nr_zamowienia" HeaderText="Numer zamówienia" SortExpression="nr_zamowienia" />
            <asp:BoundField DataField="imieNazwisko" HeaderText="Imię i Nazwisko" SortExpression="imieNazwisko" />
            <asp:BoundField DataField="czas" HeaderText="Data zamówienia" SortExpression="czas" />
            <asp:BoundField DataField="zaplacono" HeaderText="Zaplacono" SortExpression="zaplacono" />
            <asp:BoundField DataField="wyslano" HeaderText="Wyslano" SortExpression="wyslano" />
            <asp:HyperLinkField DataNavigateUrlFields="nr_zamowienia" DataNavigateUrlFormatString="DetaleZamowienia.aspx?Edycja={0}" DataTextField="nr_zamowienia" HeaderText="Edycja" NavigateUrl="~/DetaleZamowienia.aspx" Text="Edycja" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <hr />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [nr_zamowienia], [kto], uzytkownik.imieNazwisko, [czas], [zaplacono], [wyslano] FROM [obsluga], [uzytkownik] WHERE obsluga.kto=uzytkownik.login"></asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" CellSpacing="1" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="nr_zamowienia" HeaderText="Numer zamówienia" SortExpression="nr_zamowienia" />
            <asp:BoundField DataField="imieNazwisko" HeaderText="Imię i Nazwisko" SortExpression="imieNazwisko" />
            <asp:BoundField DataField="czas" HeaderText="Data zamówienia" SortExpression="czas" />
            <asp:BoundField DataField="zaplacono" HeaderText="Zaplacono" SortExpression="zaplacono" />
            <asp:BoundField DataField="wyslano" HeaderText="Wyslano" SortExpression="wyslano" />
            <asp:HyperLinkField DataNavigateUrlFields="nr_zamowienia" DataNavigateUrlFormatString="DetaleZamowienia.aspx?Edycja={0}" DataTextField="nr_zamowienia" HeaderText="Edycja" NavigateUrl="~/DetaleZamowienia.aspx" Text="Edycja" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

    <br />

    <br />
    <br />

   
</asp:Content>

