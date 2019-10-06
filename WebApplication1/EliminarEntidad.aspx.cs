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
            ViewState["elimEst"] = true;
            ViewState["elimProf"] = false;
            ViewState["elimAsig"] = false;
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
            ViewState["elimEst"] = false;
            ViewState["elimProf"] = true;
            ViewState["elimAsig"] = false;
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
            ViewState["elimEst"] = false;
            ViewState["elimProf"] = false;
            ViewState["elimAsig"] = true;
            Label3.Text = "";

            RadioButtonListAsig.Items.Clear();
            foreach (AsignaturasRow asig in asignaturas.GetData().Rows)
            {
                RadioButtonListAsig.Items.Add(new ListItem(asig["Clave"].ToString() + " - " + asig["NombreAsig"].ToString(), asig["Clave"].ToString()));
            }

            divAsig.Visible = true;
        }

        protected void TryEliminarEst_Click(object sender, EventArgs e)
        {
            if (RadioButtonListEst.SelectedIndex != -1)
            {
                divEst.Visible = false;
                div1.Visible = false;

                Label5.Text = RadioButtonListEst.SelectedItem.Text.ToString();

                divConf.Visible = true;
            }
            else
                Label1.Text = "Seleccione un estudiante";

        }
        protected void TryEliminarProf_Click(object sender, EventArgs e)
        {
            if (RadioButtonListProf.SelectedIndex != -1)
            {
                divProf.Visible = false;
                div1.Visible = false;

                Label5.Text = RadioButtonListProf.SelectedItem.Text.ToString();

                divConf.Visible = true;
            }
            else
                Label2.Text = "Seleccione un profesor";

        }
        protected void TryEliminarAsig_Click(object sender, EventArgs e)
        {
            if (RadioButtonListAsig.SelectedIndex != -1)
            {
                divAsig.Visible = false;
                div1.Visible = false;

                Label5.Text = RadioButtonListAsig.SelectedItem.Text.ToString();

                divConf.Visible = true;
            }
            else
                Label3.Text = "Seleccione una asignatura";
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            if ((bool)ViewState["elimEst"] == true)
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
                    divConf.Visible = false;
                    lblEntidadEliminada.Text = "Estudiante eliminado";
                    terminado.Visible = true;
                }
                else
                {
                    div1.Visible = false;
                    divConf.Visible = false;
                    divEst.Visible = true;
                    Label1.Text = "No esta permitido, el estudiante ya tiene calificaciones";
                }
            }
            else if ((bool)ViewState["elimProf"] == true)
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
                    divConf.Visible = false;
                    lblEntidadEliminada.Text = "Profesor eliminado";
                    terminado.Visible = true;
                }
                else
                {
                    div1.Visible = false;
                    divConf.Visible = false;
                    divProf.Visible = true;
                    Label2.Text = "No esta permitido, el profesor ya publicó calificaciones";
                }
            }
            else if ((bool)ViewState["elimAsig"] == true)
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
                    divConf.Visible = false;
                    lblEntidadEliminada.Text = "Asignatura eliminada";
                    terminado.Visible = true;
                }
                else
                {
                    div1.Visible = false;
                    divConf.Visible = false;
                    divAsig.Visible = true;
                    Label3.Text = "No esta permitido, la asignatura ya tiene calificaciones";
                }

            }
               
        }

        protected void BtnVolverAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarEntidad");
        }
        protected void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores");
        }
    }
}