using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EditarEntidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "atministrador"))
                {


                    radbtnEntidades.Items.Add("Estudiante");
                    radbtnEntidades.Items.Add("Profesor");
                    radbtnEntidades.Items.Add("Asignatura");


                    wcEditarEntidad.Visible = true;

                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btRetEst_Click(object sender, EventArgs e)
        {

        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Atministradores");
        }

        protected void radbtnEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.radbtnEntidades.SelectedValue=="Estudiante")
            {
                this.lblWarn.Visible = false;
            }
            else if (this.radbtnEntidades.SelectedValue == "Profesor")
            {
                this.lblWarn.Visible = false;
            }
            else if (this.radbtnEntidades.SelectedValue == "Asignatura")
            {
                this.lblWarn.Visible = false;
            }
            else
            {
                this.lblWarn.Visible = true;
            }
        }
    }
}