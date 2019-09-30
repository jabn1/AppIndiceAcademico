<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUsuarios.aspx.cs" Inherits="WebApplication1.ControlUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wcOpciones" runat="server" visible="false">
        <asp:Button ID="BtMenu" runat="server" Text="Menu" OnClick="BtMenu_Click" />
        <h3>Control de usuarios</h3>
        <p></p>
        Elegir una opcion:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" Width="140px">
            <asp:ListItem>Inhabilitar</asp:ListItem>
            <asp:ListItem>Habilitar</asp:ListItem>
        </asp:DropDownList>
        <p></p>
        <asp:Button ID="BtEst" runat="server" Text="Estudiante" OnClick="BtEst_Click" Width="140px" />
        <p></p>
        <asp:Button ID="BtProf" runat="server" Text="Profesor" OnClick="BtProf_Click" Width="140px" />
        <p></p>
    </div>

    <div id="wcLista" runat="server" visible="false">
        <asp:Button ID="BtVolver" runat="server" Text="Volver" OnClick="BtVolver_Click" />
        <h3>Control de usuarios</h3>
        <p></p>
        <asp:Label ID="LblTipoDato" runat="server" Text=""></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
        <p></p>
        <asp:Button ID="BtProcesar" runat="server" Text="Procesar" OnClick="BtProcesar_Click" Width="140px" />
        <p></p>
        <asp:Button ID="BtCancelar2" runat="server" Text="Cancelar" OnClick="BtCancelar_Click" Width="140px" />
        <p></p>
    </div>

    <div id="wcConfirmar" runat="server" visible="false">
        <asp:Button ID="BtEditar" runat="server" Text="Editar seleccion" Width="116px" OnClick="BtEditar_Click" />
        <h3>Control de usuarios</h3>
        <p></p>
        <asp:Label ID="LblEntidad" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Label ID="LblAccion" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Button ID="BtConfirmar" runat="server" Text="Confirmar" OnClick="BtConfirmar_Click" Width="140px" />
        <p></p>
        <asp:Button ID="BtCancelar" runat="server" Text="Cancelar" OnClick="BtCancelar_Click" Width="140px" />
        <p></p>
    </div>
</asp:Content>
