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
    public partial class AgregarEntidad : System.Web.UI.Page
    {
        private EstudiantesTableAdapter estudiantes;
        private ProfesoresTableAdapter profesores;
        private AsignaturasTableAdapter asignaturas;
        private AutenticacionTableAdapter autenticacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "administrador"))
                {
                    div1.Visible = true;
                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            divEst.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            divProf.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            divAsig.Visible = true;
        }

        protected void guardarEst_Click(object sender, EventArgs e)
        {
            estudiantes = new EstudiantesTableAdapter();
            autenticacion = new AutenticacionTableAdapter();
            if (idEst != null && nombreEst != null && carreraEst != null && contraEst != null)
            {
                estudiantes.Insert(idEst.Text, nombreEst.Text, carreraEst.Text, "0.00", 0, "Sin Honor", 0);
                autenticacion.Insert(idEst.Text, contraEst.Text, null, "estudiante");
            }
            divEst.Visible = false;
            div1.Visible = true;

        }

        protected void guardarProf_Click(object sender, EventArgs e)
        {
            profesores = new ProfesoresTableAdapter();
            autenticacion = new AutenticacionTableAdapter();
            if (idProf != null && nombreProf != null && contraProf != null)
            {
                profesores.Insert(idProf.Text, nombreProf.Text);
                autenticacion.Insert(idProf.Text, contraProf.Text, null, "profesor");
            }
            divProf.Visible = false;
            div1.Visible = true;
        }

        protected void guardarAsig_Click(object sender, EventArgs e)
        {
            asignaturas = new AsignaturasTableAdapter();
            if (claveAsig != null && nombreAsig != null && creditosAsig != null)
            {
                asignaturas.Insert(claveAsig.Text, nombreAsig.Text, int.Parse(creditosAsig.Text));
            }
            divAsig.Visible = false;
            div1.Visible = true;

        }
    }
}