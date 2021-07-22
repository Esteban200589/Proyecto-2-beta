using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set {
                if (value.Length != 10)
                    throw new Exception("El Username debe contener 10 exactamente ");
                else
                    username = value;
            }
        }
        public string Password
        {
            get { return password; }
            set {
                if (value.Length != 7)
                    throw new Exception("El Password debe contener 7 estrictamente en el siguiente formato." +
                        "\nEjemplo: 'abcd123' (4 letras y 3 números)");
                else
                    password = value;
            }
        }

        public Usuario(string pUser, string pPass)
        {
            Username = pUser;
            Password = pPass;
        }
    }
}
