using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

namespace Presentacion
{
    public partial class abm_secciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Seccion"] = null;

                this.Botones_Inicio();
                this.Limpiar();

                txtCodigo.Enabled = true;
                txtNombre.Enabled = false;
            }
        }
    

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }


        private void buscar()
        {
            try
            {
                Seccion seccion = null;
                seccion = FabricaLogica.getLogicaSecciones().BuscarSeccion(txtCodigo.Text);

                this.Limpiar();


                if (seccion == null)
                {
                    btnGuardar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCodigo.Text = seccion.Codigo_secc;
                    txtNombre.Text = seccion.Nombre_secc;

                    Session["Seccion"] = seccion;

                    lblMsj.Text = "Sección Encontrada";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        private void modificar()
        {
            try
            {
                Seccion seccion = (Seccion)Session["Seccion"];

                seccion.Codigo_secc = txtCodigo.Text.Trim();
                seccion.Nombre_secc = txtCodigo.Text.Trim();

                if (seccion == null)
                {
                    btnGuardar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    Session["Seccion"] = seccion;

                    txtCodigo.Text = seccion.Codigo_secc;
                    txtNombre.Text = seccion.Nombre_secc;

                    lblMsj.Text = "Sección Encontrada";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        private void guardar()
        {

        }

        private void eliminar()
        {

        }


        private void Botones_Inicio()
        {
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }
    }
}