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
        Usuario BuscarUsuario(string username);
    }

    public interface InterfazLogicaPeriodistas
    {
        void AgregarPeriodista(Periodista p);
        void ModificarPeriodista(Periodista p);
        void EliminarPeriodista(Periodista p);

        Periodista BuscarPeriodistaActivo(string cedula);
        List<Periodista> ListarPeriodistas();
    }

    public interface InterfazLogicaSecciones
    {
        void AgregarSeccion(Seccion s);
        void ModificarSeccion(Seccion s);
        void EliminarSeccion(Seccion s);

        Seccion BuscarSeccion(string codigo);
        List<Seccion> ListarSecciones();
    }

    public interface InterfazLogicaInternacionales
    {
        void AgregarInternacional(Internacional n, string u);
        void ModificarInternacional(Internacional n, string u);

        List<Internacional> UltimasCincoInternacionales();
        Internacional MostrarInternacional(string codigo);
    }

    public interface InterfazLogicaNacionales
    {
        void AgregarNacional(Nacional n, string u, string s);
        void ModificarNacional(Nacional n, string u, string s);

        List<Nacional> UltimasCincoNacionales();
        Nacional MostrarNacional(string codigo);
    }

    
    
}
