using AntroLaNocheSigue.BIZ;
using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using AntroLaNocheSigue.DAL;
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

namespace AntroLaNocheSigue.GUI.Escritorio.Administrador
{
    /// <summary>
    /// Lógica de interacción para VentanaCambiarDeContrasena.xaml
    /// </summary>
    public partial class VentanaCambiarDeContrasena : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion accionDeContras;

        IManejadorDeContrasena manejadorDeContrasena;
        public VentanaCambiarDeContrasena()
        {
            InitializeComponent();

            manejadorDeContrasena = new ManejadorDeContrasena(new RepositorioGenerico<Contrasena>());

            cmbxUsuaario.ItemsSource = manejadorDeContrasena.Listar;

            if (manejadorDeContrasena.Listar.Count == 0)
            {
                accionDeContras = accion.nuevo;
                txtDeContrasena.Clear();
                txtDeContrasena.Clear();
                txbxUsuaario.Visibility = Visibility.Visible;
                cmbxUsuaario.Visibility = Visibility.Collapsed;
            }
            else
            {
                accionDeContras = accion.editar;
                txtDeContrasena.Clear();
                txtDeContrasena.Clear();
                txbxUsuaario.Visibility = Visibility.Collapsed;
                cmbxUsuaario.Visibility = Visibility.Visible;
            }

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (accionDeContras == accion.nuevo)
            {
                if (!string.IsNullOrWhiteSpace(txbxUsuaario.Text) && !string.IsNullOrWhiteSpace(txtDeContrasena.Text))
                {
                    Contrasena usu = new Contrasena()
                    {
                        Contrasenas = txtDeContrasena.Text,
                        usuario = txbxUsuaario.Text
                    };
                    if (manejadorDeContrasena.Agregar(usu))
                    {
                        MessageBox.Show("Se agrego Correctamente el usuario", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow pagina = new MainWindow();
                        pagina.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ah ocurrido un error al guardar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Te Faltan Datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                if (cmbxUsuaario.SelectedItem!=null && !string.IsNullOrWhiteSpace(txtDeContrasena.Text))
                {
                    Contrasena usu = cmbxUsuaario.SelectedItem as Contrasena;

                    usu.Contrasenas = txtDeContrasena.Text;

                    if (manejadorDeContrasena.Editar(usu))
                    {
                        MessageBox.Show("Se modifico Correctamente el usuario", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow pagina = new MainWindow();
                        pagina.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ah ocurrido un error al modificar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Te Faltan Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }
    }
}
