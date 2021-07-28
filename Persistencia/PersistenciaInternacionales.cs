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
    internal class PersistenciaInternacionales: InterfazPersistenciaInternacionales
    {
        private static PersistenciaInternacionales instancia = null;
        private PersistenciaInternacionales() { }
        public static PersistenciaInternacionales GetInstanciaInternacionales()
        {
            if (instancia == null)
                instancia = new PersistenciaInternacionales();

            return instancia;
        }

        public void AgregarInternacional(Internacional n, Usuario u)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand cmd = new SqlCommand("agregar_internacional", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codigo", n.Codigo);
            cmd.Parameters.AddWithValue("fecha", n.Fecha);
            cmd.Parameters.AddWithValue("titulo", n.Titulo);
            cmd.Parameters.AddWithValue("cuerpo", n.Cuerpo);
            cmd.Parameters.AddWithValue("importancia", n.Importancia);
            cmd.Parameters.AddWithValue("pais", n.Pais);
            cmd.Parameters.AddWithValue("username", u.Username);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);

            SqlTransaction trn = null;

            try
            {
                cnn.Open();

                trn = cnn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La Noticia ya existe.");
                if (valor == -2)
                    throw new Exception("El usuario no existe.");

                foreach (Periodista p in n.Periodistas)
                {
                    PersistenciaEscriben.GetInstanciaEscriben().AgregarEscriben(n.Codigo,p,trn);
                }

                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }

        public void ModificarInternacional(Internacional n, Usuario u)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand cmd = new SqlCommand("modificar_internacional", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("codigo", n.Codigo);
            cmd.Parameters.AddWithValue("fecha", n.Fecha);
            cmd.Parameters.AddWithValue("titulo", n.Titulo);
            cmd.Parameters.AddWithValue("cuerpo", n.Cuerpo);
            cmd.Parameters.AddWithValue("importancia", n.Importancia);
            cmd.Parameters.AddWithValue("pais", n.Pais);
            cmd.Parameters.AddWithValue("username", u.Username);

            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);

            SqlTransaction trn = null;

            try
            {
                cnn.Open();

                trn = cnn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La Noticia ya existe.");
                if (valor == -2)
                    throw new Exception("El usuario no existe.");

                foreach (Periodista p in n.Periodistas)
                {
                    PersistenciaEscriben.GetInstanciaEscriben().AgregarEscriben(n.Codigo, p, trn);
                }

                trn.Commit();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }


        public List<Internacional> UltimasCincoInternacioinales()
        {
            List<Internacional> lista = new List<Internacional>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("ultimas_cinco_internacionales", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Usuario user = null;
                Internacional noticia = null;
                List<Periodista> ptas = new List<Periodista>();

                while (dr.Read())
                {
                    InterfazPersistenciaPeriodistas IntPtas = FabricaPersistencia.getPersistenciaPeriodista();
                    ptas = IntPtas.ListarPeriodistas();
                    InterfazPersistenciaUsuarios IntUser = FabricaPersistencia.getPersistenciaUsuario();
                    user = IntUser.BuscarUsuario(dr["username"].ToString());
                    noticia = new Internacional(dr["pais"].ToString(), dr["codigo"].ToString(), Convert.ToDateTime(dr["fecha"]),
                                                dr["titulo"].ToString(), dr["cuerpo"].ToString(), Convert.ToInt32(dr["importancia"]),
                                                ptas, user);
                    lista.Add(noticia);
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

            return lista;
        }

        public Internacional MostrarInternacional(string codigo)
        {
            Usuario user = null;
            Internacional noticia = null;
            List<Periodista> ptas = new List<Periodista>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("noticia_individual", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("tipo", 0);
                cmd.Parameters.AddWithValue("codigo", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    InterfazPersistenciaPeriodistas IntPtas = FabricaPersistencia.getPersistenciaPeriodista();
                    ptas = IntPtas.ListarPeriodistas();
                    InterfazPersistenciaUsuarios IntUser = FabricaPersistencia.getPersistenciaUsuario();
                    noticia = new Internacional(dr["pais"].ToString(), dr["codigo"].ToString(), Convert.ToDateTime(dr["fecha"]),
                                            dr["titulo"].ToString(), dr["cuerpo"].ToString(), Convert.ToInt32(dr["importancia"]),
                                            ptas, user);
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
