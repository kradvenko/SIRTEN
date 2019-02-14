using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cMovimiento
    {
        public String IdMovimiento { get; set; }
        public String IdActo { get; set; }
        public String Nombre { get; set; }
        public String TipoFolio { get; set; }

        public cMovimiento()
        {

        }

        public static ObservableCollection<cMovimiento> ObtenerMovimientosActo(String idActo)
        {
            ObservableCollection<cMovimiento> movimientos = new ObservableCollection<cMovimiento>();
            cMovimiento c = new cMovimiento();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM Movimientos " +
                        "WHERE id_acto = @IdActo", con))
                    {
                        query.Parameters.AddWithValue("IdActo", idActo);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cMovimiento();
                                c.IdActo = reader["id_acto"].ToString();
                                c.IdMovimiento = reader["id_movimiento"].ToString();
                                c.Nombre = reader["nombre"].ToString();
                                c.TipoFolio = reader["tipo_folio"].ToString();
                                movimientos.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                movimientos = null;
            }
            return movimientos;
        }

        public static ObservableCollection<cMovimiento> ObtenerMovimientosActoBusqueda(String claveActo, String busqueda)
        {
            ObservableCollection<cMovimiento> movimientos = new ObservableCollection<cMovimiento>();
            cMovimiento c = new cMovimiento();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM Movimientos " +
                        "WHERE id_acto = @ClaveActo AND nombre LIKE @Busqueda", con))
                    {
                        query.Parameters.AddWithValue("ClaveActo", claveActo);
                        query.Parameters.AddWithValue("Busqueda", busqueda);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cMovimiento();
                                c.IdActo = reader["id_acto"].ToString();
                                c.IdMovimiento = reader["id_movimiento"].ToString();
                                c.Nombre = reader["nombre"].ToString();
                                c.TipoFolio = reader["tipo_folio"].ToString();
                                movimientos.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                movimientos = null;
            }
            return movimientos;
        }
    }
}
