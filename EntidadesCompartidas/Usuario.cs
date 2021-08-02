using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;


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
                if (value.Trim().Length != 10)
                    throw new Exception("El Username debe contener 10 exactamente ");
                else
                    username = value;
            }
        }
        public string Password
        {
            get { return password; }
            set {
                if (value.Trim().Length != 7)
                    throw new Exception("El Password debe contener 7 estrictamente en el siguiente formato." +
                                        "\nEjemplo: 'abcd123' (4 letras y 3 números)");
                //else if (Regex.IsMatch(value, "[A-Z]{4}[0-9]{3}") == false)
                //    throw new Exception("El formato debe ser: Ejemplo: 'abcd123' (4 letras y 3 números)");  
                else
                    password = value;
            }
        }

        //public string Password_login
        //{
        //    get { return password; }
        //    set
        //    {
        //        if (value.Trim().Length != 7)
        //            throw new Exception("El Password es incorrecto.");
        //        else if (Regex.IsMatch(value, "[A-Z]{4}[0-9]{3}") == false)
        //            throw new Exception("El Password es incorrecto.");
        //        else
        //            password = value;
        //    }
        //}

        public Usuario(string pUser, string pPass)
        {
            Username = pUser;
            Password = pPass;
        }

        //public Usuario(string pUser, string pPass, string context)
        //{
        //    Username = pUser;
        //    Password_login = pPass;
        //}
    }
}