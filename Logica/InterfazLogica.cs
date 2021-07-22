using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Logica
{
    public interface InterfazLogicaUsuarios
    {
        void AgregarUsuario(Usuario user);
        Usuario Login(string username, string password);
    }

    public interface InterfazLogicaPeriodistas
    {
        void AgregarPeriodista(Periodista p);
        void ModificarPeriodista(Periodista p);
        void EliminarPeriodista(Periodista p);
        Periodista BuscarPeriodista(string cedula);
        //Periodista BuscarPeriodistaActivo(string cedula);
        //List<Periodista> ListarPeriodistas();
    }

    public interface InterfazLogicaNoticias
    {

    }

    public interface InterfazLogicaSecciones
    {

    }
    
}
