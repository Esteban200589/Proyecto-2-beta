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
            List<Nacional> nacionales = FabricaLogica.getLogicaNacionales().UltimasCincoNacionales();
            List<Internacional> internacionales = FabricaLogica.getLogicaInternacionales().UltimasCincoInternacionales();
           
            List<object> listado = (from nacio in nacionales
                                    join inter in internacionales
                                    on nacio.TipoNoticia equals inter.TipoNoticia into table
                                    select new{
                                        Fecha = table.First(),
                                        Tipo = table.ElementAt(1)
                                    }).ToList<object>();

            foreach (var n in nacionales)
            {
                this.Response.Write(n);
            }

            //try
            //{
            //    Session["Noticias"] = listado;
            //    gvNoticias.DataSource = listado;
            //    gvNoticias.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    this.Response.Write("Error al cargar grilla. "+ ex);
            //}


            gvNoticias.DataSource = nacionales;
            gvNoticias.DataBind();
        }
    }
}