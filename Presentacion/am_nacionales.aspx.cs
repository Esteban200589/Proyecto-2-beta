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
    public partial class am_nacionales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeriodistas();
                CargarSecciones();
                Botones_Inicio();
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }


        private void Buscar()
        {
            try
            {
                Nacional noticia = null;
                noticia = FabricaLogica.getLogicaNacionales().MostrarNacional(txtCodigo.Text);

                this.Limpiar();


                if (noticia == null)
                {
                    btnGuardar.Enabled = true;
                }
                else
                {
                    btnGuardar.Enabled = false;

                    txtCodigo.Text = noticia.Codigo;
                    txtTitulo.Text = noticia.Titulo;
                    txtCuerpo.Text = noticia.Cuerpo;
                    
                    //List<Periodista> ptas = FabricaLogica.getLogicaPeriodistas().
                    

                    Session["nacional"] = noticia;

                    lblMsj.Text = "Noticia Encontrada";
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
                Usuario user = (Usuario)Session["user"];

                if (fecha.SelectedDate.ToString("yyyyMMdd") == "00010101")
                    throw new Exception("Debe seleccionar una fecha");

                if (txtCodigo.Text == string.Empty)
                    throw new Exception("Debe ingresar un codigo");

                if (txtTitulo.Text == string.Empty)
                    throw new Exception("Debe ingresar un titulo");

                if (txtCuerpo.Text == string.Empty)
                    throw new Exception("Debe escribir algo en el cuerpo de la noticia");

                if (gvPeriodistasElegidos.Rows.Count == 0)
                    throw new Exception("Debe seleccionar un periodista");

                if (ddlImportancia.SelectedItem.Value == string.Empty)
                    throw new Exception("Debe seleccionar la importancia.");

                if (ddlSecciones.SelectedItem.Value == string.Empty)
                    throw new Exception("Debe elegir una seccion.");


                DateTime date = fecha.SelectedDate;
                string code = txtCodigo.Text;
                string title = txtTitulo.Text;
                string body = txtCuerpo.Text;
                List<Periodista> ptas = null;
                // ptas = gvPeriodistasElegidos.;  <--------------------------------------------------------
                int imp = Convert.ToInt32(ddlImportancia.SelectedValue);

                Seccion secc = FabricaLogica.getLogicaSecciones().BuscarSeccion(ddlSecciones.SelectedValue);

                Nacional noticia = new Nacional(secc,code,date,title,body,imp,ptas,user);

                if (noticia != null)
                {
                    FabricaLogica.getLogicaNacionales().AgregarNacional(noticia);

                    lblMsj.Text = "Noticia Nacional Agregada con Exito";
                    lblMsj.ForeColor = Color.Green;

                    Limpiar();
                }
                else
                {
                    

                    lblMsj.Text = "No se pudo agregar la Noticia Nacional";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                txtCodigo.Focus();

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void CargarPeriodistas()
        {
            List<Periodista> periodistas = FabricaLogica.getLogicaPeriodistas().ListarPeriodistas();
            Session["periodistas_seleccion"] = periodistas;
            gvPeriodistasSeleccion.DataSource = periodistas;
            gvPeriodistasSeleccion.DataBind();
        }

        protected void CargarSecciones()
        {
            List<Seccion> secciones = FabricaLogica.getLogicaSecciones().ListarSecciones();
            Session["secciones"] = secciones;
            ddlSecciones.DataSource = secciones;
            ddlSecciones.DataTextField = "Nombre_secc";
            ddlSecciones.DataValueField = "Codigo_secc";
            ddlSecciones.DataBind();
        }

        private void Botones_Inicio()
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnLimpiar.Enabled = true;
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtCuerpo.Text = "";
            //fecha.SelectedDate.Date.ti = "00010101";
            gvPeriodistasElegidos = null;
            //ddlImportancia.
            //ddlSecciones.
        }

        
    }
}