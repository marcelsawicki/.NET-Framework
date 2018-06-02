<%@ Page Title="Galeria" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="str4.aspx.cs" Inherits="str4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Zapraszamy do obejrzenia zdjęć naszych produktów.</h2>
            </hgroup>
            <p>
                Firma prowadzi sprzedaż i dystrubucje plandek, siatek oraz akcesorów do rusztowań. <br />
                Zapraszamy do zapoznania się z naszą bogatą ofertą. <br />
                Zamawiając wiecej niż dwa produkty transport gratis.<br />
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

