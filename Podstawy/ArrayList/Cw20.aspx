<%@ Page Language="C#" Inherits="Klasa20" src="Cw20.aspx.cs" %>
<html>
<body>
<form id="F1" runat="server">

	<H2>Kolekcja: ArrayList</H2>
	<asp:Label id="Lab" runat="server" Text="<h3>Wybra³eœ: </h3>" />
	<asp:ListBox id="ListB1" runat="server" Font-Size=15 ForeColor=#ff66ff Rows="4" SelectionMode="Single">
	</asp:ListBox>
	&nbsp;
	<asp:ListBox id="ListB2" runat="server" Font-Size=15 ForeColor=Blue Rows="4" SelectionMode="Single">
	</asp:ListBox>
	<br />
	<asp:Button id="But1" Text="Wybierz z lewego okna" onClick="WybierzL" runat="server" />
	&nbsp; &nbsp; &nbsp; &nbsp; 
	<asp:Button id="But2" Text="Wybierz z prawego okna" onClick="WybierzP" runat="server" />
	<asp:Label id="Lab2" runat="server" Text="" />
</form>
</body>
</html>