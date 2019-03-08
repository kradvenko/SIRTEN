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
        public String UsuarioCaptura { get; set; }
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
        public String HoraCaptura { get; set; }
        public String Total { get; set; }
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

        public static String GuardarPrelacion(String IdTramitante, String IdUsuarioCaptura, String FolioPropiedad, String NombreTitular, String Escritura, String DescripcionBien, String TipoDocumento, String FechaDocumento, String LugarOtorgamiento, String LineaCaptura, String Banco, String Telefono, String Total, String Estatus, String NotasRecepcion, String ClaveCatastral, ObservableCollection<cAntecedente> AntecedentesPrelacion, ObservableCollection<cMovimientoPrelacion> MovimientosPrelacion)
        {
            String resultado = "";

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("INSERT INTO Prelaciones " +
                        "(id_tramitante, id_usuario_captura, fecha, hora, folio, nombre_titular, numero_escritura, descripcion_bien, tipo_documento, tipo_moneda, fecha_documento, lugar_otorgamiento, linea_captura, banco, telefono, total, estatus, notas_recepcion, fecha_asignacion, clave_catastral) " +
                        "OUTPUT INSERTED.id_prelacion " +
                        "VALUES (@IdTramitante, @IdUsuarioCaptura, CONVERT(varchar, getdate(), 103), CONVERT(varchar, getdate(), 8), @FolioPropiedad, @NombreTitular, @Escritura, @DescripcionBien, @TipoDocumento, 'Pesos', @FechaDocumento, @LugarOtorgamiento, @LineaCaptura, @Banco, @Telefono, @Total, @Estatus, @NotasRecepcion, '', @ClaveCatastral)", con))
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
                        query.Parameters.AddWithValue("@Total", Total);
                        query.Parameters.AddWithValue("@Estatus", Estatus);
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

        public static cPrelacion ObtenerPrelacionPorIdPrelacion(String IdPrelacion)
        {
            cPrelacion prelacion = new cPrelacion();

            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SIRTEN.Properties.Settings.SIRTEN_RPP_MainConnectionString"].ConnectionString))
                {
                    using (SqlCommand query = new SqlCommand("SELECT Prelaciones.*, " +
                        "(Tramitantes.nombre + ' ' + Tramitantes.apellido_paterno + ' ' + tramitantes.apellido_materno + ' Not. ' + tramitantes.num_notaria) AS NombreTramitante, " +
                        "(Usuarios.nombre + ' ' + Usuarios.apellido_paterno + ' ' + Usuarios.apellido_materno) As UsuarioCaptura " +
                        "FROM Prelaciones " +
                        "INNER JOIN Tramitantes " +
                        "ON Tramitantes.id_tramitante = Prelaciones.id_tramitante " +
                        "INNER JOIN Usuarios " +
                        "ON Usuarios.id_usuario = Prelaciones.id_usuario_captura " +
                        "WHERE id_prelacion = @IdPrelacion", con))
                    {
                        query.Parameters.AddWithValue("@IdPrelacion", IdPrelacion);

                        con.Open();

                        SqlDataReader reader = query.ExecuteReader();
                        //Se obtienen los datos generales de la prelación.
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                prelacion = new cPrelacion();
                                prelacion.IdPrelacion = reader["id_prelacion"].ToString();
                                prelacion.IdTramitante = reader["id_tramitante"].ToString();
                                prelacion.NombreTramitante = reader["NombreTramitante"].ToString();
                                prelacion.NombreTitular = reader["nombre_titular"].ToString();
                                prelacion.DescripcionBien = reader["descripcion_bien"].ToString();
                                prelacion.Escritura = reader["numero_escritura"].ToString();
                                prelacion.FolioPropiedad = reader["folio"].ToString();
                                prelacion.Total = reader["total"].ToString();
                                prelacion.Estatus = reader["estatus"].ToString();
                                prelacion.FechaCaptura = reader["fecha"].ToString();
                                prelacion.HoraCaptura = reader["hora"].ToString();
                                prelacion.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();
                                prelacion.TipoDocumento = reader["tipo_documento"].ToString();
                                prelacion.FechaDocumento = reader["fecha_documento"].ToString();
                                prelacion.ObservacionesRegistrador = reader["observaciones_verificador"].ToString();
                                prelacion.FechaAsignacion = reader["fecha_asignacion"].ToString();
                                prelacion.IdUsuarioCaptura = reader["id_usuario_captura"].ToString();
                                prelacion.UsuarioCaptura = reader["UsuarioCaptura"].ToString();
                                prelacion.LineaCaptura = reader["linea_captura"].ToString();
                                prelacion.Banco = reader["banco"].ToString();
                                prelacion.Telefono = reader["telefono"].ToString();
                                prelacion.NotasRecepcion = reader["notas_recepcion"].ToString();
                                prelacion.ClaveCatastral = reader["clave_catastral"].ToString();
                            }
                        }

                        con.Close();
                        //Se obtienen los antecedentes de la prelación y se almacenan en el arreglo correspondiente.
                        ObservableCollection<cAntecedente> antecedentes = new ObservableCollection<cAntecedente>();

                        using (SqlCommand queryAntecedentes = new SqlCommand("SELECT * " +
                            "FROM PrelacionesAntecedentes " +
                            "WHERE id_prelacion = @IdPrelacion", con))
                        {
                            queryAntecedentes.Parameters.AddWithValue("@IdPrelacion", IdPrelacion);

                            con.Open();

                            SqlDataReader readerAntecedentes = queryAntecedentes.ExecuteReader();

                            if (readerAntecedentes.HasRows)
                            {
                                while (readerAntecedentes.Read())
                                {
                                    cAntecedente antecedente = new cAntecedente();
                                    antecedente.IdPrelacionAntecedente = readerAntecedentes["id_prelacion_antecedente"].ToString();
                                    antecedente.IdPrelacion = readerAntecedentes["id_prelacion"].ToString();
                                    antecedente.Libro = readerAntecedentes["libro"].ToString();
                                    antecedente.Tomo = readerAntecedentes["tomo"].ToString();
                                    antecedente.Semestre = readerAntecedentes["semestre"].ToString();
                                    antecedente.Seccion = readerAntecedentes["seccion"].ToString();
                                    antecedente.Serie = readerAntecedentes["serie"].ToString();
                                    antecedente.Partida = readerAntecedentes["partida"].ToString();
                                    antecedente.AnioSemestre = readerAntecedentes["anio"].ToString();
                                    antecedente.Folio = readerAntecedentes["folio"].ToString();
                                    antecedente.Notas = readerAntecedentes["notas"].ToString();
                                    antecedentes.Add(antecedente);
                                }
                                prelacion.AntecedentesPrelacion = antecedentes;
                            }

                            con.Close();
                        }

                        //Se obtienen los actos (movimientos) de la prelación
                        ObservableCollection<cMovimientoPrelacion> movimientos = new ObservableCollection<cMovimientoPrelacion>();

                        using (SqlCommand queryMovimientos = new SqlCommand("SELECT PrelacionesActos.*, Actos.nombre As NombreActo, Actos.clave_acto As ClaveActo, Movimientos.nombre As NombreMovimiento " +
                            "FROM PrelacionesActos " +
                            "INNER JOIN Actos " +
                            "ON Actos.id_acto = PrelacionesActos.id_acto " +
                            "INNER JOIN Movimientos " +
                            "ON Movimientos.id_movimiento = PrelacionesActos.id_movimiento " +
                            "WHERE id_prelacion = @IdPrelacion", con))
                        {
                            queryMovimientos.Parameters.AddWithValue("@IdPrelacion", IdPrelacion);

                            con.Open();

                            SqlDataReader readerMovimientos = queryMovimientos.ExecuteReader();

                            if (readerMovimientos.HasRows)
                            {
                                while (readerMovimientos.Read())
                                {
                                    cMovimientoPrelacion movimientoPrelacion = new cMovimientoPrelacion();
                                    movimientoPrelacion.IdPrelacionActo = readerMovimientos["id_prelacion_acto"].ToString();
                                    movimientoPrelacion.IdPrelacion = readerMovimientos["id_prelacion"].ToString();
                                    movimientoPrelacion.IdActo = readerMovimientos["id_acto"].ToString();
                                    movimientoPrelacion.IdMovimiento = readerMovimientos["id_movimiento"].ToString();
                                    movimientoPrelacion.EstadoMovimiento = readerMovimientos["estado_movimiento"].ToString();
                                    movimientoPrelacion.Importe = readerMovimientos["importe"].ToString();
                                    movimientoPrelacion.ValorBase = readerMovimientos["valor_base"].ToString();
                                    movimientoPrelacion.ClaveActo = readerMovimientos["ClaveActo"].ToString();
                                    movimientoPrelacion.NombreActo = readerMovimientos["NombreActo"].ToString();
                                    movimientoPrelacion.NombreMovimiento = readerMovimientos["NombreMovimiento"].ToString();
                                    movimientos.Add(movimientoPrelacion);
                                }
                                prelacion.MovimientosPrelacion = movimientos;
                            }

                            con.Close();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                prelacion = null;
            }

            return prelacion;
        }
    }
}
