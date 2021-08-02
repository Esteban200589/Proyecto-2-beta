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
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // List<Noticia> todas = 

            // noticias de los ultimos 5 dias

            List<Internacional> internacionales = FabricaLogica.getLogicaInternacionales().UltimasCincoInternacionales();

            List<Nacional> nacionales = FabricaLogica.getLogicaNacionales().UltimasCincoNacionales();

            List<object> listado = (from inter in internacionales
                                    join nacio in nacionales
                                    on inter.TipoNoticia equals nacio.TipoNoticia
                                    group inter by inter.TipoNoticia into grupo  
                                    select new
                                    {
                                        Fecha = grupo.Key
                                        //Tipo = 
                                    }
                                    
                                    ).ToList<object>();

            gvNoticias.DataSource = listado;
            gvNoticias.DataBind();
        }
    }
}