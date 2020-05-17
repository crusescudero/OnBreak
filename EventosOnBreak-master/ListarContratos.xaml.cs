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
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls.Dialogs;


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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow principal = new MainWindow();
            this.Close();
            principal.ShowDialog();
        }
    }
}
