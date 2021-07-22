using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using System.Drawing;

namespace Presentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsj.Text = "";

                string username = txtUser.Text;
                string password = txtPass.Text;

                Usuario usuario = FabricaLogica.getLogicaUsuarios().Login(username,password);

                if (usuario != null)
                {
                    Session["user"] = username;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblMsj.Text = "Datos incorrectos";
                    lblMsj.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}