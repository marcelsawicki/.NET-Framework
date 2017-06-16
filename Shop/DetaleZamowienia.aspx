<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="DetaleZamowienia.aspx.cs" Inherits="Pomoc"%>

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
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [nr_zamowienia], [czas], [kto] FROM [obsluga] WHERE ([nr_zamowienia] = ?)">
        <SelectParameters>
            <asp:QueryStringParameter Name="nr_zamowienia" QueryStringField="Edycja" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            Numer zamówienia:
            <asp:Label ID="nr_zamowieniaLabel" runat="server" Text='<%# Eval("nr_zamowienia") %>' />
            <br />
            Data zamówienia:
            <asp:Label ID="czasLabel" runat="server" Text='<%# Eval("czas") %>' />
            <br />
            Zamawiający (login):
            <asp:Label ID="ktoLabel" runat="server" Text='<%# Eval("kto") %>' />
            <br />
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [imieNazwisko] FROM [uzytkownik] WHERE ([login] = ?)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ktoLabel" Name="login" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource3">
                <ItemTemplate>
                    Imię i Nazwisko:&nbsp;
                    <asp:Label ID="imieNazwiskoLabel" runat="server" Text='<%# Eval("imieNazwisko") %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT obsluga.Identyfikator, obsluga.nr_zamowienia, obsluga.kto, obsluga.czas, obsluga.elementy, obsluga.zaplacono, obsluga.wyslano, produkt.nazwa, produkt.Cena FROM [obsluga], [produkt] WHERE ([nr_zamowienia] = ?) AND produkt.produktID=obsluga.elementy">
        <SelectParameters>
            <asp:QueryStringParameter Name="nr_zamowienia" QueryStringField="Edycja" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="elementy" HeaderText="ID Produktu" SortExpression="elementy" />
            <asp:BoundField DataField="nazwa" HeaderText="Nazwa produktu" SortExpression="nazwa" />
            <asp:BoundField DataField="Cena" DataFormatString="{0} zł" HeaderText="Cena" SortExpression="Cena" />
            <asp:BoundField DataField="zaplacono" HeaderText="Zaplacono" SortExpression="zaplacono" />
            <asp:BoundField DataField="wyslano" HeaderText="Wyslano" SortExpression="wyslano" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

    <br />
    Łączna kwota zamówienia:
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT SUM(produkt.Cena) FROM [obsluga], [produkt] WHERE ([nr_zamowienia] = ?) AND produkt.produktID=obsluga.elementy">
        <SelectParameters>
            <asp:QueryStringParameter Name="?" QueryStringField="Edycja" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataSource4">
        <ItemTemplate>
            &nbsp;<asp:Label ID="Expr1000Label" runat="server" Text='<%# Eval("Expr1000") %>' />
            &nbsp;zł<br />
<br />
        </ItemTemplate>
    </asp:DataList>

    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Obsluga.aspx">Powrót do obsługi zamówień.</asp:LinkButton>

    <br />
    <br />

   
</asp:Content>

