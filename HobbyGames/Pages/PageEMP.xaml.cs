using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для PageEMP.xaml
    /// </summary>
    public partial class PageEMP : Page
    {
        public PageEMP()
        {
            InitializeComponent();

            Employees employees = ClassBase.BASE.Employees.FirstOrDefault(z => z.IDEmp == Start.idemp);
            FIO.Text = employees.Second_Name + " " + employees.First_Name + " " + employees.Patronymic;
            Gender.Text = "Пол: " + employees.Gender;
            Phone.Text = employees.PhoneE;
            Pasport.Text = employees.Seria_Passport + " " + employees.Nomer_Passport;
            Contacts contacts = ClassBase.BASE.Contacts.FirstOrDefault(z => z.IdStore == employees.Store);
            StoreBox.Text = contacts.Adress;
            if(employees.Photo != null)
            {
                byte[] Barr = employees.Photo;  // считываем изображение из базы (считываем байтовый массив двоичных данных)
                BitmapImage Bim = new BitmapImage();  // создаем объект для загрузки изображения
                using (MemoryStream MS = new MemoryStream(Barr))  // для считывания байтового потока
                {
                    Bim.BeginInit();  // начинаем считывание
                    Bim.StreamSource = MS;  // задаем источник потока
                    Bim.CacheOption = BitmapCacheOption.OnLoad;  // переводим изображение
                    Bim.EndInit();  // заканчиваем считывание
                }
                Photo.Source = Bim;  // показываем картинку на экране (UserPhotoImage – имя картиник в разметке)
                Photo.Stretch = Stretch.Uniform;
            }
        }

        byte[] Barray;

        private void btn_changeLogin_Click(object sender, RoutedEventArgs e)
        {
            ChangeLoginAndPassword clap = new ChangeLoginAndPassword();
            clap.Show();
        }

        private void btn_changePersonal_Click(object sender, RoutedEventArgs e)
        {
            ChangePersonalData cpd = new ChangePersonalData();
            cpd.Show();
        }

        private void Photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try {
                Employees employees = ClassBase.BASE.Employees.FirstOrDefault(z => z.IDEmp == Start.idemp);
                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                OFD.ShowDialog();  // открываем диалоговое окно
                string Path = OFD.FileName;  // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(Path);  // создаем объект для загрузки изображения в базу
                ImageConverter ISC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                Barray = (byte[])ISC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                employees.Photo = Barray;
                Photo.Source = BitmapFrame.Create(new Uri(Path));
                ClassBase.BASE.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Добавление картинки", "Ошибка при добавление");
            }
            
        }
    }
}
