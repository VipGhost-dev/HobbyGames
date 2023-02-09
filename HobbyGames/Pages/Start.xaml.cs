using HobbyGames.Pages;
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
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
        }

        public static int idemp;

        /// <summary>
        /// Администратор Логин: lied00 Пароль: Asdf123!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogON_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxt.Text != "" && PasswordTxt.Password != null)
            {
                int pwd = PasswordTxt.Password.GetHashCode();
                Logins loginsUsers = ClassBase.BASE.Logins.FirstOrDefault(z => z.Login == LoginTxt.Text && z.Password == pwd);
                if(loginsUsers != null)
                {
                    if(loginsUsers.IDRole == 2)
                    {
                        idemp = loginsUsers.IDe;
                        LoginTxt.Text = "";
                        PasswordTxt.Password = null;
                        ClassFrame.Mfrm.Navigate(new AdminPage());
                    }
                    else
                    {
                        idemp = loginsUsers.IDe;
                        LoginTxt.Text = "";
                        PasswordTxt.Password = null;
                        ClassFrame.Mfrm.Navigate(new PageEMP());
                    }
                }
                else
                {
                    MessageBox.Show("Введены неверный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new RegisterPage());
        }

        private void Ad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new AdPage());
        }
    }
}
