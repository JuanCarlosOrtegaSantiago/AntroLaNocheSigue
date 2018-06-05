using AntroLaNocheSigue.BIZ;
using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using AntroLaNocheSigue.DAL;
using MongoDB.Bson;
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

namespace AntroLaNocheSigue.GUI.Escritorio.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorDeContrasena manejadorDeContrasena;
        public MainWindow()
        {
            InitializeComponent();

            manejadorDeContrasena = new ManejadorDeContrasena(new RepositorioGenerico<Contrasena>());

            cmbxUsuaario.ItemsSource = manejadorDeContrasena.Listar;

            lblDatosIncorrectos.Visibility = Visibility.Collapsed;
            lblFaltanDatos.Visibility = Visibility.Collapsed;
        }

        private void ValidarContraseña()
        {
            lblDatosIncorrectos.Visibility = Visibility.Collapsed;
            lblFaltanDatos.Visibility = Visibility.Collapsed;

            if (cmbxUsuaario.SelectedItem == null && manejadorDeContrasena.Listar.Count == 0)
            {
                VentanaCambiarDeContrasena pagina = new VentanaCambiarDeContrasena();
                pagina.Show();
                this.Close();
            }
            else
            {
                if (cmbxUsuaario.SelectedItem!=null && !string.IsNullOrWhiteSpace(pswrDeContrasena.Password))
                {
                    Contrasena usuario = cmbxUsuaario.SelectedItem as Contrasena;
                    Contrasena Usu = manejadorDeContrasena.buscaPorId(usuario.Id);

                    if (pswrDeContrasena.Password == Usu.Contrasenas) 
                    {
                        VentanaDeOpciones pagina = new VentanaDeOpciones();
                        pagina.Show();
                        this.Close();
                    }
                    else
                    {
                        lblDatosIncorrectos.Visibility = Visibility.Visible;
                        lblFaltanDatos.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    lblDatosIncorrectos.Visibility = Visibility.Collapsed;
                    lblFaltanDatos.Visibility = Visibility.Visible;
                }

            }
                
            
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ValidarContraseña();
        }
    }
}
