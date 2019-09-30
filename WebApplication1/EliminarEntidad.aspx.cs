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
            div1.Visible = true;
            //if (!IsPostBack)
            //{
            //    if (Session["Role"] != null && (Session["Role"].ToString() == "admin"))
            //    {
            //        div1.Visible = true;
            //        estudiantes = new EstudiantesTableAdapter();
            //        profesores = new ProfesoresTableAdapter();
                   

                    
            //    }
            //    else
            //    {
            //        Response.Redirect("Default");
            //    }
            //}
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            div1.Visible = false;

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
            div1.Visible = true;
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
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
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
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                Label2.Text = "No esta permitido, el profesor ya publicó calificaciones";
            }   
        }

        protected void EliminarAsig_Click(object sender, EventArgs e)
        {
            int count3 = 0;

            foreach (CalificacionesRow calificacion in calificaciones.GetData().Rows)
            {
                if (calificacion["ClaveAsignatura"].ToString() == RadioButtonListProf.SelectedValue.ToString())
                    count3++;
            }
            if (count3 == 0)
            {
                asignaturas.Delete(RadioButtonListAsig.SelectedValue);
                divAsig.Visible = false;
                div1.Visible = true;
            }
            else
            {
                div1.Visible = false;
                Label3.Text = "No esta permitido, la asignatura ya tiene calificaciones";
            }
        }
    }
}