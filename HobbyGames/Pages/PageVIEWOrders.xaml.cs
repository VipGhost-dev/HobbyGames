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
    /// Логика взаимодействия для PageVIEWOrders.xaml
    /// </summary>
    public partial class PageVIEWOrders : Page
    {
        public PageVIEWOrders()
        {
            InitializeComponent();
            listOrders.ItemsSource = ClassBase.BASE.Orders.ToList();
            listOrders.SelectedValuePath = "Id";
        }

        private void ProfitBlock_Loaded(object sender, RoutedEventArgs e)
        {
            int profit = ClassBase.BASE.Orders.Sum(z => z.CostS);
            ProfitBlock.Text = profit.ToString();
        }

        private void BacOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new AdminPage());
        }

        private void AddOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new PageADDOrders());
        }

        private void listOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Convert.ToInt32(listOrders.SelectedValue);
            Orders order = ClassBase.BASE.Orders.FirstOrDefault(x => x.Id == index);
            ClassFrame.Mfrm.Navigate(new PageADDOrders(order));
        }
    }
}
