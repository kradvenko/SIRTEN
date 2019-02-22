using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    //Clase para el control de los movimientos de una prelación.
    //Los movimientos de una prelación son la combinación de
    //Acto y Movimiento con su costo correspondiente que se registrarán
    //en la prelación.
    //Tabla: PrelacionesActos.
    public class cMovimientoPrelacion
    {
        public String IdPrelacionActo { get; set; }
        public String IdPrelacion { get; set; }
        public String IdActo { get; set; }
        public String IdMovimiento { get; set; }
        public String EstadoMovimiento { get; set; }
        public String Descripcion { get; set; }
        public String ValorBase { get; set; }
        public String Cantidad { get; set; }
        public String Descuento { get; set; }
        public String Importe { get; set; }
        public String NombreActo { get; set; }
        public String NombreMovimiento { get; set; }

        public cMovimientoPrelacion()
        {

        }

        public static ObservableCollection<cMovimientoPrelacion> ObtenerMovimientosPrelacion(String busqueda)
        {
            ObservableCollection<cMovimientoPrelacion> movimientosprelacion = new ObservableCollection<cMovimientoPrelacion>();
            cMovimientoPrelacion c = new cMovimientoPrelacion();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("sp_rpp_obtener_ListaMovimientosPrelacion", con))
                    {
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("busqueda", busqueda);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cMovimientoPrelacion();
                                c.IdPrelacionActo = reader["id_prelacion_acto"].ToString();
                                c.IdPrelacion = reader["id_prelacion"].ToString();
                                c.IdActo = reader["id_acto"].ToString();
                                c.IdMovimiento = reader["id_movimiento"].ToString();
                                c.EstadoMovimiento = reader["estado_movimiento"].ToString();
                                c.Importe = reader["importe"].ToString();

                                movimientosprelacion.Add(c);
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                movimientosprelacion = null;
            }

            return movimientosprelacion;
        }
    }
}
