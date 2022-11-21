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
    /// Логика взаимодействия для PageADDOrders.xaml
    /// </summary>
    public partial class PageADDOrders : Page
    {
        public PageADDOrders()
        {
            InitializeComponent();

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
            }
        }

        private void BackAddOrders_btn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.GoBack();
        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("Данные не записаны. Возможно не все текстовые поля заполнены.");
            }
        }

        private void GameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
