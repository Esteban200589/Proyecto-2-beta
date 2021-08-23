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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                cargar_noticias_todas();
                cargar_secciones();
                
                ddlSeccion.Enabled = false;
            }
        }

        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            ddlSeccion.Enabled = false;
            ddlTipo.ClearSelection();
            ddlSeccion.ClearSelection();
        }   
        protected void gvNoticias_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionar();
        }
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro_seccion();
        }

        protected void seleccionar()
        {
            try
            {
                string codigo = gvNoticias.SelectedRow.Cells[0].Text;
                Noticia noticia = FabricaLogica.getLogicaNoticias().BuscarNoticia(codigo);

                if (noticia != null)
                {
                    Session["noticia_selected"] = noticia;
                    Response.Redirect("noticia.aspx");
                }
            }
            catch (Exception)
            {
                //lblMsj.Text = ex.Message;
                //this.Response.Write("error al seleccionar!" + ex);
            }
        }
        protected void cargar_secciones()
        {
            try
            {
                List<Seccion> secciones = FabricaLogica.getLogicaSecciones().ListarSecciones();
                Session["secciones"] = secciones;
                ddlSeccion.DataSource = secciones;
                ddlSeccion.DataTextField = "Nombre_secc";
                ddlSeccion.DataValueField = "Codigo_secc";
                ddlSeccion.DataBind();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }   
        
        protected void filtro()
        {
            try
            {

                //DateTime fecha = DateTime.Now;
                //try
                //{
                //    fecha = Convert.ToDateTime(txtfecha.Text);
                //}
                //catch (Exception)
                //{
                //}
                    
                // todas
                if (ddlTipo.SelectedIndex == 0)
                {
                    List<Noticia> noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
                    Session["TodasLasNoticias"] = noticias;

                    lblMsj.Text = "";
                    ddlSeccion.Enabled = false;
                    ddlSeccion.ClearSelection();

                    List<object> listado = (from n in noticias
                                            orderby n.Fecha
                                            select new
                                            {
                                                Codigo = n.Codigo,
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }
                    ).ToList<object>();
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();

                }
                // nacionales
                else if (ddlTipo.SelectedIndex == 1)
                {
                    ddlSeccion.Enabled = true;
                    filtro_seccion();
                }
                // internacionales
                else if (ddlTipo.SelectedIndex == 2)
                {
                    List<Noticia> noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
                    Session["TodasLasNoticias"] = noticias;

                    ddlSeccion.Enabled = false;
                    ddlSeccion.ClearSelection();

                    lblMsj.Text = "";
                    List<object> listado = (from n in noticias
                                            where n.TipoNoticia == "Internacional"
                                            orderby n.Fecha
                                            select new
                                            {
                                                Codigo = n.Codigo,
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }
                    ).ToList<object>();
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();

                }
                // fail
                else
                {
                    this.Response.Write("error de filtro");
                }  
                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
                //this.Response.Write("error " + ex);
            }

        }
        protected void filtro_seccion()
        {
            List<Noticia> noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
            Session["TodasLasNoticias"] = noticias;

            string seccion = ddlSeccion.SelectedValue;

            lblMsj.Text = "";
            List<object> listado = (from n in noticias
                                    where (n is Nacional) && ((Nacional)n).Seccion.Codigo_secc == seccion
                                    orderby n.Fecha
                                    select new
                                    {
                                        Codigo = n.Codigo,
                                        Fecha = n._fecha,
                                        Tipo = n.TipoNoticia,
                                        Titulo = n.Titulo
                                    }
            ).ToList<object>();
            gvNoticias.DataSource = listado;
            gvNoticias.DataBind();
        }

        protected void cargar_noticias_todas()
        {
            try
            {
                List<Noticia> noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
                Session["TodasLasNoticias"] = noticias;

                lblMsj.Text = "";
                ddlSeccion.Enabled = false;
                ddlSeccion.ClearSelection();

                List<object> listado = (from n in noticias
                                        orderby n.Fecha
                                        select new
                                        {
                                            Codigo = n.Codigo,
                                            Fecha = n._fecha,
                                            Tipo = n.TipoNoticia,
                                            Titulo = n.Titulo
                                        }
                ).ToList<object>();
                gvNoticias.DataSource = listado;
                gvNoticias.DataBind();
                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
            
        }

    }
}