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

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для custom_window.xaml
    /// </summary>
    public partial class custom_window : Window
    {
        public custom_window()
        {
            InitializeComponent();
        }
       
        public class dataa
        {
            public static string src;
            public static string nm = "Morty";
            public static bool vis = false;
            public static bool state = false;
            
        }

        private void uno_Click(object sender, RoutedEventArgs e)
        {
            norm_m.Visibility = Visibility.Visible;
            one_discr.Visibility = Visibility.Visible;
            dataa.src = norm_m.Source.ToString();
            ok.Visibility = Visibility.Visible;
            pink_m.Visibility = Visibility.Hidden;
            duo_discr.Visibility = Visibility.Hidden;
            tired_m.Visibility = Visibility.Hidden;
            tre_discr.Visibility = Visibility.Hidden;
            anime_m.Visibility = Visibility.Hidden;
            four_discr.Visibility = Visibility.Hidden;
            curly_m.Visibility = Visibility.Hidden;
            five_discr.Visibility = Visibility.Hidden;
        }

        private void duo_Click(object sender, RoutedEventArgs e)
        {
            norm_m.Visibility = Visibility.Hidden;
            one_discr.Visibility = Visibility.Hidden;
            dataa.src = pink_m.Source.ToString();
            pink_m.Visibility = Visibility.Visible;
            duo_discr.Visibility = Visibility.Visible;
            tired_m.Visibility = Visibility.Hidden;
            tre_discr.Visibility = Visibility.Hidden;
            anime_m.Visibility = Visibility.Hidden;
            four_discr.Visibility = Visibility.Hidden;
            curly_m.Visibility = Visibility.Hidden;
            five_discr.Visibility = Visibility.Hidden;
            ok.Visibility = Visibility.Visible;
        }

        private void tre_Click(object sender, RoutedEventArgs e)
        {
            norm_m.Visibility = Visibility.Hidden;
            one_discr.Visibility = Visibility.Hidden;
            dataa.src = tired_m.Source.ToString();
            tired_m.Visibility = Visibility.Visible;
            tre_discr.Visibility = Visibility.Visible;
            pink_m.Visibility = Visibility.Hidden;
            duo_discr.Visibility = Visibility.Hidden;
            anime_m.Visibility = Visibility.Hidden;
            four_discr.Visibility = Visibility.Hidden;
            curly_m.Visibility = Visibility.Hidden;
            five_discr.Visibility = Visibility.Hidden;
            ok.Visibility = Visibility.Visible;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            norm_m.Visibility = Visibility.Hidden;
            one_discr.Visibility = Visibility.Hidden;
            dataa.src = anime_m.Source.ToString();
            anime_m.Visibility = Visibility.Visible;
            four_discr.Visibility = Visibility.Visible;
            pink_m.Visibility = Visibility.Hidden;
            duo_discr.Visibility = Visibility.Hidden;
            tired_m.Visibility = Visibility.Hidden;
            tre_discr.Visibility = Visibility.Hidden;
            curly_m.Visibility = Visibility.Hidden;
            ok.Visibility = Visibility.Visible;
            five_discr.Visibility = Visibility.Hidden;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            norm_m.Visibility = Visibility.Hidden;
            one_discr.Visibility = Visibility.Hidden;
            dataa.src = curly_m.Source.ToString();
            anime_m.Visibility = Visibility.Hidden;
            four_discr.Visibility = Visibility.Hidden;
            pink_m.Visibility = Visibility.Hidden;
            duo_discr.Visibility = Visibility.Hidden;
            tired_m.Visibility = Visibility.Hidden;
            tre_discr.Visibility = Visibility.Hidden;
            curly_m.Visibility = Visibility.Visible;
            ok.Visibility = Visibility.Visible;
            five_discr.Visibility = Visibility.Visible;
        }

        private void name_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dataa.nm = name_tb.Text;
        }

        private void visibility_chekbox_Checked(object sender, RoutedEventArgs e)
        {
            dataa.vis = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataa.state = true;
            this.Close();
        }
    }
}
