<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" Inherits="Administrator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }
        .auto-style2 {
            width: 132px;
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
            width: 307px;
        }
        .auto-style5 {
            width: 307px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Panel administracyjny. <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [uzytkownik] WHERE [userID] = ?" InsertCommand="INSERT INTO [uzytkownik] ([userID], [login], [haslo], [imieNazwisko], [email]) VALUES (?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [uzytkownik]" UpdateCommand="UPDATE [uzytkownik] SET [login] = ?, [haslo] = ?, [imieNazwisko] = ?, [email] = ? WHERE [userID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="userID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="userID" Type="Int32" />
            <asp:Parameter Name="login" Type="String" />
            <asp:Parameter Name="haslo" Type="String" />
            <asp:Parameter Name="imieNazwisko" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="login" Type="String" />
            <asp:Parameter Name="haslo" Type="String" />
            <asp:Parameter Name="imieNazwisko" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="userID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Zarejestrowani użytkownicy systemu:<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="userID" DataSourceID="SqlDataSource1" AllowSorting="True" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="userID" HeaderText="userID" InsertVisible="False" ReadOnly="True" SortExpression="userID" />
            <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
            <asp:BoundField DataField="haslo" HeaderText="haslo" SortExpression="haslo" DataFormatString="*********" />
            <asp:BoundField DataField="imieNazwisko" HeaderText="imieNazwisko" SortExpression="imieNazwisko" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <hr />

    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Obsluga.aspx">Obsługa i lista złożonych zamówień.</asp:HyperLink>
    <br />
    <br />
    <hr />

    <br />
    Lista produktów dostępnych w ofercie sklepu:<br />
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [produkt] WHERE [ProduktID] = ?" InsertCommand="INSERT INTO [produkt] ([ProduktID], [Nazwa], [Opis], [Foto], [Cena], [kategoriaID]) VALUES (?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [produkt]" UpdateCommand="UPDATE [produkt] SET [Nazwa] = ?, [Opis] = ?, [Foto] = ?, [Cena] = ?, [kategoriaID] = ? WHERE [ProduktID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="original_ProduktID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProduktID" Type="Int32" />
            <asp:Parameter Name="Nazwa" Type="String" />
            <asp:Parameter Name="Opis" Type="String" />
            <asp:Parameter Name="Foto" Type="String" />
            <asp:Parameter Name="Cena" Type="Decimal" />
            <asp:Parameter Name="kategoriaID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nazwa" Type="String" />
            <asp:Parameter Name="Opis" Type="String" />
            <asp:Parameter Name="Foto" Type="String" />
            <asp:Parameter Name="Cena" Type="Decimal" />
            <asp:Parameter Name="kategoriaID" Type="Int32" />
            <asp:Parameter Name="original_ProduktID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ProduktID" DataSourceID="SqlDataSource3" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="ProduktID" HeaderText="ProduktID" InsertVisible="False" ReadOnly="True" SortExpression="ProduktID" />
            <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
            <asp:BoundField DataField="Opis" HeaderText="Opis" SortExpression="Opis" />
            <asp:BoundField DataField="Foto" HeaderText="Foto" SortExpression="Foto" />
            <asp:BoundField DataField="Cena" HeaderText="Cena" SortExpression="Cena" />
            <asp:BoundField DataField="kategoriaID" HeaderText="kategoriaID" SortExpression="kategoriaID" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <br />
    <hr />

    <br />
    Dodawanie nowego produktu do oferty sklepu:<br />
    <br />
    <table style="width:100%; height: 77px;" border="1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Nazwa:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox2" runat="server" Width="291px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Opis:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox3" runat="server" Width="291px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="auto-style1">Zdjęcie:</td>
            <td class="auto-style5">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Wgraj zdjęcie do systemu." />
                podaj ścieżkę do zdjęcia stosując format: images/nazwapliku.jpg
                <asp:TextBox ID="TextBox4" runat="server" Width="291px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="auto-style1">Cena:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox5" runat="server" Width="291px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td class="auto-style1">Kategoria ID:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="236px">
                    <asp:ListItem Value="3">Plandeki (3)</asp:ListItem>
                    <asp:ListItem Value="4">Folie (4)</asp:ListItem>
                    <asp:ListItem Value="7">Siatki (7)</asp:ListItem>
                    <asp:ListItem Value="8">Haki (8)</asp:ListItem>
                    <asp:ListItem Value="12">Ogrodzenia (12)</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>
    </table>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Dodaj nowy produkt." OnClick="Button2_Click" />
    <br />
    <br />
</asp:Content>

