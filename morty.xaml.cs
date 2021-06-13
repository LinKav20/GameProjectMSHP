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
    /// Логика взаимодействия для morty.xaml
    /// </summary>
    public partial class morty : UserControl
    {
        public morty()
        {
            InitializeComponent();
        }
        public String Name {
            get
            {
                return name_tblck.Text;
            }
            set
            {
                name_tblck.Text = value;
            }
        }

        public string img
        {
            get
            {
                return morty_img.Source.ToString();
            }
            set
            {
                morty_img.Source = new BitmapImage(new Uri(value));
            }
        }


    }
}
