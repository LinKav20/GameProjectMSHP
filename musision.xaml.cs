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
using System.Windows.Threading;

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для musision.xaml
    /// </summary>
    public partial class musision : Window
    {
        DispatcherTimer time = new DispatcherTimer();
        private MediaPlayer ff1 = new MediaPlayer();
        private MediaPlayer ff2 = new MediaPlayer();
        private MediaPlayer ff3 = new MediaPlayer();
        private MediaPlayer ff4 = new MediaPlayer();
        private MediaPlayer ff5 = new MediaPlayer();
        private MediaPlayer ff6 = new MediaPlayer();
        private MediaPlayer ff7 = new MediaPlayer();
        private MediaPlayer ff8 = new MediaPlayer();

        public int f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0;

        private void p6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Open(new Uri("Песня Blur - Song 2 [ backingtrackx.com ].mp3", UriKind.Relative));
            ff6.Volume = 0.5;
            ff6.Play();
            DispatcherTimer time6 = new DispatcherTimer();
            time6.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time6.IsEnabled = true;
            time6.Tick += stop6;
        }

        private void p7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Open(new Uri("Happy.mp3", UriKind.Relative));
            ff7.Volume = 0.5;
            ff7.Play();
            DispatcherTimer time7 = new DispatcherTimer();
            time7.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time7.IsEnabled = true;
            time7.Tick += stop7;
        }

        private void p8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Open(new Uri("Come Together.mp3", UriKind.Relative));
            ff8.Volume = 0.5;
            ff8.Play();
            DispatcherTimer time8 = new DispatcherTimer();
            time8.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time8.IsEnabled = true;
            time8.Tick += stop8;
        }

        private void p5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff5.Open(new Uri("Queen Bohemian Rhapsody.mp3", UriKind.Relative));
            ff5.Volume = 0.5;
            ff5.Play();
            DispatcherTimer time5 = new DispatcherTimer();
            time5.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time5.IsEnabled = true;
            time5.Tick += stop5;
        }

        private void p4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Open(new Uri("Nirvana Come As You Are.mp3", UriKind.Relative));
            ff4.Volume = 0.5;
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff4.Play();
            DispatcherTimer time4 = new DispatcherTimer();
            time4.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time4.IsEnabled = true;
            time4.Tick += stop4;
        }

        private void p3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Open(new Uri("eminem-feat.-rihanna-the-monster.mp3", UriKind.Relative));
            ff3.Volume = 0.5;
            ff3.Play();
            DispatcherTimer time3 = new DispatcherTimer();
            time3.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time3.IsEnabled = true;
            time3.Tick += stop3;
        }

        private void p2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Open(new Uri("Rammstein Du Hast.mp3", UriKind.Relative));
            ff2.Volume = 0.5;
            ff2.Play();
            DispatcherTimer time2 = new DispatcherTimer();
            time2.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time2.IsEnabled = true;
            time2.Tick += stop2;
        }

        private void p1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 5, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff1.Open(new Uri("Marilyn Manson Sweet Dreams.mp3", UriKind.Relative));
            ff1.Volume = 0.5;
            ff1.Play();
            DispatcherTimer time1 = new DispatcherTimer();
            time1.Interval = new TimeSpan(0, 0, 0, 30, 0);
            time1.IsEnabled = true;
            time1.Tick += stop1;
        }

        public musision()
        {
            InitializeComponent();
            time.Interval = new TimeSpan(0, 0, 0, 0, 1);
            time.IsEnabled = true;
            time.Tick += checker;
            win.Visibility = Visibility.Hidden;
        }
        void checker(object sender, EventArgs e)
        {
            if (f_first.Text == "Sweet Dreams" && f1 == 0)
            {
                f1 = 1;
                f_first.IsEnabled = false;
            }
            if (f_two.Text == "Du Hast" && f2 == 0)
            {
                f2 = 1;
                f_two.IsEnabled = false;
            }
            if (f_three.Text == "Monster" && f3 == 0)
            {
                f3 = 1;
                f_three.IsEnabled = false;
            }
            if (f_four.Text == "Come As You Were" && f4 == 0)
            {
                f4 = 1;
                f_four.IsEnabled = false;
            }
            if (f_five.Text == "Bohemian Rhapsody" && f5 == 0)
            {
                f5 = 1;
                f_five.IsEnabled = false;
            }
            if (f_six.Text == "Song 2" && f6 == 0)
            {
                f6 = 1;
                f_six.IsEnabled = false;
            }
            if (f_seven.Text == "Happy" && f7 == 0)
            {
                f7 = 1;
                f_seven.IsEnabled = false;
            }
            if (f_eight.Text == "Come Together" && f8 == 0)
            {
                f8 = 1;
                f_eight.IsEnabled = false;
            }
            if (f1 + f2 + f3 + f4 + f5 + f6 + f7 + f8 == 8) win.Visibility = Visibility.Visible;
        }
        void stop1(object sender, EventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void win_Click(object sender, RoutedEventArgs e)
        {
            if (Data.nameLVLs.IndexOf("LvlMusic") == -1)
            {
                Data.countLVLs++;
                Data.nameLVLs += " LvlMusic";
            }
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            MainWindow.progress[6] = true;
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            ff1.Pause();
            ff1.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
            this.Close();
        }

        void stop2(object sender, EventArgs e)
        {
            ff2.Pause();
            ff2.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop3(object sender, EventArgs e)
        {
            ff3.Pause();
            ff3.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop4(object sender, EventArgs e)
        {
            ff4.Pause();
            ff4.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop5(object sender, EventArgs e)
        {
            ff5.Pause();
            ff5.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop6(object sender, EventArgs e)
        {
            ff6.Pause();
            ff6.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop7(object sender, EventArgs e)
        {
            ff7.Pause();
            ff7.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void stop8(object sender, EventArgs e)
        {
            ff8.Pause();
            ff8.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
    }
}
