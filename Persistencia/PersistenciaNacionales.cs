using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaNacionales
    {
        private static PersistenciaNacionales instancia = null;
        private PersistenciaNacionales() { }
        public static PersistenciaNacionales GetInstanciaNacionales()
        {
            if (instancia == null)
                instancia = new PersistenciaNacionales();

            return instancia;
        }


    }
}
