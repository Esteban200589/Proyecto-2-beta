using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Internacional : Noticia
    {
        private string pais;

        public string Pais
        {
            get { return pais; }
            set {
                if (value != null)
                    throw new Exception("Debe tener un pais de origen.");
                else if (value.Length > 25)
                    throw new Exception("El nombre del pais puede tener hasta 25 caracteres de largo maximo.");
                else
                    pais = value;
            }
        }

        public override string TipoNoticia
        {
            get { return "Noticia Internacional"; }
        }

        public Internacional(string pPais, string pCode, DateTime pFecha, string pTitle, 
            string pBody, int pImp, List<Periodista> pPer, Usuario pUser)
        : base(pCode, pFecha, pTitle, pBody, pImp, pPer, pUser)
        {
            Pais = pPais;
        }
    }
}