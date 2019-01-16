using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cActo
    {
        public String IdActo { get; set; }
        public String ClaveActo { get; set; }
        public String ClaveIngresos { get; set; }
        public String Nombre { get; set; }
        public String Cuenta { get; set; }
        public String Area { get; set; }
        public String Seccion { get; set; }
        public String Tipo { get; set; }

        public cActo()
        {

        }

        public static ObservableCollection<cActo> ObtenerActos(String busqueda)
        {
            ObservableCollection<cActo> actos = new ObservableCollection<cActo>();
            cActo c = new cActo();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("sp_rpp_obtener_ListaActos", con))
                    {
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("busqueda", busqueda);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cActo();
                                c.IdActo = reader["id_tramitante"].ToString();
                                c.ClaveActo = reader["clave_acto"].ToString();
                                c.ClaveIngresos = reader["clave_ingresos"].ToString();
                                c.Nombre = reader["nombre"].ToString();
                                c.Cuenta = reader["cuenta"].ToString();
                                c.Area = reader["area"].ToString();
                                c.Seccion = reader["seccion"].ToString();
                                c.Tipo = reader["tipo"].ToString();
                                actos.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                actos = null;
            }
            return actos;
        }
    }
}
