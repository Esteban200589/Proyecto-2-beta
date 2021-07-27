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


        public Noticia MostrarNoticiaIndividual(int tipo, string codigo, Usuario user, Seccion secc = null, List<Periodista> ptas = null)
        {
            Noticia noticia = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("noticia_individual", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", tipo);
                cmd.Parameters.AddWithValue("codigo", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (true)
                    {
                        if (tipo == 0)
                        {
                            noticia = new Nacional(secc, dr["codigo"].ToString(), Convert.ToDateTime(dr["fecha"]), 
                                                   dr["titulo"].ToString(), dr["cuerpo"].ToString(), Convert.ToInt32(dr["importancia"]),
                                                   ptas, user);
                        }
                        else
                        {
                            noticia = new Internacional(dr["pais"].ToString(), dr["codigo"].ToString(), Convert.ToDateTime(dr["fecha"]), 
                                                   dr["titulo"].ToString(), dr["cuerpo"].ToString(), Convert.ToInt32(dr["importancia"]),
                                                   ptas, user);
                        }
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            return noticia;
        }

    }

}
