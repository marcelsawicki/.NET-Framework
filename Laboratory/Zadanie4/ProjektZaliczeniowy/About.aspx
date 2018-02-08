<%@ Page Title="O firmie Siatki Husar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Jesteśmy na rynku od roku 2009.</h2>
    </hgroup>

    <article>
        <p>        
            Siedziba firmy znajduje się na terenie we Wrocławiu.
        </p>

        <p>        
            Prowadzimy sprzedaż hurtową oraz detaliczną.
        </p>

        <p>        
            Akceptujemy płatność kartą kredytową.
        </p>
    </article>

    <aside>
        <h3>Zapraszmy!</h3>
        <p>        
            W celu zapoznania się z naszą ofertą proszę kliknąc zakładkę "Oferta".
        </p>
        <ul>
            <li><a runat="server" href="~/oferta.aspx">Oferta</a></li>
            <li><a runat="server" href="~/Contact">Kontakt</a></li>
        </ul>
    </aside>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
</asp:Content>