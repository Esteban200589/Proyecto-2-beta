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


        public void AgregarNacional(Nacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaNoticias.AgregarNacional(n);
        }

        public void ModificarNacional(Nacional n)
        {
            if (n.Fecha < DateTime.Now)
                FabricaNoticias.ModificarNacional(n);
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
