using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

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
        }

       
        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            txtPais.Text = "";
            txtPais.Enabled = false;

            ddlSeccion.SelectedItem.Text = "";
            ddlSeccion.Enabled = false;

            rblNoticias.ClearSelection();

            tipo = "todas";
            cargar_datos(tipo);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargar_datos(tipo);
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (tipo == "nacionales")
            {
                txtPais.Enabled = false;
                ddlSeccion.Enabled = true;
            }
            else if (tipo == "internacionales")
            {
                txtPais.Enabled = true;
                ddlSeccion.SelectedItem.Text = "";
                ddlSeccion.Enabled = false;
            }
            else
            {
                txtPais.Enabled = false;
                ddlSeccion.SelectedItem.Text = "";
                ddlSeccion.Enabled = false;
                
            }
        }

        protected void rblNoticias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = rblNoticias.SelectedItem.Value.ToString();
            tipo = valor;

            //if (rblNoticias.SelectedItem.Value == "nacionales")
            //{
            //    txtPais.Enabled = false;
            //    ddlSeccion.Enabled = true;
            //}
            //else if (rblNoticias.SelectedItem.Value == "internacionales")
            //{
            //    txtPais.Enabled = true;
            //    ddlSeccion.SelectedItem.Text = "";
            //    ddlSeccion.Enabled = false;
            //}
            //else
            //{
            //    txtPais.Enabled = false;
            //    ddlSeccion.SelectedItem.Text = "";
            //    ddlSeccion.Enabled = false;
            //}
            //this.Response.Write(valor);
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
                                            {
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }).ToList<object>();

                    Session[tipo] = listado;
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }

                if (tipo == "nacionales" && secc != "")
                {
                    List<object> listado = (from n in noticias
                                            where (n.TipoNoticia == "Noticia Nacional")
                                            select new
                                            {
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }).ToList<object>();

                    Session[tipo] = listado;
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }

                if (tipo == "internacionales")
                {
                    List<object> listado = (from n in noticias
                                            where n.TipoNoticia == "Noticia Internacional"
                                            select new
                                            {
                                                Fecha = n._fecha,
                                                Tipo = n.TipoNoticia,
                                                Titulo = n.Titulo
                                            }).ToList<object>();

                    Session[tipo] = listado;
                    gvNoticias.DataSource = listado;
                    gvNoticias.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
            
        }

        
    }
}