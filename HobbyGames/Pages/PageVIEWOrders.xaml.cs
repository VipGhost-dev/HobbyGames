using HobbyGames.Classes;
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
        PageChange pc = new PageChange();  // создаем объект класса для отображения страниц
        List<Orders> OrderC = new List<Orders>();
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

            OrderC = ClassBase.BASE.Orders.ToList();
            pc.CountPage = ClassBase.BASE.Orders.ToList().Count;
            DataContext = pc;  // добавляем объект для отображения страниц в ресурсы страницы
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
            string game = GameBox.SelectedValue.ToString();

            if (GameBox.SelectedIndex != 0)
            {
                OrderC = ClassBase.BASE.Orders.Where(z => z.TableGames.Name == game).ToList();
            }
            else
            {
                OrderC = ClassBase.BASE.Orders.ToList();
            }

            if(checkImage.IsChecked == true)
            {
                OrderC = OrderC.Where(z => z.TableGames.Picture != null).ToList();
            }

            switch (SortBox.SelectedIndex)
            {
                case 0:
                    {
                        OrderC.Sort((x,y) => x.Kolvo.CompareTo(y.Kolvo));
                    }
                break;
                case 1:
                    {
                        OrderC.Sort((x, y) => x.Kolvo.CompareTo(y.Kolvo));
                        OrderC.Reverse();
                    }
                break;
                case 2:
                    {
                        OrderC.Sort((x, y) => x.CostS.CompareTo(y.CostS));
                    }
                break;
                case 3:
                    {
                        OrderC.Sort((x, y) => x.CostS.CompareTo(y.CostS));
                        OrderC.Reverse();
                    }
                break;
                case 4:
                    {
                        OrderC.Sort((x, y) => x.TableGames.Name.CompareTo(y.TableGames.Name));
                    }
                break;
                case 5:
                    {
                        OrderC.Sort((x, y) => x.TableGames.Name.CompareTo(y.TableGames.Name));
                        OrderC.Reverse();
                    }
                break;
            }

            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                OrderC = OrderC.Where(z => z.Employees.Second_Name.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            }

            listOrders.ItemsSource = OrderC;

            
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

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = OrderC.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = OrderC.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listOrders.ItemsSource = OrderC.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)  // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            listOrders.ItemsSource = OrderC.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
            // Skip(pc.CurrentPage* pc.CountPage - pc.CountPage) - сколько пропускаем записей
            // Take(pc.CountPage) - сколько записей отображаем на странице
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            pc.CurrentPage = 1;

            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = OrderC.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = OrderC.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listOrders.ItemsSource = OrderC.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
        }
    }
}
