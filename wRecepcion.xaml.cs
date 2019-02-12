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
        
        public wRecepcion()
        {
            antecedentes = new ObservableCollection<cAntecedente>();
            actos = new ObservableCollection<cActo>();
            actos = cActo.ObtenerActos("%");
            movimientosPrelacion = new ObservableCollection<cMovimientoPrelacion>();
            cMovimientoPrelacion c = new cMovimientoPrelacion();
            c.IdActo = "1";
            c.IdMovimiento = "2";
            movimientosPrelacion.Add(c);

            InitializeComponent();

            tbFechaTramite.Text = DateTime.Now.ToShortDateString();
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
                cAntecedente c = (cAntecedente)dgAntecedentes.SelectedItem;
                antecedentes.Remove(c);
            }
        }
    }
}
