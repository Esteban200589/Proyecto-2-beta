using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Seccion
    {
        private string codigo_secc;
        private string nombre_secc;

        public string Codigo_secc
        {
            get { return codigo_secc; }
            set { 
                codigo_secc = value; 
            }
        }
        public string Nombre_secc
        {
            get { return nombre_secc; }
            set {
                if (value.Length != 5)
                    throw new Exception("El Nombre debe contener hasta 5 caracteres de largo.");
                else
                    nombre_secc = value;
            }
        }

        public Seccion(string pCode, string pName)
        {
            Codigo_secc = pCode;
            Nombre_secc = pName;
        }
    }
}
