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
using IP_BusinessLayer;
using IP_Booking_Overtime;

namespace OvertimeWPF
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        CRUDoperations _crudOperations = new CRUDoperations();
        Admins _adminEntered;
        public AdminPage(string admin, Admins adminEntered)
        {
            InitializeComponent();
            txtHelloUser.Text = $"Welcome {admin}!";
            _adminEntered = adminEntered;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LogInPage login = new LogInPage();
            frame.Content = login;
        }

        private void txtHelloUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBookedOvertime_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateBookedOvertimeForAllUsers();
        }

        private void btnAvailableOvertime_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateAvailabelOvertime();
        }

        private void btnMonday_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForMonday();
        }

        private void btnTuesday_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForTuesday();
        }

        private void btnWednesday_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForWednesday();
        }

        private void btnThursday_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForThursday();
        }

        private void btnFriday_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForFriday();
        }

        private void btnCreateOvertime_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Daybox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartTimeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
