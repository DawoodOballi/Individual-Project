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
        public CRUDoperations _crudOperation = new CRUDoperations();
        public LogInPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboxUserType.SelectedItem.ToString().Contains("User"))
            {
                string userText = txtUsername.Text;
                _crudOperation.GetUserForUserName(userText);
                if (_crudOperation.EnteredUser != null)
                {
                    MainPage main = new MainPage(txtUsername.Text, _crudOperation.EnteredUser);
                    frame.Content = main;
                }
                else
                {
                    MessageBox.Show("The Username entered is incorrect");
                }
            }
            else if (comboxUserType.SelectedItem.ToString().Contains("Admin"))
            {
                MessageBox.Show("Please enter an Admin User name");
            }
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            frame.Content = register;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string userText = txtUsername.Text;
                _crudOperation.GetUserForUserName(userText);
                if (_crudOperation.EnteredUser != null)
                {
                    MainPage main = new MainPage(txtUsername.Text, _crudOperation.EnteredUser);
                    frame.Content = main;
                }
                else
                {
                    MessageBox.Show("The Username entered is incorrect");
                }
            }
        }

        private void comboxUserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
