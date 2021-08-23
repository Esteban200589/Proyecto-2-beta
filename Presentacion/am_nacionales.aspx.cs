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
                botones_inicio();
                cargar_secciones();
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
        
        protected void buscar()
        {
            try
            {
                Nacional noticia = null;
                Noticia n = FabricaLogica.getLogicaNoticias().BuscarNoticia(txtCodigo.Text);

                if (n != null && n.TipoNoticia != "Nacional")
                {
                    limpiar();
                    throw new Exception("La noticia no es Nacional");
                }

                noticia = (Nacional)n;

                if (txtCodigo.Text == string.Empty)
                    throw new Exception("Debe ingresar un codigo");

                if (noticia == null)
                {
                    btnGuardar.Enabled = true;

                    lblMsj.Text = "No se encontró la noticia. Puede agregarla.";
                    lblMsj.ForeColor = Color.DarkOrange;
                    //Session["periodistas_noticia"] = new List<Periodista>();
                }
                else
                {
                    btnModificar.Enabled = true;
                    btnLimpiar.Enabled = true;

                    txtCodigo.Text = noticia.Codigo;
                    txtfecha.Text = noticia.Fecha.Date.ToString("yyyy-MM-dd");
                    txtTitulo.Text = noticia.Titulo;
                    txtCuerpo.Text = noticia.Cuerpo;
                    ddlImportancia.SelectedItem.Text = noticia.Importancia.ToString();
                    ddlSecciones.SelectedValue = noticia.Seccion.Codigo_secc;

                    lbPeriodistasNoticia.DataSource = noticia.Periodistas;
                    lbPeriodistasNoticia.DataValueField = "cedula";
                    lbPeriodistasNoticia.DataTextField = "nombre";
                    lbPeriodistasNoticia.DataBind();

                    //Session["periodistas_noticia"] = noticia.Periodistas;

                    Session["nacional"] = noticia;
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
                Seccion secc = FabricaLogica.getLogicaSecciones().BuscarSeccion(ddlSecciones.SelectedValue);
                int imp = Convert.ToInt32(ddlImportancia.SelectedValue);

                // coleccion de memoria Periodistas
                List<Periodista> ptas = (List<Periodista>)Session["periodistas_noticia"];

                Nacional noticia = new Nacional(secc, code, date, title, body, imp, ptas, user);

                if (noticia != null)
                {
                    FabricaLogica.getLogicaNoticias().AgregarNoticia(noticia);

                    lblMsj.Text = "Noticia Nacional Agregada con Exito";
                    lblMsj.ForeColor = Color.Green;

                    limpiar();
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
                Nacional noticia = (Nacional)Session["Nacional"];

                if (noticia != null)
                {
                    noticia.Fecha = Convert.ToDateTime(txtfecha.Text);
                    noticia.Titulo = txtTitulo.Text.Trim();
                    noticia.Cuerpo = txtCuerpo.Text;              
                    noticia.Importancia = Convert.ToInt32(ddlImportancia.SelectedValue);
                    noticia.Seccion =  FabricaLogica.getLogicaSecciones().BuscarSeccion(ddlSecciones.SelectedValue);

                    FabricaLogica.getLogicaNoticias().ModificarNoticia(noticia);
                    lblMsj.Text = "Noticia Internacional Modificada con Exito";
                    lblMsj.ForeColor = Color.Green;
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
                btnGuardar.Enabled = false;
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void limpiar()
        {
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtCuerpo.Text = "";
            //ddlSecciones.Items.Clear();
            Session["periodistas_noticia"] = null;
            lbPeriodistasNoticia.Items.Clear();
            //ddlImportancia.Items.Clear();

            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }
        protected void botones_inicio()
        {
            btnBuscar.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnLimpiar.Enabled = false;
        }

        protected void cargar_secciones()
        {
            try
            {
                List<Seccion> secciones = FabricaLogica.getLogicaSecciones().ListarSecciones();
                ddlSecciones.DataSource = secciones;
                ddlSecciones.DataTextField = "Nombre_secc";
                ddlSecciones.DataValueField = "Codigo_secc";
                ddlSecciones.DataBind();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void cargar_periodistas()
        {
            try
            {
                List<Periodista> periodistas = FabricaLogica.getLogicaPeriodistas().ListarPeriodistas();
                Session["periodistas_disponibles"] = periodistas;
                ddlPeriodistasDisponibles.DataSource = periodistas;
                ddlPeriodistasDisponibles.DataTextField = "nombre";
                ddlPeriodistasDisponibles.DataValueField = "cedula";
                ddlPeriodistasDisponibles.DataBind();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPeriodistasDisponibles.Text.Trim().Length > 0)
                {
                    object existe = lbPeriodistasNoticia.Items.FindByText(ddlPeriodistasDisponibles.SelectedItem.Text);

                    if (existe != null)
                    {
                        lblMsj.Text = "Ya está elegido ese Periodista";
                    }
                    else
                    {
                        Noticia noticia = (Noticia)Session["nacional"];
                        Periodista periodista = FabricaLogica.getLogicaPeriodistas().BuscarPeriodistaActivo(ddlPeriodistasDisponibles.SelectedValue);

                        if (noticia == null)
                        {
                            List<Periodista> ptas = (List<Periodista>)Session["periodistas_noticia"];

                            if (ptas == null)
                            {
                                ptas = new List<Periodista>();
                            }

                            ptas.Add(periodista);
                            Session["periodistas_noticia"] = ptas;
                            lbPeriodistasNoticia.DataSource = ptas;
                            lbPeriodistasNoticia.DataValueField = "cedula";
                            lbPeriodistasNoticia.DataTextField = "nombre";
                            lbPeriodistasNoticia.DataBind();
                        }
                        else
                        {
                            noticia.Periodistas.Add(periodista);

                            lbPeriodistasNoticia.DataSource = noticia.Periodistas;
                            lbPeriodistasNoticia.DataValueField = "cedula";
                            lbPeriodistasNoticia.DataTextField = "nombre";
                            lbPeriodistasNoticia.DataBind();
                        }
                    }
                }
                else
                    lblMsj.Text = "Seleccione un periodista";
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPeriodistasDisponibles.Text.Trim().Length > 0)
                {
                    Noticia noticia = (Noticia)Session["nacional"];
                    noticia.Periodistas.RemoveAt(lbPeriodistasNoticia.SelectedIndex);

                    lbPeriodistasNoticia.DataSource = noticia.Periodistas;
                    lbPeriodistasNoticia.DataValueField = "cedula";
                    lbPeriodistasNoticia.DataTextField = "nombre";
                    lbPeriodistasNoticia.DataBind();
                }
                else
                    lblMsj.Text = "Seleccione un periodista lista";
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
    }
}