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

namespace AntroLaNocheSigue.GUI.Escritorio.Empleado
{
    /// <summary>
    /// Lógica de interacción para VentanaEmpleados.xaml
    /// </summary>
    public partial class VentanaEmpleados : Window
    {
        IManejadorDeEmpleado manejadorDeEmpleado;
        public VentanaEmpleados()
        {
            InitializeComponent();
            manejadorDeEmpleado = new ManejadorDeEmpleados(new RepositorioGenerico<Trabajador>());

            cmbxEmpleado.ItemsSource = manejadorDeEmpleado.Listar;
        }
    }
}
