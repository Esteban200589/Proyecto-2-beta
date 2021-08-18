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
            if(!IsPostBack)
                cargar_noticias_todas();
            
            cargar_secciones();
            cargar_periodistas();
            
            ddlSeccion.Enabled = false;
            //btnBuscar.Enabled = false;

            Session["noticia_selected"] = null;

            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    
        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            ddlSeccion.Enabled = false;
            ddlTipo.ClearSelection();
            ddlSeccion.ClearSelection();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            filtro();
        }
        protected void gvNoticias_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionar();
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
        protected void cargar_periodistas()
        {
            List<Periodista> periodistas = FabricaLogica.getLogicaPeriodistas().ListarPeriodistas();
            Session["periodistas_todos"] = periodistas;
        }
        
        protected void filtro()
        {
            List<Noticia> noticias = (List<Noticia>)Session["TodasLasNoticias"];

            try
            {
                DateTime fecha = Convert.ToDateTime(txtfecha.Text);
                this.Response.Write(fecha);

                if (fecha == null)
                {
                    // sin seleccion
                    if (ddlTipo.SelectedIndex == -1)
                    {
                        lblMsj.Text = "Debe seleccionar un tipo";
                    }
                    // seleccionar
                    else if (ddlTipo.SelectedIndex == 0)
                    {
                        lblMsj.Text = "Debe seleccionar un tipo";
                    }
                    // todas las noticias
                    else if (ddlTipo.SelectedIndex == 1)
                    {
                        lblMsj.Text = "";
                        ddlSeccion.Enabled = false;
                        ddlSeccion.ClearSelection();
                        cargar_noticias_todas();
                    }
                    // nacionales
                    else if (ddlTipo.SelectedIndex == 2)
                    {
                        string seccion = ddlSeccion.SelectedValue;
                        ddlSeccion.Enabled = true;
                        //this.Response.Write(seccion);

                        lblMsj.Text = "";
                        if (seccion != "")
                        {
                            List<object> listado = (from n in noticias
                                                    where (n.TipoNoticia == "Nacional")
                                                    //where (n.Seccion.Codigo_secc == ddlSeccion.SelectedValue)
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
                    else if (ddlTipo.SelectedIndex == 3)
                    {
                        ddlSeccion.Enabled = false;
                        ddlSeccion.ClearSelection();

                        lblMsj.Text = "";
                        List<object> listado = (from n in noticias
                                                where (n.TipoNoticia == "Internacional")
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
                    // fail
                    else
                    {
                        this.Response.Write("error de filtro");
                    }
                }
                else
                {
                    // sin seleccion
                    if (ddlTipo.SelectedIndex == -1)
                    {
                        lblMsj.Text = "Debe seleccionar un tipo";
                    }
                    // seleccionar
                    else if (ddlTipo.SelectedIndex == 0)
                    {
                        lblMsj.Text = "Debe seleccionar un tipo";
                    }
                    // todas las noticias
                    else if (ddlTipo.SelectedIndex == 1)
                    {
                        lblMsj.Text = "";
                        ddlSeccion.Enabled = false;
                        ddlSeccion.ClearSelection();
                        cargar_noticias_todas();
                    }
                    // nacionales
                    else if (ddlTipo.SelectedIndex == 2)
                    {
                        string seccion = ddlSeccion.SelectedValue;
                        ddlSeccion.Enabled = true;
                        //this.Response.Write(seccion);

                        lblMsj.Text = "";
                        if (seccion != "")
                        {
                            List<object> listado = (from n in noticias
                                                    where (n.TipoNoticia == "Nacional"
                                                        && n.Fecha == fecha)
                                                    // (n.Seccion.Codigo_secc == ddlSeccion.SelectedValue)
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
                    else if (ddlTipo.SelectedIndex == 3)
                    {
                        ddlSeccion.Enabled = false;
                        ddlSeccion.ClearSelection();

                        lblMsj.Text = "";
                        List<object> listado = (from n in noticias
                                                where (n.TipoNoticia == "Internacional"
                                                    && n.Fecha == fecha)
                                                
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
                    // fail
                    else
                    {
                        this.Response.Write("error de filtro");
                    }
                    
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