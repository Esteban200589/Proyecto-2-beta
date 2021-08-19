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
                filtro();
                cargar_secciones();
            }
                
            ddlSeccion.Enabled = false;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtfecha.Text = DateTime.Now.ToString();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //filtro();
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
        protected void txtfecha_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtro();
        }

        protected void seleccionar()
        {
            try
            {
                Noticia noticia = ((List<Noticia>)Session["TodasLasNoticias"])[gvNoticias.SelectedIndex];

                if (noticia != null)
                {
                    Session["noticia_selected"] = noticia;
                    Response.Redirect("noticia.aspx");
                }
            }
            catch (Exception ex)
            {
                this.Response.Write("error al seleccionar!" + ex);
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
            List<Noticia> noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
            Session["TodasLasNoticias"] = noticias;

            try
            {
                string fecha = txtfecha.Text;
                this.Response.Write(fecha);
      
                // todas
                if (ddlTipo.SelectedIndex == 0)
                {
                    lblMsj.Text = "";
                    ddlSeccion.Enabled = false;
                    ddlSeccion.ClearSelection();

                    if (fecha != "")
                    {
                        List<object> listado = (from n in noticias
                                                where n._fecha == fecha
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                        ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    else
                    {
                        List<object> listado = (from n in noticias
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                                           ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                   
                }
                // nacionales
                else if (ddlTipo.SelectedIndex == 1)
                {
                    ddlSeccion.Enabled = true;
                    string seccion = ddlSeccion.SelectedValue;
                    
                    lblMsj.Text = "";
                    if (fecha != "")
                    {
                        List<object> listado = (from n in noticias
                                                where (n is Nacional) && ((Nacional)n).Seccion.Codigo_secc == seccion
                                                    && (n._fecha == fecha)
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                        ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    else
                    {
                        List<object> listado = (from n in noticias
                                                where (n is Nacional) && ((Nacional)n).Seccion.Codigo_secc == seccion
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                        ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                        }
                    
                }
                // internacionales
                else if (ddlTipo.SelectedIndex == 2)
                {
                    ddlSeccion.Enabled = false;
                    ddlSeccion.ClearSelection();

                    lblMsj.Text = "";
                    if (fecha != "")
                    {
                        List<object> listado = (from n in noticias
                                                where n.TipoNoticia == "Internacional" && n._fecha == fecha
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                        ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    else
                    {
                        List<object> listado = (from n in noticias
                                                where n.TipoNoticia == "Internacional"
                                                orderby n.Fecha
                                                select new
                                                {
                                                    Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }
                        ).ToList<object>();
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    
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

        protected void cargar_noticias_todas()
        {
            try
            {
                txtfecha.Text = "20210818";

                //DateTime fecha = DateTime.Now;
                string fecha = null;

                List<Noticia> noticias = null;
                noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
                Session["TodasLasNoticias"] = noticias;

                if (fecha == null)
                {
                    List<object> listado = (from n in noticias
                                            orderby n.Fecha
                                            select new
                                            {
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }
                    ).ToList<object>();
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }
                else
                {
                    List<object> listado = (from n in noticias
                                            //where (n.Fecha == fecha)
                                            orderby n.Fecha
                                            select new
                                            {
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }
                    ).ToList<object>();
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
            
        }

    }
}