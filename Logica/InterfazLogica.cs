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

        Periodista BuscarPeriodistaActivo(string cedula);
        List<Periodista> ListarPeriodistas();
        List<Periodista> ListarPeriodistasPorNoticia(Noticia n);
    }

    public interface InterfazLogicaSecciones
    {

    }


    public interface InterfazLogicaInternacionales
    {

    }

    public interface InterfazLogicaNacionales
    {

    }

    
    
}
