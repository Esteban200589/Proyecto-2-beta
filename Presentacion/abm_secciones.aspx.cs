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
    public partial class abm_secciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botones_inicio();
            if (!IsPostBack)
            {
                Session["Seccion"] = null;
                limpiar();
            }
        }
    
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        protected void buscar()
        {
            try
            {
                Seccion seccion = null;
                seccion = FabricaLogica.getLogicaSecciones().BuscarSeccion(txtCodigo.Text);

                if (txtCodigo.Text == string.Empty)
                    throw new Exception("Debe ingresar un codigo");

                if (seccion == null)
                {
                    btnGuardar.Enabled = true;
                    lblMsj.Text = "No se encontró la sección. Puede agregarla.";
                    lblMsj.ForeColor = Color.DarkOrange;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCodigo.Text = seccion.Codigo_secc;
                    txtNombre.Text = seccion.Nombre_secc;

                    Session["Seccion"] = seccion;
                    lblMsj.Text = "Sección Encontrada";
                    lblMsj.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }
        protected void guardar()
        {
            try
            {
                Seccion seccion = new Seccion(txtCodigo.Text, txtNombre.Text);

                if (seccion != null)
                {
                    FabricaLogica.getLogicaSecciones().AgregarSeccion(seccion);

                    lblMsj.Text = "Sección Registrada";
                    lblMsj.ForeColor = Color.Green;
                }
                else
                {
                    lblMsj.Text = "No se pudo registrar la Sección";
                    lblMsj.ForeColor = Color.DarkOrange;
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }

            limpiar();
            botones_inicio();
        }
        protected void modificar()
        {
            try
            {
                lblMsj.Text = "";
                Seccion seccion = (Seccion)Session["Seccion"];

                if (seccion != null)
                {
                    seccion.Nombre_secc = txtNombre.Text.Trim();

                    FabricaLogica.getLogicaSecciones().ModificarSeccion(seccion);
                    lblMsj.Text = "Sección Modificada";
                    lblMsj.ForeColor = Color.Green;

                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    lblMsj.Text = "No se pudo modificar la sección";
                    lblMsj.ForeColor = Color.DarkOrange;
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }

            limpiar();
            botones_inicio();
        }   
        protected void eliminar()
        {
            try
            {
                Seccion seccion = (Seccion)Session["Seccion"];

                if (seccion != null)
                {
                    FabricaLogica.getLogicaSecciones().EliminarSeccion(seccion);
                    lblMsj.Text = "Sección Eliminada";
                    lblMsj.ForeColor = Color.Green;
                }
                else
                {
                    lblMsj.Text = "No se puede elimiinar la Sección";
                    lblMsj.ForeColor = Color.DarkOrange;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }

            limpiar();
            botones_inicio();
        }
        
        protected void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }
        protected void botones_inicio()
        {
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = false;
        }

    }
}