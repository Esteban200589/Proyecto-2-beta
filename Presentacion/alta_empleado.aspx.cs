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
    public partial class alta_empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botones_inicio();
            if (!IsPostBack)
            {
                Session["Usuario"] = null;
                limpiar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void buscar()
        {
            try
            {
                Usuario usuario = null;
                usuario = FabricaLogica.getLogicaUsuarios().BuscarUsuario(txtUsername.Text);

                if (txtUsername.Text == string.Empty)
                    throw new Exception("Debe ingresar un username");

                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                    lblMsj.Text = "No se encontró el usuario. Puede agregarlo.";
                    lblMsj.ForeColor = Color.DarkOrange;
                }
                else
                {
                    btnGuardar.Enabled = false;

                    txtUsername.Text = usuario.Username;
                    txtPassword.Text = usuario.Password;

                    Session["Usuario"] = usuario;
                    lblMsj.Text = "Usuario Encontrado";
                    lblMsj.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void guardar()
        {
            try
            {
                Usuario usuario = new Usuario(txtUsername.Text, txtPassword.Text);
                    
                if (usuario != null)
                {
                    FabricaLogica.getLogicaUsuarios().AgregarUsuario(usuario);
                
                    lblMsj.Text = "Usuario Registrado";
                    lblMsj.ForeColor = Color.Green;

                    limpiar();
                }
                else
                {
                    botones_inicio();

                    lblMsj.Text = "No se pudo registrar el Usuario";
                    lblMsj.ForeColor = Color.DarkOrange;

                    txtUsername.Focus();
                }

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        private void limpiar()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void botones_inicio()
        {
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = true;
        }   
    }
}