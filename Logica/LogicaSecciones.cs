using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaSecciones : InterfazLogicaSecciones
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


        public void AgregarSeccion(Seccion s)
        {
            FabricaSecciones.AgregarSeccion(s);
        }

        public void ModificarSeccion(Seccion s)
        {
            FabricaSecciones.ModificarSeccion(s);
        }

        public void EliminarSeccion(Seccion s)
        {
            FabricaSecciones.EliminarSeccion(s);
        }


        public Seccion BuscarSeccion(string codigo)
        {
            return FabricaSecciones.BuscarSeccionActiva(codigo);
        }

        public List<Seccion> ListarSecciones()
        {
            return FabricaSecciones.ListarSecciones();
        }

    }
}
