<%@ Page Title="Padrón Electoral" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Consulta Padron Electoral</h1>
        <p class="lead">Ingrese la cédula de la persona a buscar en el sistema</p>
        <p><input type="text" name ="cedula"></p>
        <p><a class="btn btn-primary btn-lg">Buscar &raquo;</a></p>
    </div>

    <div>
        <p>Cédula: </p>
        <p>CODELEC: </p>
        <p>Sexo: </p>
        <p>Fecha Caducidad: </p>
        <p># de Junta Receptora de Votos: </p>
        <p>Nombre: </p>
        <p>Apellido 1: </p>
        <p>Apellido 2: </p>
    </div>

</asp:Content>
