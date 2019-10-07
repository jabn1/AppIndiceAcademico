using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Database1DataSetTableAdapters;
using static WebApplication1.Database1DataSet;

namespace WebApplication1
{
    
    public partial class AgregarEntidad : System.Web.UI.Page
    {
        private DataUpdate dataUpdate = new DataUpdate();
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
                    this.btnAgregar.Visible = false;
                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        protected void btnAgregarEst_Click(object sender, EventArgs e)
        {

            div1.Visible = false;
            divEst.Visible = true;
            ViewState["agrEst"] = true;
            ViewState["agrProf"] = false;
            ViewState["agrAsig"] = false;
            this.btnAgregar.Visible = true;
        }

        protected void btnAgregarProf_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            divProf.Visible = true;
            
            this.btnAgregar.Visible = true;
            ViewState["agrEst"] =false;
            ViewState["agrProf"] = true;
            ViewState["agrAsig"] = false;

        }

        protected void btnAgregarAsig_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            divAsig.Visible = true;
            ViewState["agrEst"] = false;
            ViewState["agrProf"] = false;
            ViewState["agrAsig"] = true;
            this.btnAgregar.Visible = true;

        }

        protected void btVolverAgr_Click(object sender, EventArgs e)
        {
            ViewState["agrEst"] = false;
            ViewState["agrProf"] = false;
            ViewState["agrAsig"] = false;
            Response.Redirect("Administradores");
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            IdUsuariosTableAdapter idUsuariosTableAdapter = new IdUsuariosTableAdapter();

            this.btnVolverMenuPrincipal.Visible = false;
            this.lblEntidadAgregada.Visible = false;
            if ((bool)ViewState["agrEst"] == true)
            {
                if (this.nombreEst.Text != "" && this.contraEst.Text != "")
                {
                    lblError.Visible = false;
                    this.btnAgregar.Visible = false;
                    this.divEst.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar al estudiante?";

                    this.lblId.Text = $"ID: {Convert.ToInt32(idUsuariosTableAdapter.scope().ToString())+1}";
                    this.lblNombre.Text = $"Nombre: {this.nombreEst.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Contraseña: {this.contraEst.Text.ToString()}";
                    this.lblCarrera.Text = $"Carrera: {this.ListCarreras.SelectedValue}";

                    this.lblId.Visible = true;
                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible = true;
                    this.lblCarrera.Visible = true;
                    this.lblCreditos.Visible = false;

                }
                else
                {
                    lblError.Text = "No se ha podido agregar al estudiante";
                    lblError.Visible = true;
                }
            }
            if((bool)ViewState["agrProf"] == true)
            {
                if (this.nombreProf.Text != "" && this.contraProf.Text != "")
                {
                    lblError.Visible = false;
                    this.btnAgregar.Visible = false;
                    this.divProf.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar al profesor?";

                    this.lblId.Text = $"ID: {Convert.ToInt32(idUsuariosTableAdapter.scope().ToString()) + 1}";
                    this.lblNombre.Text = $"Nombre: {this.nombreProf.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Contraseña: {this.contraProf.Text.ToString()}";

                    this.lblId.Visible = true;
                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible = true;
                    this.lblCarrera.Visible = false;
                    this.lblCreditos.Visible = false;

                }
                else
                {
                    lblError.Text = "No se ha podido agregar el profesor";
                    lblError.Visible = true;
                }

            }
            if ((bool)ViewState["agrAsig"] == true)
            {
                asignaturas = new AsignaturasTableAdapter();
                if (this.nombreAsig.Text != "" && this.claveAsig.Text != "" && this.creditosAsig.Text!="" && Regex.IsMatch(creditosAsig.Text, @"^\d+$") && (Int32)asignaturas.contador(claveAsig.Text.ToString())==0)
                {
                    lblError.Visible = false;
                    this.btnAgregar.Visible = false;
                    this.divAsig.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar la asignatura?";
                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible =true;
                    this.lblCarrera.Visible =false;
                    this.lblCreditos.Visible = true;

                    this.lblNombre.Text = $"Nombre: {this.nombreAsig.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Clave: {this.claveAsig.Text.ToString().ToUpper()}";
                    this.lblCreditos.Text = $"No. de creditos: {this.creditosAsig.Text.ToString()}";

                }
                else
                {
                    lblError.Text = $"No se ha podido agregar la asignatura";
                    lblError.Visible = true;
                }
            }
        }
        //Volver
        protected void btnVolverEst_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = false;
            this.divEst.Visible = false;
            this.div1.Visible = true;
            ViewState["agrEst"] = false;
            this.nombreEst.Text = "";
            this.contraEst.Text = "";
            //this.carreraEst.Text = "";
        }

        protected void btnVolverProf_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = false;

            this.divProf.Visible = false;
            this.div1.Visible = true;
            ViewState["agrProf"] = false;
            this.nombreProf.Text = "";
            this.contraProf.Text = "";
        }

        protected void btnVolverAsig_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = false;

            this.divAsig.Visible = false;
            this.div1.Visible = true;
            ViewState["agrAsig"] = false;

            this.nombreAsig.Text = "";
            this.claveAsig.Text = "";
            this.creditosAsig.Text = "";
        }

        protected void btnVolverEditar_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = true;
            if((bool)ViewState["agrEst"]==true)
            {
                this.divEst.Visible = true;
            }
            else if((bool)ViewState["agrProf"] == true)
            {
                this.divProf.Visible = true;

            }
            else if((bool)ViewState["agrAsig"] == true)
            {
                this.divAsig.Visible = true;

            }
            this.Seguro.Visible = false;
        }

        protected void btnSeguroAgregar_Click(object sender, EventArgs e)
        {
            this.btnVolverEditar.Visible = false;
            this.btnSeguroAgregar.Visible = false;
            this.btnVolverMenuPrincipal.Visible = true;
            this.lblEntidadAgregada.Visible = true;
            if ((bool)ViewState["agrEst"] == true)
            {
                //this.btnAgregar.Visible = true;
                estudiantes = new EstudiantesTableAdapter();
                autenticacion = new AutenticacionTableAdapter();
                if (nombreEst != null && contraEst != null)
                {
                    string id = dataUpdate.GetID();
                    //this.btnAgregar.Visible = true;
                    estudiantes.Insert(id, nombreEst.Text.ToUpper(), ListCarreras.SelectedValue, "0.00", 0, "Sin Honor", 0);
                    autenticacion.Insert(id, contraEst.Text, null, "estudiante");
                    lblEntidadAgregada.Text = "Estudiante agregado";
                }
                else
                    lblEntidadAgregada.Text = "No se ha podido agregar el estudiante";
                //divEst.Visible = false;
                //div1.Visible = true;

            }
            else if ((bool)ViewState["agrProf"] == true)
            {
                profesores = new ProfesoresTableAdapter();
                autenticacion = new AutenticacionTableAdapter();
                if (nombreProf != null && contraProf != null)
                {
                    string id = dataUpdate.GetID();
                    //this.btnAgregar.Visible = true;
                    profesores.Insert(id, nombreProf.Text.ToUpper());
                    autenticacion.Insert(id, contraProf.Text, null, "profesor");
                }
                else
                    lblEntidadAgregada.Text = "No se ha podido agregar el profesor";
                //divProf.Visible = false;
                //div1.Visible = true;


            }
            else if ((bool)ViewState["agrAsig"] == true)
            {
                asignaturas = new AsignaturasTableAdapter();
                if (claveAsig != null && nombreAsig != null && creditosAsig != null && Regex.IsMatch(creditosAsig.Text, @"^\d+$"))
                {
                    //this.btnAgregar.Visible = true;
                    asignaturas.Insert(claveAsig.Text.ToUpper(), nombreAsig.Text.ToUpper(), int.Parse(creditosAsig.Text));
                }
                else
                    lblEntidadAgregada.Text = "No se ha podido agregar la asignatura";
                    //lblError.Text = "No se ha podido agregar la asignatura";
                    //lblError.Visible = true;
                    //btnVolverEditar.Visible = true;
                
                //divAsig.Visible = false;
                //div1.Visible = true;

            }
        }

        protected void btnVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores");
        }

        protected void BtnVolverAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEntidad");
        }
    }
}