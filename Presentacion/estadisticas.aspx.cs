using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace Presentacion
{
    public partial class estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    XmlDocument docu = FabricaLogica.getLogicaNoticias().ListadoNoticiasXML();
                    XElement documento = XElement.Parse(docu.OuterXml);
                    Session["Documento"] = documento;

                    noticias_todas(documento);
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }

        }

        protected void btnCantAnual_Click(object sender, EventArgs e)
        {
            try
            {
                XElement documento = (XElement)Session["Documento"];

                noticias_cantidades(documento);
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            noticias_todas((XElement)Session["Documento"]);
        }
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XElement docu = (XElement)Session["Documento"];

                if (ddlTipo.SelectedIndex == 0)
                {
                    noticias_todas(docu);
                }
                else if (ddlTipo.SelectedIndex == 1)
                {
                    noticias_nacionales(docu);
                }
                else if (ddlTipo.SelectedIndex == 2)
                {
                    noticias_internacionales(docu);
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = Color.Red;
            }
        }

        protected void noticias_todas(XElement documento)
        {
            List<object> result = (from nodo in documento.Elements("Noticia")
                                   select new
                                   {
                                       Codigo = nodo.Element("Codigo").Value,
                                       Fecha = nodo.Element("Fecha").Value,
                                       Tipo = nodo.Element("Tipo").Value,
                                       Titulo = nodo.Element("Titulo").Value,
                                       Importancia = nodo.Element("Importancia").Value
                                   }).ToList<object>();

            gvNoticias.DataSource = result;
            gvNoticias.DataBind();
        }
        protected void noticias_nacionales(XElement documento)
        {
            List<object> result = (from nodo in documento.Elements("Noticia")
                                   where (string)nodo.Element("Tipo") == "Nacional"
                                   select new
                                   {
                                       Codigo = nodo.Element("Codigo").Value,
                                       Fecha = nodo.Element("Fecha").Value,
                                       Tipo = nodo.Element("Tipo").Value,
                                       Titulo = nodo.Element("Titulo").Value,
                                       Importancia = nodo.Element("Importancia").Value
                                   }).ToList<object>();

            gvNoticias.DataSource = result;
            gvNoticias.DataBind();
        }
        protected void noticias_internacionales(XElement documento)
        {
            List<object> result = (from nodo in documento.Elements("Noticia")
                                   where (string)nodo.Element("Tipo") == "Internacional"
                                   select new
                                   {
                                       Codigo = nodo.Element("Codigo").Value,
                                       Fecha = nodo.Element("Fecha").Value,
                                       Tipo = nodo.Element("Tipo").Value,
                                       Titulo = nodo.Element("Titulo").Value,
                                       Importancia = nodo.Element("Importancia").Value
                                   }).ToList<object>();

            gvNoticias.DataSource = result;
            gvNoticias.DataBind();
        }

        protected void noticias_cantidades(XElement documento)
        {

            var result = from x in documento.Elements()
                         group x by new
                         {
                             Tipo = (string)x.Element("Tipo"),
                             Año = (string)x.Element("Anio")
                         } 
                         into g
                         select new
                         {
                             Tipo = g.Key.Tipo,
                             Año = g.Key.Año,
                             Cantidad = g.Count()
                         };

            gvNoticias.DataSource = result;
            gvNoticias.DataBind();
        }
    }
}