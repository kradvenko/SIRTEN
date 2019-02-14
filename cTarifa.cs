using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cTarifa
    {
        public String IdTarifa { get; set; }
        public String ClaveActo { get; set; }
        public String ClaveIngresos { get; set; }
        public String Descuento { get; set; }
        public String Porcentaje { get; set; }
        public String SalariosMinimos { get; set; }
        public String SalariosMaximos { get; set; }
        public String SalariosFijos { get; set; }

        public cTarifa()
        {

        }

        public static cTarifa ObtenerTarifaActo(String ClaveActo)
        {
            cTarifa tarifa = new cTarifa();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * " +
                        "FROM Tarifas " +
                        "WHERE clave_acto = @ClaveActo " +
                        "", con))
                    {
                        query.Parameters.AddWithValue("ClaveActo", ClaveActo);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tarifa = new cTarifa();
                                tarifa.IdTarifa = reader["id_tarifa"].ToString();
                                tarifa.ClaveActo = reader["clave_acto"].ToString();
                                tarifa.ClaveIngresos = reader["clave_ingresos"].ToString();
                                tarifa.Descuento = reader["descuento"].ToString();
                                tarifa.Porcentaje = reader["porcentaje"].ToString();
                                tarifa.SalariosMinimos = reader["sm_min"].ToString();
                                tarifa.SalariosMaximos = reader["sm_max"].ToString();
                                tarifa.SalariosFijos = reader["sm_fijo"].ToString();
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                tarifa = null;
            }

            return tarifa;
        }
    }
}
