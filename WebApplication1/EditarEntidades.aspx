<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarEntidades.aspx.cs" Inherits="WebApplication1.EditarEntidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="wcEditarEntidad" runat="server" visible="false" >
        <div style="text-align: right; width: 100%;">
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" /></div>
        <h3>Editar entidades</h3>
    <p></p>
        <h4>Elegir la entidad a editar:</h4>        

        <asp:RadioButtonList ID="radbtnEntidades" runat="server" OnSelectedIndexChanged="radbtnEntidades_SelectedIndexChanged"></asp:RadioButtonList>
        
    </div>
    <div>

        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
&nbsp; 
        <asp:Label ID="lblWarn" runat="server" style="color: #FF0000" Text="Seleccione una entidad" Visible="False"></asp:Label>
    </div>

</asp:Content>