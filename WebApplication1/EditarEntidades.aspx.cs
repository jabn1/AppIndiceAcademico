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
            this.lblWarn.Visible = false;
            this.lblWarnEst.Visible = false;
            this.lblWarnrad.Visible = false;
            this.lblWarnTxt0.Visible = false;
            if (this.radbtnEntidades.SelectedValue == "Estudiante")
            {
                this.wcEditarEntidad.Visible = false;
                this.estudiante.Visible = true;

                EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();

                foreach (EstudiantesRow row in estudiantesTableAdapter.GetData())
                {
                    radbtnEstudiantes.Items.Add(new ListItem(row["IdEst"].ToString() + " - " + row["NombreEst"].ToString(), row["IdEst"].ToString()));
                }
            }
            else if (this.radbtnEntidades.SelectedValue == "Profesor")
            {
                this.wcEditarEntidad.Visible = false;
                this.profesor.Visible = true;

                ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();

                foreach (ProfesoresRow row in profesoresTableAdapter.GetData())
                {
                    radbtnProfesores.Items.Add(new ListItem(row["IdProf"].ToString() + " - " + row["NombreProf"].ToString(), row["IdProf"].ToString()));
                }
            }
            else if (this.radbtnEntidades.SelectedValue == "Asignatura")
            {
                this.wcEditarEntidad.Visible = false;
                this.asignatura.Visible = true;

                AsignaturasTableAdapter asignaturasTableAdapter = new AsignaturasTableAdapter();

                foreach (AsignaturasRow row in asignaturasTableAdapter.GetData())
                {
                    radbtnAsignaturas.Items.Add(new ListItem(row["Clave"].ToString() + " - " + row["NombreAsig"].ToString(), row["Clave"].ToString()));
                }
            }
            else
            {
                this.lblWarn.Visible = true;
            }
        }

        //estudiantes
        protected void btnEditarEstudiante_Click(object sender, EventArgs e)
        {
            this.lblWarn.Visible = false;
            this.lblWarnEst.Visible = false;
            this.lblWarnrad.Visible = false;
            this.lblWarnTxt0.Visible = false;
            EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();
            if (this.radbtnEstudiantes.SelectedValue != "")
            {
                ViewState["IdEditarEst"] = this.radbtnEstudiantes.SelectedValue.Substring(0, 7);
                this.lblElegirDatos.Text = $"Elija que desea cambiar del estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";
                this.radbtnElegirDatosEst.Items.Add("Cambiar nombre");
                this.estudiante.Visible = false;
                this.ElegirCambioEst.Visible = true;

                if (estudiantesTableAdapter.GetStudentsNotInUses(ViewState["IdEditarEst"].ToString()).ToString() == "si")
                {
                    this.txtIDEst.Visible = false;
                }
                else
                {
                    this.radbtnElegirDatosEst.Items.Add("Cambiar ID");
                    this.radbtnElegirDatosEst.Items.Add("Cambiar Ambos");
                    this.txtIDEst.Visible = true;
                }
            }
            else
            {
                this.lblWarnEst.Visible = true;
            }
        }
        protected void btnVolverEstudiante_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            ViewState["IdEditarEst"] = null;
            this.txtNombreEstudiante.Text = "";
            this.txtIDEstudiante.Text = "";
            this.lblWarn.Visible = false;
        }
        protected void btnVolverCambioEstudiante_Click(object sender, EventArgs e)
        {
            this.CambiarEstudiante.Visible = false;
            this.ElegirCambioEst.Visible = true;
            //this.radbtnElegirDatosEst.Items.Clear();
            this.txtNombreEstudiante.Text = "";
            this.txtIDEstudiante.Text = "";
            this.lblWarnrad.Visible = false;
        }
        protected void btnModificarEstudiante_Click(object sender, EventArgs e)
        {
            this.lblWarn.Visible = false;
            this.lblWarnEst.Visible = false;
            this.lblWarnrad.Visible = false;
            this.lblWarnTxt0.Visible = false;
            if(!this.txtIDEstudiante.Visible)
            {
                if (txtNombreEstudiante.Text != "")
                {
                    this.CambiarEstudiante.Visible = false;
                    this.ConfirmarEst.Visible = true;
                    this.lblConfirmarNombreEst.Visible = true;                    
                    lblConfirmarNombreEst.Text = $"Nombre del estudiante: {txtNombreEstudiante.Text.ToString().ToUpper()}";
                }
                else
                {
                    this.lblWarnTxt0.Visible = true;
                }
            }
            else if(!this.txtNombreEstudiante.Visible)
            {
                if (this.txtIDEstudiante.Text.Length==7)
                {
                    this.CambiarEstudiante.Visible = false;
                    this.ConfirmarEst.Visible = true;
                    this.lblConfirmarIDEst.Visible = true;
                    lblConfirmarIDEst.Text = $"ID del estudiante: {txtIDEstudiante.Text.ToString().ToUpper()}"; 
                }
                else
                {
                    this.lblWarnTxt0.Visible = true;
                }
            }
            else if (this.txtNombreEstudiante.Visible && this.txtIDEstudiante.Visible)
            {
                if (this.txtNombreEstudiante.Text != "" && this.txtIDEstudiante.Text.Length == 7)
                {
                    this.CambiarEstudiante.Visible = false;
                    this.ConfirmarEst.Visible = true;
                    this.lblConfirmarNombreEst.Visible = true;
                    this.lblConfirmarIDEst.Visible = true;
                    lblConfirmarNombreEst.Text = $"Nombre del estudiante: {txtNombreEstudiante.Text.ToString().ToUpper()}";
                    lblConfirmarIDEst.Text = $"ID del estudiante: {txtIDEstudiante.Text.ToString()}";
                }
                else
                {
                    this.lblWarnTxt0.Visible = true;
                }
            }
            
        }
        protected void btnConfirmarEst_Click(object sender, EventArgs e)
        {
            this.lblWarn.Visible = false;
            this.lblWarnEst.Visible = false;
            this.lblWarnrad.Visible = false;
            this.lblWarnTxt0.Visible = false;
            EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();
            estudiantesTableAdapter.ChangeEstName(txtNombreEstudiante.Text.ToString().ToUpper(), ViewState["IdEditarEst"].ToString());
            if(txtIDEstudiante.Visible)
            {
                estudiantesTableAdapter.ChangeEstId(txtIDEstudiante.Text.ToString(),ViewState["IdEditarEst"].ToString());
            }
            ViewState["IdEditarEst"] = null;
            Response.Redirect("Administradores");
        }
        protected void btnCancelarEst_Click(object sender, EventArgs e)
        {
            this.ConfirmarEst.Visible = false;
            this.CambiarEstudiante.Visible = true;
            this.lblWarnTxt0.Visible = false;
        }
        protected void btnVolverElegirEst_Click(object sender, EventArgs e)
        {
            this.ElegirCambioEst.Visible = false;
            this.estudiante.Visible = true;
            ViewState["IdEditarEst"] = null;
            this.radbtnElegirDatosEst.Items.Clear();
            this.txtNombreEstudiante.Text = "";
            this.txtIDEstudiante.Text = "";
            this.lblWarnEst.Visible = false;
        }
        protected void btnContinuarEst_Click(object sender, EventArgs e)
        {
            this.lblWarn.Visible = false;
            this.lblWarnEst.Visible = false;
            this.lblWarnrad.Visible = false;
            this.lblWarnTxt0.Visible = false;
            //this.ElegirCambioEst.Visible = false;
            EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();
            if (this.radbtnElegirDatosEst.SelectedValue == "Cambiar nombre")
            {
                this.lblEstudiante.Text = $"Cambiar estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";
                this.ElegirCambioEst.Visible = false;

                this.CambiarEstudiante.Visible = true;
                this.txtIDEst.Visible = false;
                this.txtNombreEst.Visible = true;
            }
            else if (this.radbtnElegirDatosEst.SelectedValue == "Cambiar ID")
            {
                this.lblEstudiante.Text = $"Cambiar estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";

                this.ElegirCambioEst.Visible = false;

                this.CambiarEstudiante.Visible = true;

                this.txtNombreEst.Visible = false;
                this.txtIDEst.Visible = true;
            }
            else if (this.radbtnElegirDatosEst.SelectedValue == "Cambiar Ambos")
            {
                this.lblEstudiante.Text = $"Cambiar estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";

                this.ElegirCambioEst.Visible = false;

                this.CambiarEstudiante.Visible = true;

                this.txtNombreEst.Visible = true;
                this.txtIDEst.Visible = true;
            }
            else
            {
                this.lblWarnrad.Visible = true;
            }

        }
        
        
        
        
        //profesores
        protected void btnVolverProfesor_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            ViewState["IdEditarProf"] = null;
            this.lblWarnradp.Visible = false;
        }
        protected void btnVolverCambioProfesor_Click(object sender, EventArgs e)
        {
            this.CambiarProfesor.Visible = false;
            this.ElegirCambioProf.Visible = true;
            this.txtNombreProfesor.Text = "";
            this.txtIDProfesor.Text = "";
            this.lblWarnradp.Visible = false;
        }
        protected void radbtnProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnEditarProfesor_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
            if (this.radbtnProfesores.SelectedValue != "")
            {
                ViewState["IdEditarProf"] = this.radbtnProfesores.SelectedValue.Substring(0, 7);
                this.lblElegirDatosp.Text = $"Elija que desea cambiar del profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";
                this.radbtnElegirDatosProf.Items.Add("Cambiar nombre");
                this.profesor.Visible = false;
                this.ElegirCambioProf.Visible = true;

                if (profesoresTableAdapter.GetUse(ViewState["IdEditarProf"].ToString()).ToString() == "si")
                {
                    this.txtIDProfesor.Visible = false;
                }
                else
                {
                    this.radbtnElegirDatosProf.Items.Add("Cambiar ID");
                    this.radbtnElegirDatosProf.Items.Add("Cambiar Ambos");
                    this.txtIDProfesor.Visible = true;
                }
            }
            else
            {
                this.lblWarnProf.Visible = true;
            }
        }
        protected void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            if (this.txtNombreProfesor.Text != "" && this.txtIDProfesor.Text.Length == 7)
            {
                this.CambiarProfesor.Visible = false;
                this.ConfirmarProf.Visible = true;
                this.lblConfirmarNombreProf.Visible = true;
                this.lblConfirmarIDProf.Visible = true;
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar nombre")
                {
                    lblConfirmarNombreProf.Text = $"Nombre del profesor: {txtNombreProfesor.Text.ToString().ToUpper()}";
                }
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar ID")
                {
                    lblConfirmarIDProf.Text = $"ID del profesor: {txtIDProfesor.Text.ToString()}";
                }
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar Ambos")
                {
                    lblConfirmarNombreProf.Text = $"Nombre del profesor: {txtNombreProfesor.Text.ToString().ToUpper()}";
                    lblConfirmarIDEst.Text = $"ID del estudiante: {txtIDProfesor.Text.ToString()}";
                }
            }
            else
            {
                this.lblWarnTxt1.Visible = true;
            }
        }



        //asignaturas
        protected void btnVolverAsignatura_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            Session["IdEditarAsig"] = null;
        }       
        protected void btnVolverCambioAsignatura_Click(object sender, EventArgs e)
        {
            this.CambiarAsignatura.Visible = false;
            this.asignatura.Visible = true;
        }
        protected void radbtnAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnEditarAsignatura_Click(object sender, EventArgs e)
        {
            AsignaturasTableAdapter asignaturaTableAdapter = new AsignaturasTableAdapter();
            Session["IdEditarAsig"] = this.radbtnAsignaturas.SelectedValue.Substring(0, 6);
            this.asignatura.Visible = false;
            this.CambiarAsignatura.Visible = true;
            this.lblAsignatura.Text = "Cambiar asignatura " + asignaturaTableAdapter.GetAsigName(Session["IdEditarAsig"].ToString());

            if (asignaturaTableAdapter.GetUse(Session["IdEditarAsig"].ToString()).ToString() == "si")
            {
                this.CambioClave.Visible = false;
                this.CambioCreditos.Visible = false;
            }
            else
            {
                this.CambioClave.Visible = true;
                this.CambioCreditos.Visible = true;
            }
        }     
        protected void btnModificarAsignatura_Click(object sender, EventArgs e)
        {

        }

        protected void radbtnElegirDatos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnVolverElegirProf_Click(object sender, EventArgs e)
        {
            this.ElegirCambioProf.Visible = false;
            this.profesor.Visible = true;
            ViewState["IdEditarProf"] = null;
            this.radbtnElegirDatosProf.Items.Clear();
            this.txtNombreProfesor.Text = "";
            this.txtIDProfesor.Text = "";
            this.lblWarnProf.Visible = false;
        }

        protected void btnContinuarProf_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
            if (this.radbtnElegirDatosProf.SelectedValue != "")
            {
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar nombre")
                {
                    this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";
                    this.ElegirCambioProf.Visible = false;
                    this.CambiarProfesor.Visible = true;
                    this.idprof.Visible = false;
                    this.nombreprof.Visible = true;
                }
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar ID")
                {
                    this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";
                    this.ElegirCambioProf.Visible = false;

                    this.CambiarProfesor.Visible = true;
                    this.nombreprof.Visible = false;
                    this.idprof.Visible = true;
                }
                if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar Ambos")
                {
                    this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";
                    this.ElegirCambioProf.Visible = false;

                    this.CambiarProfesor.Visible = true;
                    this.idprof.Visible = true;
                    this.nombreprof.Visible = true;
                } 
            }
            else
            {
                this.lblWarnradp.Visible = true;
            }

        }

        protected void btnConfirmarProf_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
            profesoresTableAdapter.ChangeProfName(txtNombreProfesor.Text.ToString().ToUpper(), ViewState["IdEditarProf"].ToString());
            if (txtIDProfesor.Visible)
            {
                profesoresTableAdapter.ChangeProfID(txtIDEstudiante.Text.ToString(), ViewState["IdEditarProf"].ToString());
            }
            ViewState["IdEditarProf"] = null;
            Response.Redirect("Administradores");
        }

        protected void btnCancelarProf_Click(object sender, EventArgs e)
        {
            this.ConfirmarProf.Visible = false;
            this.CambiarProfesor.Visible = true;
            this.lblWarnTxt1.Visible=false;
        }
    }
}