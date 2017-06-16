<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Historia1.aspx.cs" Inherits="Historia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;" ForeColor="Red" BackColor="White"></asp:Label>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        Historia zamówień użytkownika!<br />

    Przeglądanie i zarządzanie zamówieniami: 
    <br />
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [nr_zamowienia] FROM [obsluga] GROUP BY [nr_zamowienia]"></asp:SqlDataSource>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <br />
            Numer zamówienia:
            <asp:Label ID="nr_zamowieniaLabel" runat="server" Text='<%# Eval("nr_zamowienia") %>' />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="
SELECT zamowienie.login, zamowienie.czas, zamowienie.produktID, zamowienie.ilosc, produkt.Nazwa, produkt.Cena, obsluga.zaplacono, obsluga.wyslano FROM obsluga, zamowienie, produkt WHERE zamowienie.zamowienieID=obsluga.elementy AND obsluga.nr_zamowienia=? AND produkt.produktID=zamowienie.produktID">
                <SelectParameters>
                    <asp:ControlParameter ControlID="nr_zamowieniaLabel" Name="?" PropertyName="Text" />
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"  ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [zamowienie] WHERE ([login] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="login" SessionField="ZALOGOWANY" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [uzytkownik]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="zamowienieID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="zamowienieID" HeaderText="zamowienieID" InsertVisible="False" ReadOnly="True" SortExpression="zamowienieID" />
                <asp:BoundField DataField="userID" HeaderText="userID" SortExpression="userID" />
                <asp:BoundField DataField="produktID" HeaderText="produktID" SortExpression="produktID" />
                <asp:BoundField DataField="ilosc" HeaderText="ilosc" SortExpression="ilosc" />
                <asp:BoundField DataField="czas" HeaderText="czas" SortExpression="czas" />
                <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
            </Columns>
        </asp:GridView>
        <br />
        <!-- <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="userID" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="userID" HeaderText="userID" InsertVisible="False" ReadOnly="True" SortExpression="userID" />
                <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                <asp:BoundField DataField="haslo" HeaderText="haslo" SortExpression="haslo" />
                <asp:BoundField DataField="imieNazwisko" HeaderText="imieNazwisko" SortExpression="imieNazwisko" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            </Columns>
        </asp:GridView> -->
        <br />
        <br />


</asp:Content>

