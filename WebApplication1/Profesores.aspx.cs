using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Profesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string Id;

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var entity = new Database1Entities();
            var a = entity.GetAutenticacionById(this.Login2.UserName).ToArray();
            if (a.Length == 0)
            {
                //Usuario no existe
            }
            else if (a[0].Role == "estudiante" && this.Login2.Password == a[0].Clave)
            {
                
                this.Login2.Visible = false;
                this.webcontentLogin.Visible = false;
                Id = a[0].Id;
                this.SqlDataSource1.SelectParameters["Id"].DefaultValue = Id;
                this.SqlDataSource2.SelectParameters["IdEst"].DefaultValue = Id;
                this.webcontentEst.Visible = true;

            }
            else
            {
                //Negar acceso
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.webcontentListCal.Visible = false;
            this.webcontentEst.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.webcontentEst.Visible = false;
            this.webcontentListCal.Visible = true;
        }
    }
}