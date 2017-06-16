<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="Rejestracja.aspx.cs" Inherits="Rejestracja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-styleR1 {
            width: 377px;
        }
        .auto-styleR2 {
            width: 313px;
        }
        .auto-styleR3 {
            height: 24px;
        }
    .auto-style6 {
        width: 134px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <a href="Historia.aspx">
    <asp:Label ID="LabelLogin" runat="server" Text="&nbsp; Nie zalogowany &nbsp;"></asp:Label>
    </a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    Rejestracja nowego użytkownika:<br />
    <br />

    <table style="width:89%;" border="1">


        <tr>

            <td class="auto-style6">login:</td>
            <td class="auto-styleR2">
                <asp:TextBox ID="TextBox1" runat="server" Width="325px"></asp:TextBox>
                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Pole wymagane!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="auto-style6">hasło:</td>
            <td class="auto-styleR2">
                <asp:TextBox ID="TextBox2" runat="server" Width="325px" TextMode="Password"></asp:TextBox>
                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Pole wymagane!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
            </td>

        </tr>
                <tr>
            <td class="auto-style6">imie i nazwisko:</td>
            <td class="auto-styleR2">
                <asp:TextBox ID="TextBox3" runat="server" Width="325px"></asp:TextBox>
                
            </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Pole wymagane!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
                    </td>

        </tr>
        <tr>
            <td class="auto-style6">email:</td>
            <td class="auto-styleR2">
                <asp:TextBox ID="TextBox4" runat="server" Width="325px"></asp:TextBox>
                
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Pole wymagane!" ForeColor="Red" ValidationGroup="Rejestracja"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>

    <br />
    <br />

    <br />
    <asp:Button ID="ButtonREJESTRACJA2" runat="server" Text="Zarejestruj nowego użytkownika." OnClick="ButtonREJESTRACJA2_Click" ValidationGroup="Rejestracja" />
    <br />
    <br />

</asp:Content>

