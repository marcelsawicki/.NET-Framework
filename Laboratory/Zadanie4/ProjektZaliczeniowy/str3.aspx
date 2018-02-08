<%@ Page Title="Warunki sprzedaży" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="str3.aspx.cs" Inherits="str3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Zapraszamy do dokonania zakupu.</h2>
            </hgroup>
            <p>
                Firma prowadzi sprzedaż i dystrubucje plandek, siatek oraz akcesorów do rusztowań. <br />
                Zapraszamy do zapoznania się z naszą bogatą ofertą. <br />
                Zamawiając wiecej niż dwa produkty transport gratis.<br />
            </p>
        </div>
    </section>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Age], [Name] FROM [Friends]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
     </asp:GridView>
     <br />
     <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" GridLines="Both">
         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
         <ItemStyle BackColor="White" ForeColor="#330099" />
         <ItemTemplate>
             Age:
             <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />
             <br />
             Name:
             <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
             <br />
             <br />
         </ItemTemplate>
         <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
     </asp:DataList>
     <br />
     <asp:FormView ID="FormView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource1" GridLines="Both">
         <EditItemTemplate>
             Age:
             <asp:TextBox ID="AgeTextBox" runat="server" Text='<%# Bind("Age") %>' />
             <br />
             Name:
             <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
             <br />
             <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
             &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
         </EditItemTemplate>
         <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
         <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
         <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
         <InsertItemTemplate>
             Age:
             <asp:TextBox ID="AgeTextBox" runat="server" Text='<%# Bind("Age") %>' />
             <br />
             Name:
             <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
             <br />
             <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
             &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
         </InsertItemTemplate>
         <ItemTemplate>
             Age:
             <asp:Label ID="AgeLabel" runat="server" Text='<%# Bind("Age") %>' />
             <br />
             Name:
             <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
             <br />
         </ItemTemplate>
         <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
         <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
     </asp:FormView>
     <br />
     <br />
     <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
     </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

