<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PruebaApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Edición Padron Electoral</h1>
        <p class="lead">Ingrese la cédula de la persona a buscar en el sistema</p>
        <p><input type="text" name ="cedula"></p>
        <p><a class="btn btn-primary btn-lg">Buscar &raquo;</a></p>
    </div>

    <div>
        <p>CODELEC: </p>
        <p>Sexo: 
            <select name="Genero">
                <option>Masculino</option>
                <option>Femenino</option>
            </select>
        </p>
        <p>Fecha Caducidad: <input type="date"></p>
        <p># de Junta Receptora de Votos: 
            <select name="Junta">
                <option>1</option>
                <option>2</option>
                <option>3</option>
            </select>
        </p>
        <p>Nombre: <input type="text" name ="nombre"></p>
        <p>Apellido 1: <input type="text" name ="ape1"></p>
        <p>Apellido 2: <input type="text" name ="ape2"></p>
    </div>
</asp:Content>
