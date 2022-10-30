using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HobbyGames
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            StoreBox.ItemsSource = ClassBase.BASE.Contacts.ToList();
            StoreBox.SelectedValuePath = "IdStore";
            StoreBox.DisplayMemberPath = "Adress";
        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBOX.Text != "" && PasswrodBOX.Password != "" && GenderBox.SelectedIndex != null && NameBox.Text != "" && SecondNameBox.Text != "" && PatronymicBox.Text != "" && PhoneBox.Text != "" && SeriaBox.Text != "" && NomerBox.Text != "" && StoreBox.SelectedIndex != null)
            {
                Logins loginsUsers = ClassBase.BASE.Logins.FirstOrDefault(z => z.Login == LoginBOX.Text);
               
                if (loginsUsers != null)
                {
                    MessageBox.Show("Данный логин занят");
                }
                else 
                {
                    Regex r1 = new Regex("[A-Z]+");
                    Regex r2 = new Regex("[a-z]{3,}");
                    Regex r3 = new Regex("[0-9]{2,}");
                    Regex r4 = new Regex("\\W");
                    if (r1.IsMatch(PasswrodBOX.Password) == false)
                    {
                        MessageBox.Show("Пароль должен содержать одну заглавную латинскую букву!");
                    }
                    else if (r2.IsMatch(PasswrodBOX.Password) == false)
                    {
                        MessageBox.Show("Пароль должен содержать 3 прописные латинские буквы!");
                    }
                    else if (r3.IsMatch(PasswrodBOX.Password) == false)
                    {
                        MessageBox.Show("Пароль должен содержать 2 цифры!");
                    }
                    else if (r4.IsMatch(PasswrodBOX.Password) == false)
                    {
                        MessageBox.Show("Пароль должен содержать 1 спец символ!");
                    }
                    else
                    {
                        r1 = new Regex("[0-9]{11}");
                        if(r1.IsMatch(PhoneBox.Text) == false)
                        {
                            MessageBox.Show("Вводите в поле 'Телефон' только цифры без пробелов и спец символов");
                        }
                        else
                        {
                            r1 = new Regex("[0-9]{4}");
                            if (r1.IsMatch(SeriaBox.Text) == false)
                            {
                                MessageBox.Show("Введите 4 цифры в серии паспорта");
                            }
                            else
                            {
                                r1 = new Regex("[0-9]{6}");
                                if (r1.IsMatch(NomerBox.Text) == false)
                                {
                                    MessageBox.Show("Введите 6 цифр в номере паспорта");
                                }
                                else
                                {
                                    Employees emp = ClassBase.BASE.Employees.FirstOrDefault(z => z.First_Name == NameBox.Text && z.Second_Name == SecondNameBox.Text && z.Patronymic == PatronymicBox.Text);
                                    if (emp == null)
                                    {
                                        emp = new Employees()
                                        {
                                            First_Name = NameBox.Text,
                                            Second_Name = SecondNameBox.Text,
                                            Patronymic = PatronymicBox.Text,
                                            Gender = GenderBox.Text,
                                            PhoneE = PhoneBox.Text,
                                            Seria_Passport = SeriaBox.Text,
                                            Nomer_Passport = NomerBox.Text,
                                            Store = StoreBox.SelectedIndex + 1
                                        };
                                        ClassBase.BASE.Employees.Add(emp);
                                        loginsUsers = new Logins()
                                        {
                                            IDe = emp.IDEmp,
                                            Login = LoginBOX.Text,
                                            Password = PasswrodBOX.Password.GetHashCode(),
                                            IDRole = 1
                                        };
                                        ClassBase.BASE.Logins.Add(loginsUsers);
                                        ClassBase.BASE.SaveChanges();
                                        MessageBox.Show("Регистрация прошла успешно");
                                        NameBox.Text = "";
                                        SecondNameBox.Text = "";
                                        PatronymicBox.Text = "";
                                        GenderBox.SelectedIndex = -1;
                                        PhoneBox.Text = "";
                                        SeriaBox.Text = "";
                                        NomerBox.Text = "";
                                        StoreBox.SelectedIndex = -1;
                                        LoginBOX.Text = "";
                                        PasswrodBOX.Password = null;
                                        ClassFrame.Mfrm.GoBack();
                                    }
                                }
                            } 
                        }  
                    }
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            
        }

        private void BackREGBtn_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = "";
            SecondNameBox.Text = "";
            PatronymicBox.Text = "";
            GenderBox.SelectedIndex = -1;
            PhoneBox.Text = "";
            SeriaBox.Text = "";
            NomerBox.Text = "";
            StoreBox.SelectedIndex = -1;
            LoginBOX.Text = "";
            PasswrodBOX.Password = null;
            ClassFrame.Mfrm.GoBack();
        }
    }
}
