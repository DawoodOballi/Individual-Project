using IP_Booking_Overtime;
using IP_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Users _userEntered;
        UserManager userManager = new UserManager();
        OvertimeManager overtimeManager = new OvertimeManager();
        public MainPage(string user, Users userEntered)
        {
            InitializeComponent();
            txtHelloUser.Text = $"Welcome {user}!";
            _userEntered = userEntered;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                if (overtimeManager.CheckForOverlap(_userEntered, ListBox.SelectedItem) == true)
                {
                    overtimeManager.SetUser_IDs_ForBookedOvertime(_userEntered, ListBox.SelectedItem);
                    ListBox.ItemsSource = null;
                    if (overtimeManager.SelectedOvertime.Day.Equals("Monday"))
                    {
                        ListBox.ItemsSource = overtimeManager.PopulateOvertimeForMonday();
                    }
                    else if (overtimeManager.SelectedOvertime.Day.Equals("Tuesday"))
                    {
                        ListBox.ItemsSource = overtimeManager.PopulateOvertimeForTuesday();
                    }
                    else if (overtimeManager.SelectedOvertime.Day.Equals("Wednesday"))
                    {
                        ListBox.ItemsSource = overtimeManager.PopulateOvertimeForWednesday();
                    }
                    else if (overtimeManager.SelectedOvertime.Day.Equals("Thursday"))
                    {
                        ListBox.ItemsSource = overtimeManager.PopulateOvertimeForThursday();
                    }
                    else if (overtimeManager.SelectedOvertime.Day.Equals("Friday"))
                    {
                        ListBox.ItemsSource = overtimeManager.PopulateOvertimeForFriday();
                    }
                }
                else
                {
                    MessageBox.Show("The Overtime slot you have selected overlaps with 1 or more of the booked overtimes. Please cancel any overlapping overtimes if you want to book this slot.");
                }
            }
            else
            {
                MessageBox.Show("Please select a slot to book for overtime.");
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new LogInPage();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                overtimeManager.RemoveUser_IDs_FromBookedOvertime(ListBox.SelectedItem);
                ListBox.ItemsSource = null;
                ListBox.ItemsSource = overtimeManager.PopulateBookedOvertime(_userEntered);
            }
            else
            {
                MessageBox.Show("Please select a slot to Cancel");
            }
        }

        private void txtHelloUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btnBookedOvertime_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateBookedOvertime(_userEntered);
        }

        private void btnAvailableOvertime_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateAvailabelOvertime();
        }

        private void btnMonday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateOvertimeForMonday();
        }

        private void btnTuesday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateOvertimeForTuesday();
        }

        private void btnWednesday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateOvertimeForWednesday();
        }

        private void btnThursday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateOvertimeForThursday();
        }

        private void btnFriday_Click(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = overtimeManager.PopulateOvertimeForFriday();
        }
    }
}
