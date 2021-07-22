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
    public class PersistenciaUsuarios : InterfazPersistenciaUsuarios
    {
        private static PersistenciaUsuarios instancia = null;
        private PersistenciaUsuarios() { }
        public static PersistenciaUsuarios GetInstanciaUsuarios()
        {
            if (instancia == null)
                instancia = new PersistenciaUsuarios();

            return instancia;
        }

        public void AgregarUsuario(Usuario user)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("agregar_usuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("password", user.Password);

                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                int valor = Convert.ToInt32(ret.Value);

                if (valor == -1)
                    throw new Exception("El username ya existe.");
                if (valor == -2)
                    throw new Exception("El password debe tener 7 caracteres exctamente.");
                if (valor == -3)
                    throw new Exception("El username debe tener 10 caracteres exctamente.");
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

        public Usuario Login(string username, string password)
        {
            Usuario user = null;
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("logueo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);
               
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    user = new Usuario(username,password);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return user;
        }

    }
}