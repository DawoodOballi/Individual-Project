using IP_BusinessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IP_Booking_Overtime;
using System.Linq;

namespace OvertimeWPF
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public CRUDoperations _crudOperation = new CRUDoperations();
        public LogIn()
        {
            InitializeComponent();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string userText = txtUsername.Text;
            var user = _crudOperation.GetUserForUserName(userText);
            if (user != null)
            {
                MainWindow main = new MainWindow();
                main.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("The Username entered is incorrect");
            }
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
