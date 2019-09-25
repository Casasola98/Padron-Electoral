<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PruebaApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Edición Padron Electoral</h1>
        <p class="lead">Ingrese la cédula de la persona a buscar en el sistema</p>
        <p><asp:TextBox ID="TextBoxAbout" runat="server"></asp:TextBox></p>
        <p><asp:Button class="btn btn-primary btn-lg" ID="BUTTONBuscar" runat="server" Text="Consultar" onClick="enviarDatos"/></p>
    </div>

    <div>
        <p>Nombre: <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
        </p>
        <p>Apellido 1: <asp:TextBox ID="TextBoxAp1" runat="server"></asp:TextBox>
        </p>
        <p>Apellido 2: <asp:TextBox ID="TextBoxAp2" runat="server"></asp:TextBox>
        </p>
        <p>Provincia:&nbsp;
            <asp:DropDownList ID="DropDownListProvincia" runat="server"  OnSelectedIndexChanged="ActualizarCantones" AutoPostBack="True" ViewStateMode="Enabled">
            </asp:DropDownList>
        </p>
        <p>Canton:&nbsp;
            <asp:DropDownList ID="DropDownListCanton" runat="server" OnSelectedIndexChanged="ActualizarDistritos" AutoPostBack="True" ViewStateMode="Enabled">
            </asp:DropDownList>
        </p>
        <p>Distrito:&nbsp;
            <asp:DropDownList ID="DropDownListDistrito" runat="server" AutoPostBack="True" ViewStateMode="Enabled">
            </asp:DropDownList>
        </p>
        <p>Sexo:&nbsp;
            <asp:DropDownList ID="DropDownListSexo" runat="server">
            </asp:DropDownList>
        </p>
        <p>Fecha Caducidad: 
            <asp:TextBox ID="TextBoxCaducidad" runat="server"></asp:TextBox>
        </p>
        <p># de Junta Receptora de Votos:&nbsp;
            <asp:DropDownList ID="DropDownListJunta" runat="server">
            </asp:DropDownList>
        </p>
        <p><asp:Button class="btn btn-primary btn-lg" ID="BUTTONGuardar" runat="server" Text="Guardar Cambios" onClick="EditarPersona"/></p>

    </div>
</asp:Content>
