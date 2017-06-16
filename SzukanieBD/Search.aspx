<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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
                <img src="Images/cyklotronix_logo_subs.png" /><br />
                Szukana fraza :
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Powrót" />
                <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Tabela1] WHERE ([Tytuł] LIKE '%' + ? + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label1" DefaultValue="*" Name="Tytuł2" PropertyName="Text" Type="String" />
            </SelectParameters>
                </asp:SqlDataSource>
    
                <br />
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
