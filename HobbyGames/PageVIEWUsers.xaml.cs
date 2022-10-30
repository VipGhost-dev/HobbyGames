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
    /// Логика взаимодействия для PageVIEWUsers.xaml
    /// </summary>
    public partial class PageVIEWUsers : Page
    {
        public PageVIEWUsers()
        {
            InitializeComponent();
            UsersData.ItemsSource = ClassBase.BASE.Employees.ToList();
        }

        private void BackVIEWUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.GoBack();
        }

        private void UPsort_Click(object sender, RoutedEventArgs e)
        {
            UsersData.ItemsSource = ClassBase.BASE.Employees.OrderBy(z => z.Second_Name).ToList();
        }

        private void DOWNsort_Click(object sender, RoutedEventArgs e)
        {
            UsersData.ItemsSource = ClassBase.BASE.Employees.OrderByDescending(z => z.Second_Name).ToList();
        }

        private void Mfiltr_Click(object sender, RoutedEventArgs e)
        {
            UsersData.ItemsSource = ClassBase.BASE.Employees.Where(z => z.Gender == "М").ToList();
        }

        private void Ffiltr_Click(object sender, RoutedEventArgs e)
        {
            UsersData.ItemsSource = ClassBase.BASE.Employees.Where(z => z.Gender == "Ж").ToList();
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SearchItemBOX.SelectedIndex == 0 && SearchBox.Text != "")
            {
                UsersData.ItemsSource = ClassBase.BASE.Employees.Where(z => z.First_Name == SearchBox.Text).ToList();
            }
            if (SearchItemBOX.SelectedIndex == 1 && SearchBox.Text != "")
            {
                UsersData.ItemsSource = ClassBase.BASE.Employees.Where(z => z.PhoneE == SearchBox.Text).ToList();
            }
        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {
            UsersData.ItemsSource = ClassBase.BASE.Employees.ToList();
            SearchItemBOX.SelectedIndex = -1;
            SearchBox.Text = "";
        }
    }
}
