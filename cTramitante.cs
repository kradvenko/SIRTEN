using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    //Clase para el control de los datos del tramitante de la prelación
    public class cTramitante
    {
        public String IdTramitante { get; set; }
        public String NombreCompleto { get; set; }
        public String Nombre { get; set; }
        public String ApPaterno { get; set; }
        public String ApMaterno { get; set; }
        public String RazonSocial { get; set; }
        public String RFC { get; set; }
        public String CURP { get; set; }
        public String Calle { get; set; }
        public String Numero { get; set; }
        public String Colonia { get; set; }
        public String CodigoPostal { get; set; }
        public String IdPoblacion { get; set; }
        public String IdMunicipio { get; set; }
        public String Estado { get; set; }
        public String NumeroNotaria { get; set; }
        public String TipoTramitante { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        public String Extension { get; set; }

        public cTramitante()
        {

        }

        public static ObservableCollection<cTramitante> ObtenerTramitantes(String busqueda = "%")
        {
            ObservableCollection<cTramitante> lista = new ObservableCollection<cTramitante>();
            cTramitante c = new cTramitante();
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("sp_rpp_obtener_ListaTramitantes", con))
                    {
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("busqueda", busqueda);
                        con.Open();
                        SqlDataReader reader = query.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                c = new cTramitante();
                                c.IdTramitante = reader["id_tramitante"].ToString();
                                c.Nombre = reader["nombre"].ToString();
                                c.ApPaterno = reader["apellido_paterno"].ToString();
                                c.ApMaterno = reader["apellido_materno"].ToString();
                                c.RazonSocial = reader["razon_social"].ToString();
                                c.RFC = reader["rfc"].ToString();
                                c.CURP = reader["curp"].ToString();
                                c.Calle = reader["calle"].ToString();
                                c.Numero = reader["numero"].ToString();
                                c.Colonia = reader["colonia"].ToString();
                                c.CodigoPostal = reader["codigo_postal"].ToString();
                                c.IdPoblacion = reader["poblacion"].ToString();
                                c.IdMunicipio = reader["municipio"].ToString();
                                c.Estado = reader["estado"].ToString();
                                c.NumeroNotaria = reader["num_notaria"].ToString();
                                c.TipoTramitante = reader["tipo_tramitante"].ToString();
                                c.Telefono = reader["telefono"].ToString();
                                c.Fax = reader["fax"].ToString();
                                c.Extension = reader["extension"].ToString();

                                c.NombreCompleto = c.Nombre + " " + c.ApPaterno + " " + c.ApMaterno + " Not. " + c.NumeroNotaria;
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
