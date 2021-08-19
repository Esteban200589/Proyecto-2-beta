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
                    //falta mostrar LinqToXML para mostrar en la grilla
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
                XElement docu = (XElement)Session["Documento"];

                if (ddlTipo.SelectedIndex == -1)
                {
                    lblMsj.Text = "Debe seleccionar un tipo";
                }
                else if (ddlTipo.SelectedIndex == 0)
                {
                    lblMsj.Text = "Debe seleccionar un tipo";
                }
                else if (ddlTipo.SelectedIndex == 1)
                {
                    // grilla
                    //XmlListar.DocumentContent = docu.ToString();
                }
                else if (ddlTipo.SelectedIndex == 2)
                {
                    var result = (from nodo in docu.Elements("Noticia")
                                  where nodo.Element("Tipo").Equals("Nacional")
                                  select nodo);

                    string _res = "<Root>";
                    foreach (var nodo in result)
                    {
                        _res += nodo.ToString();
                    }
                    _res += "</Root>";
                    //XmlListar.DocumentContent = _res;
                }
                else if (ddlTipo.SelectedIndex == 3)
                {
                    var result = (from nodo in docu.Elements("Noticia")
                                  where nodo.Element("Tipo").Equals("Internacional")
                                  select nodo);

                    string _res = "<Root>";
                    foreach (var nodo in result)
                    {
                        _res += nodo.ToString();
                    }
                    _res += "</Root>";
                    XmlListar.DocumentContent = _res;
                }

                

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            ddlTipo.ClearSelection();
         

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 2 filtro por tipo (Nacionales e Internacioinales)
        }
    }
}