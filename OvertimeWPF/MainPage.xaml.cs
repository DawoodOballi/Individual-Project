﻿using System;
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
        public MainPage(string user)
        {
            InitializeComponent();
            txtHelloUser.Text = "Hello" + user;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LogInPage login = new LogInPage();
            frame.Content = login;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtHelloUser_TextChanged(object sender, TextChangedEventArgs e)
        {


        }
    }
}
