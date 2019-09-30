<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEntidad.aspx.cs" Inherits="WebApplication1.AgregarEntidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="div1" runat="server" visible="false">
        <h3>Agregar: </h3>
        <p></p>
        <h4>Que desea agregar?</h4>
            <asp:Button ID="Button1" runat="server" Text="Agregar Estudiante" OnClick="Button1_Click" Width="200px" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Agregar Profesor" OnClick="Button2_Click" Width="200px"/>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Agregar Asignatura" OnClick="Button3_Click" Width="200px"/>
    </div>

    <div id="divEst" runat="server" visible="false">
        <h3>Agregar: </h3>
        <h4>Estudiante</h4>
        <p></p>
        <p>Id: <asp:TextBox ID="idEst" runat="server"></asp:TextBox></p>
        <p>Nombre: <asp:TextBox ID="nombreEst" runat="server"></asp:TextBox></p>
        <p>Carrera: <asp:TextBox ID="carreraEst" runat="server"></asp:TextBox></p>
        <p>Contraseña: <asp:TextBox ID="contraEst" runat="server"></asp:TextBox></p>
        <asp:Button ID="guardarEst" runat="server" Text="Guardar" OnClick="guardarEst_Click" />
    </div>

    <div id="divProf" runat="server" visible="false">
        <h3>Agregar: </h3>
        <h4>Profesor</h4>
        <p></p>
        <p>Id: <asp:TextBox ID="idProf" runat="server"></asp:TextBox></p>
        <p>Nombre: <asp:TextBox ID="nombreProf" runat="server"></asp:TextBox></p>
        <p>Contraseña: <asp:TextBox ID="contraProf" runat="server"></asp:TextBox></p>
        <asp:Button ID="guardarProf" runat="server" Text="Guardar" OnClick="guardarProf_Click" />
    </div>

    <div id="divAsig" runat="server" visible="false">
        <h3>Agregar: </h3>
        <h4>Asignatura</h4>
        <p></p>
        <p>Clave: <asp:TextBox ID="claveAsig" runat="server"></asp:TextBox></p>
        <p>Nombre: <asp:TextBox ID="nombreAsig" runat="server"></asp:TextBox></p>
        <p>Creditos: <asp:TextBox ID="creditosAsig" runat="server"></asp:TextBox></p>
        <asp:Button ID="guardarAsig" runat="server" Text="Guardar" OnClick="guardarAsig_Click" />
    </div>


</asp:Content>
