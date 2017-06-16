<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:Label ID="LabelAdmin" runat="server" Text="Nie jesteś zalogowany."></asp:Label>

    <asp:HyperLink ID="HyperLinkAdmin" Visible="False" runat="server" NavigateUrl="~/Administrator.aspx">Panel Administratora.</asp:HyperLink>

    <hr />

    <!-- <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Yellow"></asp:Label> -->
    <!-- <asp:Label ID="TBLogin" runat="server" Text="TBLogin - tu komunikat"></asp:Label>
    <asp:Label ID="TBPassword" runat="server" Text="TBPassword"></asp:Label>
    <br />

    <asp:Label ID="LZalogowanyJako" runat="server" Text="Label"></asp:Label>
    <br /> -->


    <asp:AccessDataSource ID="ADSUzytkownik" runat="server" DataFile="~/App_Data/sklep.mdb"
        SelectCommand="SELECT userID, login, haslo, imieNazwisko, email FROM uzytkownik WHERE (login = ?) AND (haslo = ?)" OnLoad="Page_Load">
        <SelectParameters>
            <asp:FormParameter DefaultValue="&quot;&quot;" FormField="ctl00$TBLogin" Name="login" Type="String" />
            <asp:FormParameter DefaultValue="&quot;&quot;" FormField="ctl00$TBPassword" Name="haslo" Type="String" />
        </SelectParameters>
    </asp:AccessDataSource>

    <asp:FormView ID="FVUzytkownik" runat="server" CellPadding="4" DataKeyNames="userID"
        DataSourceID="ADSUzytkownik" OnDataBound="FVUzytkownik_DataBound">
        <EditItemTemplate>
            Twoj userID:
            <asp:Label ID="userIDLabel1" runat="server" Text='<%# Eval("userID") %>' />
            <br />
            Login:
            <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>'></asp:TextBox>
            <br />
            Haslo: ukryte
            <asp:TextBox ID="hasloTextBox" runat="server" Text='<%# Bind("haslo") %>' Visible="False"></asp:TextBox>
            <br />
            Imie i Nazwisko:
            <asp:TextBox ID="imieNazwiskoTextBox" runat="server" Text='<%# Bind("imieNazwisko") %>' />
            <br />
            E-mail:
            <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />

        </EditItemTemplate>
        <InsertItemTemplate>
            login:
            <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>'></asp:TextBox>
            <br />
            haslo:
            <asp:TextBox ID="hasloTextBox" runat="server" Text='<%# Bind("haslo") %>'></asp:TextBox>
            <br />
            imieNazwisko:
            <asp:TextBox ID="imieNazwiskoTextBox" runat="server" Text='<%# Bind("imieNazwisko") %>' />
            <br />
            email:
            <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <br />
            <!-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("userID", "Koszyk.aspx?action=zamow&userID={0}") %>' Text="Zamow!"></asp:HyperLink> -->
            <br />
        </ItemTemplate>
    </asp:FormView>

        <br />
        <br />
        <br />
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
</asp:Content>

