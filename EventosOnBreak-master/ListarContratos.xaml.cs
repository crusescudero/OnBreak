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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls.Dialogs;
using OnBreak.Negocio;



namespace EventosOnBreak_master
{
    /// <summary>
    /// Lógica de interacción para ListarContratos.xaml
    /// </summary>
    public partial class ListarContratos : MetroWindow
    {
        public ListarContratos()
        {
            InitializeComponent();           
            llenarGrilla();
            TipoEvento te = new TipoEvento();
            cboTipoEvento.ItemsSource = te.ListaCombo();
            cboTipoEvento.SelectedValue = 0;
            Contrato cont = new Contrato();
            dgContratos.ItemsSource = cont.LeerTodo();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
        }

        private void llenarGrilla()
        {

            List<OnBreak.Negocio.Contrato> listaContrato = new List<OnBreak.Negocio.Contrato>();
            OnBreak.Negocio.Contrato objContrato = new OnBreak.Negocio.Contrato();

            listaContrato = objContrato.LeerTodo();
            dgContratos.ItemsSource = listaContrato;

        }


        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cboTipoEvento.SelectedValue != null)
            {
                int id_tipo = 0;
                if (cboTipoEvento.SelectedIndex > -1)
                {
                    id_tipo = int.Parse(cboTipoEvento.SelectedValue.ToString());
                    ModalidadServicio ms = new ModalidadServicio();
                    ms.IdTipoEvento = id_tipo;
                    cboMod.ItemsSource = ms.ListarPorTE();
                }
            }
        }
    }
       
}
