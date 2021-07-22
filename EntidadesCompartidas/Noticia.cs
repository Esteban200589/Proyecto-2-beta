using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public abstract class Noticia
    {
        private string codigo;
        private DateTime fecha;
        private string titulo;
        private string cuerpo;
        private int importancia;
        private List<Periodista> periodistas;
        private Usuario usuario;

        public string Codigo 
        {
            get { return codigo; }
            set {
                if (value.Length != 6)
                    throw new Exception("El codigo debe ser contener 6 digitos ");
                else
                    codigo = value;
            }
        }
        public DateTime Fecha 
        {
            get { return fecha; } 
            set {
                fecha = value;
            }
        }
        public string Titulo 
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Cuerpo 
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }
        public int Importancia 
        {
            get { return importancia; }
            set { importancia = value; }
        }
        public Periodista Periodista 
        {
            get { return periodista; }
            set {
                if (value == null)
                    throw new Exception("La Noticia Nacional debe contener un");
                else
                    periodista = value;
            }
        }
        public Usuario Usuario 
        {
            get { return usuario; }
            set {
                if (value == null)
                    throw new Exception("La Noticia debe contener un Usuario");
                else
                    usuario = value;
            }
        }

        public Noticia(string pCode, DateTime pFecha, string pTitle, string pBody, int pImp, 
            Periodista pPer, Usuario pUser)
        {
            Codigo = pCode;
            Fecha = pFecha;
            Titulo = pTitle;
            Cuerpo = pBody;
            Importancia = pImp;
            Periodista = pPer;
            Usuario = pUser;
        }

        
    }
}
