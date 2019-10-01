using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Database1DataSetTableAdapters;
using static WebApplication1.Database1DataSet;

namespace WebApplication1
{
    public partial class Atministradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdAdmin"] != null)
                {
                    this.webcontentLogin.Visible = false;
                    this.idAdmin.Text = Session["IdAdmin"].ToString();
                    this.nomAdmin.Text = Session["NomAdmin"].ToString();
                    this.webcontentAdmin.Visible = true;
                }
            }
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            AutenticacionTableAdapter authTBLA = new AutenticacionTableAdapter();
            AutenticacionDataTable datosAuth = authTBLA.GetDataById(this.Login1.UserName);
            
            if (datosAuth.Rows.Count == 1)
            {
                var datosUsuario = (AutenticacionRow)datosAuth.Rows[0];
                if (datosUsuario["Role"].ToString() == "administrador" && datosUsuario["Clave"].ToString() == this.Login1.Password)
                {
                    this.webcontentLogin.Visible = false;

                    Session["IdAdmin"] = datosUsuario["Id"].ToString();
                    Session["Role"] = "administrador";
                    AtministradoresTableAdapter atministradoresTableAdapter = new AtministradoresTableAdapter();
                    Session["NomAdmin"] = atministradoresTableAdapter.GetAdminName(Session["IdAdmin"].ToString());

                    this.idAdmin.Text = Session["IdAdmin"].ToString();
                    this.nomAdmin.Text = Session["NomAdmin"].ToString();
                    this.webcontentAdmin.Visible = true;
                }               
            }      
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
        }

        protected void btLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default");
        }
    }
}