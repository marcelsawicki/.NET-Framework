<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Historia2.aspx.cs" Inherits="Pomoc"%>

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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [nr_zamowienia] FROM [obsluga] GROUP BY [nr_zamowienia]"></asp:SqlDataSource>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <br />
            Numer zamówienia:
            <asp:Label ID="nr_zamowieniaLabel" runat="server" Text='<%# Eval("nr_zamowienia") %>' />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="
SELECT zamowienie.login, zamowienie.czas, zamowienie.produktID, zamowienie.ilosc, produkt.Nazwa, produkt.Cena, obsluga.zaplacono, obsluga.wyslano FROM obsluga, zamowienie, produkt WHERE zamowienie.zamowienieID=obsluga.elementy AND obsluga.nr_zamowienia=? AND produkt.produktID=zamowienie.produktID AND zamowienie.login=?">
                <SelectParameters>
                    <asp:ControlParameter ControlID="nr_zamowieniaLabel" Name="?" PropertyName="Text" />
                    <asp:SessionParameter Name="?" SessionField="ZALOGOWANY" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                <Columns>
                    <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                    <asp:BoundField DataField="czas" HeaderText="czas" SortExpression="czas" />
                    <asp:BoundField DataField="produktID" HeaderText="produktID" SortExpression="produktID" />
                    <asp:BoundField DataField="ilosc" HeaderText="ilosc" SortExpression="ilosc" />
                    <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                    <asp:BoundField DataField="Cena" HeaderText="Cena" SortExpression="Cena" />
                    <asp:BoundField DataField="zaplacono" HeaderText="zaplacono" SortExpression="zaplacono" />
                    <asp:BoundField DataField="wyslano" HeaderText="wyslano" SortExpression="wyslano" />
                </Columns>
            </asp:GridView>
<br />
            <br />
        </ItemTemplate>
    </asp:DataList>

    <br />
    <br />

   
</asp:Content>

