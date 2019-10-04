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
        <h3>Editar nombre del estudiante</h3>
    <h4>Elegir estudiante a editar:</h4>
        <asp:RadioButtonList ID="radbtnEstudiantes" runat="server" OnSelectedIndexChanged="radbtnEntidades_SelectedIndexChanged"></asp:RadioButtonList>

    <p></p>
    <asp:Button ID="btnEditarEstudiante" runat="server" Text="Editar" OnClick="btnEditarEstudiante_Click" Width="96px" />
      
        <asp:Label ID="lblWarnEst" runat="server" style="color: #FF0000" Text="Seleccione un estudiante" Visible="False"></asp:Label>
      
</div>
<div id="ElegirCambioEst" runat="server" visible="false">
        <div style="text-align: right; " class="nav-justified">
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
    <p></p>
        <p>
        <asp:Button ID="btnModificarEstudiante" runat="server" Text="Modificar" OnClick="btnModificarEstudiante_Click" />      
        <asp:Label ID="lblWarnTxt0" runat="server" style="color: #FF0000" Text="Llene los campos requeridos" Visible="False"></asp:Label>
      
    </p>
    
    </div>
<div id="ConfirmarEst" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos del estudiante?</h3>
        <p></p>
   
        <h4>
<asp:Label ID="lblConfirmarNombreEst" runat="server" Text=""></asp:Label>
        </h4>
    
    <p></p>
<asp:Button ID="btnConfirmarEst" runat="server" Text="Confirmar" OnClick="btnConfirmarEst_Click" />
    <p></p>
        <asp:Button ID="btnCancelarEst" runat="server" Text="Volver a editar" OnClick="btnCancelarEst_Click" />
    
    <div>
        <p></p>
        <h3>
        <asp:Label ID="lblEdicionEst" runat="server" Text="El nombre del estudiante ha sido cambiado."></asp:Label>
        </h3>
        <p></p>
        <asp:Button ID="btnVolverMenuPrincipalEst" runat="server" Text="Volver al menu principal" OnClick="btnVolverMenuPrincipalEst_Click" />
        
    </div>
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
            <asp:TextBox ID="txtNombreProfesor" runat="server"></asp:TextBox>
        </h4>
        <p></p>
        <p>
        <asp:Button ID="btnModificarProfesor" runat="server" Text="Modificar" OnClick="btnModificarProfesor_Click" />
    <asp:Label ID="lblWarnTxt1" runat="server" style="color: #FF0000" Text="Llene los campos requeridos" Visible="False"></asp:Label>
        </p>
    </div>
<div id="ConfirmarProf" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos del profesor?</h3>
    <p></p>
        <h4>
<asp:Label ID="lblConfirmarNombreProf" runat="server" Text=""></asp:Label>
        </h4>    
    <p></p>
<asp:Button ID="btnConfirmarProf" runat="server" Text="Confirmar" OnClick="btnConfirmarProf_Click" />
    <p></p>
        <asp:Button ID="btnCancelarProf" runat="server" Text="Volver a editar" OnClick="btnCancelarProf_Click" />
    <div>
        <p></p>
        <h3>
        <asp:Label ID="lblEdicionProf" runat="server" Text="El nombre del profesor ha sido cambiado."></asp:Label>
        </h3>
        <p></p>
        <asp:Button ID="btnVolverMenuPrincipalProf" runat="server" Text="Volver al menu principal" OnClick="btnVolverMenuPrincipalProf_Click" />
        
    </div>
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
      <asp:Label ID="lblWarnAsig" runat="server" style="color: #FF0000" Text="Seleccione una asignatura" Visible="False"></asp:Label>
</div>
<div id="ElegirCambioAsig" runat="server" visible="false">
        <div style="text-align: right; " class="nav-justified">
        <asp:Button ID="btnVolverElegirAsig" runat="server" Text="Volver" OnClick="btnVolverElegirAsig_Click" />
    </div>
        <h3>
            <asp:Label ID="lblElegirDatosa" runat="server" Text=""></asp:Label>
        </h3>
        <p>
            <asp:CheckBoxList ID="CheckBoxListAsig" runat="server"></asp:CheckBoxList>
        </p>
        <p></p>
        <asp:Button ID="btnContinuarAsig" runat="server" Text="Continuar" OnClick="btnContinuarAsig_Click" />
      
        <asp:Label ID="lblWarnrada" runat="server" style="color: #FF0000" Text="Seleccione los datos a editar" Visible="False"></asp:Label>
      
    </div>
<div id="CambiarAsignatura" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btnVolverCambioAsignatura" runat="server" Text="Volver" OnClick="btnVolverCambioAsignatura_Click" style="height: 26px" />
    </div>
        <h3>
            <asp:Label ID="lblAsignatura" runat="server" Text=""></asp:Label>
        </h3>
        <p></p>
        <h4 id="nombreasig" runat="server" visible="false">Nombre:&nbsp; 
            <asp:TextBox ID="txtNombreAsignatura" runat="server"></asp:TextBox>
        </h4>
    <h4 id="claveasig" runat="server" visible="false">
        Clave:&nbsp;&nbsp;&nbsp;&nbsp;     
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
</h4>
    <h4 id="creditoasig" runat="server" visible="false">
    Creditos:     
            <asp:TextBox ID="txtCreditosAsignatura" runat="server"></asp:TextBox>
    </h4>
        <p>
        <asp:Button ID="btnModificarAsignatura" runat="server" Text="Modificar" OnClick="btnModificarAsignatura_Click" />
   <asp:Label ID="lblWarnTxt2" runat="server" style="color: #FF0000" Text="Llene los campos requeridos" Visible="False"></asp:Label>
            </p>
    </div>
<div id="ConfirmarAsig" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos de la asignatura?</h3>
        <p></p>
    <p></p>
        <h4>
<asp:Label ID="lblConfirmarNombreAsig" runat="server" Text=""></asp:Label>
        </h4>
    <h4>
<asp:Label ID="lblConfirmarClaveAsig" runat="server" Text=""></asp:Label>       
    </h4>
    <h4>
<asp:Label ID="lblConfirmarCreditosAsig" runat="server" Text=""></asp:Label>       
    </h4>
    <p></p>
<asp:Button ID="btnConfirmarAsig" runat="server" Text="Confirmar y volver al menu principal" OnClick="btnConfirmarAsig_Click" />
    <p></p>
        <asp:Button ID="btnCancelarAsig" runat="server" Text="Volver a editar" OnClick="btnCancelarAsig_Click" />
    </div>


<div id="Calificacion" runat="server" visible="false">    
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="Button1" runat="server" Text="Volver" OnClick="btnVolverAsignatura_Click" />
    </div>
        <h3>Editar calificacion</h3>
    <h4>Elegir calificacion a editar:</h4>
        <asp:RadioButtonList ID="RBLcalif" runat="server"></asp:RadioButtonList>

    <p></p>
    <asp:Button ID="btEditarCal" runat="server" Text="Editar" OnClick="btEditarCal_Click" />
      <asp:Label ID="LblCalSelWarn" runat="server" style="color: #FF0000" Text="Seleccione una calificacion" Visible="False"></asp:Label>
</div>

<div id="ModCal" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="BtVolverCal" runat="server" Text="Volver"  style="height: 26px" />
    </div>
    <h3>Introduzca la nueva calificacion para la calificacion elegida:</h3>
        <h7>
            <asp:Label ID="LblDatosCal" runat="server" Text=""></asp:Label>
        </h7>
        <p></p>
       
    <h4 id="H2" runat="server">
        Nueva calificacion:&nbsp;&nbsp;&nbsp;&nbsp;     
            <asp:TextBox ID="TbNuevaCal" runat="server"></asp:TextBox>
    </h4>
    
        <p>
        <asp:Button ID="BtModCal" runat="server" Text="Modificar" OnClick="BtModCal_Click" />
   <asp:Label ID="LblCalModWarn" runat="server" style="color: #FF0000" Text="La calificacion debe ser un valor entre 0 y 100" Visible="False"></asp:Label>
            </p>
    </div>

<div id="ConfirmarCal" runat="server" visible="false">
        <h3>Seguro que desea cambiar los siguientes datos de la calificacion?</h3>
        <p></p>
    <p></p>
        <h7>
<asp:Label ID="LblDatosCalCon" runat="server" Text=""></asp:Label>
        </h7>
    <h4>
<asp:Label ID="LblNuevaCal" runat="server" Text=""></asp:Label>       
    </h4>

    <p></p>
<asp:Button ID="btConfirmar" runat="server" Text="Confirmar y volver al menu principal" OnClick="btConfirmar_Click" Width="260px"/>
    <p></p>
        <asp:Button ID="BtCancelCalif" runat="server" Text="Volver a editar" OnClick="BtCancelCalif_Click" Width="260px" />
    </div>

</asp:Content>