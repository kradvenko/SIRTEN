using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cConfiguracion
    {
        public String IdConfiguracion { get; set; }
        public String NombreOficina { get; set; }

        public cConfiguracion()
        {

        }

        public static ObservableCollection<cConfiguracion> ObtenerConfiguracion()
        {
            ObservableCollection<cConfiguracion> config = new ObservableCollection<cConfiguracion>();
            cConfiguracion c = new cConfiguracion();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM Configuracion", con))
                    {
                        con.Open();

                        SqlDataReader reader = query.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cConfiguracion();
                                c.IdConfiguracion = reader["id_configuracion"].ToString();
                                c.NombreOficina = reader["nombre_oficina"].ToString();
                                config.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                config = null;
            }
            return config;
        }
    }
}
