using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cPoblacion
    {
        public String IdPoblacion { get; set; }
        public String IdMunicipio { get; set; }
        public String Nombre { get; set; }
        public String Ambito { get; set; }

        public cPoblacion()
        {

        }

        public static ObservableCollection<cPoblacion> ObtenerPoblacionesMunicipio(String IdMunicipio)
        {
            ObservableCollection<cPoblacion> lista = new ObservableCollection<cPoblacion>();
            cPoblacion c = new cPoblacion();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM Poblaciones " +
                        "WHERE id_municipio = @IdMunicipio", con))
                    {
                        query.Parameters.AddWithValue("@IdMunicipio", IdMunicipio);
                        con.Open();

                        SqlDataReader reader = query.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cPoblacion();
                                c.IdPoblacion = reader["id_poblacion"].ToString();
                                c.IdMunicipio = reader["id_municipio"].ToString();
                                c.Nombre = reader["nombre"].ToString();
                                c.Ambito = reader["ambito"].ToString();
                                lista.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                lista = null;
            }
            return lista;
        }

    }
}
