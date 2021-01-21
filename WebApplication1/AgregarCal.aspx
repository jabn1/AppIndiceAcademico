<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="AgregarCal.aspx.cs" Inherits="WebApplication1.AgregarCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="wcElegirAsig" runat="server" visible="false" >


        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" /></div>
        <h3>Agregar Calificacion</h3>
        <h4>Elegir la asignatura:&nbsp; <asp:Label ID="LblElegirAsig" runat="server" Text=""></asp:Label>       
        </h4>        
        <p></p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"></asp:RadioButtonList>
        <p></p>
        <asp:Button ID="btElegirAsig" runat="server" Text="Elegir Asignatura" OnClick="btElegirAsig_Click" Width="200px" />
        <p></p>
    <asp:Button ID="btCancelarEA" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>
<div id="wcElegirEst" runat="server" visible="false">
        <h3>Agregar Calificacion</h3>
        <asp:Label ID="lblAsig" runat="server"></asp:Label>
        <h4>Elegir el estudiante:&nbsp; <asp:Label ID="LblElegirEst" runat="server" Text=""></asp:Label>
        </h4> 
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" ></asp:RadioButtonList> <p></p>
        <asp:Button ID="btElegirEst" runat="server" Text="Elegir Estudiante" OnClick="btElegirEst_Click" Width="200px" /> <p></p>
    <asp:Button ID="btRetAsig" runat="server" Text="Cambiar asignatura" OnClick="btRetAsig_Click" Width="200px" /> <p></p>
    <asp:Button ID="btCancelarEE" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>

<div id="wcCalificar" runat="server" visible="false">
        <h3>Agregar Calificacion</h3>

        <asp:Label ID="lblAsig2" runat="server"></asp:Label> <p></p>
        <asp:Label ID="lblEst" runat="server" ></asp:Label> <p></p>
        <asp:Label ID="Label1" runat="server" Text="Calificacion:"></asp:Label>
        <asp:TextBox ID="tbCal" runat="server" OnTextChanged="tbCal_TextChanged"  ></asp:TextBox>
        <asp:Label ID="lblWarn" runat="server" ForeColor="Red" ></asp:Label>
        <p></p>
        <asp:Button ID="btProcesar" runat="server" Text="Procesar" OnClick="btProcesar_Click" Width="200px" /> <p></p>
        <asp:Button ID="btRetEst" runat="server" Text="Cambiar estudiante" OnClick="btRetEst_Click" Width="200px" /> <p></p>
    <asp:Button ID="btCancelarCal" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>

<div id="wcConfirmar" runat="server" visible="false">
        <h3>¿Desea agregar la siguiente calificacion?</h3>

        <asp:Label ID="lblAsig3" runat="server"></asp:Label> <p></p>
        <asp:Label ID="lblEst2" runat="server" ></asp:Label> <p></p>
        <asp:Label ID="lblValor" runat="server"></asp:Label>
    <div id="wcAgregar" runat="server" visible="true">
    <p></p>
    <asp:Button ID="BtAgregar" runat="server" Text="Agregar Calificacion" OnClick="BtAgregar_Click" Width="250px"/>     
    <p></p>
        <asp:Button ID="btRetCal" runat="server" Text="Cambiar valor de calificacion" OnClick="btRetCal_Click" Width="250px" />
    <p></p>
        <asp:Button ID="btCancelar" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="250px" />
    <p></p>
    </div>
    <p></p>
    <div id="subWcFinal" runat="server" visible="false">
        <p></p>
        <h3>La calificacion se agrego exitosamente.</h3>
    <p></p>
        <asp:Button ID="btConfirmar1" runat="server" Text="Volver al portal" OnClick="btConfirmar1_Click" Width="250px" />
    <p></p>
        <asp:Button ID="btConfirmar2" runat="server" Text="Agregar otra calificacion" OnClick="btConfirmar2_Click" Width="250px" />
   </div>

    </div>

</asp:Content>
