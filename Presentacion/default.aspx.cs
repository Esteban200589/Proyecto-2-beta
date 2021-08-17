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
            ddlSeccion.SelectedItem.Text = "";

            Session["noticia_selected"] = null;
        }
    
        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            ddlSeccion.Enabled = false;
            ddlSeccion.SelectedItem.Text = "";
            ddlTipo.SelectedItem.Value = "1";
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
            List<Seccion> secciones = FabricaLogica.getLogicaSecciones().ListarSecciones();
            Session["secciones"] = secciones;
            ddlSeccion.DataSource = secciones;
            ddlSeccion.DataTextField = "Nombre_secc";
            ddlSeccion.DataValueField = "Codigo_secc";
            ddlSeccion.DataBind();
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
                if (ddlTipo.SelectedIndex == -1)
                {
                    lblMsj.Text = "Debe seleccionar un tipo";
                }
                else if (ddlTipo.SelectedIndex == 0)
                {
                    lblMsj.Text = "Debe seleccionar un tipo";
                }

                // todas las noticias
                else if (ddlTipo.SelectedIndex == 1)
                {
                    ddlSeccion.Enabled = false;
                    ddlSeccion.SelectedItem.Text = "";
                    cargar_noticias_todas();
                }

                // nacionales
                else if (ddlTipo.SelectedIndex == 2)
                {
                    List<Nacional> list_aux = new List<Nacional>();
                    foreach (Noticia item in noticias)
                    {
                        if (item is Nacional)
                        {
                            list_aux.Add((Nacional)item);
                        }
                    }

                    ddlSeccion.Enabled = true;
                    string seccion = ddlSeccion.SelectedValue;
                    this.Response.Write(seccion);
                    lblMsj.Text = "";

                    List<object> listado = new List<object>();

                    if (seccion != "")
                    {
                        listado = (from n in noticias
                                   join m in list_aux on n.Codigo equals m.Codigo
                                   where (n.TipoNoticia == "Nacional" && m.Seccion.Nombre_secc == seccion)
                                   orderby n.Fecha
                                   select new
                                   {
                                        Fecha = n._fecha,
                                        Tipo = n.TipoNoticia,
                                        Titulo = n.Titulo
                                   }
                                  ).ToList<object>();
                    } 
                    else
                    {
                        listado = (from n in noticias
                                   where (n.TipoNoticia == "Nacional")
                                   orderby n.Fecha
                                   select new
                                   {
                                       Fecha = n._fecha,
                                       Tipo = n.TipoNoticia,
                                       Titulo = n.Titulo
                                   }
                                  ).ToList<object>();
                    }
                    
                    

                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();             
                }

                // internacionales
                else if (ddlTipo.SelectedIndex == 3)
                {
                    ddlSeccion.Enabled = false;
                    ddlSeccion.SelectedItem.Text = "";

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
                else
                {
                    this.Response.Write("error de filtro");
                }
                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
                this.Response.Write("error " + ex);
            }

        }

        protected void cargar_noticias_todas()
        {
            try
            {
                List<Noticia> noticias = null;
                noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
                Session["TodasLasNoticias"] = noticias;

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
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
            
        }
    }
}