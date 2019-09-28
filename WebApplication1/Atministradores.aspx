<%@ Page Title="Atministradores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atministradores.aspx.cs" Inherits="WebApplication1.Atministradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Portal de acceso Indice Academico para atministradores</h3>
    <div id="webcontentLogin" runat="server" visible="true">
        <asp:Login ID="Login1" runat="server" LoginButtonText="Entrar" PasswordLabelText="Clave:" TitleText="Iniciar Sesion:" UserNameLabelText="Usuario:" DisplayRememberMe="False" FailureText="No pudo acceder. Intente de nuevo." Height="119px" Width="151px" OnAuthenticate="Login_Authenticate">
    </asp:Login>
    </div>
    <div id="webcontentAtmin" runat="server" visible="false">

        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar entidad" />

    </div>
    <div id="datosAtmin" runat="server" visible="false">
        <div>
        <p></p>
        <asp:Label runat="server" Text="Nombre: "></asp:Label>
        <asp:Label ID="nomAtmin" runat="server" Text=""></asp:Label>
    </div>
        <div>
        <asp:Label runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="idAtmin" runat="server" Text=""></asp:Label>
        <p></p>
      </div>
    </div>
    </asp:Content>