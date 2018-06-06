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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AntroLaNocheSigue.GUI.Escritorio.Empleado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorDeClientesVip manejadorDeClientesVip;
        IManejadorDeReguistroDeEntradas manejadorDeReguistroDeEntradas;

        public MainWindow()
        {
            InitializeComponent();

            manejadorDeClientesVip = new ManejadorDeClienteVip(new RepositorioGenerico<ClienteVip>());
            manejadorDeReguistroDeEntradas = new ManejadorDeReguistroDeEntradas(new RepositorioGenerico<ReguistroDeEntradas>());

            PanelClienteNormal.Visibility = Visibility.Collapsed;
            PanelClienteVip.Visibility = Visibility.Collapsed;

        }

        private void btnClienteVip_Click(object sender, RoutedEventArgs e)
        {
            PanelClienteNormal.Visibility = Visibility.Collapsed;
            PanelClienteVip.Visibility = Visibility.Visible;
            btnClienteNuevo.IsEnabled = true;
            btnClienteVip.IsEnabled = false;
            cmbxDeClienteVips.ItemsSource = manejadorDeClientesVip.Listar;

        }

        private void btnClienteNuevo_Click(object sender, RoutedEventArgs e)
        {
            PanelClienteNormal.Visibility = Visibility.Visible;
            PanelClienteVip.Visibility = Visibility.Collapsed;
            btnClienteNuevo.IsEnabled = false;
            btnClienteVip.IsEnabled = true;
        }

        private void cmbxClienteVip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxDeClienteVips.SelectedItem != null)
            {
                ClienteVip cliente = cmbxDeClienteVips.SelectedItem as ClienteVip;
                if (cliente.HoraDeEntrada.Count < 1)
                {
                    cliente.HoraDeEntrada = new List<DateTime?>();
                    cliente.HoraDeEntrada.Add(DateTime.Now);
                }
                else
                {
                    cliente.HoraDeEntrada.Add(DateTime.Today);
                }


            }

        }
    }
}
