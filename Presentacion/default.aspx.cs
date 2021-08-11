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
            cargar_datos();
        }

        private void cargar_datos()
        {
            List<Noticia> noticias = null;
            noticias = FabricaLogica.getLogicaNoticias().noticias_ultimos_cinco_dias();
            //this.Response.Write(nacionales);

            List<object> listado = (from n in noticias
                                    select new
                                    {
                                        Fecha = n.Fecha,
                                        Tipo = n.TipoNoticia,
                                        Titulo = n.Titulo

                                    }).ToList<object>();

            gvNoticias.DataSource = listado;
            gvNoticias.DataBind();
        }
    }
}