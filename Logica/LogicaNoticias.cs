using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;
using System.Xml;

namespace Logica
{
    internal class LogicaNoticias : InterfazLogicaNoticias
    {
        private static LogicaNoticias instancia = null;
        private LogicaNoticias() { }
        public static LogicaNoticias GetInstanciaNoticias()
        {
            if (instancia == null)
                instancia = new LogicaNoticias();

            return instancia;
        }

        static InterfazPersistenciaInternacionales FabricaInter = FabricaPersistencia.getPersistenciaInteracional();
        static InterfazPersistenciaNacionales FabricaNacionales = FabricaPersistencia.getPersistenciaNacional();

        public List<Noticia> noticias_ultimos_cinco_dias()
        {
            List<Noticia> noticias_ultimos_cinco_dias = new List<Noticia>();
            noticias_ultimos_cinco_dias.AddRange(FabricaNacionales.UltimasCincoNacionales());
            noticias_ultimos_cinco_dias.AddRange(FabricaInter.UltimasCincoInternacionales());
            return noticias_ultimos_cinco_dias;
        }
        public List<Noticia> noticias_para_estadisticas()
        {
            List<Noticia> noticias_para_estadisticas = new List<Noticia>();
            noticias_para_estadisticas.AddRange(FabricaNacionales.EstadisticasNacionales());
            noticias_para_estadisticas.AddRange(FabricaInter.EstadisticasInternacionales());
            return noticias_para_estadisticas;
        }

        public void AgregarNoticia(Noticia n)
        {
            if (n.Fecha.Date > DateTime.Now.Date)
            {
                if (n is Nacional)
                    FabricaNacionales.AgregarNacional((Nacional)n);
                else
                    FabricaInter.AgregarInternacional((Internacional)n);
            }
            else
            {
                throw new Exception("La fecha debe ser posterior a la actual");
            }

        }
        public void ModificarNoticia(Noticia n)
        {
            if (n.Fecha.Date > DateTime.Now.Date)
            {
                if (n is Nacional)
                    FabricaNacionales.ModificarNacional((Nacional)n);
                else
                    FabricaInter.ModificarInternacional((Internacional)n);
            }
            else
                throw new Exception("La fecha debe ser posterior a la actual");

        }
        public Noticia BuscarNoticia(string codigo)
        {
            Noticia n = null;
            if (n == null)
            {
                n = FabricaNacionales.BuscarNacional(codigo);
            }    
                       
            if (n == null)
            {
                n = FabricaInter.BuscarInternacional(codigo);
            }
                
            return n;
        }  
        
        public XmlDocument ListadoNoticiasXML()
        {
            //obtengo datos
            List<Noticia> listado = FabricaLogica.getLogicaNoticias().noticias_para_estadisticas();

            //convierto a xml
            XmlDocument documento = new XmlDocument();
            documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
            XmlNode root = documento.DocumentElement;

            //recorro la lista para crear los nodos
            foreach (Noticia n in listado)
            {
                XmlElement nodo = documento.CreateElement("Noticia");

                XmlElement codigo = documento.CreateElement("Codigo");
                codigo.InnerText = n.Codigo.ToString();
                nodo.AppendChild(codigo);

                XmlElement fecha = documento.CreateElement("Fecha");
                fecha.InnerText = n.Fecha.ToString("dd/MM/yyyy");
                nodo.AppendChild(fecha);

                XmlElement anio = documento.CreateElement("Anio");
                anio.InnerText = n.Fecha.ToString("yyyy");
                nodo.AppendChild(anio);

                XmlElement tipo = documento.CreateElement("Tipo");
                tipo.InnerText = n.TipoNoticia.ToString();
                nodo.AppendChild(tipo);

                XmlElement titulo = documento.CreateElement("Titulo");
                titulo.InnerText = n.Titulo.ToString();
                nodo.AppendChild(titulo);

                XmlElement importancia = documento.CreateElement("Importancia");
                importancia.InnerText = n.Importancia.ToString();
                nodo.AppendChild(importancia);

                root.AppendChild(nodo);

            }

            return documento;
        }

        public XmlDocument ListadoCantidadesXML()
        {
            //obtengo datos
            List<Noticia> listado = FabricaLogica.getLogicaNoticias().noticias_para_estadisticas();

            //convierto a xml
            XmlDocument documento = new XmlDocument();
            documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
            XmlNode root = documento.DocumentElement;

            //recorro la lista para crear los nodos
            foreach (Noticia n in listado)
            {
                XmlElement nodo = documento.CreateElement("Noticia");

                XmlElement codigo = documento.CreateElement("Codigo");
                codigo.InnerText = n.Codigo.ToString();
                nodo.AppendChild(codigo);

                XmlElement fecha = documento.CreateElement("Fecha");
                fecha.InnerText = n.Fecha.ToString("yyyy");
                nodo.AppendChild(fecha);

                XmlElement tipo = documento.CreateElement("Tipo");
                tipo.InnerText = n.TipoNoticia.ToString();
                nodo.AppendChild(tipo);

                XmlElement titulo = documento.CreateElement("Titulo");
                titulo.InnerText = n.Titulo.ToString();
                nodo.AppendChild(titulo);

                XmlElement importancia = documento.CreateElement("Importancia");
                importancia.InnerText = n.Importancia.ToString();
                nodo.AppendChild(importancia);

                root.AppendChild(nodo);

            }

            return documento;
        }
    }
}
