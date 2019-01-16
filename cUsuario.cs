using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    //Clase para el control de los usuarios del sistema.
    //Incluye los datos de usuario y funciones para:
    //-Inicio de Sesión (LoginUsuario)
    //
    public class cUsuario
    {
        public String idUsuario;
        public String nombre;
        public String apellidoPaterno;
        public String apellidoMaterno;
        public String login;
        public String password;
        public String idTipoUsuario;
        public String tipoUsuario;
        public String estado;

        public cUsuario()
        {

        }
        //Función para el inicio de sesión.
        //Primero se verifica que existe el nombre de usuario.
        //Después que su contraseña sea la correcta.
        //Si no existe el usuario el código de error retornado es 01.
        //Si existe el usuario pero la contraseña es equivocada el código de error retornado es 02.
        //Si ambos datos son correctos se retorna OK.
        public static String LoginUsuario(String login, String password, out cUsuario c)
        {
            String resultado = "OK";
            c = new cUsuario();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("sp_rpp_login", con))
                    {
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("login", login);
                        query.Parameters.AddWithValue("password", password);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["respuesta"].ToString() == "OK")
                                {
                                    c.idUsuario = reader["id_usuario"].ToString();
                                    c.nombre = reader["nombre"].ToString();
                                    c.apellidoPaterno = reader["apellido_paterno"].ToString();
                                    c.apellidoMaterno = reader["apellido_materno"].ToString();
                                    c.login = reader["login"].ToString();
                                    c.password = reader["password"].ToString();
                                    c.idUsuario = reader["id_tipo_usuario"].ToString();
                                    c.tipoUsuario = reader["tipo"].ToString();
                                    c.estado = reader["estatus"].ToString();
                                }
                                else
                                {
                                    resultado = reader["respuesta"].ToString();
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                resultado = exc.Message;
                c = null;
            }
            return resultado;
        }
    }
}
