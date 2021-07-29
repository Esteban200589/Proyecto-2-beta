using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaInternacionales : InterfazLogicaInternacionales
    {
        private static LogicaInternacionales instancia = null;
        private LogicaInternacionales() { }
        public static LogicaInternacionales GetInstanciaInternacionales()
        {
            if (instancia == null)
                instancia = new LogicaInternacionales();

            return instancia;
        }

        static InterfazPersistenciaInternacionales FabricaNoticias = FabricaPersistencia.getPersistenciaInteracional();


        public void AgregarInternacional(Internacional n, string u)
        {
            FabricaNoticias.AgregarInternacional(n, u);
        }

        public void ModificarInternacional(Internacional n, string u)
        {
            FabricaNoticias.ModificarInternacional(n, u);
        }


        public List<Internacional> UltimasCincoInternacionales()
        {
            return FabricaNoticias.UltimasCincoInternacioinales();
        }

        public Internacional MostrarInternacional(string codigo)
        {
            return FabricaNoticias.MostrarInternacional(codigo);
        }
    }
}