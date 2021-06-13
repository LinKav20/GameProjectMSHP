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
    /// Логика взаимодействия для lvl3.xaml
    /// </summary>
    public partial class lvl3 : Window
    {
        private MediaPlayer knopki = new MediaPlayer();
        private MediaPlayer main = new MediaPlayer();
        public lvl3()
        {
            InitializeComponent();
            knopki.Open(new Uri("knopka.mp3", UriKind.Relative));
            main.Open(new Uri("from_warcraft.mp3", UriKind.Relative));
            main.Play();

            System.Windows.Threading.DispatcherTimer music = new System.Windows.Threading.DispatcherTimer();

            music.Tick += new EventHandler(mus);
            music.Interval = new TimeSpan(0, 0, 1, 47, 0);
            music.Start();
        }

        private void mus(object sender, EventArgs e)
        {
            main.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void esc_nedoknopka_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.Stop();
            this.Close();
        }

        private void one_MouseDown(object sender, MouseButtonEventArgs e)
        {
            s.Visibility = Visibility.Visible;
            knopki.Play();
            knopki.Position = new TimeSpan(0, 0, 0, 0, 1);

        }

        private void three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            p.Visibility = Visibility.Visible;
            knopki.Play();
            knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            d.Visibility = Visibility.Visible;
            knopki.Play();
            knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void four_MouseDown(object sender, MouseButtonEventArgs e)
        {
            shkaf shkaf = new shkaf();
            shkaf.ShowDialog();
            if (shkaf.s == true)
            {
                key.Visibility = Visibility.Visible;
                knopki.Play();
                knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
            }
        }

        private void spr_nedoknopka_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sprav spr = new sprav();
            knopki.Play();
            knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
            spr.ShowDialog();
        }

        private void key_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Data.nameLVLs.IndexOf("Lvl3") == -1)
            {
                Data.countLVLs++;
                Data.nameLVLs += " Lvl3";
            }
            win_lvl v = new win_lvl();
            MainWindow.progress[3] = true;
            v.ShowDialog();
            main.Stop();
            this.Close();
        }
    }
}

