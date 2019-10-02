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
    public partial class EliminarEntidad : System.Web.UI.Page
    {
        private EstudiantesTableAdapter estudiantes = new EstudiantesTableAdapter();
        private ProfesoresTableAdapter profesores = new ProfesoresTableAdapter();
        private AsignaturasTableAdapter asignaturas = new AsignaturasTableAdapter();
        private AutenticacionTableAdapter autenticacion = new AutenticacionTableAdapter();
        private CalificacionesTableAdapter calificaciones = new CalificacionesTableAdapter();

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
            Label1.Text = "";

            RadioButtonListEst.Items.Clear();
            foreach (EstudiantesRow est in estudiantes.GetData().Rows)
            {
                RadioButtonListEst.Items.Add(new ListItem(est["IdEst"].ToString() + " - " + est["NombreEst"].ToString() + " - " + est["Carrera"], est["IdEst"].ToString()));
            }

            divEst.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            Label2.Text = "";

            RadioButtonListProf.Items.Clear();
            foreach (ProfesoresRow prof in profesores.GetData().Rows)
            {
                RadioButtonListProf.Items.Add(new ListItem(prof["IdProf"].ToString() + " - " + prof["NombreProf"].ToString(), prof["IdProf"].ToString()));
            }

            divProf.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            Label3.Text = "";

            RadioButtonListAsig.Items.Clear();
            foreach (AsignaturasRow asig in asignaturas.GetData().Rows)
            {
                RadioButtonListAsig.Items.Add(new ListItem(asig["Clave"].ToString() + " - " + asig["NombreAsig"].ToString(), asig["Clave"].ToString()));
            }

            divAsig.Visible = true;
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            divAsig.Visible = false;
            divProf.Visible = false;
            divEst.Visible = false;
            divConfEst.Visible = false;
            divConfProf.Visible = false;
            divConfAsig.Visible = false;
            div1.Visible = true;
        }
        protected void TryEliminarEst_Click(object sender, EventArgs e)
        {
            divEst.Visible = false;
            div1.Visible = false;

            Label4.Text = RadioButtonListEst.SelectedItem.Text.ToString();

            divConfEst.Visible = true;

        }
        protected void TryEliminarProf_Click(object sender, EventArgs e)
        {
            divProf.Visible = false;
            div1.Visible = false;

            Label5.Text = RadioButtonListProf.SelectedItem.Text.ToString();

            divConfProf.Visible = true;

        }
        protected void TryEliminarAsig_Click(object sender, EventArgs e)
        {
            divAsig.Visible = false;
            div1.Visible = false;

            Label6.Text = RadioButtonListAsig.SelectedItem.Text.ToString();

            divConfAsig.Visible = true;

        }

        protected void EliminarEst_Click(object sender, EventArgs e)
        {
            int count1 = 0;

            foreach (CalificacionesRow calificacion in calificaciones.GetData().Rows)
            {
                if (calificacion["IdEstudiante"].ToString() == RadioButtonListEst.SelectedValue.ToString())
                    count1++;
            }
            if (count1 == 0)
            {
                estudiantes.Delete(RadioButtonListEst.SelectedValue);
                autenticacion.Delete(RadioButtonListEst.SelectedValue);
                divEst.Visible = false;
                divConfEst.Visible = false;
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                divConfEst.Visible = false;
                divEst.Visible = true;
                Label1.Text = "No esta permitido, el estudiante ya tiene calificaciones";
            }   
        }

        protected void EliminarProf_Click(object sender, EventArgs e)
        {
            int count2 = 0;

            foreach (CalificacionesRow calificacion in calificaciones.GetData().Rows)
            {
                if (calificacion["IdProfesor"].ToString() == RadioButtonListProf.SelectedValue.ToString())
                    count2++;
            }
            if (count2 == 0)
            {
                profesores.Delete(RadioButtonListProf.SelectedValue);
                autenticacion.Delete(RadioButtonListProf.SelectedValue);
                divProf.Visible = false;
                divConfProf.Visible = false;
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                divConfProf.Visible = false;
                divProf.Visible = true;
                Label2.Text = "No esta permitido, el profesor ya publicó calificaciones";
            }   
        }

        protected void EliminarAsig_Click(object sender, EventArgs e)
        {
            int count3 = 0;

            foreach (CalificacionesRow calificacion in calificaciones.GetData().Rows)
            {
                if (calificacion["ClaveAsignatura"].ToString() == RadioButtonListAsig.SelectedValue.ToString())
                    count3++;
            }
            if (count3 == 0)
            {
                asignaturas.Delete(RadioButtonListAsig.SelectedValue);
                divAsig.Visible = false;
                divConfAsig.Visible = false;
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                divConfAsig.Visible = false;
                divAsig.Visible = true;
                Label3.Text = "No esta permitido, la asignatura ya tiene calificaciones";
            }
        }

        
    }
}