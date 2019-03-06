using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cMunicipio
    {
        public String IdMunicipio { get; set; }
        public String Nombre { get; set; }

        public cMunicipio()
        {

        }

        public static ObservableCollection<cMunicipio> ObtenerMunicipios()
        {
            ObservableCollection<cMunicipio> lista = new ObservableCollection<cMunicipio>();
            cMunicipio c = new cMunicipio();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM Municipios", con))
                    {
                        con.Open();

                        SqlDataReader reader = query.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cMunicipio();
                                c.IdMunicipio = reader["id_municipio"].ToString();
                                c.Nombre = reader["nombre"].ToString();
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
