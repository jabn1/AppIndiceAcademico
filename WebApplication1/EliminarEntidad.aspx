<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarEntidad.aspx.cs" Inherits="WebApplication1.EliminarEntidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="div1" runat="server" visible="false">
        <h3>Eliminar: </h3>
        <p></p>
        <h4>Que desea eliminar?</h4>
            <asp:Button ID="Button1" runat="server" Text="Eliminar Estudiante" OnClick="Button1_Click" Width="200px" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Eliminar Profesor" OnClick="Button2_Click" Width="200px"/>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Eliminar Asignatura" OnClick="Button3_Click" Width="200px"/>
    </div>

    <div id="divEst" runat="server" visible="false">
        <h3>Eliminar: </h3>
        <h4>Estudiante</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListEst" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="regresar1" runat="server" Text="regresar" OnClick="regresar_Click" />
        
        
        <asp:Button ID="EliminarEst" runat="server" Text="Eliminar" OnClick="EliminarEst_Click" />
        
        
    </div>

    <div id="divProf" runat="server" visible="false">
        <h3>Eliminar:</h3>
        <h4>Profesor</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListProf" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="regresar2" runat="server" Text="regresar" OnClick="regresar_Click" />
        
        <asp:Button ID="EliminarProf" runat="server" Text="Eliminar" OnClick="EliminarProf_Click" />
        
    </div>

    <div id="divAsig" runat="server" visible="false">
        <h3>Eliminar: </h3>
        <h4>Asignatura</h4>
        <p></p>
        <asp:RadioButtonList ID="RadioButtonListAsig" runat="server">
        </asp:RadioButtonList>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:Button ID="regresar3" runat="server" Text="regresar" OnClick="regresar_Click" />
        
        <asp:Button ID="EliminarAsig" runat="server" Text="Eliminar" OnClick="EliminarAsig_Click" />
        
    </div>

</asp:Content>
