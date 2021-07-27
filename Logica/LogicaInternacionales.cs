using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaInternacionales
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


    }
}
