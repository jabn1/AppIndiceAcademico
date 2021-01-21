<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="WebApplication1.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        btn{
            margin:10px 0;
        }
    </style>
    <div id="wcOpciones" runat="server" visible="false">
        <asp:Button  class="btn" ID="BtMenu" runat="server" Text="Menu" OnClick="BtMenu_Click" />
        <h3>Consulta de datos y reportes</h3>
        <p></p>
        <h4>Elegir una opcion:</h4>
        <asp:DropDownList class="btn"  ID="DropDownList1" runat="server" Width="201px"></asp:DropDownList>
        <br />
        <br />
        <asp:Button  class="btn" ID="BtGenerar" runat="server" OnClick="BtGenerar_Click" Text="Generar" Width="196px" />
    </div>
    <div id="wcReporte" runat="server" visible="false">
        <asp:Button  class="btn" ID="BtVolver" runat="server" Text="Volver" OnClick="BtVolver_Click" />
        <h3>Reportes del administrador:</h3>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="90%" Height="600px"></rsweb:ReportViewer>
        <br />
        <br />
    </div>
</asp:Content>
