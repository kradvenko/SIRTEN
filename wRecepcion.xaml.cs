using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIRTEN
{
    /// <summary>
    /// Lógica de interacción para wRecepcion.xaml
    /// </summary>
    public partial class wRecepcion : Window
    {
        public ObservableCollection<cTramitante> tramitantes;
        public ObservableCollection<cAntecedente> antecedentes { get; set; }
        public ObservableCollection<cActo> actos { get; set; }
        public ObservableCollection<cMovimientoPrelacion> movimientosPrelacion { get; set; }

        float total;
        
        public wRecepcion()
        {
            antecedentes = new ObservableCollection<cAntecedente>();
            actos = new ObservableCollection<cActo>();
            //actos = cActo.ObtenerActos("%");
            movimientosPrelacion = new ObservableCollection<cMovimientoPrelacion>();
            cMovimientoPrelacion c = new cMovimientoPrelacion();
            //c.IdActo = "1";
            //c.IdMovimiento = "2";
            //movimientosPrelacion.Add(c);

            InitializeComponent();

            tbFechaTramite.Text = DateTime.Now.ToShortDateString();
            tbFolioPropiedad.Focus();
        }

        private void tbTramitantes_TextChange(object sender, TextChangedEventArgs e)
        {
            tramitantes = new ObservableCollection<cTramitante>();
            tramitantes = cTramitante.ObtenerTramitantes("%" + tbTramitantes.Text + "%");
            tbTramitantes.AutoCompleteSource = tramitantes;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void AgregarAntecedente(cAntecedente nuevo)
        {
            antecedentes.Add(nuevo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wAntecedenteInfo antecedente = new wAntecedenteInfo(this);
            antecedente.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgAntecedentes.SelectedItems.Count > 0)
            {
                try
                {
                    cAntecedente c = (cAntecedente)dgAntecedentes.SelectedItem;
                    antecedentes.Remove(c);
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wMovimientoInfo movimiento = new wMovimientoInfo(this);
            movimiento.ShowDialog();
        }

        public void AgregarMovimientoPrelacion(cMovimientoPrelacion movimiento)
        {
            movimientosPrelacion.Add(movimiento);
            CalcularTotal();
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            cTramitante tramitante = new cTramitante();

            if (tbTramitantes.SelectedItem == null)
            {
                MessageBox.Show("No ha elegido un tramitante.");
                return;
            }

            if (movimientosPrelacion.Count == 0)
            {
                MessageBox.Show("No ha agregado actos al trámite.");
                return;
            }


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dgActos.SelectedItems.Count > 0)
            {
                try
                {
                    cMovimientoPrelacion c = (cMovimientoPrelacion)dgActos.SelectedItem;
                    movimientosPrelacion.Remove(c);
                    CalcularTotal();
                }
                catch (Exception exc)
                {

                }
            }
        }

        private void CalcularTotal()
        {
            total = 0;

            foreach (cMovimientoPrelacion mov in movimientosPrelacion)
            {
                total = total + float.Parse(mov.Importe);
            }

            lblTotal.Content = "Total: $ " + total.ToString();
        }
    }
}
