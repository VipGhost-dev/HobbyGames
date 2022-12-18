using System;
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

            List<TableGames> games = ClassBase.BASE.TableGames.ToList();
            GameBox.Items.Add("Все игры");
            for(int i = 0; i < games.Count; i++)
            {
                GameBox.Items.Add(games[i].Name);
            }
            GameBox.SelectedIndex = 0;
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

        private void GameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            List<Orders> orders = new List<Orders>();
            string game = GameBox.SelectedValue.ToString();

            if (GameBox.SelectedIndex != 0)
            {
                orders = ClassBase.BASE.Orders.Where(z => z.TableGames.Name == game).ToList();
            }
            else
            {
                orders = ClassBase.BASE.Orders.ToList();
            }

            if(checkImage.IsChecked == true)
            {
                orders = orders.Where(z => z.TableGames.Picture != null).ToList();
            }

            switch (SortBox.SelectedIndex)
            {
                case 0:
                    {
                        orders.Sort((x,y) => x.Kolvo.CompareTo(y.Kolvo));
                    }
                break;
                case 1:
                    {
                        orders.Sort((x, y) => x.Kolvo.CompareTo(y.Kolvo));
                        orders.Reverse();
                    }
                break;
                case 2:
                    {
                        orders.Sort((x, y) => x.CostS.CompareTo(y.CostS));
                    }
                break;
                case 3:
                    {
                        orders.Sort((x, y) => x.CostS.CompareTo(y.CostS));
                        orders.Reverse();
                    }
                break;
                case 4:
                    {
                        orders.Sort((x, y) => x.TableGames.Name.CompareTo(y.TableGames.Name));
                    }
                break;
                case 5:
                    {
                        orders.Sort((x, y) => x.TableGames.Name.CompareTo(y.TableGames.Name));
                        orders.Reverse();
                    }
                break;
            }

            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                orders = orders.Where(z => z.Employees.Second_Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            }

            listOrders.ItemsSource = orders;

            
        }

        private void checkImage_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
