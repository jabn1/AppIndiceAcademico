  <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarEntidad.aspx.cs" Inherits="WebApplication1.EliminarEntidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="div1" runat="server" visible="false">
            <div style="text-align: right; width: 100%;">
                <asp:Button ID="volverMP" runat="server" Text="Volver" OnClick="btnVolverMenuPrincipal_Click" />
            </div>
            <h3>Eliminar: </h3>
            
            <h4>Que desea eliminar?</h4>
            <asp:Button ID="Button1" runat="server" Text="Eliminar Estudiante" OnClick="Button1_Click" Width="200px" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Eliminar Profesor" OnClick="Button2_Click" Width="200px"/>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Eliminar Asignatura" OnClick="Button3_Click" Width="200px"/>
    </div>

    <div id="divEst" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
            <asp:Button ID="Button6" runat="server" Text="Volver" OnClick="BtnVolverAgregar_Click" />
        </div>
        <h3>Eliminar: </h3>
        <h4>Estudiante</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListEst" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="EliminarEst" runat="server" Text="Eliminar" OnClick="TryEliminarEst_Click" /> 
        
    </div>

    <div id="divProf" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
            <asp:Button ID="Button7" runat="server" Text="Volver" OnClick="BtnVolverAgregar_Click" />
        </div>
        <h3>Eliminar:</h3>
        <h4>Profesor</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListProf" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="EliminarProf" runat="server" Text="Eliminar" OnClick="TryEliminarProf_Click" />     

    </div>

    <div id="divAsig" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
            <asp:Button ID="Button8" runat="server" Text="Volver" OnClick="BtnVolverAgregar_Click" />
        </div>
        <h3>Eliminar: </h3>
        <h4>Asignatura</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListAsig" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:Button ID="EliminarAsig" runat="server" Text="Eliminar" OnClick="TryEliminarAsig_Click" />
        
        
    </div>
    <div id="divConf" runat="server" visible="false">
        <div style="text-align: right; width: 100%;">
            <asp:Button ID="Button4" runat="server" Text="Volver" OnClick="BtnVolverAgregar_Click" />
        </div>
        <h3>Seguro desea eliminar: </h3>
        <h4>
        <asp:Label ID="Label5" runat="server"></asp:Label>        
        </h4>
        <br />
        <asp:Button ID="Button5" runat="server" Text="Confirmar" OnClick="Eliminar_Click" />
        
    </div>

    <div id ="terminado" runat="server" visible="false">
        <h3>
        <asp:Label ID="lblEntidadEliminada" runat="server"></asp:Label>
        </h3>
        <p></p>
        <asp:Button ID="BtnVolverAgregar" runat="server" Text="Volver al menu eliminar" OnClick="BtnVolverAgregar_Click" />
        <br />
        <asp:Button ID="btnVolverMenuPrincipal" runat="server" Text="Volver al menu principal" OnClick="btnVolverMenuPrincipal_Click" />
        
    </div>

</asp:Content>
