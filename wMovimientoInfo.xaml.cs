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
        public wRecepcion parent;
        public ObservableCollection<cActo> actos;
        public ObservableCollection<cMovimiento> movimientos;

        public cActo actoElegido;

        public float total;

        public wMovimientoInfo(wRecepcion p)
        {
            InitializeComponent();
            actoElegido = null;
            parent = p;
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
                total = cantidad;
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

        private void Guardar(object sender, RoutedEventArgs e)
        {
            if (tbActos.SelectedItem != null)
            {
                if (tbMovimientos.SelectedItem != null)
                {
                    if (tbValorBase.Text.Length > 0)
                    {
                        cActo a = (cActo)tbActos.SelectedItem;
                        cMovimiento m = (cMovimiento)tbMovimientos.SelectedItem;

                        cMovimientoPrelacion movimientoPrelacion = new cMovimientoPrelacion();
                        movimientoPrelacion.IdPrelacionActo = "0";
                        movimientoPrelacion.IdPrelacion = "0";
                        movimientoPrelacion.IdActo = a.IdActo;
                        movimientoPrelacion.IdMovimiento = m.IdMovimiento;
                        movimientoPrelacion.EstadoMovimiento = "NOREGISTRADA";
                        movimientoPrelacion.Descripcion = m.Nombre;
                        movimientoPrelacion.ValorBase = tbValorBase.Text;
                        movimientoPrelacion.Descuento = "0";
                        movimientoPrelacion.Cantidad = total.ToString();
                        movimientoPrelacion.Importe = total.ToString();

                        parent.AgregarMovimientoPrelacion(movimientoPrelacion);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No ha escrito un monto base válido.");
                    }
                }
                else
                {
                    MessageBox.Show("No ha elegido un Movimiento.");
                }
            }
            else
            {
                MessageBox.Show("No ha elegido un Acto.");
            }
        }
    }
}
