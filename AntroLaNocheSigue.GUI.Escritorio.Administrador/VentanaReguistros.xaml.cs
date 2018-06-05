using AntroLaNocheSigue.BIZ;
using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using AntroLaNocheSigue.DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para VentanaReguistros.xaml
    /// </summary>
    public partial class VentanaReguistros : Window
    {
        enum accion
        {
            nuevo, editar
        }
        accion accionDeCliente;
        accion accionDeEmpleado;

        IManejadorDeClientesVip manejadorDeClientesVip;
        IManejadorDeEmpleado manejadorDeEmpleado;
        public VentanaReguistros()
        {
            InitializeComponent();

            manejadorDeEmpleado = new ManejadorDeEmpleados(new RepositorioGenerico<Trabajador>());
            manejadorDeClientesVip = new ManejadorDeClienteVip(new RepositorioGenerico<ClienteVip>());

            ActualizarTablaDeEmpleado();
            ActualizarTablaDeCliente();

            LimpiarCamposDeEmpleado(false);
            LimpiarCamposDeCliente(false);

            HabilitarBotonesParaEmpleados(false);
            HabilitarBotonesParaClientes(false);
        }

        private void HabilitarBotonesParaClientes(bool habilitado)
        {
            btnCancelarCliente.IsEnabled = habilitado;
            btnEditarCliente.IsEnabled = !habilitado;
            btnEliminarCliente.IsEnabled = !habilitado;
            btnGuardarCliente.IsEnabled = habilitado;
            btnNuevoCliente.IsEnabled = !habilitado;

        }

        private void HabilitarBotonesParaEmpleados(bool v)
        {
            btnCancelarEmpleado.IsEnabled = v;
            btnEditarEmpleado.IsEnabled = !v;
            btnEliminarEmpleado.IsEnabled = !v;
            btnGuardarEmpleado.IsEnabled = v;
            btnNuevoEmpleado.IsEnabled = !v;
        }

        private void LimpiarCamposDeCliente(bool v)
        {
            tbxClaveDeElectorCliente.Clear();
            tbxDomicilioDeCliente.Clear();
            tbxNombreDeCliente.Clear();
            tbxMensaualidadesDeCliente.Clear();

            panelDeDatosCliente.IsEnabled = v;
            panelDeDatosClienteConFoto.IsEnabled = v;
            lstvClientes.IsEnabled = !v;
            ImgFotoCliente.Source = null;
        }

        private void LimpiarCamposDeEmpleado(bool v)
        {
            tbxCargoDeEmpleado.Clear();
            tbxNombreDeEmpleado.Clear();
            tbxDomicilioDeEmpleado.Clear();
            tbxClaveDeElectorDeEmpleado.Clear();

            panelDeDatosEmpleado.IsEnabled = v;
            panelDeDatosEmpleadoConFoto.IsEnabled = v;
            lstvEmpleados.IsEnabled = !v;
            ImgFotoEmpleado.Source = null;
        }

        private void ActualizarTablaDeCliente()
        {
            lstvClientes.ItemsSource = null;
            lstvClientes.ItemsSource = manejadorDeClientesVip.Listar;
        }

        private void ActualizarTablaDeEmpleado()
        {
            lstvEmpleados.ItemsSource = null;
            lstvEmpleados.ItemsSource = manejadorDeEmpleado.Listar;
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotonesParaClientes(true);
            LimpiarCamposDeCliente(true);
            accionDeCliente = accion.nuevo;
        }

        private void btnCancelarCliente_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotonesParaClientes(false);
            LimpiarCamposDeCliente(false);
        }

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorDeClientesVip.Listar.Count != 0)
            {
                ClienteVip cliente = lstvClientes.SelectedItem as ClienteVip;

                if (cliente != null)
                {
                    HabilitarBotonesParaClientes(true);
                    LimpiarCamposDeCliente(true);
                    accionDeCliente = accion.editar;
                    tbxClaveDeElectorCliente.Text = cliente.ClaveDeElector;
                    tbxNombreDeCliente.Text = cliente.Nombre;
                    tbxDomicilioDeCliente.Text = cliente.Domicilio;
                    tbxMensaualidadesDeCliente.Text = cliente.NumeroDeMensualidaes.ToString();
                    ImgFotoCliente.Source = ByteToImagen(cliente.Foto);
                }
                else
                {
                    MensajeNoSeleccionadoNada("cliente", "editar", "Error al editar cliente");
                }
            }
            else
            {
                MensajeNoContienes("cliente", "editar", "Error al editar cliente");

            }


        }

        private ImageSource ByteToImagen(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage bitimg = new BitmapImage();
                MemoryStream las = new MemoryStream(imageData);
                bitimg.BeginInit();
                bitimg.StreamSource = las;
                bitimg.EndInit();
                ImageSource imgSrc = bitimg as ImageSource;
                return imgSrc;
            }
        }

        private void MensajeNoSeleccionadoNada(string elemento, string accion, string Titulo)
        {
            MessageBox.Show("No has selecionado ningun " + elemento + " para " + accion, "" + Titulo, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
        }

        private void MensajeDeOperacionIncorrecta(string elemento, string accion, string titulo)
        {
            MessageBox.Show("Ocurrio un error al " + accion + " el " + elemento, "" + titulo, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
        }

        private void MensajeDeOperacionCorrecta(string elemento, string accionTerminacionO, string tituloDeAccion)
        {
            MessageBox.Show("" + elemento + " se " + accionTerminacionO + " correctamente", "Elemento " + tituloDeAccion + " Correctamente", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
        }

        private void MensajeNoContienes(string elemento, string accion, string Titulo)
        {
            MessageBox.Show("No tienes ningun " + elemento + " para " + accion, "" + Titulo, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorDeClientesVip.Listar.Count != 0)
            {
                Cliente cliente = lstvClientes.SelectedItem as Cliente;

                if (cliente != null)
                {
                    if (MessageBox.Show("Realmente deseas eliminar el cliente''" + cliente.Nombre + "''", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.ServiceNotification) == MessageBoxResult.Yes)

                        if (manejadorDeClientesVip.Eliminar(cliente.Id))
                        {
                            MensajeDeOperacionCorrecta("cliente", "elimino", "eliminado");
                            ActualizarTablaDeCliente();
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("cliente", "eliminar", "Error al eliminar cliente");
                        }
                }
                else
                {
                    MensajeNoSeleccionadoNada("cliente", "eliminar", "Error se seleccion");
                }
            }
            else
            {
                MensajeNoContienes("cliente", "eliminar", "Error de elementos");

            }
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbxClaveDeElectorCliente.Text) && !string.IsNullOrWhiteSpace(tbxNombreDeCliente.Text) && !string.IsNullOrWhiteSpace(tbxDomicilioDeCliente.Text) && !string.IsNullOrWhiteSpace(tbxMensaualidadesDeCliente.Text))
                {
                    if (accionDeCliente == accion.nuevo)
                    {
                        ClienteVip cliente = new ClienteVip()
                        {
                            ClaveDeElector = tbxClaveDeElectorCliente.Text,
                            Nombre = tbxNombreDeCliente.Text,
                            Domicilio = tbxDomicilioDeCliente.Text,
                            NumeroDeMensualidaes = int.Parse(tbxMensaualidadesDeCliente.Text),
                            Foto = ImageToByte(ImgFotoCliente.Source)
                        };
                        if (manejadorDeClientesVip.Agregar(cliente))
                        {
                            MensajeDeOperacionCorrecta("cliente", "agrego", "agregado");
                            ActualizarTablaDeCliente();
                            HabilitarBotonesParaClientes(false);
                            LimpiarCamposDeCliente(false);
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("cliente", "guardar", "Error al guardar cliente");
                        }
                    }
                    else
                    {
                        ClienteVip cliente = lstvClientes.SelectedItem as ClienteVip;
                        cliente.ClaveDeElector = tbxClaveDeElectorCliente.Text;
                        cliente.Nombre = tbxNombreDeCliente.Text;
                        cliente.Domicilio = tbxDomicilioDeCliente.Text;
                        cliente.NumeroDeMensualidaes = int.Parse(tbxMensaualidadesDeCliente.Text);
                        cliente.Foto = ImageToByte(ImgFotoCliente.Source);

                        if (manejadorDeClientesVip.Editar(cliente))
                        {
                            MensajeDeOperacionCorrecta("cliente", "modifico", "modificado");
                            ActualizarTablaDeCliente();
                            HabilitarBotonesParaClientes(false);
                            LimpiarCamposDeCliente(false);
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("cliente", "modificar", "Error al modificar cliente");
                        }
                    }
                }
                else
                {
                    MensajeFaltaDeDatos();
                }
            }
            catch (Exception ex)
            {

                MensajeDeError(ex);
            }
        }

        public byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
            else
            {
                return null;
            }
        }


        private void MensajeFaltaDeDatos()
        {
            MessageBox.Show("Faltan datos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
        }

        private void MensajeDeError(Exception ex)
        {
            MessageBox.Show("" + ex.Message);
        }

        private void btnFotoCliente_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecciona la fotografia";
            dialog.Filter = "Formato de imagen|*.jpg; *.png";
            if (dialog.ShowDialog().Value)
            {
                ImgFotoCliente.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void btnFotoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecciona la fotografia";
            dialog.Filter = "Formato de imagen|*.jpg; *.png";
            if (dialog.ShowDialog().Value)
            {
                ImgFotoEmpleado.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void btnNuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotonesParaEmpleados(true);
            LimpiarCamposDeEmpleado(true);
            tbxCargoDeEmpleado.IsEnabled = true;
            accionDeEmpleado = accion.nuevo;
        }

        private void btnCancelarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotonesParaEmpleados(false);
            LimpiarCamposDeEmpleado(false);
        }

        private void btnEditarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorDeEmpleado.Listar.Count != 0)
            {
                Trabajador empleado = lstvEmpleados.SelectedItem as Trabajador;
                if (empleado != null)
                {
                    LimpiarCamposDeEmpleado(true);
                    HabilitarBotonesParaEmpleados(true);
                    accionDeEmpleado = accion.editar;

                    tbxCargoDeEmpleado.Text = empleado.Cargo;
                    tbxClaveDeElectorDeEmpleado.Text = empleado.ClaveDeElector;
                    tbxNombreDeEmpleado.Text = empleado.Nombre;
                    tbxDomicilioDeEmpleado.Text = empleado.Domicilio;
                    ImgFotoEmpleado.Source = ByteToImagen(empleado.Foto);
                }
                else
                {
                    MensajeNoSeleccionadoNada("empleado", "editar", "Error en selección");
                }
            }
            else
            {
                MensajeNoContienes("empleado", "editar", "Falta de datos");
            }
        }

        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (manejadorDeEmpleado.Listar.Count != 0)
            {
                Trabajador empleado = lstvEmpleados.SelectedItem as Trabajador;
                if (empleado != null)
                {

                    if (MessageBox.Show("Realmente deseas eliminar el empleado''" + empleado.Nombre + "''", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.None, MessageBoxOptions.ServiceNotification) == MessageBoxResult.Yes)
                    {
                        if (manejadorDeEmpleado.Eliminar(empleado.Id))
                        {
                            MensajeDeOperacionCorrecta("empleado", "eliminado", "eliminado");
                            ActualizarTablaDeEmpleado();
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("empleado", "eliminar", "Error al eliminar");
                        }
                    }


                }
                else
                {
                    MensajeNoSeleccionadoNada("empleado", "eliminar", "Error en selección");
                }
            }
            else
            {
                MensajeNoContienes("empleado", "eliminar", "Falta de datos");
            }
        }

        private void btnGuardarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accionDeEmpleado == accion.nuevo)
                {
                    if (!string.IsNullOrWhiteSpace(tbxCargoDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxNombreDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxClaveDeElectorDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxDomicilioDeEmpleado.Text))
                    {
                        Trabajador empleado = new Trabajador()
                        {
                            Cargo = tbxCargoDeEmpleado.Text,
                            Nombre = tbxNombreDeEmpleado.Text,
                            Domicilio = tbxDomicilioDeEmpleado.Text,
                            Foto = ImageToByte(ImgFotoEmpleado.Source)
                        };

                        if (manejadorDeEmpleado.Agregar(empleado))
                        {
                            MensajeDeOperacionCorrecta("empleado", "agrego", "agregado");
                            ActualizarTablaDeEmpleado();
                            HabilitarBotonesParaEmpleados(false);
                            LimpiarCamposDeEmpleado(false);
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("empleado", "agregar", "Error al agregar el empleado");
                            throw new Exception("error");

                        }

                    }
                    else
                    {
                        MensajeFaltaDeDatos();
                    }
                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(tbxCargoDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxNombreDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxClaveDeElectorDeEmpleado.Text) && !string.IsNullOrWhiteSpace(tbxDomicilioDeEmpleado.Text))
                    {
                        Trabajador empleado = lstvEmpleados.SelectedItem as Trabajador;

                        empleado.ClaveDeElector = tbxClaveDeElectorCliente.Text;
                        empleado.Cargo = tbxCargoDeEmpleado.Text;
                        empleado.Nombre = tbxNombreDeEmpleado.Text;
                        empleado.Domicilio = tbxDomicilioDeEmpleado.Text;
                        empleado.Foto = ImageToByte(ImgFotoEmpleado.Source);

                        if (manejadorDeEmpleado.Editar(empleado))
                        {
                            MensajeDeOperacionCorrecta("empleado", "modifico", "modificado");
                            ActualizarTablaDeEmpleado();
                            HabilitarBotonesParaEmpleados(false);
                            LimpiarCamposDeEmpleado(false);
                        }
                        else
                        {
                            MensajeDeOperacionIncorrecta("gerente", "modifico", "Error al modificar el gerente");
                        }
                    }
                    else
                    {
                        MensajeFaltaDeDatos();
                    }

                }
            }
            catch (Exception ex)
            {

                MensajeDeError(ex);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }
    }
}
