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

        protected void guardarEst_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = true;
            estudiantes = new EstudiantesTableAdapter();
            autenticacion = new AutenticacionTableAdapter();
            if (nombreEst != null && carreraEst != null && contraEst != null)
            {
                string id = dataUpdate.GetID();
                this.btnAgregar.Visible = true;
                estudiantes.Insert(id,nombreEst.Text, carreraEst.Text, "0.00", 0, "Sin Honor", 0);
                autenticacion.Insert(id, contraEst.Text, null, "estudiante");
            }
            divEst.Visible = false;
            div1.Visible = true;

        }

        protected void guardarProf_Click(object sender, EventArgs e)
        {

            profesores = new ProfesoresTableAdapter();
            autenticacion = new AutenticacionTableAdapter();
            if (nombreProf != null && contraProf != null)
            {
                string id = dataUpdate.GetID();
                this.btnAgregar.Visible = true;
                profesores.Insert(id, nombreProf.Text);
                autenticacion.Insert(id, contraProf.Text, null, "profesor");
            }
            divProf.Visible = false;
            div1.Visible = true;
        }

        protected void guardarAsig_Click(object sender, EventArgs e)
        {
            this.btnAgregar.Visible = true;
            asignaturas = new AsignaturasTableAdapter();
            if (claveAsig != null && nombreAsig != null && creditosAsig != null)
            {                
                this.btnAgregar.Visible = true;
                asignaturas.Insert(claveAsig.Text, nombreAsig.Text, int.Parse(creditosAsig.Text));
            }
            divAsig.Visible = false;
            div1.Visible = true;

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
            this.btnVolverMenuPrincipal.Visible = false;
            this.lblEntidadAgregada.Visible = false;
            if ((bool)ViewState["agrEst"] == true)
            {
                if (this.nombreEst.Text != "" && this.contraEst.Text != "" && this.carreraEst.Text != "")
                {
                    this.btnAgregar.Visible = false;
                    this.divEst.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar al estudiante?";

                    this.lblNombre.Text = $"Nombre: {this.nombreEst.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Contraseña: {this.contraEst.Text.ToString()}";
                    this.lblCarrera.Text = $"Carrera: {this.carreraEst.Text.ToString().ToUpper()}";

                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible = true;
                    this.lblCarrera.Visible = true;
                    this.lblCreditos.Visible = false;



                }
                else
                {

                }
            }
            if((bool)ViewState["agrProf"] == true)
            {
                if (this.nombreProf.Text != "" && this.contraProf.Text != "")
                {
                    this.btnAgregar.Visible = false;
                    this.divProf.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar al profesor?";
                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible = true;
                    this.lblCarrera.Visible = false;
                    this.lblCreditos.Visible = false;
                    this.lblNombre.Text = $"Nombre: {this.nombreProf.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Contraseña: {this.contraProf.Text.ToString()}";

                }
                else
                {

                }

            }
            if ((bool)ViewState["agrAsig"] == true)
            {
                if (this.nombreAsig.Text != "" && this.claveAsig.Text != "" && this.creditosAsig.Text!="")
                {
                    this.btnAgregar.Visible = false;
                    this.divAsig.Visible = false;
                    this.Seguro.Visible = true;
                    this.lblSeguroEntidad.Text = "Seguro que desea agregar la asignatura?";
                    this.lblNombre.Visible = true;
                    this.lblContraseña.Visible =false;
                    this.lblCarrera.Visible =false;
                    this.lblCreditos.Visible = true;

                    this.lblNombre.Text = $"Nombre: {this.nombreAsig.Text.ToString().ToUpper()}";
                    this.lblContraseña.Text = $"Clave: {this.claveAsig.Text.ToString()}";
                    this.lblCreditos.Text = $"No. de creditos: {this.creditosAsig.Text.ToString()}";

                }
                else
                {

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
            this.carreraEst.Text = "";
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
            this.btnVolverMenuPrincipal.Visible = true;
            this.lblEntidadAgregada.Visible = true;
        }
    }
}