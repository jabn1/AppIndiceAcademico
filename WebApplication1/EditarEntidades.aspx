<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEntidades.aspx.cs" Inherits="WebApplication1.EditarEntidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="wcEditarEntidad" runat="server" visible="true" >
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" />
        </div>
        <h3>Editar entidades</h3>
    <p></p>
        <h4>Elegir la entidad a editar:</h4>        

        <asp:RadioButtonList ID="radbtnEntidades" runat="server" OnSelectedIndexChanged="radbtnEntidades_SelectedIndexChanged"></asp:RadioButtonList>
    <p></p>
    <div>
        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" Width="114px" /> 
        <asp:Label ID="lblWarn" runat="server" style="color: #FF0000" Text="Seleccione una entidad" Visible="False"></asp:Label>
    </div>

</div>

<div id="estudiante" runat="server" visible="false">    
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverEstudiante" runat="server" Text="Volver" OnClick="btnVolverEstudiante_Click" />
    </div>
        <h3>Editar estudiante</h3>
    <h4>Elegir estudiante a editar:</h4>
        <asp:RadioButtonList ID="radbtnEstudiantes" runat="server" OnSelectedIndexChanged="radbtnEntidades_SelectedIndexChanged"></asp:RadioButtonList>

    <p></p>
    <asp:Button ID="btnEditarEstudiante" runat="server" Text="Editar" OnClick="btnEditarEstudiante_Click" Width="96px" />
      
        <asp:Label ID="lblWarnEst" runat="server" style="color: #FF0000" Text="Seleccione un estudiante" Visible="False"></asp:Label>
      
</div>
<div id="ElegirCambioEst" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverElegirEst" runat="server" Text="Volver" OnClick="btnVolverElegirEst_Click" />
    </div>
        <h3>
            <asp:Label ID="lblElegirDatos" runat="server" Text=""></asp:Label>
        </h3>
        <p>
            <asp:RadioButtonList ID="radbtnElegirDatosEst" runat="server">
            </asp:RadioButtonList>
        </p>
        <p></p>
        <asp:Button ID="btnContinuarEst" runat="server" Text="Continuar" OnClick="btnContinuarEst_Click" />
      
        <asp:Label ID="lblWarnrad" runat="server" style="color: #FF0000" Text="Seleccione los datos a editar" Visible="False"></asp:Label>
      
    </div>
<div id="CambiarEstudiante" runat="server" visible="false">
        <div style="text-align: right; " class="nav-justified">
        <asp:Button ID="btnVolverCambioEstudiante" runat="server" Text="Volver" OnClick="btnVolverCambioEstudiante_Click" style="height: 26px" />
    </div>
        <h3>
            <asp:Label ID="lblEstudiante" runat="server" Text=""></asp:Label>
        </h3>
        <p></p>
        <h4 id="txtNombreEst" runat="server" visible="false">Nombre: 
            <asp:TextBox ID="txtNombreEstudiante" runat="server"></asp:TextBox>
        </h4>
    <div id="txtIDEst" runat="server" visible="false">
        <h4>ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
            <asp:TextBox ID="txtIDEstudiante" runat="server"></asp:TextBox>
        </h4> 
    </div>
        <p>
        <asp:Button ID="btnModificarEstudiante" runat="server" Text="Modificar" OnClick="btnModificarEstudiante_Click" />
      
        <asp:Label ID="lblWarnTxt0" runat="server" style="color: #FF0000" Text="Llene los campos requeridos" Visible="False"></asp:Label>
      
    </p>
    
    </div>
<div id="ConfirmarEst" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos del estudiante?</h3>
        <p></p>
    <p></p>
        <h4>
<asp:Label ID="lblConfirmarNombreEst" runat="server" Text=""></asp:Label>
        </h4>
    <h4>
<asp:Label ID="lblConfirmarIDEst" runat="server" Text=""></asp:Label>       
    </h4>
    <p></p>
<asp:Button ID="btnConfirmarEst" runat="server" Text="Confirmar y volver al menu principal" OnClick="btnConfirmarEst_Click" />
    <p></p>
        <asp:Button ID="btnCancelarEst" runat="server" Text="Volver a editar" OnClick="btnCancelarEst_Click" />
    </div>


<div id="profesor" runat="server" visible="false">    
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverProfesor" runat="server" Text="Volver" OnClick="btnVolverProfesor_Click" />
    </div>
        <h3>Editar profesor</h3>
    <h4>Elegir profesor a editar:</h4>
        <asp:RadioButtonList ID="radbtnProfesores" runat="server" OnSelectedIndexChanged="radbtnProfesores_SelectedIndexChanged"></asp:RadioButtonList>

    <p></p>
    <asp:Button ID="btnEditarProfesor" runat="server" Text="Editar" OnClick="btnEditarProfesor_Click" Width="57px" />
      <asp:Label ID="lblWarnProf" runat="server" style="color: #FF0000" Text="Seleccione un profesor" Visible="False"></asp:Label>
</div>
<div id="ElegirCambioProf" runat="server" visible="false">
        <div style="text-align: right; " class="nav-justified">
        <asp:Button ID="btnVolverElegirProf" runat="server" Text="Volver" OnClick="btnVolverElegirProf_Click" />
    </div>
        <h3>
            <asp:Label ID="lblElegirDatosp" runat="server" Text=""></asp:Label>
        </h3>
        <p>
            <asp:RadioButtonList ID="radbtnElegirDatosProf" runat="server">
            </asp:RadioButtonList>
        </p>
        <p></p>
        <asp:Button ID="btnContinuarProf" runat="server" Text="Continuar" OnClick="btnContinuarProf_Click" />
      
        <asp:Label ID="lblWarnradp" runat="server" style="color: #FF0000" Text="Seleccione los datos a editar" Visible="False"></asp:Label>
      
    </div>
<div id="CambiarProfesor" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverCambioProfesor" runat="server" Text="Volver" OnClick="btnVolverCambioProfesor_Click" style="height: 26px" />
    </div>
        <h3>
            <asp:Label ID="lblProfesor" runat="server" Text=""></asp:Label>
        </h3>
        <p></p>
        <h4 id="nombreprof" runat="server" visible="false">Nombre: 
            <asp:TextBox ID="txtNombreProfesor" runat="server" style="margin-top: 2"></asp:TextBox>
        </h4>
    <div id="idprof" runat="server" visible="true">
        <h4>ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
            <asp:TextBox ID="txtIDProfesor" runat="server"></asp:TextBox>
        </h4> 
    </div> 
        <p>
        <asp:Button ID="btnModificarProfesor" runat="server" Text="Modificar" OnClick="btnModificarProfesor_Click" />
    <asp:Label ID="lblWarnTxt1" runat="server" style="color: #FF0000" Text="Llene los campos requeridos" Visible="False"></asp:Label>
        </p>
    </div>
<div id="ConfirmarProf" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos del profesor?</h3>
        <p></p>
    <p></p>
        <h4>
<asp:Label ID="lblConfirmarNombreProf" runat="server" Text=""></asp:Label>
        </h4>
    <h4>
<asp:Label ID="lblConfirmarIDProf" runat="server" Text=""></asp:Label>       
    </h4>
    <p></p>
<asp:Button ID="btnConfirmarProf" runat="server" Text="Confirmar y volver al menu principal" OnClick="btnConfirmarProf_Click" />
    <p></p>
        <asp:Button ID="btnCancelarProf" runat="server" Text="Volver a editar" OnClick="btnCancelarProf_Click" />
    </div>


<div id="asignatura" runat="server" visible="false">    
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverAsignatura" runat="server" Text="Volver" OnClick="btnVolverAsignatura_Click" />
    </div>
        <h3>Editar asignatura</h3>
    <h4>Elegir asignatura a editar:</h4>
        <asp:RadioButtonList ID="radbtnAsignaturas" runat="server" OnSelectedIndexChanged="radbtnAsignaturas_SelectedIndexChanged"></asp:RadioButtonList>

    <p></p>
    <asp:Button ID="btnEditarAsignatura" runat="server" Text="Editar" OnClick="btnEditarAsignatura_Click" />
      
</div>
<div id="CambiarAsignatura" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverCambioAsignatura" runat="server" Text="Volver" OnClick="btnVolverCambioAsignatura_Click" style="height: 26px" />
    </div>
        <h3>
            <asp:Label ID="lblAsignatura" runat="server" Text=""></asp:Label>
        </h3>
        <p></p>
        <h4>Nombre:&nbsp; 
            <asp:TextBox ID="txtNombreAsignatura" runat="server"></asp:TextBox>
        </h4>
    <div id="CambioClave" runat="server" visible="true">
        <h4>Clave:&nbsp;&nbsp;&nbsp;&nbsp;     
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
        </h4>
</div>
    <div id="CambioCreditos" runat="server" visible="true">
    <h4>Creditos:     
            <asp:TextBox ID="txtCreditosAsignatura" runat="server"></asp:TextBox>
        </h4>

    </div>
        <p>
        <asp:Button ID="btnModificarAsignatura" runat="server" Text="Modificar" OnClick="btnModificarAsignatura_Click" />
    </p>
    </div>
</asp:Content>