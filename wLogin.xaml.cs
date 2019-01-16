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
    /// Lógica de interacción para wLogin.xaml
    /// </summary>
    public partial class wLogin : Window
    {
        public bool inLogin;

        public wLogin()
        {
            InitializeComponent();
            inLogin = false;
            tbLogin.Focus();
        }

        private void PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && inLogin == false)
            {
                if (pbPassword.Password.ToString().Length > 0)
                {
                    inLogin = true;
                    Login();
                }
            }
            else
            {
                inLogin = false;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && inLogin == false)
            {
                if (tbLogin.Text.Length > 0)
                {
                    inLogin = true;
                    Login();
                }
            }
            else
            {
                inLogin = false;
            }
        }        
        //Códigos de error retornados por la función de logeo
        //Error SP001 - No existe el nombre de usuario.
        //Error SP002 - No es correcta la contraseña.
        //Error SP003 - No está activo el usuario.
        private void Login()
        {
            cUsuario c;
            String respuesta = cUsuario.LoginUsuario(tbLogin.Text, pbPassword.Password.ToString(), out c);
            if (respuesta == "OK")
            {
                inLogin = false;
                MainWindow main = new MainWindow(c);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(respuesta);
                if (respuesta.Contains("SP001"))
                {
                    tbLogin.Focus();
                }
                else if (respuesta.Contains("SP002")) {
                    pbPassword.Focus();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
