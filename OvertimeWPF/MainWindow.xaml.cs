using IP_BusinessLayer;
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

namespace OvertimeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUDoperations _crudOperation = new CRUDoperations();
        public MainWindow(string user)
        {
            InitializeComponent();
            txtHelloUser.Text = "Hello" + user;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LogIn log = new LogIn();
            log.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtHelloUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
