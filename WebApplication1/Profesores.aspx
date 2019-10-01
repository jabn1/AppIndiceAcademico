<%@ Page Title="Profesores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="WebApplication1.Profesores" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="webcontentLogin" runat="server" visible="true">
    <h3>Portal de acceso Indice Academico para profesores</h3>
    
    <div>
        <asp:Login ID="Login1" runat="server" LoginButtonText="Entrar" PasswordLabelText="Clave:" TitleText="Iniciar Sesion:" UserNameLabelText="Usuario:" DisplayRememberMe="False" FailureText="No pudo acceder. Intente de nuevo." Height="119px" Width="151px" OnAuthenticate="Login_Authenticate">
    </asp:Login>
    </div>
         
</div>
<div id="webcontentProfesor" runat="server" visible="false">
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="btLogout" runat="server" Text="Cerrar Sesion" OnClick="btLogout_Click" />
    </div>
    <h3>Portal de Profesores</h3>    
    <div>
        <p></p>
        <asp:Button ID="btReporte" runat="server" Text="Reporte Calificaciones" OnClick="btReporte_Click" Width="200px" />
        <p></p>
    </div> 
    <div>
        <asp:Button ID="btAddCal" runat="server" Text="Agregar Calificacion" OnClick="btAddCal_Click" Width="200px" />
    </div>
    <div>
        <p></p>
        <asp:Label runat="server" Text="Nombre: "></asp:Label>
        <asp:Label ID="nomProf" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="idProf" runat="server" Text=""></asp:Label>
        <p></p>
    </div>
</div>
<div id="reportViewerWC" runat="server" visible="false">
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ClientIDMode="AutoID" Width="90%" Height="700px" Visible="True">
        </rsweb:ReportViewer>

    </div>
</asp:Content>
