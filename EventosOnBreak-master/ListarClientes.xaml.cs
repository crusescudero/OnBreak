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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using OnBreak.Negocio;

namespace EventosOnBreak_master
{
    /// <summary>
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : MetroWindow
    {
        public ListarClientes()
        {
            InitializeComponent();
            llenarGrilla();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
        }

        private void llenarGrilla()
        {

            List<OnBreak.Negocio.Cliente> listaClientes = new List<OnBreak.Negocio.Cliente>();
            OnBreak.Negocio.Cliente objCliente = new OnBreak.Negocio.Cliente();

            listaClientes = objCliente.LeerTodo();
            dgClientes.ItemsSource = listaClientes;

        }


    }
}
