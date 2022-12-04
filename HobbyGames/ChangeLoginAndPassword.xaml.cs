using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ChangeLoginAndPassword.xaml
    /// </summary>
    public partial class ChangeLoginAndPassword : Window
    {
        public ChangeLoginAndPassword()
        {
            InitializeComponent();
        }

        private void btn_applychangeLogin_Click(object sender, RoutedEventArgs e)
        {
            Logins logins = ClassBase.BASE.Logins.FirstOrDefault(z => z.IDe == Start.idemp);
            logins.Login = LoginBox.Text;
            Regex r1 = new Regex("[A-Z]+");
            Regex r2 = new Regex("[a-z]{3,}");
            Regex r3 = new Regex("[0-9]{2,}");
            Regex r4 = new Regex("\\W");
            if (r1.IsMatch(PasswordBoxch.Password) == false)
            {
                MessageBox.Show("Пароль должен содержать одну заглавную латинскую букву!");
            }
            else if (r2.IsMatch(PasswordBoxch.Password) == false)
            {
                MessageBox.Show("Пароль должен содержать 3 прописные латинские буквы!");
            }
            else if (r3.IsMatch(PasswordBoxch.Password) == false)
            {
                MessageBox.Show("Пароль должен содержать 2 цифры!");
            }
            else if (r4.IsMatch(PasswordBoxch.Password) == false)
            {
                MessageBox.Show("Пароль должен содержать 1 спец символ!");
            }
            else
            {
                logins.Password = PasswordBoxch.Password.GetHashCode();
            }
            ClassBase.BASE.SaveChanges();
            MessageBox.Show("Обновление Логина и Пароля", "Обновление успешно");
            this.Close();
        }
    }
}
