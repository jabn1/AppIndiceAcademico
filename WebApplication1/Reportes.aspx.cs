using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Database1DataSetTableAdapters;

namespace WebApplication1
{
    public enum TiposReporte
    {
        ListadoEst = 0,
        ListadoProf = 1,
        ListadoAsig = 2,
        ListadoCal = 3
    }
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "administrador"))
                {


                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add(new ListItem("Elegir tipo", ""));
                    DropDownList1.Items.Add(new ListItem("Listado de estudiantes", TiposReporte.ListadoEst.ToString()));
                    DropDownList1.Items.Add(new ListItem("Listado de profesores", TiposReporte.ListadoProf.ToString()));
                    DropDownList1.Items.Add(new ListItem("Listado de asignaturas", TiposReporte.ListadoAsig.ToString()));
                    DropDownList1.Items.Add(new ListItem("Listado de calificaciones", TiposReporte.ListadoCal.ToString()));

                    wcOpciones.Visible = true;

                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        protected void BtGenerar_Click(object sender, EventArgs e)
        {
            string path = "";
            if(DropDownList1.SelectedItem.Value == "")
            {
                return;
            }
            else if(DropDownList1.SelectedValue == TiposReporte.ListadoEst.ToString())
            {
                path = Server.MapPath("~/ListadoEstRep.rdlc");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = path;
                EstudiantesTableAdapter estudiantesTable = new EstudiantesTableAdapter();
                ReportDataSource data = new ReportDataSource("DataSet1", (DataTable)estudiantesTable.GetData());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(data);
                
            }
            else if (DropDownList1.SelectedValue == TiposReporte.ListadoProf.ToString())
            {
                path = Server.MapPath("~/ListadoProfRep.rdlc");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = path;
                ProfesoresTableAdapter profesoresTable = new ProfesoresTableAdapter();
                ReportDataSource data = new ReportDataSource("DataSet1", (DataTable)profesoresTable.GetData());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(data);
            }
            else if (DropDownList1.SelectedValue == TiposReporte.ListadoAsig.ToString())
            {
                path = Server.MapPath("~/ListadoAsigRep.rdlc");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = path;
                AsignaturasTableAdapter asignaturasTable = new AsignaturasTableAdapter();
                ReportDataSource data = new ReportDataSource("DataSet1", (DataTable)asignaturasTable.GetData());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(data);
            }
            else if (DropDownList1.SelectedValue == TiposReporte.ListadoCal.ToString())
            {
                path = Server.MapPath("~/ListadoCalRep.rdlc");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = path;
                ListCalEstTableAdapter listCalTblA = new ListCalEstTableAdapter();
                ReportDataSource datasource = new ReportDataSource("EstRepDS", (DataTable)listCalTblA.GetData());
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            wcOpciones.Visible = false;
            wcReporte.Visible = true;
        }

        protected void BtMenu_Click(object sender, EventArgs e)
        {
            //Direccion de pagina de admin
            Response.Redirect("Administradores");
        }

        protected void BtVolver_Click(object sender, EventArgs e)
        {
            wcReporte.Visible = false;
            wcOpciones.Visible = true;
        }
    }
}