<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div  <%--style="width:50%; margin: 0 auto;"--%>>
    <h1>Portal de Estudiantes</h1>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Listado de calificaciones" Width="210px" />
    </div>
    <div style="height: 30px; width: 1451px;">&nbsp;&nbsp;</div>
    <div>
        <asp:Button ID="Button2" runat="server" Text="Descargar Reporte" Width="210px" />
        <p></p>
    </div>
    
        <asp:DataList ID="DataList1" runat="server" DataKeyField="Id" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" RepeatLayout="Flow" >
            <ItemTemplate>
                Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Nombre:
                <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" >
        </asp:SqlDataSource>
        </div>
</asp:Content>
