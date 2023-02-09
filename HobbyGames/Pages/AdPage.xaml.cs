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
using System.Windows.Media.Animation;

namespace HobbyGames.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdPage.xaml
    /// </summary>
    public partial class AdPage : Page
    {
        public AdPage()
        {
            InitializeComponent();
            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = 210; // начальное значение свойства
            WA.To = 310; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            GoToLoginPage.BeginAnimation(WidthProperty, WA); // «навешивание» анимации на свойство ширины кнопки
            DoubleAnimation HA = new DoubleAnimation();
            HA.From = 45;
            HA.To = 145;
            HA.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            HA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            HA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            GoToLoginPage.BeginAnimation(HeightProperty, HA); // «навешивание» анимации на свойство ширины кнопки
            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ
            MA.From = new Thickness(200,100, 200, 100);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.AutoReverse = true;
            GoToLoginPage.BeginAnimation(MarginProperty, MA);
            ColorAnimation BA = new ColorAnimation();
            Color Cstart = Color.FromRgb(255, 255, 255); // присваивание начального цвета эл-ту
            GoToLoginPage.Background = new SolidColorBrush(Cstart);
            BA.From = Cstart;
            BA.To = Color.FromRgb(125, 255, 20);
            BA.Duration = TimeSpan.FromSeconds(5);
            BA.RepeatBehavior = RepeatBehavior.Forever;
            BA.AutoReverse = true;
            GoToLoginPage.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

            DoubleAnimation FSA = new DoubleAnimation();
            FSA.From = 20;
            FSA.To = 28;
            FSA.Duration = TimeSpan.FromSeconds(2);
            FSA.RepeatBehavior = RepeatBehavior.Forever;
            FSA.AutoReverse = true;
            LogoLabelAd.BeginAnimation(FontSizeProperty, FSA);

            DoubleAnimation WI = new DoubleAnimation(); // создание объекта для настройки анимации
            WI.From = 200; // начальное значение свойства
            WI.To = 400; // конечное значение свойства
            WI.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            WI.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WI.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            LogoImageAD.BeginAnimation(WidthProperty, WI); // «навешивание» анимации на свойство ширины кнопки
            DoubleAnimation HI = new DoubleAnimation();
            HI.From = 200;
            HI.To = 400;
            HI.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            HI.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            HI.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            LogoImageAD.BeginAnimation(HeightProperty, HI); // «навешивание» анимации на свойство ширины кнопки
        }

        private void GoToLoginPage_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mfrm.Navigate(new Start());
        }
    }
}
