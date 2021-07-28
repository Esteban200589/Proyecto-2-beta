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
    public interface InterfazPersistenciaUsuarios
    {
        void AgregarUsuario(Usuario user);
        Usuario Login(string username, string password);
        Usuario BuscarUsuario(string username);
    }

    public interface InterfazPersistenciaPeriodistas
    {
        void AgregarPeriodista(Periodista p);
        void EliminarPeriodista(Periodista p);
        void ModificarPeriodista(Periodista p);
        Periodista BuscarPeriodistaActivo(string cedula);
        List<Periodista> ListarPeriodistas();
    }

    public interface InterfazPersistenciaSecciones
    {
        void AgregarSeccion(Seccion s);
        void ModificarSeccion(Seccion s);
        void EliminarSeccion(Seccion s);
        Seccion BuscarSeccionActiva(string coodigo);
        List<Seccion> ListarSecciones();
    }

    public interface InterfazPersistenciaInternacionales
    {
        void AgregarInternacional(Internacional n, Usuario u);
        void ModificarInternacional(Internacional n, Usuario u);
        List<Internacional> UltimasCincoInternacioinales(Usuario user, List<Periodista> ptas);
    }

    public interface InterfazPersistenciaNacionales
    {
        void AgregarNacional(Nacional n, Usuario u, Seccion s);
        void ModificarNacional(Nacional n, Usuario u, Seccion s);
        List<Nacional> UltimasCincoNacionales(Usuario user, List<Periodista> ptas, Seccion secc);
    }
}
