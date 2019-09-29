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
    public partial class EditarEntidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "administrador"))
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
            Response.Redirect("Administradores");
        }

        protected void radbtnEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.radbtnEntidades.SelectedValue == "Estudiante")
            {
                this.wcEditarEntidad.Visible = false;
                this.estudiante.Visible = true;

                EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();
                
                foreach(EstudiantesRow row in estudiantesTableAdapter.GetStudentsNotInUse())
                {
                    radbtnEstudiantes.Items.Add(new ListItem(row["IdEst"].ToString() + " - " + row["NombreEst"].ToString(), row["IdEst"].ToString()));
                }
            }
            else if (this.radbtnEntidades.SelectedValue == "Profesor")
            {

            }
            else if (this.radbtnEntidades.SelectedValue == "Asignatura")
            {

            }
            else
            {
                this.lblWarn.Visible = true;
            }
        }

        protected void btnVolverEstudiante_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
        }
    }
}