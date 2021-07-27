using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaSecciones
    {
        private static LogicaSecciones instancia = null;
        private LogicaSecciones() { }
        public static LogicaSecciones GetInstanciaSecciones()
        {
            if (instancia == null)
                instancia = new LogicaSecciones();

            return instancia;
        }

        static InterfazPersistenciaSecciones FabricaSecciones = FabricaPersistencia.getPersistenciaSeccion();


    }
}
