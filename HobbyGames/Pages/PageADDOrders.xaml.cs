using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для PageADDOrders.xaml
    /// </summary>
    public partial class PageADDOrders : Page
    {
        int[] empid = new int[ClassBase.BASE.Employees.Count()];

        int itog = 0;

        bool update = false;

        Orders order;

        void uploadfields()
        {
            StoreBox.ItemsSource = ClassBase.BASE.Contacts.ToList();
            StoreBox.SelectedValuePath = "IdStore";
            StoreBox.DisplayMemberPath = "Adress";

            GameBox.ItemsSource = ClassBase.BASE.TableGames.ToList();
            GameBox.SelectedValuePath = "IDGame";
            GameBox.DisplayMemberPath = "Name";

            List<Employees> emp = ClassBase.BASE.Employees.ToList();
            for (int i = 0; i < emp.Count; i++)
            {
                EmpBox.Items.Add(emp[i].Second_Name + " " + emp[i].First_Name + " " + emp[i].Patronymic);
                empid[i] = emp[i].IDEmp;
            }
        }

        public PageADDOrders(Orders order)
        {
            InitializeComponent();
            uploadfields();
            this.order = order;
            CreateOrderBtn.Content = "Изменить запись";
            update = true;
            GameBox.SelectedValue = order.Game;
            KolvoTxt.Text = order.Kolvo.ToString();
            List<Employees> emp = ClassBase.BASE.Employees.ToList();
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].IDEmp == order.Employee)
                {
                    EmpBox.SelectedIndex = i;
                    break;
                }
            }
            StoreBox.SelectedValue = order.Store;
            DeleteBtn.Visibility = Visibility.Visible;
            List<TableGames> tb = ClassBase.BASE.TableGames.ToList();
            itog = tb.FirstOrDefault(x => x.IDGame == Convert.ToInt32(GameBox.SelectedValue)).Cost;
        }

        public PageADDOrders()
        {
            InitializeComponent();
            uploadfields();

            CreateOrderBtn.Content = "Создать запись";
        }

        private void BackAddOrders_btn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.GoBack();
        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (update) 
                {
                    int raznica = order.Kolvo- Convert.ToInt32(KolvoTxt.Text);
                    order.Game = (int)GameBox.SelectedValue;
                    order.Kolvo = Convert.ToInt32(KolvoTxt.Text);
                    order.Employee = empid[EmpBox.SelectedIndex];
                    order.Store = (int)StoreBox.SelectedValue;
                    order.CostS = itog * order.Kolvo;
                    Storage storage = ClassBase.BASE.Storage.FirstOrDefault(x => x.Game == order.Game && x.Store == order.Store);
                    if(raznica > 0)
                    {
                        storage.Kolvo += raznica;
                    }
                    else
                    {
                        storage.Kolvo -= Math.Abs(raznica);
                    } 
                    ClassBase.BASE.SaveChanges();
                    MessageBox.Show("Запись изменена");
                    ClassFrame.Mfrm.Navigate(new PageVIEWOrders());
                }
                else 
                {
                    Orders ord = new Orders();
                    ord.Game = (int)GameBox.SelectedValue;
                    ord.Kolvo = Convert.ToInt32(KolvoTxt.Text);
                    ord.Employee = empid[EmpBox.SelectedIndex];
                    ord.Store = (int)StoreBox.SelectedValue;
                    ord.CostS = itog * ord.Kolvo;
                    ClassBase.BASE.Orders.Add(ord);
                    Storage storage = ClassBase.BASE.Storage.FirstOrDefault(x => x.Game == ord.Game && x.Store == ord.Store);
                    storage.Kolvo -= ord.Kolvo;
                    ClassBase.BASE.SaveChanges();
                    MessageBox.Show("Данные записаны.");
                    ClassFrame.Mfrm.Navigate(new PageVIEWOrders());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Данные не записаны. Возможно не все текстовые поля заполнены."+ex.Message);
            }
        }

        private void GameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<TableGames> tb = ClassBase.BASE.TableGames.ToList();
            itog = tb.FirstOrDefault(x => x.IDGame == Convert.ToInt32(GameBox.SelectedValue)).Cost;

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Storage storage = ClassBase.BASE.Storage.FirstOrDefault(x => x.Game == order.Game && x.Store == order.Store);
            storage.Kolvo += order.Kolvo;
            ClassBase.BASE.Orders.Remove(order);   
            ClassBase.BASE.SaveChanges();
            ClassFrame.Mfrm.Navigate(new PageVIEWOrders());
        }
    }
}
