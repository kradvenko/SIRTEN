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
    /// Lógica de interacción para wNuevoTramitante.xaml
    /// </summary>
    public partial class wNuevoTramitante : Window
    {
        wRecepcion parent;

        ObservableCollection<cMunicipio> municipios;
        ObservableCollection<cPoblacion> poblaciones;

        public wNuevoTramitante(wRecepcion p)
        {
            InitializeComponent();
            parent = p;

            municipios = cMunicipio.ObtenerMunicipios();
            cbMunicipio.ItemsSource = municipios;
            cbMunicipio.SelectedIndex = 0;
            tbNombre.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text.Length == 0)
            {
                MessageBox.Show("No ha ingresado el nombre del tramitante.");
                tbNombre.Focus();
                return;
            }

            cTramitante tramitante = new cTramitante();

            tramitante.Nombre = tbNombre.Text;
            tramitante.ApPaterno = tbApPaterno.Text;
            tramitante.ApMaterno = tbApMaterno.Text;
            tramitante.Calle = tbCalle.Text;
            tramitante.Numero = tbNumero.Text;
            tramitante.Colonia = tbColonia.Text;
            tramitante.CodigoPostal = tbCodigoPostal.Text;
            tramitante.IdMunicipio = ((cMunicipio)cbMunicipio.SelectedItem).IdMunicipio;
            tramitante.IdPoblacion = ((cPoblacion)cbPoblacion.SelectedItem).IdPoblacion;
            tramitante.Estado = tbEstado.Text;
            tramitante.NumeroNotaria = tbNumNotaria.Text;
            tramitante.Telefono = tbTelefono.Text;

            String resultado = cTramitante.GuardarTramitante(tramitante);

            if (resultado != "0")
            {
                MessageBox.Show("Se ha ingresado el tramitante.");
                
                if (parent != null)
                {
                    //En caso de requerir que se ejecute algo en la forma padre (wRecepcion).
                }

                this.Close();
            }
            
        }

        private void CbMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cMunicipio municipio = new cMunicipio();
            municipio = (cMunicipio)cbMunicipio.SelectedItem;

            poblaciones = cPoblacion.ObtenerPoblacionesMunicipio(municipio.IdMunicipio);
            cbPoblacion.ItemsSource = poblaciones;
            cbPoblacion.SelectedIndex = 0;
        }
    }
}
