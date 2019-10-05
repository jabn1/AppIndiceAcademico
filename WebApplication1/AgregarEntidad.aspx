<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarEntidad.aspx.cs" Inherits="WebApplication1.AgregarEntidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="div1" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverAgr" runat="server" Text="Volver" OnClick="btVolverAgr_Click" />
        </div>
        <h3>Agregar: </h3>
        <p></p>
        <h4>Elija que entidad desea agregar:</h4>
        <p></p>
            <asp:Button ID="btnAgregarEst" runat="server" Text="Agregar Estudiante" OnClick="btnAgregarEst_Click" Width="200px" />
            <p></p>
            <asp:Button ID="btnAgregarProf" runat="server" Text="Agregar Profesor" OnClick="btnAgregarProf_Click" Width="200px"/>
        <p></p>
            <asp:Button ID="btnAgregarAsig" runat="server" Text="Agregar Asignatura" OnClick="btnAgregarAsig_Click" Width="200px"/>
    </div>

    <div id="divEst" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverEst" runat="server" Text="Volver" OnClick="btnVolverEst_Click" />
        </div>
        <h3>Agregar: </h3>
        <h4>Estudiante</h4>
        <p></p>        
        <h4>Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="nombreEst" runat="server"></asp:TextBox></h4>
        
        <h4>Contraseña: <asp:TextBox ID="contraEst" runat="server"></asp:TextBox></h4>
        <h4>Carrera:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="carreraEst" runat="server"></asp:TextBox></h4>
       <p></p>
        
    </div>
    
    <div id="divProf" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverProf" runat="server" Text="Volver" OnClick="btnVolverProf_Click" />
        </div>
        <h3>Agregar: </h3>
        <h4>Profesor</h4>
        <p></p>
        <h4>Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="nombreProf" runat="server"></asp:TextBox></h4>
        <h4>Contraseña: <asp:TextBox ID="contraProf" runat="server"></asp:TextBox></h4>
    </div>

    <div id="divAsig" runat="server" visible="false">
        <div style="text-align: right; " class="nav-justified">
        <asp:Button ID="btnVolverAsig" runat="server" Text="Volver" OnClick="btnVolverAsig_Click" />
        </div>
        <h3>Agregar: </h3>
        <h4>Asignatura</h4>
        <p></p>
        <h4>Clave:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="claveAsig" runat="server"></asp:TextBox></h4>
        <h4>Nombre:&nbsp;&nbsp; <asp:TextBox ID="nombreAsig" runat="server"></asp:TextBox></h4>
        <h4>Creditos:&nbsp; <asp:TextBox ID="creditosAsig" runat="server"></asp:TextBox></h4>
    </div>

  <div id="divbtnAgregar" runat="server" visible="true">
      <p></p>
<asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>

    <div id="Seguro" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        </div>
        <h3>
            <asp:Label ID="lblSeguroEntidad" runat="server" Text=""></asp:Label>
        </h3>
   <p></p>
      <p></p>  
        <h4>
        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        </h4> 
        <h4>
        <asp:Label ID="lblContraseña" runat="server" Text=""></asp:Label>

        </h4>
        <h4>
        <asp:Label ID="lblCarrera" runat="server" Text=""></asp:Label>

        </h4>
        <h4>
        <asp:Label ID="lblCreditos" runat="server" Text=""></asp:Label>
        </h4>


        <p></p>
<asp:Button ID="btnSeguroAgregar" runat="server" Text="Agregar" OnClick="btnSeguroAgregar_Click" />
        <p></p>
        
        
        <asp:Button ID="btnVolverEditar" runat="server" Text="Volver a editar" OnClick="btnVolverEditar_Click" />
        <p></p>
        <h3>
        <asp:Label ID="lblEntidadAgregada" runat="server" Text=""></asp:Label>
        </h3>
        <p></p>
        <asp:Button ID="btnVolverMenuPrincipal" runat="server" Text="Volver al menu principal" Visible="false" />
    </div>

</asp:Content>
