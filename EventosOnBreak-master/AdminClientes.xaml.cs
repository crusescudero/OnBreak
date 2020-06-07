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
    }
}
