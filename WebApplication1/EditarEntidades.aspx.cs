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
        //page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "administrador"))
                {
                    radbtnEntidades.Items.Add("Estudiante");
                    radbtnEntidades.Items.Add("Profesor");
                    radbtnEntidades.Items.Add("Asignatura");
                    radbtnEntidades.Items.Add("Calificacion");
                    wcEditarEntidad.Visible = true;
                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        //edicion
        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores");
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
            else if (this.radbtnEntidades.SelectedValue == "Calificacion")
            {
                

                ListCalEstTableAdapter calEstTableAdapter = new ListCalEstTableAdapter();
                foreach (ListCalEstRow row in calEstTableAdapter.GetData().Rows)
                {
                    RBLcalif.Items.Add(new ListItem(
                        "Estudiante: " + row["IdEst"].ToString() + " - " + row["NombreEst"].ToString() + 
                        " / Asignatura: " + row["Clave"].ToString() + " - " + row["NombreAsig"].ToString() + 
                        " / Profesor: " + row["IdProf"].ToString() + " - " + row["NombreProf"].ToString() +
                        " / Calificacion: " + row["Valor"].ToString() + " - " + row["Alpha"].ToString(), row["IdCal"].ToString()));
                }
                this.wcEditarEntidad.Visible = false;
                this.Calificacion.Visible = true;
            }
            else
            {
                this.lblWarn.Visible = true;
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void radbtnEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //estudiantes
        protected void btnVolverEstudiante_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            ViewState["IdEditarEst"] = null;
            this.txtNombreEstudiante.Text = "";
            this.txtIDEstudiante.Text = "";
            this.lblWarn.Visible = false;
        }
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
            ViewState["nombre"] = false;
            ViewState["ID"] = false;


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
                ViewState["nombre"] = true;
            }
            else if (this.radbtnElegirDatosEst.SelectedValue == "Cambiar ID")
            {
                this.lblEstudiante.Text = $"Cambiar estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";

                this.ElegirCambioEst.Visible = false;

                this.CambiarEstudiante.Visible = true;

                this.txtNombreEst.Visible = false;
                this.txtIDEst.Visible = true;

                ViewState["ID"] = true;

            }
            else if (this.radbtnElegirDatosEst.SelectedValue == "Cambiar Ambos")
            {
                this.lblEstudiante.Text = $"Cambiar estudiante {estudiantesTableAdapter.GetNombreEst(ViewState["IdEditarEst"].ToString())}";

                this.ElegirCambioEst.Visible = false;

                this.CambiarEstudiante.Visible = true;

                this.txtNombreEst.Visible = true;
                this.txtIDEst.Visible = true;

                ViewState["nombre"] = true;
                ViewState["ID"] = true;
            }
            else
            {
                this.lblWarnrad.Visible = true;
            }

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
            //estudiantesTableAdapter.ChangeEstName(txtNombreEstudiante.Text.ToString().ToUpper(), ViewState["IdEditarEst"].ToString());

            if ((bool)ViewState["nombre"])
            {
                estudiantesTableAdapter.ChangeEstName(txtNombreEstudiante.Text.ToString().ToUpper(), ViewState["IdEditarEst"].ToString());
            }
            if ((bool)ViewState["ID"])
            {
                estudiantesTableAdapter.ChangeEstId(txtIDEstudiante.Text.ToString(),ViewState["IdEditarEst"].ToString());
            }
            //ViewState["IdEditarEst"] = null;
            Response.Redirect("Administradores");
        }
        protected void btnCancelarEst_Click(object sender, EventArgs e)
        {
            this.ConfirmarEst.Visible = false;
            this.CambiarEstudiante.Visible = true;
            this.lblWarnTxt0.Visible = false;
        }
        
        
        //profesores
        protected void btnVolverProfesor_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            ViewState["IdEditarProf"] = null;
            this.lblWarnradp.Visible = false;
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
                    this.idprof.Visible = false;
                }
                else
                {
                    this.radbtnElegirDatosProf.Items.Add("Cambiar ID");
                    this.radbtnElegirDatosProf.Items.Add("Cambiar Ambos");
                    this.nombreprof.Visible = true;
                }
            }
            else
            {
                this.lblWarnProf.Visible = true;
            }
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
            ViewState["nombreprof"] = false;
            ViewState["IDprof"] = false;

            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
            if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar nombre")
            {
                this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";
                this.ElegirCambioProf.Visible = false;

                this.CambiarProfesor.Visible = true;
                this.idprof.Visible = false;
                this.nombreprof.Visible = true;
                ViewState["nombreprof"] = true;

            }
            else if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar ID")
            {
                this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";

                this.ElegirCambioProf.Visible = false;

                this.CambiarProfesor.Visible = true;

                this.nombreprof.Visible = false;
                this.idprof.Visible = true;
                ViewState["IDprof"] = true;

            }
            else if (this.radbtnElegirDatosProf.SelectedValue == "Cambiar Ambos")
            {
                this.lblProfesor.Text = $"Cambiar profesor {profesoresTableAdapter.GetProfName(ViewState["IdEditarProf"].ToString())}";

                this.ElegirCambioProf.Visible = false;

                this.CambiarProfesor.Visible = true;

                this.nombreprof.Visible = true;
                this.idprof.Visible = true;

                ViewState["nombreprof"] = true;
                ViewState["IDprof"] = true;

            }
            else
            {
                this.lblWarnradp.Visible = true;
            }

        }
        protected void btnVolverCambioProfesor_Click(object sender, EventArgs e)
        {
            this.CambiarProfesor.Visible = false;
            this.ElegirCambioProf.Visible = true;
            this.txtNombreProfesor.Text = "";
            this.txtIDProfesor.Text = "";
            this.lblWarnradp.Visible = false;
        }               
        protected void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;

            if (!this.txtIDProfesor.Visible)
            {
                if (txtNombreProfesor.Text != "")
                {
                    this.CambiarProfesor.Visible = false;
                    this.ConfirmarProf.Visible = true;
                    this.lblConfirmarNombreProf.Visible = true;
                    lblConfirmarNombreProf.Text = $"Nombre del profesor: {txtNombreProfesor.Text.ToString().ToUpper()}";
                }
                else
                {
                    this.lblWarnTxt1.Visible = true;
                }
            }
            else if (!this.txtNombreProfesor.Visible)
            {
                if (this.txtIDProfesor.Text.Length == 7)
                {
                    this.CambiarProfesor.Visible = false;
                    this.ConfirmarProf.Visible = true;
                    this.lblConfirmarIDProf.Visible = true;
                    lblConfirmarIDProf.Text = $"ID del profesor: {txtIDProfesor.Text.ToString().ToUpper()}";
                }
                else
                {
                    this.lblWarnTxt1.Visible = true;
                }
            }
            else if (this.txtNombreProfesor.Visible && this.txtIDProfesor.Visible)
            {
                if (this.txtNombreProfesor.Text != "" && this.txtIDProfesor.Text.Length == 7)
                {
                    this.CambiarProfesor.Visible = false;
                    this.ConfirmarProf.Visible = true;
                    this.lblConfirmarNombreProf.Visible = true;
                    this.lblConfirmarIDProf.Visible = true;
                    lblConfirmarNombreProf.Text = $"Nombre del profesor: {txtNombreProfesor.Text.ToString().ToUpper()}";
                    lblConfirmarIDProf.Text = $"ID del profesor: {txtIDProfesor.Text.ToString()}";
                }
                else
                {
                    this.lblWarnTxt1.Visible = true;
                }
            }
        }              
        protected void btnConfirmarProf_Click(object sender, EventArgs e)
        {
            this.lblWarnProf.Visible = false;
            this.lblWarnradp.Visible = false;
            this.lblWarnTxt1.Visible = false;
            ProfesoresTableAdapter profesoresTableAdapter = new ProfesoresTableAdapter();
            //profesoresTableAdapter.ChangeProfName(txtNombreProfesor.Text.ToString().ToUpper(), ViewState["IdEditarProf"].ToString());
            if ((bool)ViewState["nombreprof"])
            {
                profesoresTableAdapter.ChangeProfName(txtNombreProfesor.Text.ToString().ToUpper(), ViewState["IdEditarProf"].ToString());
            }
            if ((bool)ViewState["IDprof"])
            {
                profesoresTableAdapter.ChangeProfID(txtIDProfesor.Text.ToString(), ViewState["IdEditarProf"].ToString());
            }
            //ViewState["IdEditarProf"] = null;
            Response.Redirect("Administradores");
        }
        protected void btnCancelarProf_Click(object sender, EventArgs e)
        {
            this.ConfirmarProf.Visible = false;
            this.CambiarProfesor.Visible = true;
            this.lblWarnTxt1.Visible=false;
        }


        //asignaturas
        protected void btnVolverAsignatura_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarEntidades");
            ViewState["IdEditarAsig"] = null;
            this.lblWarnrada.Visible = false;
        }
        protected void btnEditarAsignatura_Click(object sender, EventArgs e)
        {
            this.lblWarnAsig.Visible = false;
            this.lblWarnrada.Visible = false;
            this.lblWarnTxt2.Visible = false;
            AsignaturasTableAdapter asignaturaTableAdapter = new AsignaturasTableAdapter();
            if (this.radbtnAsignaturas.SelectedValue != "")
            {
                ViewState["IdEditarAsig"] = this.radbtnAsignaturas.SelectedValue.Substring(0, 6);
                this.lblElegirDatosa.Text = $"Elija que desea cambiar de la asignatura {asignaturaTableAdapter.GetAsigName(ViewState["IdEditarAsig"].ToString())}";
                this.CheckBoxListAsig.Items.Add("Cambiar nombre");
                
                this.asignatura.Visible = false;
                this.ElegirCambioAsig.Visible = true;

                if (asignaturaTableAdapter.GetUse(ViewState["IdEditarAsig"].ToString()).ToString() == "si")
                {
                    this.claveasig.Visible = false;
                    this.creditoasig.Visible = false;
                }
                else
                {
                    this.CheckBoxListAsig.Items.Add("Cambiar clave");
                    this.CheckBoxListAsig.Items.Add("Cambiar no. de creditos");
                    
                    this.claveasig.Visible = true;
                    this.creditoasig.Visible = true;
                }
            }
            else
            {
                this.lblWarnAsig.Visible = true;
            }
        }
        protected void btnVolverElegirAsig_Click(object sender, EventArgs e)
        {
            this.ElegirCambioAsig.Visible = false;
            this.asignatura.Visible = true;
            ViewState["IdEditarAsig"] = null;
            this.CheckBoxListAsig.Items.Clear();
            this.txtNombreAsignatura.Text = "";
            this.txtClave.Text = "";
            this.txtCreditosAsignatura.Text = "";
            this.lblWarnAsig.Visible = false;
        }
        protected void btnContinuarAsig_Click(object sender, EventArgs e)
        {
            ViewState["Cambiar nombre"]=false;
            ViewState["Cambiar clave"]=false;
            ViewState["credito"]=false;

            this.lblWarnAsig.Visible = false;
            this.lblWarnrada.Visible = false;
            this.lblWarnTxt2.Visible = false;

            this.nombreasig.Visible = false;
            this.claveasig.Visible = false;
            this.creditoasig.Visible = false;

            //string[] datos = new string[3];
            //datos[0] = "Cambiar nombre";
            //datos[1] = "Cambiar clave";
            //datos[2] = "Cambiar no. de creditos";
            AsignaturasTableAdapter asignaturasTableAdapter = new AsignaturasTableAdapter();
            //this.CheckBoxListAsig.Items.s
            if (this.CheckBoxListAsig.SelectedValue != "")
            {
                foreach (ListItem item in this.CheckBoxListAsig.Items)
                {
                    if (item.Selected)
                    {
                        if (item.Text=="Cambiar nombre")
                        {
                            this.nombreasig.Visible = true;
                            ViewState["Cambiar nombre"] = true;
                        }
                        if (item.Text == "Cambiar clave")
                        {
                            this.claveasig.Visible = true;
                            ViewState["Cambiar clave"] = true;

                        }
                        if (item.Text == "Cambiar no. de creditos")
                        {
                            this.creditoasig.Visible = true;
                            ViewState["credito"] = true;

                        }
                    }

                }
                this.lblProfesor.Text = $"Cambiar asignatura {asignaturasTableAdapter.GetAsigName(ViewState["IdEditarAsig"].ToString())}";
                this.ElegirCambioAsig.Visible = false;
                this.CambiarAsignatura.Visible = true;
            }
            else
            {
                this.lblWarnrada.Visible = true;
            }
        }
        protected void btnVolverCambioAsignatura_Click(object sender, EventArgs e)
        {
            this.CambiarAsignatura.Visible = false;
            this.ElegirCambioAsig.Visible = true;
            this.nombreasig.Visible = false;
            this.claveasig.Visible = false;
            this.creditoasig.Visible = false;
            this.txtNombreAsignatura.Text = "";
            this.txtClave.Text = "";
            this.txtCreditosAsignatura.Text = "";
            this.lblWarnrada.Visible = false;
        }
        protected void btnModificarAsignatura_Click(object sender, EventArgs e)
        {
            this.lblWarnAsig.Visible = false;
            this.lblWarnrada.Visible = false;
            this.lblWarnTxt2.Visible = false;

            int total = 0;
            int hecho = 0;
            if (this.nombreasig.Visible)
            {
                total++;
                if (this.txtNombreAsignatura.Text != "")
                {
                    hecho++;
                    this.lblConfirmarNombreAsig.Visible = true;
                    lblConfirmarNombreAsig.Text = $"Nombre de la asignatura: {txtNombreAsignatura.Text.ToString().ToUpper()}";
                }
                else
                {
                    this.lblWarnTxt2.Visible = true;
                }
            }


            if (this.claveasig.Visible)
            {
                total++;
                if (this.txtClave.Text.Length == 6)
                {
                    hecho++;
                    this.lblConfirmarClaveAsig.Visible = true;
                    lblConfirmarClaveAsig.Text = $"Clave de la asignatura: {txtClave.Text.ToString()}";
                }
                else
                {
                    this.lblWarnTxt2.Visible = true;
                }
            }
            
            int num;
            if (this.creditoasig.Visible)
            {
                total++;
                if (int.TryParse(this.txtCreditosAsignatura.Text.ToString(), out num))
                {
                    hecho++;
                    this.lblConfirmarCreditosAsig.Visible = true;
                    lblConfirmarCreditosAsig.Text = $"No. de creditos de la asignatura: {txtCreditosAsignatura.Text.ToString()}";
                }
                else
                {
                    this.lblWarnTxt2.Visible = true;
                }
            }

            if (hecho == total)
            {
                this.CambiarAsignatura.Visible = false;
                this.ConfirmarAsig.Visible = true;
            }
            else
            {
                this.lblWarnTxt2.Visible = true;
            }
            
               
        }           
        protected void btnConfirmarAsig_Click(object sender, EventArgs e)
        {
            this.lblWarnAsig.Visible = false;
            this.lblWarnrada.Visible = false;
            this.lblWarnTxt2.Visible = false;
            AsignaturasTableAdapter asignaturasTableAdapter = new AsignaturasTableAdapter();
            //asignaturasTableAdapter.ChangeAsigName(txtNombreAsignatura.Text.ToString().ToUpper(), ViewState["IdEditarAsig"].ToString());
            if ((bool)ViewState["Cambiar nombre"])
            {
                //int cr = int.Parse(txtCreditosAsignatura.Text.ToString());
                asignaturasTableAdapter.ChangeAsigName(txtNombreAsignatura.Text.ToString().ToUpper(), ViewState["IdEditarAsig"].ToString());
            }
            if ((bool)ViewState["credito"])
            {
                int cr = int.Parse(txtCreditosAsignatura.Text.ToString());
                asignaturasTableAdapter.ChangeCreditoAsig(cr, ViewState["IdEditarAsig"].ToString());
            }
            if ((bool) ViewState["Cambiar clave"])
            {
                asignaturasTableAdapter.ChangeAsigID(txtClave.Text.ToString(), ViewState["IdEditarAsig"].ToString());
            }
            //ViewState["IdEditarAsig"] = null;
            Response.Redirect("Administradores");
        }
        protected void btnCancelarAsig_Click(object sender, EventArgs e)
        {
            
            this.ConfirmarAsig.Visible = false;
            this.CambiarAsignatura.Visible = true;
            this.lblWarnTxt2.Visible = false;
        }
        
                
        //radbtn
        protected void radbtnElegirDatos_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void radbtnProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void radbtnAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btEditarCal_Click(object sender, EventArgs e)
        {
            this.LblCalSelWarn.Visible = false;
                       
            if (this.RBLcalif.SelectedIndex > -1)
            {
                ViewState["IdEditarCal"] = RBLcalif.SelectedValue;
                this.LblDatosCal.Text = RBLcalif.SelectedItem.Text;
                Calificacion.Visible = false;
                ModCal.Visible = true;               
            }
            else
            {
                this.LblCalSelWarn.Visible = true;
            }
        }

        protected void BtModCal_Click(object sender, EventArgs e)
        {
            this.LblCalSelWarn.Visible = false;

            EstudiantesTableAdapter estudiantesTableAdapter = new EstudiantesTableAdapter();
            

            int valorCal;
            if (int.TryParse(TbNuevaCal.Text, out valorCal) && valorCal <= 100 && valorCal >= 0)
            {
                string alpha = "";
                int cal = valorCal;
                if (cal <= 100 && cal >= 90) alpha = "A";
                else if (cal <= 89 && cal >= 80) alpha = "B";
                else if (cal <= 79 && cal >= 70) alpha = "C";
                else if (cal <= 69 && cal >= 60) alpha = "D";
                else if (cal <= 59 && cal >= 0) alpha = "F";
                ViewState["alpha"] = alpha;

                LblDatosCalCon.Text = RBLcalif.SelectedItem.Text;
                LblNuevaCal.Text = "Nueva calificacion: " + TbNuevaCal.Text + " - " + alpha;
                    
                ViewState["valorCal"] = valorCal;

                ModCal.Visible = false;
                ConfirmarCal.Visible = true;
            }
            else
            {
                this.LblCalModWarn.Visible = true;
            }
            
            
        }

        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            CalificacionesTableAdapter calificaciones = new CalificacionesTableAdapter();

            int IDcal = int.Parse(ViewState["IdEditarCal"].ToString());

            calificaciones.ModCalifByIdCal((int)ViewState["valorCal"], ViewState["alpha"].ToString(), IDcal);
            DataUpdate.UpdateDatosEstudiante(calificaciones.GetIdEstByIdCal(IDcal));
            Response.Redirect("Administradores");
        }

        protected void BtCancelCalif_Click(object sender, EventArgs e)
        {
            LblCalModWarn.Visible = false;   
            ConfirmarCal.Visible = false;
            ModCal.Visible = true;

        }
    }
}