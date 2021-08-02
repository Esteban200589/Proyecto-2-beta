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
    internal class PersistenciaSecciones : InterfazPersistenciaSecciones
    {
        private static PersistenciaSecciones instancia = null;
        private PersistenciaSecciones() { }
        public static PersistenciaSecciones GetInstanciaSecciones()
        {
            if (instancia == null)
                instancia = new PersistenciaSecciones();

            return instancia;
        }

        public void AgregarSeccion(Seccion s)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("agregar_seccion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_secc", s.Codigo_secc);
                cmd.Parameters.AddWithValue("nombre_secc", s.Nombre_secc);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La seccion ya existe.");
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

        public void ModificarSeccion(Seccion s)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("modificar_seccion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_secc", s.Codigo_secc);
                cmd.Parameters.AddWithValue("nombre_secc", s.Nombre_secc);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("Codigo de sección incorrecto.");
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

        public void EliminarSeccion(Seccion s)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("borrar_seccion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_secc", s.Codigo_secc);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("La sección no existe, no puede eliminarse.");
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


        internal Seccion BuscarSeccion(string codigo)
        {
            Seccion s = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_seccion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_secc", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    s = new Seccion(codigo, dr["nombre_secc"].ToString());
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
            return s;
        }

        public Seccion BuscarSeccionActiva(string codigo)
        {
            Seccion s = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("buscar_seccion_activa", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigo_secc", codigo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    s = new Seccion(codigo, dr["nombre_secc"].ToString());
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
            return s;
        }

        public List<Seccion> ListarSecciones()
        {
            List<Seccion> lista = new List<Seccion>();
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("listar_secciones", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                Seccion s = null;

                while (dr.Read())
                {
                    s = new Seccion(dr["codigo_secc"].ToString(), dr["nombre_secc"].ToString());
                    lista.Add(s);
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