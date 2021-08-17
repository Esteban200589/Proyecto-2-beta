using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Nacional : Noticia
    {
        private Seccion seccion;

        public Seccion Seccion
        {
            get { return seccion; }
            set {
                if (value == null)
                    throw new Exception("La Noticia Nacional debe contener una Sección");
                else
                    seccion = value;
            }
        }

        public override string TipoNoticia
        {
            get { return "Nacional"; }
        }


        public Nacional(Seccion pSecc, string pCode, DateTime pFecha, string pTitle, string pBody, 
            int pImp, List<Periodista> pPer, Usuario pUser) 
        : base(pCode, pFecha, pTitle, pBody, pImp, pPer, pUser)
        {
            Seccion = pSecc;
        }
    }
}
