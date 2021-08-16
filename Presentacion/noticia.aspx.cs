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
    public partial class noticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Noticia n = (Noticia)Session["noticia_selected"];

                txtFecha.Text = n.Fecha.ToString();
                txtCodigo.Text = n.Codigo;
                txtTitulo.Text = n.Titulo;
            }
        }
    }
}