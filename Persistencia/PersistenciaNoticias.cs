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
    internal class PersistenciaNoticias : InterfazPersistenciaNoticias
    {
        private static PersistenciaNoticias instancia = null;
        private PersistenciaNoticias() { }
        public static PersistenciaNoticias GetInstanciaNoticias()
        {
            if (instancia == null)
                instancia = new PersistenciaNoticias();

            return instancia;
        }


    }
}
