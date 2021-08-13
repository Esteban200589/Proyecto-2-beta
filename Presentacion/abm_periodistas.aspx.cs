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
    public partial class abm_periodistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botones_inicio();
            if (!IsPostBack)
            {
                Session["Periodista"] = null;
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
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            modificar();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void buscar()
        {
            try
            {
                Periodista periodista = null;
                periodista = FabricaLogica.getLogicaPeriodistas().BuscarPeriodistaActivo(txtCedula.Text);

                if (txtCedula.Text == string.Empty)
                    throw new Exception("Debe ingresar una Cedula");

                if (periodista == null)
                {
                    btnGuardar.Enabled = true;
                    lblMsj.Text = "No se encontró Periodista con esa cedula. Puede agregarlo.";
                    lblMsj.ForeColor = Color.DarkOrange;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCedula.Text = periodista.Cedula;
                    txtNombre.Text = periodista.Nombre;
                    txtEmail.Text = periodista.E_mail;

                    Session["Periodista"] = periodista;

                    lblMsj.Text = "Periodista Encontrado";
                    lblMsj.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }
        private void guardar()
        {
            try
            {
                Periodista periodista = new Periodista(txtCedula.Text,txtNombre.Text,txtEmail.Text);

                if (periodista != null)
                {
                    FabricaLogica.getLogicaPeriodistas().AgregarPeriodista(periodista);
                    
                    lblMsj.Text = "Periodista agregado";
                    lblMsj.ForeColor = Color.Green;
                }
                else
                {
                    lblMsj.Text = "No se pudo agregar el periodista";
                    lblMsj.ForeColor = Color.DarkOrange;
                    txtCedula.Focus();
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
        private void modificar()
        {
            try
            {
                lblMsj.Text = "";
                Periodista periodista = (Periodista)Session["Periodista"];

                if (periodista != null)
                {
                    periodista.Nombre = txtNombre.Text.Trim();
                    periodista.E_mail = txtEmail.Text.Trim();

                    FabricaLogica.getLogicaPeriodistas().ModificarPeriodista(periodista);
                    lblMsj.Text = "Periodista Modificado";
                    lblMsj.ForeColor = Color.Green;
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    lblMsj.Text = "No se pudo modificar el periodista";
                    lblMsj.ForeColor = Color.DarkOrange;
                    txtCedula.Focus();
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
        private void eliminar()
        {
            try
            {
                Periodista periodista = (Periodista)Session["Periodista"];

                if (periodista != null)
                {
                    FabricaLogica.getLogicaPeriodistas().EliminarPeriodista(periodista);
                    lblMsj.Text = "Periodista Eliminado";
                    lblMsj.ForeColor = Color.Green;
                }
                else
                {
                    lblMsj.Text = "No se puede elimiinar el Periodista";
                    lblMsj.ForeColor = Color.Green;
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
       
        private void limpiar()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
        }
        private void botones_inicio()
        {
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

    }
}