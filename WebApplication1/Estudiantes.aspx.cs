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
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["IdEst"] != null)
                {
                    this.Login1.Visible = false;
                    this.webcontentLogin.Visible = false;
                    
                    
                    this.SqlDataSource1.SelectParameters["Id"].DefaultValue = Session["IdEst"].ToString();
                    //this.SqlDataSource2.SelectParameters["IdEst"].DefaultValue = Id;



                    this.webcontentEst.Visible = true;
                }
            }
        }
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            AutenticacionTableAdapter authTBLA = new AutenticacionTableAdapter();
            AutenticacionDataTable datosAuth = authTBLA.GetDataById(this.Login1.UserName);
            


            //var entity = new Database1Entities();
            //var a = entity.DatosAutenticacion(this.Login1.UserName).ToArray();
            if ( datosAuth.Rows.Count == 0)
            {
                //Usuario no existe
            }
            else if (datosAuth.Rows.Count == 1)
            {
                var datosUsuario = (AutenticacionRow)datosAuth.Rows[0];
                if(datosUsuario["Role"].ToString() == "estudiante" && datosUsuario["Clave"].ToString() == this.Login1.Password)
                {
                    this.Login1.Visible = false;
                    this.webcontentLogin.Visible = false;
                    
                    Session["IdEst"] = datosUsuario["Id"].ToString();
                    this.SqlDataSource1.SelectParameters["Id"].DefaultValue = datosUsuario["Id"].ToString();
                    //this.SqlDataSource2.SelectParameters["IdEst"].DefaultValue = Id;



                    this.webcontentEst.Visible = true;
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            //this.webcontentListCal.Visible = false;
            this.reportViewerWC.Visible = false;
            this.webcontentEst.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteEst.rdlc");
            ListCalEstTableAdapter listCalTblA = new ListCalEstTableAdapter();
            //Customers dsCustomers = GetData("select top 20 * from customers");
            ReportDataSource datasource = new ReportDataSource("EstRepDS", (DataTable)listCalTblA.GetDataByID(Session["IdEst"].ToString()));
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            this.webcontentEst.Visible = false;
            this.reportViewerWC.Visible = true;
            //this.webcontentListCal.Visible = true;
        }

        protected void btLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default");
        }
    }

}