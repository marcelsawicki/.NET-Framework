<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/StyleSheet.css" rel="stylesheet" />
    <link rel="Shortcut Icon" href="Images/favicon.ico" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="400"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Szukaj" OnClick="Button1_Click1" /><br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Tabela1]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Identyfikator" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Identyfikator" HeaderText="Identyfikator" InsertVisible="False" ReadOnly="True" SortExpression="Identyfikator" />
                <asp:BoundField DataField="Tytuł" HeaderText="Tytuł" SortExpression="Tytuł" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
