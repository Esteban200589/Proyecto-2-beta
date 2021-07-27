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
    public class PersistenciaPeriodistas : InterfazPersistenciaPeriodistas
    {
        private static PersistenciaPeriodistas instancia = null;
        private PersistenciaPeriodistas() { }
        public static PersistenciaPeriodistas GetInstanciaPeriodistas()
        {
            if (instancia == null)
                instancia = new PersistenciaPeriodistas();

            return instancia;
        }

        public void AgregarPeriodista(Periodista p)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("agregar_periodista", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", p.Cedula);
                cmd.Parameters.AddWithValue("nombre", p.Nombre);
                cmd.Parameters.AddWithValue("email", p.E_mail);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("El periodista ya existe.");
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
        
        public void ModificarPeriodista(Periodista p)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("modificar_periodista", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", p.Cedula);
                cmd.Parameters.AddWithValue("nombre", p.Nombre);
                cmd.Parameters.AddWithValue("email", p.E_mail);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La cedula debe tener hasta 8 caracteres maximo.");
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
        
        public void EliminarPeriodista(Periodista p)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("borrar_periodista", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", p.Cedula);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("El periodista no existe, no puede eliminarse.");
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
        
        public Periodista BuscarPeriodista(string cedula)
        {
            Periodista p = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_periodista", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", cedula);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p = new Periodista(cedula, dr["nombre"].ToString(), dr["email"].ToString());
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
            return p;
        }
        
        public Periodista BuscarPeriodistaActivo(string cedula)
        {
            Periodista p = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_periodista_activo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cedula", cedula);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p = new Periodista(cedula, dr["nombre"].ToString(), dr["email"].ToString());
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
            return p;
        }
        
        public List<Periodista> ListarPeriodistas()
        {
            List<Periodista> lista = new List<Periodista>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_periodistas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Periodista p = null;

                while (dr.Read())
                {
                    p = new Periodista(dr["cedula"].ToString(), dr["nombre"].ToString(), dr["email"].ToString());
                    lista.Add(p);
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

        public List<Periodista> ListarPeriodistasPorNoticia(Noticia n)
        {
            List<Periodista> lista = new List<Periodista>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_periodistas_noticia", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo", n.Codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                Periodista p = null;

                while (dr.Read())
                {
                    p = new Periodista(dr["cedula"].ToString(), dr["nombre"].ToString(), dr["email"].ToString());
                    lista.Add(p);
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
    }
}