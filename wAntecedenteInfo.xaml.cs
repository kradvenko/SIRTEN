using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para wAntecedenteInfo.xaml
    /// </summary>
    public partial class wAntecedenteInfo : Window
    {
        wRecepcion parent;

        public wAntecedenteInfo(wRecepcion p)
        {
            InitializeComponent();
            parent = p;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            cAntecedente nuevo = new cAntecedente();

            nuevo.Tipo = cbTipo.Text;

            switch (nuevo.Tipo)
            {
                case "Libro":
                    if (tbNumero.Text.Length == 0)
                    {
                        MessageBox.Show("No ha escrito el número de libro");
                        tbNumero.Focus();
                        return;
                    }
                    if (tbPartida.Text.Length == 0)
                    {
                        MessageBox.Show("No ha escrito el número de partida.");
                        tbPartida.Focus();
                        return;
                    }
                    nuevo.Libro = tbNumero.Text;
                    nuevo.Tomo = "";
                    nuevo.Semestre = "";
                    nuevo.Seccion = cbSeccion.Text;       
                    nuevo.Serie = cbSerie.Text;
                    nuevo.Partida = tbPartida.Text;
                    nuevo.Folio = tbFolio.Text;
                    nuevo.AnioSemestre = "";
                    nuevo.Notas = tbNotas.Text;
                    break;
                case "Tomo":
                    if (tbNumero.Text.Length == 0)
                    {
                        MessageBox.Show("No ha escrito el número del tomo");
                        tbNumero.Focus();
                        return;
                    }
                    if (tbPartida.Text.Length == 0)
                    {
                        MessageBox.Show("No ha escrito el número de partida.");
                        tbPartida.Focus();
                        return;
                    }
                    nuevo.Libro = "";
                    nuevo.Tomo = tbNumero.Text;
                    nuevo.Semestre = "";
                    nuevo.Seccion = cbSeccion.Text;
                    nuevo.Serie = cbSerie.Text;
                    nuevo.Partida = tbPartida.Text;
                    nuevo.Folio = tbFolio.Text;
                    nuevo.AnioSemestre = "";
                    nuevo.Notas = tbNotas.Text;
                    break;
                case "Semestre":
                    if (tbPartida.Text.Length == 0)
                    {
                        MessageBox.Show("No ha escrito el número de partida.");
                        tbPartida.Focus();
                        return;
                    }
                    nuevo.Libro = "";
                    nuevo.Tomo = "";
                    nuevo.Semestre = cbSemestre.Text;
                    nuevo.Seccion = "";
                    nuevo.Serie = "";
                    nuevo.Partida = tbPartida.Text;
                    nuevo.Folio = tbFolio.Text;
                    nuevo.AnioSemestre = tbAnioSemestre.Text;
                    nuevo.Notas = tbNotas.Text;
                    break;                    
                default:
                    break;
            }
            parent.AgregarAntecedente(nuevo);
            this.Close();
        }

        private void CbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (e.AddedItems[0] as ComboBoxItem).Content as string;

            try
            {
                if (cbTipo.SelectedIndex == 0 || cbTipo.SelectedIndex == 1)
                {
                    tbNumero.IsEnabled = true;
                    cbSeccion.IsEnabled = true;
                    cbSemestre.IsEnabled = false;
                    tbAnioSemestre.IsEnabled = false;
                }
                else if (cbTipo.SelectedIndex == 2)
                {
                    tbNumero.IsEnabled = false;
                    cbSeccion.IsEnabled = false;
                    cbSemestre.IsEnabled = true;
                    tbAnioSemestre.IsEnabled = true;
                }
            }
            catch(Exception exc)
            {

            }
        }
    }
}
