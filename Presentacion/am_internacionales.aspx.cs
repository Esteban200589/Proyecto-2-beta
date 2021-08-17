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
    public partial class am_internacionales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            botones_inicio();
            if (!IsPostBack)
            {
                Session["Internacional"] = null;
                cargar_periodistas();
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
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        protected void gvPeriodistasSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Periodista periodista = ((List<Periodista>)Session["listaPaquetes"])[gvPeriodistasSeleccion.SelectedIndex];
                Session["periodista_selected"] = periodista;
                //principal.Attributes.Add("style", "display:block;");

                if (periodista != null)
                {
                    //gvPeriodistasElegidos.
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
                //this.Response.Write("error al seleccionar!" + ex);
            }
        }

        protected void buscar()
        {
            try
            {
                Internacional noticia = null;
                Noticia n = FabricaLogica.getLogicaNoticias().BuscarNoticia(txtCodigo.Text);

                if (n != null && n.TipoNoticia != "Internacional")
                    throw new Exception("La noticia no es Internacional");

                noticia = (Internacional)n;

                if (txtCodigo.Text == string.Empty)
                    throw new Exception("Debe ingresar un codigo");

                if (noticia == null)
                {
                    btnGuardar.Enabled = true;
                    lblMsj.Text = "No se encontró la noticia. Puede agregarla.";
                    lblMsj.ForeColor = Color.DarkOrange;
                }
                else
                {
                    btnModificar.Enabled = true;

                    txtCodigo.Text = noticia.Codigo;
                    txtfecha.Text = noticia.Fecha.ToString();
                    txtTitulo.Text = noticia.Titulo;
                    txtCuerpo.Text = noticia.Cuerpo;
                    ddlImportancia.SelectedItem.Text = noticia.Importancia.ToString();
                    txtPais.Text = noticia.Pais;
                    gvPeriodistasSeleccion.DataSource = noticia.Periodistas;
                    gvPeriodistasSeleccion.DataBind();
                    Session["internacional"] = noticia;

                    lblMsj.Text = "Noticia Encontrada";
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
                Usuario user = (Usuario)Session["user"];
                DateTime date = Convert.ToDateTime(txtfecha.Text);
                string code = txtCodigo.Text;
                string title = txtTitulo.Text;
                string body = txtCuerpo.Text;
                string pais = txtPais.Text;
                int imp = Convert.ToInt32(ddlImportancia.SelectedValue);

                List<Periodista> ptas = null;
                foreach (DataGridItem item in gvPeriodistasElegidos.Rows)
                {
                    Periodista p = FabricaLogica.getLogicaPeriodistas().BuscarPeriodistaActivo(item.Cells[0].ToString());
                    ptas.Add(p);
                }

                Internacional noticia = new Internacional(pais, code, date, title, body, imp, ptas, user);

                if (noticia != null)
                {
                    FabricaLogica.getLogicaNoticias().AgregarNoticia(noticia);

                    lblMsj.Text = "Noticia Internacional Agregada con Exito";
                    lblMsj.ForeColor = Color.Green;

                    limpiar();
                }
                else
                {
                    lblMsj.Text = "No se pudo agregar la Noticia Internacional";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                txtCodigo.Focus();

            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = true;
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }
        protected void modificar()
        {
            try
            {
                lblMsj.Text = "";
                Usuario user = (Usuario)Session["user"];
                Internacional noticia = (Internacional)Session["Internacional"];

                if (noticia != null)
                {
                    noticia.Fecha = Convert.ToDateTime(txtfecha.Text);
                    noticia.Titulo = txtTitulo.Text.Trim();
                    noticia.Cuerpo = txtCuerpo.Text;
                    noticia.Pais = txtPais.Text;
                    noticia.Importancia = Convert.ToInt32(ddlImportancia.SelectedValue);
                   
                    FabricaLogica.getLogicaNoticias().ModificarNoticia(noticia);
                    lblMsj.Text = "Noticia Internacional Modificada con Exito";
                    lblMsj.ForeColor = Color.Green;

                    limpiar();
                }
                else
                {
                    lblMsj.Text = "No se pudo modificar la Noticia Internacional";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                txtCodigo.Focus();

            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = true;
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
        } 
        protected void botones_inicio()
        {
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = false;
        }

        protected void cargar_periodistas()
        {
            gvPeriodistasSeleccion.DataSource = (List<Periodista>)Session["periodistas_todos"];
            gvPeriodistasSeleccion.DataBind();
        }

    }
}