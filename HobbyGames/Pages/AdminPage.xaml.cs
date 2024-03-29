﻿using System;
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

namespace HobbyGames
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ViewUsersBTN_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new PageVIEWUsers());
        }

        private void BackAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new Start());
        }

        private void ViewOrdersBTN_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new PageVIEWOrders());
        }

        private void Cabinet_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new PageEMP());
        }
    }
}
