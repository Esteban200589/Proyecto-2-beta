using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        private static string Server = "DESKTOP-MGR3B3L\\SQLEXPRESS;";
        private static string DataBase = "Obligatorio_BIOS_News;";
        private static string cnn = "Data Source=" + Server +
                                    "Initial Catalog=" + DataBase +
                                    "Integrated Security = true";
        internal static string Cnn
        {
            get { return cnn; }
        }

        // --
    }
}