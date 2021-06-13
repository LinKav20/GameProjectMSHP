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

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для fruit.xaml
    /// </summary>
    public partial class fruit : UserControl
    {
        public fruit()
        {
            InitializeComponent();
        }
        public bool alive = true;
        
        public string HeroPhoto{
            get
            {
                return photo.Source.ToString();
            }
            internal set
            {
                photo.Source = new BitmapImage(new Uri(value));
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            alive = false;
        }
    }
}
