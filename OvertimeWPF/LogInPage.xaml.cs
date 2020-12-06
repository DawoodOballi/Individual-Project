using IP_Booking_Overtime;
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
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public AdminManager adminManager = new AdminManager();

        public OvertimeManager overtimeManager = new OvertimeManager();

        public UserManager userManager = new UserManager();
        public LogInPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboxUserType.SelectedItem.ToString().Contains("User"))
            {
                string userText = txtUsername.Text;
                userManager.GetUserForUserName(userText);
                if (userManager.EnteredUser != null)
                {
                    MainPage main = new MainPage(txtUsername.Text, userManager.EnteredUser);
                    frame.Content = main;
                }
                else
                {
                    MessageBox.Show("The Username entered is incorrect");
                }
            }
            else if (comboxUserType.SelectedItem.ToString().Contains("Admin"))
            {
                string userText = txtUsername.Text;
                adminManager.GetAdmin(userText);
                if (adminManager.EnteredAdmin != null)
                {
                    AdminPage main = new AdminPage(txtUsername.Text, adminManager.EnteredAdmin);
                    frame.Content = main;
                }
                else
                {
                    MessageBox.Show("The Username entered is incorrect");
                }
            }
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (comboxUserType.SelectedItem.ToString().Contains("User"))
                {
                    string userText = txtUsername.Text;
                    userManager.GetUserForUserName(userText);
                    if (userManager.EnteredUser != null)
                    {
                        MainPage main = new MainPage(txtUsername.Text, userManager.EnteredUser);
                        frame.Content = main;
                    }
                    else
                    {
                        MessageBox.Show("The Username entered is incorrect");
                    }
                }
                else if (comboxUserType.SelectedItem.ToString().Contains("Admin"))
                {
                    string userText = txtUsername.Text;
                    adminManager.GetAdmin(userText);
                    if (adminManager.EnteredAdmin != null)
                    {
                        AdminPage main = new AdminPage(txtUsername.Text, adminManager.EnteredAdmin);
                        frame.Content = main;
                    }
                    else
                    {
                        MessageBox.Show("The Username entered is incorrect");
                    }
                }
            }
        }

        private void comboxUserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
