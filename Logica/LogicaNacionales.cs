using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaNacionales
    {
        private static LogicaNacionales instancia = null;
        private LogicaNacionales() { }
        public static LogicaNacionales GetInstanciaInternacionales()
        {
            if (instancia == null)
                instancia = new LogicaNacionales();

            return instancia;
        }

        static InterfazPersistenciaNacionales FabricaNoticias = FabricaPersistencia.getPersistenciaNacional();


    }
}
