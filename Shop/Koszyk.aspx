<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Koszyk.aspx.cs" Inherits="Koszyk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Lista wybranych produktów które znajdują się w koszyku: <br />
    <asp:Table ID="TKoszyk" runat="server" GridLines="Both">
    </asp:Table>
    <br />
    <asp:Button ID="ButtonZamowienie" runat="server" Text="Złóż zamówienie" OnClick="ButtonZamowienie_Click" />
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [userID] FROM [uzytkownik] WHERE ([login] = ?)">
        <SelectParameters>
            <asp:SessionParameter Name="login" SessionField="ZALOGOWANY" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <!--
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="userID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="userID" HeaderText="userID" InsertVisible="False" ReadOnly="True" SortExpression="userID" />
        </Columns>
    </asp:GridView>
    -->
    <br />
    <br />
</asp:Content>

