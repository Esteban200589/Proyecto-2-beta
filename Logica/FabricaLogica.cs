using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        public static InterfazLogicaUsuarios getLogicaUsuarios()
        {
            return LogicaUsuarios.GetInstanciaUsuarios();
        }

        public static InterfazLogicaPeriodistas getLogicaPeriodistas()
        {
            return LogicaPeriodistas.GetInstanciaPeriodistas();
        }
    }
}
