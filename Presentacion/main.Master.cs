using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using System.Drawing;

namespace Presentacion
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null)
                    Response.Redirect("Login.aspx");
                else
                {
                    Usuario user = (Usuario)Session["user"];
                    lblUsername.Text = user.Username;
                    lblUsername.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            } 
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("default.aspx");
        }
    }
}