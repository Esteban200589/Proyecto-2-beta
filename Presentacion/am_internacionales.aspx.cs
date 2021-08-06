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
    public partial class am_internacionales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeriodistas();
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }


        protected void CargarPeriodistas()
        {
            List<Periodista> periodistas = FabricaLogica.getLogicaPeriodistas().ListarPeriodistas();
            Session["periodistas_seleccion"] = periodistas;
            gvPeriodistasSeleccion.DataSource = periodistas;
            gvPeriodistasSeleccion.DataBind();
        }

        
    }
}