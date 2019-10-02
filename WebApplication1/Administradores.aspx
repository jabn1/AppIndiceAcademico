<%@ Page Title="Administradores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administradores.aspx.cs" Inherits="WebApplication1.Atministradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="webcontentLogin" runat="server" visible="true">
    <h3>Portal de acceso Indice Academico para administradores</h3>
   
    
    
        <asp:Login ID="Login1" runat="server" LoginButtonText="Entrar" PasswordLabelText="Clave:" TitleText="Iniciar Sesion:" UserNameLabelText="Usuario:" DisplayRememberMe="False" FailureText="No pudo acceder. Intente de nuevo." Height="119px" Width="151px" OnAuthenticate="Login_Authenticate">
    </asp:Login>
    </div>

    <div id="webcontentAdmin" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btLogout" runat="server" Text="Cerrar Sesion" OnClick="btLogout_Click" />
        </div>
        <h3>Portal de administradores</h3>
        <p></p>
        <p>
        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar entidad" Width="200px" />
        </p>
        <p>&nbsp;</p>
            <p>
                <asp:Button ID="BtReportes" runat="server" Text="Consulta de datos y reportes" Width="200px" OnClick="BtReportes_Click" />
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="BtAgregarEnt" runat="server" Text="Agregar entidad" Width="200px" OnClick="BtAgregarEnt_Click" />
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="BtEliminarEnt" runat="server" Text="Eliminar entidad" Width="200px" OnClick="BtEliminarEnt_Click" />
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="BtControl" runat="server" Text="Control de usuarios" Width="200px" OnClick="BtControl_Click" />
            </p>
        <asp:Label runat="server" Text="Nombre: "></asp:Label>
        <asp:Label ID="nomAdmin" runat="server" Text=""></asp:Label>
        
        <div>
        <asp:Label runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="idAdmin" runat="server" Text=""></asp:Label>
        <p></p>
        </div>
    </div>
    </asp:Content>