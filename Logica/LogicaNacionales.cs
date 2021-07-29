using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaNacionales : InterfazLogicaNacionales
    {
        private static LogicaNacionales instancia = null;
        private LogicaNacionales() { }
        public static LogicaNacionales GetInstanciaNacionales()
        {
            if (instancia == null)
                instancia = new LogicaNacionales();

            return instancia;
        }

        static InterfazPersistenciaNacionales FabricaNoticias = FabricaPersistencia.getPersistenciaNacional();


        public void AgregarNacional(Nacional n, string u, string s)
        {
            FabricaNoticias.AgregarNacional(n, u, s);
        }

        public void ModificarNacional(Nacional n, string u, string s)
        {
            FabricaNoticias.ModificarNacional(n, u, s);
        }


        public List<Nacional> UltimasCincoNacionales()
        {
            return FabricaNoticias.UltimasCincoNacionales();
        }

        public Nacional MostrarNacional(string codigo)
        {
            return FabricaNoticias.MostrarNacional(codigo);
        }
    }
}
