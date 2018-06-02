<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Telefon:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>506-416-071</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Dział techniczny:</span>
            <span><a href="mailto:tech@siatkihusar.pl">tech@siatkihusar.pl</a></span>
        </p>
        <p>
            <span class="label">Biuro:</span>
            <span><a href="mailto:biuro@siatkihusar.pl">biuro@siatkihusar.pl</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Adres:</h3>
        </header>
        <p>
            ul. Jozefa Pilsudskiego 32<br />
            Wroclaw
        </p>
    </section>
</asp:Content>