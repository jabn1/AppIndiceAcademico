<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCal.aspx.cs" Inherits="WebApplication1.AgregarCal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="wcElegirAsig" runat="server" visible="false" >
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" /></div>
        <h3>Agregar Calificacion</h3>
        <h4>Elegir la asignatura:</h4>        
        <p></p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
        <p></p>
        <asp:Button ID="btElegirAsig" runat="server" Text="Elegir Asignatura" OnClick="btElegirAsig_Click" Width="200px" />
        <p></p>
    <asp:Button ID="btCancelarEA" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>
<div id="wcElegirEst" runat="server" visible="false">
        <h3>Agregar Calificacion</h3>
        <asp:Label ID="lblAsig" runat="server"></asp:Label>
        <h4>Elegir el estudiante:</h4> 
        <asp:RadioButtonList ID="RadioButtonList2" runat="server"></asp:RadioButtonList> <p></p>
        <asp:Button ID="btElegirEst" runat="server" Text="Elegir Estudiante" OnClick="btElegirEst_Click" Width="200px" /> <p></p>
    <asp:Button ID="btRetAsig" runat="server" Text="Modificar asignatura" OnClick="btRetAsig_Click" Width="200px" /> <p></p>
    <asp:Button ID="btCancelarEE" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>

<div id="wcCalificar" runat="server" visible="false">
        <h3>Agregar Calificacion</h3>

        <asp:Label ID="lblAsig2" runat="server"></asp:Label> <p></p>
        <asp:Label ID="lblEst" runat="server" ></asp:Label> <p></p>
        <asp:Label ID="Label1" runat="server" Text="Valor de calificacion:"></asp:Label>
        <asp:TextBox ID="tbCal" runat="server" OnTextChanged="tbCal_TextChanged"  ></asp:TextBox>
        <asp:Label ID="lblWarn" runat="server" ></asp:Label>
        <p></p>
        <asp:Button ID="btProcesar" runat="server" Text="Procesar" OnClick="btProcesar_Click" Width="200px" /> <p></p>
        <asp:Button ID="btRetEst" runat="server" Text="Modificar estudiante" OnClick="btRetEst_Click" Width="200px" /> <p></p>
    <asp:Button ID="btCancelarCal" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="200px" /> <p></p>
    </div>

<div id="wcConfirmar" runat="server" visible="false">
        <h3>Agregar Calificacion</h3>

        <asp:Label ID="lblAsig3" runat="server"></asp:Label> <p></p>
        <asp:Label ID="lblEst2" runat="server" ></asp:Label> <p></p>
        <asp:Label ID="lblValor" runat="server"></asp:Label>
    <p></p>
        <asp:Button ID="btConfirmar1" runat="server" Text="Confirmar y volver al portal" OnClick="btConfirmar1_Click" Width="250px" />
    <p></p>
        <asp:Button ID="btConfirmar2" runat="server" Text="Confirmar y agregar otra calificacion" OnClick="btConfirmar2_Click" Width="250px" />
    <p></p>
        <asp:Button ID="btRetCal" runat="server" Text="Modificar valor de calificacion" OnClick="btRetCal_Click" Width="250px" />
    <p></p>
        <asp:Button ID="btCancelar" runat="server" Text="Cancelar" OnClick="btCancelar_Click" Width="250px" />
    <p></p>
    </div>

</asp:Content>
