using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaEscriben : InterfazPersistenciaEscriben
    {
        private static PersistenciaEscriben instancia = null;
        private PersistenciaEscriben() { }
        public static PersistenciaEscriben GetInstanciaEscriben()
        {
            if (instancia == null)
                instancia = new PersistenciaEscriben();

            return instancia;
        }

        public void AgregarEscriben(string codigo_noticia, Periodista periodista, SqlTransaction trn)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                SqlCommand cmd = new SqlCommand("agregar_escriben", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", periodista.Cedula);
                cmd.Parameters.AddWithValue("codigo", codigo_noticia);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("El periodista no existe.");
                if (valor == -2)
                    throw new Exception("La noticia no existe.");
                if (valor == -3)
                    throw new Exception("Ya escribieron esa noticia.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEscriben(string codigo_noticia, SqlTransaction trn)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("borrar_ecriben", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", codigo_noticia);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("No existe el registro.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }


        
    }

}
