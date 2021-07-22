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
    }

    public interface InterfazPersistenciaPeriodistas
    {
        void AgregarPeriodista(Periodista p);
        void EliminarPeriodista(Periodista p);
        void ModificarPeriodista(Periodista p);
        Periodista BuscarPeriodista(string cedula);
        Periodista BuscarPeriodistaActivo(string cedula);
        List<Periodista> ListarPeriodistas();
    }

    public interface InterfazPersistenciaSecciones
    {

    }

    public interface InterfazPersistenciaNoticias
    {
        
    }

    

}
