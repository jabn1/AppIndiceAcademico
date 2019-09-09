<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profesores.aspx.cs" Inherits="WebApplication1.Profesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="webcontentEst" runat="server" visible="false">

<%--<div  <%--style="width:50%; margin: 0 auto;"--%>
    <h3>Portal de Estudiantes</h3>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Listado de calificaciones" Width="210px" OnClick="Button1_Click" />
    </div>
    <div style="height: 30px; width: 1451px;">&nbsp;&nbsp;</div>
    <div>
        <asp:Button ID="Button2" runat="server" Text="Descargar Reporte" Width="210px" />
        <p></p>
    </div>
    
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="GetStudent" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="Id" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
        </div>
<div id="webcontentLogin" runat="server" visible="true">
    <h3>Portal de acceso Indice Academico para profesores</h3>
    
    <div>
        <asp:Login ID="Login2" runat="server" LoginButtonText="Entrar" PasswordLabelText="Clave:" TitleText="Iniciar Sesion:" UserNameLabelText="Usuario:" DisplayRememberMe="False" FailureText="No pudo acceder. Intente de nuevo." Height="119px" Width="151px" OnAuthenticate="Login_Authenticate">
    </asp:Login>
    </div>
         
</div>
<div id="webcontentListCal" runat="server" visible="false">
    

    <asp:Button ID="Button3" runat="server" Text="Volver" OnClick="Button3_Click" />
    <p></p>
    <h3>Listado de Calificaciones:</h3> <p></p>
    <asp:SqlDataSource ID="SqlDataSource2"  runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="ListarCalsEst" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="IdEst" Type="String" />
        </SelectParameters>       
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" Width="664px" >
    <Columns>
                        <asp:TemplateField HeaderText="Clave">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"
                                    Text='<%# Eval("ClaveAsignatura") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asignatura">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"
                                    Text='<%# Eval("NombreAsig") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        <asp:TemplateField HeaderText="Creditos">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server"
                                    Text='<%# Eval("Creditos") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Profesor">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"
                                    Text='<%# Eval("NombreProf") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        <asp:TemplateField HeaderText="Valor">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server"
                                    Text='<%# Eval("Valor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
        <asp:TemplateField HeaderText="Calificacion">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server"
                                    Text='<%# Eval("Alpha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    </div>
</asp:Content>
