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
        public String NombreTitular { get; set; }
        public String Escritura { get; set; }
        public String DescripcionBien { get; set; }
        public String TipoDocumento { get; set; }
        public String FechaDocumento { get; set; }
        public String LugarOtorgamiento { get; set; }
        public String LineaCaptura { get; set; }
        public String Banco { get; set; }
        public String Telefono { get; set; }
        public String FechaCaptura { get; set; }
        public String Estatus { get; set; }
        public String ObservacionesRegistrador { get; set; }
        public String NotasRecepcion { get; set; }
        public String FechaAsignacion { get; set; }
        public String ClaveCatastral { get; set; }
        public ObservableCollection<cAntecedente> AntecedentesPrelacion { get; set; }
        public ObservableCollection<cMovimientoPrelacion> MovimientosPrelacion { get; set; }
        
        public cPrelacion()
        {

        }

        public static String GuardarPrelacion(String IdTramitante, String IdUsuarioCaptura, String FolioPropiedad, String NombreTitular, String Escritura, String DescripcionBien, String TipoDocumento, String FechaDocumento, String LugarOtorgamiento, String LineaCaptura, String Banco, String Telefono, String Estatus, String NotasRecepcion, String ClaveCatastral, ObservableCollection<cAntecedente> AntecedentesPrelacion, ObservableCollection<cMovimientoPrelacion> MovimientosPrelacion)
        {
            String resultado = "";

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO Prelaciones " +
                        "(id_tramitante, id_usuario_captura, fecha, folio, nombre_titular, numero_escritura, descripcion_bien, tipo_documento, fecha_documento, lugar_otorgamiento, linea_captura, banco, telefono, estatus, notas_recepcion, fecha_asignacion, clave_catastral) " +
                        "OUTPUT INSERTED.id_prelacion " +
                        "VALUES (@IdTramitante, @IdUsuarioCaptura, GETDATE(), @FolioPropiedad, @NombreTitular, @Escritura, @DescripcionBien, @TipoDocumento, @FechaDocumento, @LugarOtorgamiento, @LineaCaptura, @Banco, @Telefono, 'RECEPCION', @NotasRecepcion, '', @ClaveCatastral)", con))
                    {
                        query.Parameters.AddWithValue("@IdTramitante", IdTramitante);
                        query.Parameters.AddWithValue("@IdUsuarioCaptura", IdUsuarioCaptura);
                        query.Parameters.AddWithValue("@FolioPropiedad", FolioPropiedad);
                        query.Parameters.AddWithValue("@NombreTitular", NombreTitular);
                        query.Parameters.AddWithValue("@Escritura", Escritura);
                        query.Parameters.AddWithValue("@DescripcionBien", DescripcionBien);
                        query.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
                        query.Parameters.AddWithValue("@FechaDocumento", FechaDocumento);
                        query.Parameters.AddWithValue("@LugarOtorgamiento", LugarOtorgamiento);
                        query.Parameters.AddWithValue("@LineaCaptura", LineaCaptura);
                        query.Parameters.AddWithValue("@Banco", Banco);
                        query.Parameters.AddWithValue("@Telefono", Telefono);
                        query.Parameters.AddWithValue("@NotasRecepcion", NotasRecepcion);
                        query.Parameters.AddWithValue("@ClaveCatastral", ClaveCatastral);

                        con.Open();

                        resultado = query.ExecuteScalar().ToString();

                        if (resultado != "0")
                        {
                            foreach (cAntecedente antecedente in AntecedentesPrelacion)
                            {
                                cAntecedente.AgregarAntecedenteAPrelacion(resultado, antecedente);
                            }

                            foreach (cMovimientoPrelacion movimientoPrelacion in MovimientosPrelacion)
                            {
                                cMovimientoPrelacion.AgregarMovimientoAPrelacion(resultado, movimientoPrelacion);
                            }
                        }
                        
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
