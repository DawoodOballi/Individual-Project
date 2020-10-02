using IP_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        CRUDoperations _crudOperations = new CRUDoperations();
        public MainPage(string user)
        {
            InitializeComponent();
            txtHelloUser.Text = $"Welcome {user}!";
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new LogInPage();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtHelloUser_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void btnBookedOvertime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAvailableOvertime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMonday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items = _crudOperations.
        }

        private void btnTuesday_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWednesday_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnThursday_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFriday_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
