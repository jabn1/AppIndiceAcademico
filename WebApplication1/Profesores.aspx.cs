using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Database1DataSetTableAdapters;
using static WebApplication1.Database1DataSet;

namespace WebApplication1
{
    public partial class Profesores : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdProf"] != null)
                {
                    this.Login1.Visible = false;
                    this.webcontentLogin.Visible = false;
                    this.idProf.Text = Session["IdProf"].ToString();
                    this.nomProf.Text = Session["NomProf"].ToString();

                    // this.SqlDataSource1.SelectParameters["Id"].DefaultValue = Session["IdProf"].ToString();
                    //this.SqlDataSource2.SelectParameters["IdEst"].DefaultValue = Id;



                    this.webcontentProfesor.Visible = true;
                }
            }
        }
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            AutenticacionTableAdapter authTBLA = new AutenticacionTableAdapter();
            AutenticacionDataTable datosAuth = authTBLA.GetDataById(this.Login1.UserName);



            //var entity = new Database1Entities();
            //var a = entity.DatosAutenticacion(this.Login1.UserName).ToArray();
            if (datosAuth.Rows.Count == 0)
            {
                //Usuario no existe
            }
            else if (datosAuth.Rows.Count == 1)
            {
                var datosUsuario = (AutenticacionRow)datosAuth.Rows[0];
                if (datosUsuario["Role"].ToString() == "profesor" && datosUsuario["Clave"].ToString() == this.Login1.Password)
                {
                    this.Login1.Visible = false;
                    this.webcontentLogin.Visible = false;

                    Session["IdProf"] = datosUsuario["Id"].ToString();
                    Session["Role"] = "profesor";
                    ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
                    Session["NomProf"] = profesoresTableAdapter.GetProfName(Session["IdProf"].ToString()).ToString();

                    this.idProf.Text = Session["IdProf"].ToString();
                    this.nomProf.Text = Session["NomProf"].ToString();
                    //this.SqlDataSource1.SelectParameters["Id"].DefaultValue = datosUsuario["Id"].ToString();
                    //this.SqlDataSource2.SelectParameters["IdEst"].DefaultValue = Id;



                    this.webcontentProfesor.Visible = true;
                }
                else
                {
                    //Negar acceso
                }

            }
            else
            {
                //Negar acceso
            }
        }
        protected void btLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default");
        }

        protected void btReporte_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteProf.rdlc");
            ListCalEstTableAdapter listCalTblA = new ListCalEstTableAdapter();
           
            ReportDataSource datasource = new ReportDataSource("EstRepDS", (DataTable)listCalTblA.GetDataByProfId(Session["IdProf"].ToString()));
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            this.webcontentProfesor.Visible = false;
            this.reportViewerWC.Visible = true;
        }

        protected void btAddCal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCal");
        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            this.reportViewerWC.Visible = false;
            this.webcontentProfesor.Visible = true;
        }
    }
}