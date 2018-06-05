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
    /// Lógica de interacción para VentanaDeOpciones.xaml
    /// </summary>
    public partial class VentanaDeOpciones : Window
    {
        public VentanaDeOpciones()
        {
            InitializeComponent();
            cmbxOperacion.SelectedItem = itemSelecciona;
        }
        private void cmbxOperacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbxOperacion.SelectedItem == itemSelecciona)
            //{
            //    MessageBox.Show("Error no has seleccioando nada", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
            if (cmbxOperacion.SelectedItem == itemReguistros)
            {
                VentanaReguistros ventana = new VentanaReguistros();
                ventana.Show();
                this.Close();
            }
            if (cmbxOperacion.SelectedItem == itemCambiarContrasena)
            {
                VentanaCambiarDeContrasena ventanaCambiarDeContrasena = new VentanaCambiarDeContrasena();
                ventanaCambiarDeContrasena.Show();
                this.Close();
            }
        }
    }
}
