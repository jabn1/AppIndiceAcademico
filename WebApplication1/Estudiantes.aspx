<%@ Page Title="Estudiantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="webcontentEst" runat="server" visible="false">

<%--<div  <%--style="width:50%; margin: 0 auto;"--%>
    <div style="text-align: right; width: 100%;">
        <asp:Button ID="btLogout" runat="server" Text="Cerrar Sesion" OnClick="btLogout_Click" />
    </div>
    <h3>Portal de Estudiantes</h3>    
    <div>
        
        <asp:Button ID="Button1" runat="server" Text="Listado de calificaciones" Width="210px" OnClick="Button1_Click" />
    </div>
    <div style="height: 30px; width: 1451px;">&nbsp;&nbsp;</div>
    
        <asp:DataList ID="DataList1" runat="server" DataKeyField="IdEst" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatLayout="Flow" >
            <ItemTemplate>
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("IdEst") %>' />
                <br />
                Nombre:
                <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("NombreEst") %>' />
                <br />
                Carrera:
                <asp:Label ID="CarreraLabel" runat="server" Text='<%# Eval("Carrera") %>' />
                <br />
                Indice:
                <asp:Label ID="IndiceLabel" runat="server" Text='<%# Eval("Indice") %>' />
                <br />
                 Honor:
                <asp:Label ID="HonorLabel" runat="server" Text='<%# Eval("Honor") %>' />
                <br />
                Creditos Acumulados:
                <asp:Label ID="CreditosAccLabel" runat="server" Text='<%# Eval("CreditosAcc") %>' />
                <br />               
                Cantidad de Calificaciones:
                <asp:Label ID="CantidadCalLabel" runat="server" Text='<%# Eval("CantidadCal") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="GetStudent" SelectCommandType="StoredProcedure" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="Id" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
        </div>
<div id="webcontentLogin" runat="server" visible="true">
    <h3>Portal de acceso Indice Academico para estudiantes</h3>
    <div>
        <asp:Login ID="Login1" runat="server" LoginButtonText="Entrar" PasswordLabelText="Clave:" TitleText="Iniciar Sesion:" UserNameLabelText="Usuario:" DisplayRememberMe="False" FailureText="No pudo acceder. Intente de nuevo." Height="119px" Width="151px" OnAuthenticate="Login_Authenticate">
    </asp:Login>
    </div>        
</div>
<div id="reportViewerWC" runat="server" visible="false">
        <asp:Button ID="Button3" runat="server" Text="Volver" OnClick="Button3_Click" />
        <p>

        </p>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ClientIDMode="AutoID" Width="90%" Height="700px" Visible="True">
        </rsweb:ReportViewer>
    </div>

</asp:Content>
