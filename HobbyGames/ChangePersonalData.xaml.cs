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
using System.Windows.Shapes;

namespace HobbyGames
{
    /// <summary>
    /// Логика взаимодействия для ChangePersonalData.xaml
    /// </summary>
    public partial class ChangePersonalData : Window
    {
        public ChangePersonalData()
        {
            InitializeComponent();
            Employees employees = ClassBase.BASE.Employees.FirstOrDefault(z => z.IDEmp == Start.idemp);
            FirstBox.Text = employees.First_Name;
            SecondBox.Text = employees.Second_Name;
            PatronymicBox.Text = employees.Patronymic;
            if(employees.Gender == "М")
            {
                GenderBox.SelectedIndex = 0;
            }
            else
            {
                GenderBox.SelectedIndex = 1;
            }
            PhoneBox.Text = employees.PhoneE;
            SeriaBox.Text = employees.Seria_Passport;
            NomerBox.Text = employees.Nomer_Passport;
            StoreBox.ItemsSource = ClassBase.BASE.Contacts.ToList();
            StoreBox.SelectedValuePath = "IdStore";
            StoreBox.DisplayMemberPath = "Adress";
            StoreBox.SelectedValue = employees.Store;
        }

        private void btn_changePersonalapply_Click(object sender, RoutedEventArgs e)
        {
            if (FirstBox.Text == null || SecondBox.Text == null || PatronymicBox.Text == null || GenderBox.SelectedIndex == -1 || PhoneBox.Text == null || SeriaBox.Text == null || NomerBox.Text == null || StoreBox.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка", "Все поля должны быть заполнены");
            }
            else
            {
                Employees employees = ClassBase.BASE.Employees.FirstOrDefault(z => z.IDEmp == Start.idemp);
                employees.First_Name = FirstBox.Text;
                employees.Second_Name = SecondBox.Text;
                employees.Patronymic = PatronymicBox.Text;
                if(GenderBox.SelectedIndex == 0)
                {
                    employees.Gender = "М";
                }
                else
                {
                    employees.Gender = "Ж";
                }
                employees.PhoneE = PhoneBox.Text;
                employees.Seria_Passport = SeriaBox.Text;
                employees.Nomer_Passport = NomerBox.Text;
                employees.Store = (int)StoreBox.SelectedValue;
                ClassBase.BASE.SaveChanges();
                MessageBox.Show("Изменение персоналных данных", "Изменения успешны");
                this.Close();
            }
        }
    }
}
