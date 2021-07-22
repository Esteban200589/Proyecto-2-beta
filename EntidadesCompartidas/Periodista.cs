using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (value.Length <= 8)
                    throw new Exception("La cedula debe contener hasta 8 caracteres maximo.");
                else
                    cedula = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set {
                if (value.Length <= 30)
                    throw new Exception("El nombre debe contener hasta 30 caracteres maximo.");
                else
                    nombre = value;
            }
        }
        public string E_mail
        {
            get { return e_mail; }
            set {
                if (value.Length <= 30)
                    throw new Exception("El e-email debe contener hasta 30 caracteres maximo.");
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
