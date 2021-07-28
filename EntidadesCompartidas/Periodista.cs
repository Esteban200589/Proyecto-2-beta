using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;


namespace EntidadesCompartidas
{
    public class Periodista
    {
        private string cedula;
        private string nombre;
        private string e_mail;

        public string Cedula
        {
            get { return cedula; }
            set {
                if (value == "")
                    throw new Exception("Fala la cedula.");
                else if (value.Length != 8)
                    throw new Exception("La cedula es incorrecta.");
                else
                    cedula = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set {
                if (value == null)
                    throw new Exception("Debe contener un nombre.");
                else if (value.Length >= 30)
                    throw new Exception("El nombre debe contener hasta 30 caracteres maximo.");
                else
                    nombre = value;
            }
        }
        public string E_mail
        {
            get { return e_mail; }
            set {
                if (value == null)
                    throw new Exception("Debe contener un e-mail.");
                else if (value.Length >= 30)
                    throw new Exception("El e-mail debe contener hasta 30 caracteres maximo.");
                else if (Regex.IsMatch(value, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") == false)
                    throw new Exception("El formato es incorrecto.");
                else
                    e_mail = value;
            }
        }

        public Periodista(string pCI, string pName, string pMail)
        {
            Cedula = pCI;
            Nombre = pName;
            E_mail = pMail;
        }
    }
}
