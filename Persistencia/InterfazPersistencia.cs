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
        void AgregarInternacional(Internacional n);
        void ModificarInternacional(Internacional n);
        
        List<Internacional> UltimasCincoInternacionales();
        List<Internacional> EstadisticasInternacionales();
        Internacional MostrarInternacional(string codigo);
    }

    public interface InterfazPersistenciaNacionales
    {
        void AgregarNacional(Nacional n);
        void ModificarNacional(Nacional n);
        
        List<Nacional> UltimasCincoNacionales();
        List<Nacional> EstadisticasNacionales();
        Nacional MostrarNacional(string codigo);
    }
}
