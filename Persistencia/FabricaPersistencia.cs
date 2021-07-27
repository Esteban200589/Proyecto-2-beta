using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static InterfazPersistenciaPeriodistas getPersistenciaPeriodista()
        {
            return PersistenciaPeriodistas.GetInstanciaPeriodistas();
        }

        public static InterfazPersistenciaUsuarios getPersistenciaUsuario()
        {
            return PersistenciaUsuarios.GetInstanciaUsuarios();
        }

        public static InterfazPersistenciaSecciones getPersistenciaSeccion()
        {
            return PersistenciaSecciones.GetInstanciaSecciones();
        }

        public static InterfazPersistenciaNacionales getPersistenciaNacional()
        {
            return PersistenciaNacionales.GetInstanciaNacionales();
        }

        public static InterfazPersistenciaInternacionales getPersistenciaInteracional()
        {
            return PersistenciaInternacionales.GetInstanciaInternacionales();
        }
    }
}
