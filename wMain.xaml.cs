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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIRTEN
{    
    public partial class MainWindow : Window
    {
        cUsuario currentUser;

        public MainWindow(cUsuario cu)
        {
            InitializeComponent();
            currentUser = cu;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = currentUser.nombre;
            ValidateUsers();
        }
        //Función que muestra las opciones del menú de acuerdo al usuario activo actualmente en el sistema.
        private void ValidateUsers()
        {
            switch (currentUser.tipoUsuario)
            {
                case "Administrador":
                    mnuCatalogos.IsEnabled = true;
                    mnuEntrega.IsEnabled = true;
                    mnuRecepcion.IsEnabled = true;
                    mnuRegistro.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }

        private void CapturaNuevaPrelacion(object sender, RoutedEventArgs e)
        {
            wRecepcion recepcion = new wRecepcion();
            recepcion.Show();
        }
    }
}
