<%@ Page Title="Padrón Electoral" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Consulta Padron Electoral</h1>
        <p class="lead">Ingrese la cédula de la persona a buscar en el sistema</p>
        <p>
            <asp:TextBox ID="TextBoxDefault" runat="server"></asp:TextBox>
        </p>
        <p> <asp:Button class="btn btn-primary btn-lg" ID="BUTTON" TEXT= "Consultar" runat="server" onClick="enviarCedula"/> </p>
    </div>

    <div>
        <p>Cédula: 
            <asp:Label ID="LabelCedula" runat="server" Text=""></asp:Label>
        </p>
        <p>Nombre: 
            <asp:Label ID="LabelNombre" runat="server" Text=""></asp:Label>
        </p>
        <p>Apellido 1: 
            <asp:Label ID="LabelAp1" runat="server" Text=""></asp:Label>
        </p>
        <p>Apellido 2: 
            <asp:Label ID="LabelAp2" runat="server" Text=""></asp:Label>
        </p>
        <p>Provincia: 
            <asp:Label ID="LabelProvincia" runat="server" Text=""></asp:Label>
        </p>
        <p>Canton: 
            <asp:Label ID="LabelCanton" runat="server" Text=""></asp:Label>
        </p>
        <p>Distrito: 
            <asp:Label ID="LabelDistrito" runat="server" Text=""></asp:Label>
        </p>
        <p>Sexo: 
            <asp:Label ID="LabelSexo" runat="server" Text=""></asp:Label>
        </p>
        <p>Fecha Caducidad: 
            <asp:Label ID="LabelCaducidad" runat="server" Text=""></asp:Label>
        </p>
        <p># de Junta Receptora de Votos: 
            <asp:Label ID="LabelJunta" runat="server" Text=""></asp:Label>
        </p>
        
    </div>

</asp:Content>
