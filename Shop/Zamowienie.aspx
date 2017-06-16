<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Zamowienie.aspx.cs" Inherits="Zamowienie" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [userID], [login] FROM [uzytkownik] WHERE ([login] = ?)">
    <SelectParameters>
        <asp:SessionParameter Name="login" SessionField="ZALOGOWANY" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />

    <asp:FormView ID="FormView1" runat="server" DataKeyNames="userID" DataSourceID="SqlDataSource2">
        <EditItemTemplate>
            userID:
            <asp:Label ID="userIDLabel1" runat="server" Text='<%# Eval("userID") %>' />
            <br />
            login:
            <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            login:
            <asp:TextBox ID="loginTextBox" runat="server" Text='<%# Bind("login") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <!--
            userID:
            <asp:Label ID="userIDLabel" runat="server" Text='<%# Eval("userID") %>' />
            <br />
            login:
            <asp:Label ID="loginLabel" runat="server" Text='<%# Bind("login") %>' />
            <br />
            -->
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("userID", "Koszyk.aspx?action=zamow&userID={0}") %>' Text="Potwierdzam zamowienie!"></asp:HyperLink>
            <br />
        </ItemTemplate>
    </asp:FormView>

<hr />
    <br />

    
</asp:Content>

