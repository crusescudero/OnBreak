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
    /// Lógica de interacción para AdminContratos.xaml
    /// </summary>
    public partial class AdminContratos : MetroWindow
    {
        public AdminContratos()
        {
            InitializeComponent();
            llenarModalidad();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
        }

        public void llenarGrilla()
        {

            List<OnBreak.Negocio.Contrato> listContrato = new List<OnBreak.Negocio.Contrato>();
            OnBreak.Negocio.Contrato objCon = new OnBreak.Negocio.Contrato();

            listContrato = objCon.LeerTodo();
            listCon.ItemsSource = listContrato;

        }

        private void llenarModalidad()
        {
            OnBreak.Negocio.ModalidadServicio mod = new OnBreak.Negocio.ModalidadServicio();
            cboModalidad.ItemsSource = mod.ListarTodo();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Contrato objCont = new Contrato();
            List<OnBreak.Negocio.Contrato> listaContratos = new List<OnBreak.Negocio.Contrato>();
            objCont.Numero = txtNro.Text;
            objCont.Creacion = dpTerm.SelectedDate.Value;
            objCont.Termino = dpTerm.SelectedDate.Value;
            objCont.RutCliente = txtRut.Text;
            objCont.IdModalidad = cboModalidad.SelectedValue.ToString();
            objCont.IdModalidad = cboModalidad.SelectedValue.ToString();
            objCont.FechaHoraInicio = iniEven.SelectedDate.Value;
            objCont.FechaHoraTermino = termEven.SelectedDate.Value;
            objCont.Asistentes = int.Parse(txtAsis.Text);
            objCont.PersonalAdicional = int.Parse(txtPers.Text);
            objCont.Realizado = rbtrue.IsChecked.Value;
            objCont.ValorTotalContrato = 0;
            objCont.Observaciones = txtObs.Text;

             if (objCont.Agregar())
             {

                 MessageBox.Show("Grabar", "Datos Grabados");
                 listaContratos = objCont.LeerTodo();
                 listCon.ItemsSource = listaContratos;

             }
             else
             {
                 MessageBox.Show("Grabar", "Datos NO grabados");
             }
        }
    }
}
