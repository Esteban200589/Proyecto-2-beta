using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using System.Xml;

namespace Logica
{
    public interface InterfazLogicaUsuarios
    {
        void AgregarUsuario(Usuario user);
        
        Usuario Login(string username, string password);
        Usuario BuscarUsuario(string username);
    }

    public interface InterfazLogicaPeriodistas
    {
        void AgregarPeriodista(Periodista p);
        void ModificarPeriodista(Periodista p);
        void EliminarPeriodista(Periodista p);

        Periodista BuscarPeriodistaActivo(string cedula);
        List<Periodista> ListarPeriodistas();
    }

    public interface InterfazLogicaSecciones
    {
        void AgregarSeccion(Seccion s);
        void ModificarSeccion(Seccion s);
        void EliminarSeccion(Seccion s);

        Seccion BuscarSeccion(string codigo);
        List<Seccion> ListarSecciones();
    }

    public interface InterfazLogicaNoticias
    {
        List<Noticia> noticias_ultimos_cinco_dias();
        List<Noticia> noticias_para_estadisticas();

        void AgregarNoticia(Noticia n);
        void ModificarNoticia(Noticia n);
        Noticia BuscarNoticia(string codigo);

        XmlDocument ListadoNoticiasXML();
    }
}
