using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuarios : InterfazLogicaUsuarios
    {
        private static LogicaUsuarios _isntancia = null;
        private LogicaUsuarios() { }
        public static LogicaUsuarios GetInstanciaUsuarios()
        {
            if (_isntancia == null)
                _isntancia = new LogicaUsuarios();

            return _isntancia;
        }

        static InterfazPersistenciaUsuarios FabricaUsuarios = FabricaPersistencia.getPersistenciaUsuario();

        public void AgregarUsuario(Usuario user)
        {
            FabricaUsuarios.AgregarUsuario(user);
        }

        public Usuario Login(string username, string password)
        {
            return FabricaUsuarios.Login(username, password);
        }

        public Usuario BuscarUsuario(string username)
        {
            return FabricaUsuarios.BuscarUsuario(username);
        }
    }
}
