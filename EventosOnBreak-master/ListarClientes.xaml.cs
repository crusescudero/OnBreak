﻿using System;
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
            llenarActividad();
            llenarTipo();
            llenarGrilla();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
        }

        public void llenarGrilla()
        {

            List<OnBreak.Negocio.Cliente> listaClientes = new List<OnBreak.Negocio.Cliente>();
            OnBreak.Negocio.Cliente objCliente = new OnBreak.Negocio.Cliente();

            listaClientes = objCliente.LeerTodo();
            dgClientes.ItemsSource = listaClientes;

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

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            
                if (e.Key != Key.Enter)
                {
                    return;
                }
                else
                {
                    Cliente cli = new Cliente();
                    cli.RutCliente = txtRut.Text;
                    dgClientes.ItemsSource = cli.ListarPorRut();
                }
            
        }
    }
}
