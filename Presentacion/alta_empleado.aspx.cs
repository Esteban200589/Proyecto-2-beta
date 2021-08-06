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
            if (!IsPostBack)
            {
                Session["Usuario"] = null;

                this.Botones_Inicio();
                this.Limpiar();

                txtUsername.Enabled = true;
                txtPassword.Enabled = false;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void Buscar()
        {
            try
            {
                Usuario usuario = null;
                usuario = FabricaLogica.getLogicaUsuarios().BuscarUsuario(txtUsername.Text);

                this.Limpiar();


                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                }
                else
                {
                    btnGuardar.Enabled = false;

                    txtUsername.Text = usuario.Username;
                    txtPassword.Text = usuario.Password;

                    Session["Usuario"] = usuario;

                    lblMsj.Text = "Usuario Encontrado";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        private void Guardar()
        {
            try
            {
                Usuario usuario = new Usuario(txtUsername.Text, txtPassword.Text);
                    
                if (usuario != null)
                {
                    FabricaLogica.getLogicaUsuarios().AgregarUsuario(usuario);
                
                    lblMsj.Text = "Usuario Registrado";
                    lblMsj.ForeColor = Color.Green;

                    Limpiar();
                }
                else
                {
                    Botones_Inicio();

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


        private void Botones_Inicio()
        {
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = true;
        }

        private void Limpiar()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

    }
}