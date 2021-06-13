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
    /// Логика взаимодействия для HeroInterface.xaml
    /// </summary>
    public partial class HeroInterface : UserControl
    {
        Random random = new Random();

    
        public HeroInterface()
        {
            InitializeComponent();
        }

        public string HeroName
        {
            get
            {
                return name.Text;
            }
            set
            {
                name.Text = value;
            }
        }
       
        public int HeroHP
        {
            get
            {
                return Convert.ToInt32(hp.Value);
            }
            set
            {
                if (value > 100)
                {
                    hp.Value = 100;
                }
                else if (value < 0)
                {
                    hp.Value = 0;
                }
                else 
                {
                    hp.Value = value;
                }
            }
        }

        bool Alive = true;
        public string HeroPhoto
        {
            get
            {
                return photo.Source.ToString();
            }
            set
            {
                int z = random.Next(0, 4);
                if (z == 1)
                {
                    photo.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("pear.png")));
                }
                else if (z == 2)
                {
                    photo.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("pineapple.png")));
                }
                else
                {
                    photo.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("watremelon.png")));
                }
               
            }
        }

        public int HeroPower
        {
            get
            {
                return Convert.ToInt32(power.Text);
            }
            set
            {
                power.Text = value.ToString();
            }
        }
        void remove()
        {
            Height = 0;
            Width = 0;
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int z = Convert.ToInt32(power.Text);
            hp.Value -= random.Next(0, 40);
            if (hp.Value < 1)
            {
                Alive = false;
                remove();
            }
        }
    }
}