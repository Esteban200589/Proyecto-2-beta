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
        private static string tipo = "todas";

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_secciones();
            cargar_datos(tipo);

            txtPais.Enabled = false;
            ddlSeccion.Enabled = false;
            btnBuscar.Enabled = false;
            ddlSeccion.SelectedItem.Text = "";
        }

       
        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            lblMsj.Text = "";
            txtPais.Text = "";
            txtPais.Enabled = false;
            ddlSeccion.Enabled = false;
            ddlSeccion.SelectedItem.Text = ""; 
            tipo = "todas";
            cargar_datos(tipo);
            rblNoticias.ClearSelection();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Response.Write(tipo);
                //this.Response.Write(rblNoticias.SelectedValue);
                cargar_datos(rblNoticias.SelectedValue);
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //this.Response.Write(rblNoticias.SelectedValue);

            if (rblNoticias.SelectedValue == "")
            {
                lblMsj.Text = "Debe seleciconar un tipo de noticia primero";
                lblMsj.ForeColor = Color.DarkOrange;
            }
            else
            {
                btnBuscar.Enabled = true;

                if (tipo == "nacionales")
                {
                    txtPais.Enabled = false;
                    txtPais.Text = "";
                    ddlSeccion.Enabled = true;
                    lblMsj.Text = "Puede elegir una seccion";
                }
                else if (tipo == "internacionales")
                {
                    txtPais.Enabled = true;
                    ddlSeccion.SelectedItem.Text = "";
                    ddlSeccion.Enabled = false;
                    lblMsj.Text = "Puede elegir un pais";
                }
                else
                {
                    txtPais.Enabled = false;
                    ddlSeccion.SelectedItem.Text = "";
                    ddlSeccion.Enabled = false;
                    lblMsj.Text = "";
                }
            }
        }

        protected void rblNoticias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = rblNoticias.SelectedItem.Value.ToString();
            tipo = valor;
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

        protected void cargar_datos(string tipo, string secc = "", string pais = "")
        {
            try
            {
                List<Noticia> noticias = null;
                noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();

                if (tipo == "todas")
                {
                    List<object> listado = (from n in noticias
                                            select new
                                            {   Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }).ToList<object>();

                    Session[tipo] = listado;
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }
                else
                {
                    if (tipo == "nacionales" && secc != "")
                    {
                        List<object> listado = (from n in noticias
                                                where (n.TipoNoticia == "Noticia Nacional")
                                                select new
                                                {   Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }).ToList<object>();

                        Session[tipo] = listado;
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    else
                    {
                        lblMsj.Text = "Debe elegir una seccion";
                        lblMsj.ForeColor = Color.DarkOrange;
                    }

                    if (tipo == "internacionales" && pais != "")
                    {
                        List<object> listado = (from n in noticias
                                                where (n.TipoNoticia == "Noticia Internacional")
                                                select new
                                                {   Fecha = n._fecha,
                                                    Tipo = n.TipoNoticia,
                                                    Titulo = n.Titulo
                                                }).ToList<object>();

                        Session[tipo] = listado;
                        gvNoticias.DataSource = listado;
                        gvNoticias.DataBind();
                    }
                    else
                    {
                        lblMsj.Text = "Debe elegir un pais";
                        lblMsj.ForeColor = Color.DarkOrange;
                    }
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