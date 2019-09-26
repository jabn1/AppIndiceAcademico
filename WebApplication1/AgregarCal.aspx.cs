using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Database1DataSetTableAdapters;
using static WebApplication1.Database1DataSet;

namespace WebApplication1
{
    public partial class AgregarCal : System.Web.UI.Page
    {
        
        private EstudiantesTableAdapter estudiantes;
        private AsignaturasTableAdapter asignaturas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["Role"] != null && (Session["Role"].ToString() == "profesor"))
                {
                    asignaturas = new AsignaturasTableAdapter();
                    
                    RadioButtonList1.Items.Clear();
                    foreach (AsignaturasRow asig in asignaturas.GetData().Rows)
                    {                      
                        RadioButtonList1.Items.Add(new ListItem(asig["Clave"].ToString() + " - " + asig["NombreAsig"].ToString(), asig["Clave"].ToString()));
                    }

                    wcElegirAsig.Visible = true;
                    
                }
                else
                {
                    Response.Redirect("Default");
                }               
            }           
        }

        protected void btElegirAsig_Click(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex >= 0)
            {
                lblAsig.Text = "Asignatura: "+ RadioButtonList1.SelectedValue;
                estudiantes = new EstudiantesTableAdapter();
                RadioButtonList2.Items.Clear();
                foreach (EstudiantesRow est in estudiantes.GetDataByNoCalClave(RadioButtonList1.SelectedValue).Rows)
                {
                    RadioButtonList2.Items.Add(new ListItem(est["IdEst"].ToString() + " - " + est["NombreEst"].ToString(), est["IdEst"].ToString()));
                }

                lblAsig.Text = "Asignatura: " + RadioButtonList1.SelectedItem.Text;
                wcElegirAsig.Visible = false;
                wcElegirEst.Visible = true;
            }
        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profesores");
        }

        protected void btElegirEst_Click(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedIndex >= 0)
            {
                lblAsig2.Text = lblAsig.Text;
                lblEst.Text = "Estudiante: " + RadioButtonList2.SelectedItem.Text;
                wcElegirEst.Visible = false;
                wcCalificar.Visible = true;
            }
        }

        protected void btProcesar_Click(object sender, EventArgs e)
        {
            int valorCal;
            if(int.TryParse(tbCal.Text,out valorCal) && valorCal <= 100 && valorCal >= 0)
            {
                lblAsig3.Text = lblAsig.Text;
                lblEst2.Text = lblEst.Text;
                lblValor.Text = "Valor de calificacion: " + valorCal.ToString();
                wcCalificar.Visible = false;
                wcConfirmar.Visible = true;
                ViewState["valorCal"] = valorCal;
            }
            else
            {
                tbCal.Text = "";
                lblWarn.Text = "La calificacion debe ser un valor entre 0 y 100. Intentar de nuevo.";
            }
        }
        protected bool InsertCal(int cal)
        {
            string alpha;
            CalificacionesTableAdapter calificaciones = new CalificacionesTableAdapter();
            if (cal <= 100 && cal >= 90) alpha = "A";
            else if (cal <= 89 && cal >= 80) alpha = "B";
            else if (cal <= 79 && cal >= 70) alpha = "C";
            else if (cal <= 69 && cal >= 60) alpha = "D";
            else if (cal <= 59 && cal >= 0) alpha = "F";
            else return false;
            calificaciones.Insert(RadioButtonList2.SelectedValue,Session["IdProf"].ToString(),cal,alpha,RadioButtonList1.SelectedValue);
            return true;
        }
        protected void btConfirmar1_Click(object sender, EventArgs e)
        {
            InsertCal((int)ViewState["valorCal"]);
            DataUpdate.UpdateDatosEstudiante(RadioButtonList2.SelectedValue);
            Response.Redirect("Profesores");
        }

        protected void btConfirmar2_Click(object sender, EventArgs e)
        {
            InsertCal((int)ViewState["valorCal"]);
            DataUpdate.UpdateDatosEstudiante(RadioButtonList2.SelectedValue);
            Response.Redirect("AgregarCal");
        }

        protected void btRetCal_Click(object sender, EventArgs e)
        {
            wcConfirmar.Visible = false;
            wcCalificar.Visible = true;
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profesores");
        }

        protected void btRetEst_Click(object sender, EventArgs e)
        {
            wcCalificar.Visible = false;
            wcElegirEst.Visible = true;

        }

        protected void btRetAsig_Click(object sender, EventArgs e)
        {
            wcElegirEst.Visible = false;
            wcElegirAsig.Visible = true;

        }

        protected void tbCal_TextChanged(object sender, EventArgs e)
        {
            lblWarn.Text = "";
        }
    }
}