using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRTEN
{
    //Clase para las prelaciones.
    public class cPrelacion
    {
        //Datos generales de la captura de una nueva prelación.
        public String IdPrelacion { get; set; }
        public String IdTramitante { get; set; }
        public String IdUsuarioCaptura { get; set; }
        public String FechaTramite { get; set; }
        public String FolioPropiedad { get; set; }        
        public String NombreTramitante { get; set; }
        public String NuevoTitular { get; set; }
        public String Escritura { get; set; }
        public String DescripcionBien { get; set; }
        public String TipoDocumento { get; set; }
        public String FechaOtorgamiento { get; set; }
        public String LugarOtorgamiento { get; set; }
        public String LineaCaptura { get; set; }
        public String Banco { get; set; }
        public String Telefono { get; set; }
        public String FechaCaptura { get; set; }
        public String Estatus { get; set; }
        public String ObservacionesRegistrador { get; set; }
        public String NotasRecepcion { get; set; }
        public String FechaAsignacion { get; set; }
        public ObservableCollection<cAntecedente> AntecedentesPrelacion { get; set; }
        public ObservableCollection<cMovimientoPrelacion> MovimientosPrelacion { get; set; }
        
        public cPrelacion()
        {

        }

        public String GuardarPrelacion(String IdTramitante, String IdUsuarioCaptura, String FechaTramite, String FolioPropiedad, String NuevoTitular, String Escritura, String DescripcionBien, String TipoDocumento, String FechaOtorgamiento, String LugarOtorgamiento, String LineaCaptura, String Banco, String Telefono, String Estatus, String NotasRecepcion, ObservableCollection<cAntecedente> AntecedentesPrelacion, ObservableCollection<cMovimientoPrelacion> MovimientosPrelacion)
        {
            String resultado = "";

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO Prelaciones " +
                        "(IdTramitante, IdUsuarioCaptura, FechaTramite, FolioPropiedad, NuevoTitular, Escritura, DescripcionBien, TipoDocumento, FechaOtorgamiento, LugarOtorgamiento, LineaCaptura, Banco, Telefono, FechaCaptura, Estatus, NotasRecepcion, FechaAsignacion) " +
                        "OUTPUT INSERTED.IdPrelacion " +
                        "VALUES (@IdTramitante, @IdUsuarioCaptura, @FechaTramite, @FolioPropiedad, @NuevoTitular, @Escritura, @DescripcionBien, @TipoDocumento, @FechaOtorgamiento, @LugarOtorgamiento, @LineaCaptura, @Telefono, GETDATE())", con))
                    {
                        query.Parameters.AddWithValue("@IdTramitante", IdTramitante);
                        query.Parameters.AddWithValue("@IdUsuarioCaptura", IdUsuarioCaptura);
                        query.Parameters.AddWithValue("@FechaTramite", FechaTramite);
                        query.Parameters.AddWithValue("@FolioPropiedad", FolioPropiedad);
                        query.Parameters.AddWithValue("@NuevoTitular", NuevoTitular);
                        query.Parameters.AddWithValue("@Escritura", Escritura);
                        query.Parameters.AddWithValue("@DescripcionBien", DescripcionBien);
                        query.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
                        query.Parameters.AddWithValue("@FechaOtorgamiento", FechaOtorgamiento);
                        query.Parameters.AddWithValue("@LugarOtorgamiento", LugarOtorgamiento);
                        query.Parameters.AddWithValue("@LineaCaptura", LineaCaptura);
                        query.Parameters.AddWithValue("@Telefono", Telefono);

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
