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
using IP_Booking_Overtime;
using IP_BusinessLayer;

namespace OvertimeWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        CRUDoperations _crud = new CRUDoperations();
        public Register()
        {
            InitializeComponent();
        }

        private void btnSubmitNewName_Click(object sender, RoutedEventArgs e)
        {
            string newUser = txtNewUsername.Text;
            _crud.GetUserForUserName(newUser);
            if(_crud.EnteredUser != null)
            {
                MessageBox.Show("The name you have entered is aleady used. Please try again");
            }
            else
            {
                _crud.Create(newUser);
                _crud.GetUserForUserName(newUser);
                MainPage main = new MainPage(txtNewUsername.Text, _crud.EnteredUser);
                frame.Content = main;
            }
        }

        private void txtNewUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void txtNewUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string newUser = txtNewUsername.Text;
                _crud.GetUserForUserName(newUser);
                if (_crud.EnteredUser != null)
                {
                    MessageBox.Show("The name you have entered is aleady used. Please try again");
                }
                else
                {
                    _crud.Create(newUser);
                    _crud.GetUserForUserName(newUser);
                    MainPage main = new MainPage(txtNewUsername.Text, _crud.EnteredUser);
                    frame.Content = main;
                }
            }
        }
    }
}
