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
    public partial class ControlUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null && (Session["Role"].ToString() == "administrador"))
                {
                    wcOpciones.Visible = true;
                }
                else
                {
                    Response.Redirect("Default");
                }
            }
        }

        protected void BtMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores");
        }

        protected void BtEst_Click(object sender, EventArgs e)
        {
            AutenticacionTableAdapter autenticacion = new AutenticacionTableAdapter();
            EstudiantesTableAdapter estudiantes = new EstudiantesTableAdapter();

            RadioButtonList1.Items.Clear();
            foreach (AutenticacionRow datos in autenticacion.GetData().Rows)
            {
                if (DropDownList1.SelectedValue == "Inhabilitar")
                {
                    LblTipoDato.Text = "Estudiantes disponibles para Inhabilitar:";
                    if (datos["Role"].ToString() == "estudiante")
                    {
                        RadioButtonList1.Items.Add(new ListItem(datos["Id"].ToString() + " - " +  estudiantes.ReturnNameById(datos["Id"].ToString()), datos["Id"].ToString()));
                    }
                }
                else if(DropDownList1.SelectedValue == "Habilitar")
                {
                    LblTipoDato.Text = "Estudiantes disponibles para Habilitar:";
                    if (datos["Role"].ToString() == "estudiante$")
                    {
                        RadioButtonList1.Items.Add(new ListItem(datos["Id"].ToString() + " - " + estudiantes.ReturnNameById(datos["Id"].ToString()), datos["Id"].ToString()));
                    }
                }                
            }

            wcOpciones.Visible = false;
            wcLista.Visible = true;
        }

        protected void BtProf_Click(object sender, EventArgs e)
        {
            AutenticacionTableAdapter autenticacion = new AutenticacionTableAdapter();
            ProfesoresTableAdapter profesores = new ProfesoresTableAdapter();

            RadioButtonList1.Items.Clear();
            foreach (AutenticacionRow datos in autenticacion.GetData().Rows)
            {
                if (DropDownList1.SelectedValue == "Inhabilitar")
                {
                    LblTipoDato.Text = "Profesores disponibles para Inhabilitar:";
                    if (datos["Role"].ToString() == "profesor")
                    {
                        RadioButtonList1.Items.Add(new ListItem(datos["Id"].ToString() + " - " + profesores.GetProfName(datos["Id"].ToString()).ToString(), datos["Id"].ToString()));
                    }
                }
                else if (DropDownList1.SelectedValue == "Habilitar")
                {
                    LblTipoDato.Text = "Profesores disponibles para Habilitar:";
                    if (datos["Role"].ToString() == "profesor$")
                    {
                        RadioButtonList1.Items.Add(new ListItem(datos["Id"].ToString() + " - " + profesores.GetProfName(datos["Id"].ToString()).ToString(), datos["Id"].ToString()));
                    }
                }
            }

            wcOpciones.Visible = false;
            wcLista.Visible = true;
        }

        protected void BtVolver_Click(object sender, EventArgs e)
        {
            wcLista.Visible = false;
            wcOpciones.Visible = true;
        }

        protected void BtConfirmar_Click(object sender, EventArgs e)
        {
            FlipRole(RadioButtonList1.SelectedValue);
            Response.Redirect("ControlUsuarios");
        }

        protected void BtProcesar_Click(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex > -1)
            { 
                LblEntidad.Text = RadioButtonList1.SelectedItem.Text;
                LblAccion.Text = "Accion: " + DropDownList1.SelectedValue;

                wcLista.Visible = false;
                wcConfirmar.Visible = true;
            }
        }

        private void FlipRole(string id)
        {
            AutenticacionTableAdapter autenticacion = new AutenticacionTableAdapter(); 
            string role = autenticacion.ScalarQueryGetRoleById(id);
            if (role.Contains("$"))
            {
                role = role.Remove(role.Length-1);
            }
            else
            {
                role += "$";
            }
            autenticacion.UpdateQueryForRoleDisable(role, id);
        }

        protected void BtCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administradores");
        }


        protected void BtEditar_Click(object sender, EventArgs e)
        {
            wcConfirmar.Visible = false;
            wcLista.Visible = true;
        }
    }
}