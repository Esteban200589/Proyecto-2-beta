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
            if (!IsPostBack)
            {
                //obtengo el xml desde el WS
                XmlDocument docu = FabricaLogica.getLogicaNoticias().ListadoNoticiasXML();
                //de la logica viene un xml document
                //creo y cargo con los datos el documento q me devolvio el WS- formato para Linq
                XElement documento = XElement.Parse(docu.OuterXml);
                Session["Documento"] = documento;
            }
        }
    }
}