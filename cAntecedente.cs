using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    public class cAntecedente
    {
        public String IdPrelacionAntecedente { get; set; }
        public String IdPrelacion { get; set; }
        public String Tipo { get; set; }
        public String Libro { get; set; }
        public String Tomo { get; set; }
        public String Semestre { get; set; }
        public String Seccion { get; set; }
        public String Serie { get; set; }
        public String Partida { get; set; }
        public String AnioSemestre { get; set; }
        public String Folio { get; set; }
        public String Notas { get; set; }

        public cAntecedente()
        {

        }

        public static String AgregarAntecedenteAPrelacion(String IdPrelacion, cAntecedente Antecedente)
        {
            String resultado = "OK";

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO PrelacionesAntecedentes " +
                        "(id_prelacion, libro, tomo, semestre, seccion, serie, partida, anio, folio, notas) " +
                        "OUTPUT INSERTED.id_prelacion_antecedente " +
                        "VALUES (@IdPrelacion, @Libro, @Tomo, @Semestre, @Seccion, @Serie, @Partida, @Anio, @Folio, @Notas)", con))
                    {
                        query.Parameters.AddWithValue("@IdPrelacion", IdPrelacion);
                        query.Parameters.AddWithValue("@Libro", Antecedente.Libro);
                        query.Parameters.AddWithValue("@Tomo", Antecedente.Tomo);
                        query.Parameters.AddWithValue("@Semestre", Antecedente.Semestre);
                        query.Parameters.AddWithValue("@Seccion", Antecedente.Seccion);
                        query.Parameters.AddWithValue("@Serie", Antecedente.Serie);
                        query.Parameters.AddWithValue("@Partida", Antecedente.Partida);
                        query.Parameters.AddWithValue("@Anio", Antecedente.AnioSemestre);
                        query.Parameters.AddWithValue("@Folio", Antecedente.Folio);
                        query.Parameters.AddWithValue("@Notas", Antecedente.Notas);

                        con.Open();

                        resultado = query.ExecuteScalar().ToString();

                        con.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                resultado = exc.Message;
            }

            return resultado;
        }
    }
}
