﻿using System;
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
    public partial class consultar_noticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Noticia n = (Noticia)Session["noticia_selected"];
            n = FabricaLogica.getLogicaNoticias().BuscarNoticia(n.Codigo);


        }
    }
}