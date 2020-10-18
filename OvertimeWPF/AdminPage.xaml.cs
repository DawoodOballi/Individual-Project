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
            string start = string.Empty;
            if (Daybox.Text != null & StartTimeBox.Text != null & NoHoursBox.Text != null)
            {
                int startTime = int.Parse(StartTimeBox.Text);
                if (startTime >= 0 && startTime <= 24)
                {
                    start = startTime + ":" + "00";
                    TimeSpan time = TimeSpan.Parse(start);
                    _crudOperations.CreateOvertime(Daybox.Text, time, NoHoursBox.Text);
                    ListBox1.ItemsSource = null;
                    if (Daybox.Text.Contains("Monday"))
                    {
                        ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForMonday();
                    }
                    else if (Daybox.Text.Contains("Tuesday"))
                    {
                        ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForTuesday();
                    }
                    else if (Daybox.Text.Contains("Tuesday"))
                    {
                        ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForWednesday();
                    }
                    else if (Daybox.Text.Contains("Tuesday"))
                    {
                        ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForThursday();
                    }
                    else if (Daybox.Text.Contains("Tuesday"))
                    {
                        ListBox1.ItemsSource = _crudOperations.PopulateOvertimeForFriday();
                    }
                }
                else
                {
                    MessageBox.Show("Please input a number between 0 and 24");
                }
            }
            else if (Daybox.Text == null || StartTimeBox.Text == null || NoHoursBox.Text == null)
            {
                MessageBox.Show("Please fill out the details to create new overtime slot.");
            }
        }

        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            string newUser = newUsertxt.Text;
            _crudOperations.GetUserForUserName(newUser);
            if (_crudOperations.EnteredUser != null)
            {
                MessageBox.Show("The name you have entered is aleady used. Please try again");
            }
            else
            {
                _crudOperations.CreateUser(newUser);
                _crudOperations.GetUserForUserName(newUser);
                MessageBox.Show($"The new user '{newUser}' has been created");
            }
        }

        private void Daybox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartTimeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NoHoursBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void newUsertxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboxTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
