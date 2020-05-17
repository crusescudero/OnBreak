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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace EventosOnBreak_master
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void BtnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes listarclientes= new ListarClientes();
            this.Close();
            listarclientes.ShowDialog();
        }

        private void BtnRegistrarCliente(object sender, RoutedEventArgs e)
        {
            AdminClientes adminClientes = new AdminClientes();
            this.Close();
            adminClientes.ShowDialog();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnListarContratos_Click(object sender, RoutedEventArgs e)
        {
            ListarContratos listarcontratos = new ListarContratos();
            this.Close();
            listarcontratos.ShowDialog();
        }

        private void BtnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos adminContratos = new AdminContratos();
            this.Close();
            adminContratos.ShowDialog();
        }
    }
}
