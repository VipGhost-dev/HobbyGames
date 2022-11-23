using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HobbyGames
{
    public partial class Orders
    {
        public SolidColorBrush Genrecolor
        {
            get
            {
                switch (Kolvo)
                {
                    case 1:
                        return Brushes.Aquamarine;
                    case 2:
                        return Brushes.Pink;
                    case 3:
                        return Brushes.Green;
                    case 4:
                        return Brushes.Blue;
                    case 5:
                        return Brushes.Magenta;
                    default:
                        return Brushes.White;
                }
            }
        }
        public string Coststr
        {
            get
            {
                return CostS + " ₽";
            }
        }
        public string FIO
        {
            get
            {
                return Employees.Second_Name + " " + Employees.First_Name + " " + Employees.Patronymic;
            }
        }
    }
}
