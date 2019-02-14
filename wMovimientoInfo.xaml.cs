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
    /// Lógica de interacción para wMovimientoInfo.xaml
    /// </summary>
    public partial class wMovimientoInfo : Window
    {
        public ObservableCollection<cActo> actos;
        public ObservableCollection<cMovimiento> movimientos;

        public cActo actoElegido;

        public wMovimientoInfo()
        {
            InitializeComponent();
            actoElegido = null;
        }

        private void TbActos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                actos = new ObservableCollection<cActo>();
                actos = cActo.ObtenerActos("%" + tbActos.Text + "%");
                tbActos.AutoCompleteSource = actos;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void TbActos_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            cActo a = new cActo();
            if (tbActos.SelectedItem != null)
            {
                a = (cActo)tbActos.SelectedItem;
                actoElegido = a;
            }
        }

        private void TbMovimientos_TextChanged(object sender, TextChangedEventArgs e)
        {
            cMovimiento m = new cMovimiento();
            if (actoElegido != null)
            {
                movimientos = new ObservableCollection<cMovimiento>();
                movimientos = cMovimiento.ObtenerMovimientosActoBusqueda(actoElegido.ClaveActo, "%" + tbMovimientos.Text + "%");
                tbMovimientos.AutoCompleteSource = movimientos;
            }
        }

        private void TbValorBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            float valor = 0;
            float cantidad = 0;

            if (actoElegido == null)
            {
                tbValorBase.Text = "0";
                return;
            }

            if (float.TryParse(tbValorBase.Text, out valor))
            {
                cTarifa tarifa = new cTarifa();
                tarifa = cTarifa.ObtenerTarifaActo(actoElegido.ClaveActo);
                valor = float.Parse(tbValorBase.Text);

                if (tarifa.Porcentaje != "0")
                {
                    cantidad = valor * float.Parse(tarifa.Porcentaje);
                    if (cantidad > float.Parse(tarifa.SalariosMaximos))
                    {
                        cantidad = float.Parse(tarifa.SalariosMaximos);
                    }
                    lblCantidad.Content = "$ " + cantidad.ToString();
                }
                else
                {
                    cantidad = float.Parse(tarifa.SalariosFijos);
                    lblCantidad.Content = "$ " + cantidad.ToString();
                }
            }
            else
            {
                tbValorBase.Text = "0";
                return;
            }
        }

        private void TbMovimientos_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            float valor = 0;
            float cantidad = 0;

            if (actoElegido == null)
            {
                tbValorBase.Text = "0";
                return;
            }

            if (float.TryParse(tbValorBase.Text, out valor))
            {
                cTarifa tarifa = new cTarifa();
                tarifa = cTarifa.ObtenerTarifaActo(actoElegido.ClaveActo);
                valor = float.Parse(tbValorBase.Text);

                if (tarifa.Porcentaje != "0")
                {
                    cantidad = valor * float.Parse(tarifa.Porcentaje);
                    if (cantidad > float.Parse(tarifa.SalariosMaximos))
                    {
                        cantidad = float.Parse(tarifa.SalariosMaximos);
                    }
                    lblCantidad.Content = "$ " + cantidad.ToString();
                }
                else
                {
                    cantidad = float.Parse(tarifa.SalariosFijos);
                    lblCantidad.Content = "$ " + cantidad.ToString();
                }
            }
            else
            {
                tbValorBase.Text = "0";
                return;
            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
