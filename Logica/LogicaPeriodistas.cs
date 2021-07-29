using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPeriodistas : InterfazLogicaPeriodistas
    {
        private static LogicaPeriodistas instancia = null;
        private LogicaPeriodistas() { }
        public static LogicaPeriodistas GetInstanciaPeriodistas()
        {
            if (instancia == null)
                instancia = new LogicaPeriodistas();

            return instancia;
        }

        static InterfazPersistenciaPeriodistas FabricaPeriodistas = FabricaPersistencia.getPersistenciaPeriodista();


        public void AgregarPeriodista(Periodista p)
        {
            FabricaPeriodistas.AgregarPeriodista(p);
        }

        public void ModificarPeriodista(Periodista p)
        {
            FabricaPeriodistas.ModificarPeriodista(p);
        }

        public void EliminarPeriodista(Periodista p)
        {
            FabricaPeriodistas.EliminarPeriodista(p);
        }


        public Periodista BuscarPeriodistaActivo(string cedula)
        {
            return FabricaPeriodistas.BuscarPeriodistaActivo(cedula);
        }

        public List<Periodista> ListarPeriodistas()
        {
            return FabricaPeriodistas.ListarPeriodistas();
        }
    }
}