using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

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


        public void AgregarInternacional(Internacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaInter.AgregarInternacional(n);
        }
        public void ModificarInternacional(Internacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaInter.ModificarInternacional(n);
        }
        public Internacional BuscarInternacional(string codigo)
        {
            return FabricaInter.BuscarInternacional(codigo);
        }

        public void AgregarNacional(Nacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaNacionales.AgregarNacional(n);
        }

        public void ModificarNacional(Nacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaNacionales.ModificarNacional(n);
        }

        public Nacional BuscarNacional(string codigo)
        {
            return FabricaNacionales.BuscarNacional(codigo);
        }
    }
}
