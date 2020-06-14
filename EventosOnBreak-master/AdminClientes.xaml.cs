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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using OnBreak.Negocio;

namespace EventosOnBreak_master
{
    /// <summary>
    /// Lógica de interacción para AdminClientes.xaml
    /// </summary>
    public partial class AdminClientes : MetroWindow
    {
        
        public AdminClientes()
        {
            
            InitializeComponent();
            llenarActividad();
            llenarTipo();
            Limpiar();
            llenarGrilla();

        }

        public void llenarGrilla()
        {

            List<OnBreak.Negocio.Cliente> listClientes = new List<OnBreak.Negocio.Cliente>();
            OnBreak.Negocio.Cliente objCli = new OnBreak.Negocio.Cliente();

            listClientes = objCli.LeerTodo();
            listCli.ItemsSource = listClientes;

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
            
        }

        private void llenarActividad()
        {
            OnBreak.Negocio.ActividadEmpresa act = new OnBreak.Negocio.ActividadEmpresa();
            cboActividad.ItemsSource = act.ListarTodo();
        }

        private void llenarTipo()
        {
            OnBreak.Negocio.TipoEmpresa tip = new OnBreak.Negocio.TipoEmpresa();
            cboTipo.ItemsSource = tip.ListarTodo();
        }

        private void Limpiar()
        {
            txtRut.Text = String.Empty;
            txtRazon.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtMail.Text = String.Empty;
            txtDire.Text = String.Empty;
            txtNum.Text = String.Empty;
            cboActividad.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*List<OnBreak.Negocio.Cliente> listaClientes = new List<OnBreak.Negocio.Cliente>();
            OnBreak.Negocio.Cliente objCliente = new OnBreak.Negocio.Cliente();
            listaClientes = objCliente.LeerTodo();
            listCli.ItemsSource = listaClientes;*/

            DataGrid dg = (DataGrid)sender;
            Cliente selected_cli = dg.SelectedItem as Cliente;
            if (selected_cli != null)
            {
                txtRut.Text = selected_cli.RutCliente;
                txtRazon.Text = selected_cli.RazonSocial;
                txtNombre.Text = selected_cli.NombreContacto;
                txtMail.Text = selected_cli.MailContacto;
                txtDire.Text = selected_cli.Direccion;
                txtNum.Text = selected_cli.Telefono;
                cboActividad.SelectedValue = selected_cli.IdActividadEmpresa;
                cboTipo.SelectedValue = selected_cli.IdTipoEmpresa;
                
           
                txtRut.IsEnabled = false;
                btnGrabar.IsEnabled = false;

            }
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            Cliente objCli = new Cliente();
            List<OnBreak.Negocio.Cliente> listaClientes = new List<OnBreak.Negocio.Cliente>();
            objCli.RutCliente = txtRut.Text;
            objCli.RazonSocial = txtRazon.Text;
            objCli.NombreContacto = txtNombre.Text;
            objCli.MailContacto = txtMail.Text;
            objCli.Direccion = txtDire.Text;
            objCli.Telefono = txtNum.Text;
            objCli.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
            objCli.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

            if (objCli.Agregar())
            {
                
                MessageBox.Show("Grabar", "Datos Grabados");
                listaClientes=objCli.LeerTodo();
                listCli.ItemsSource = listaClientes;

            }
            else
            {
                MessageBox.Show("Grabar", "Datos NO grabados");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente objCli = new Cliente();

            objCli.RutCliente = txtRut.Text;

            if (objCli.Eliminar())
            {
                MessageBox.Show("Eliminar", "Datos Eliminados");

                llenarGrilla();
                Limpiar();
                txtRut.IsEnabled = true;
                btnGrabar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Eliminar", "Datos NO eliminados");
            }   
        }    

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            Cliente objCli = new Cliente();

            objCli.RutCliente = txtRut.Text;
            objCli.RazonSocial = txtRazon.Text;
            objCli.NombreContacto = txtNombre.Text;
            objCli.MailContacto = txtMail.Text;
            objCli.Direccion = txtDire.Text;
            objCli.Telefono = txtNum.Text;
            objCli.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
            objCli.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

            if (objCli.Modificar())
            {
                MessageBox.Show("Modificar", "Datos Modificados");
                llenarGrilla();
                Limpiar();
                txtRut.IsEnabled = true;
                btnGrabar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Modificar", "Datos NO modificados");
            }
        }

        private void TxtRut_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                
                return;
            }
            else
            {    
                Cliente cli = new Cliente();
                cli.RutCliente = txtRut.Text;
                listCli.ItemsSource = cli.ListarPorRut();
                
            }
        }
    }
}


