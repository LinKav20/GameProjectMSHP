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
using System.Windows.Threading;

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowGB : Window
    {
        DispatcherTimer time = new DispatcherTimer();
         DispatcherTimer time1 = new DispatcherTimer();
        DispatcherTimer CnZn = new DispatcherTimer();
        DispatcherTimer portal = new DispatcherTimer();
        public int x, y, stop = 0, ControlZn=200, temp_ControlZn=200, is_key=0,on=0,is_button=0;
        bb bob = new bb();

        private void pauza_Click(object sender, RoutedEventArgs e)
        {
            mmm.Visibility = Visibility.Visible;
            mmuse.Visibility = Visibility.Visible;
            fon_p.Visibility = Visibility.Visible;
            restart.Visibility = Visibility.Visible;
            con.Visibility = Visibility.Visible;
            exit.Visibility = Visibility.Visible;
        }

        private void con_Click(object sender, RoutedEventArgs e)
        {
            mmm.Visibility = Visibility.Hidden;
            mmuse.Visibility = Visibility.Hidden;
            fon_p.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            con.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            open_.Visibility = Visibility.Hidden;
            x = 0;
            y = 200;
            first.Visibility = Visibility.Hidden;
            Canvas.SetLeft(bob, x);
            Canvas.SetTop(bob, y);
            stop = 0;
            ControlZn = 200;
            temp_ControlZn = 200;
            is_key = 0;
            key.Visibility = Visibility.Visible;
            on = 0;
            mmm.Visibility = Visibility.Hidden;
            mmuse.Visibility = Visibility.Hidden;
            fon_p.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            close.Visibility = Visibility.Visible;
            con.Visibility = Visibility.Hidden;
            key.Visibility = Visibility.Hidden;
            kr_knopka.Visibility = Visibility.Visible;
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            music.Stop();
            this.Close();
        }
        private void mmuse_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            music.Volume = mmuse.Value;
        }

        private MediaPlayer music = new MediaPlayer();

        public MainWindowGB()
        {
            
            InitializeComponent();

            music.Open(new Uri("hula_festival.mp3", UriKind.Relative));
            music.Volume = 0.5;
            music.Play();

            time1.Interval = new TimeSpan(0, 0, 2, 10, 0);
            time1.IsEnabled = true;
            time1.Tick += muz;

            time.Interval = new TimeSpan(0, 0, 0, 0, 1);
            time.IsEnabled = true;
            time.Tick += Clock;

            CnZn.Interval = new TimeSpan(0, 0, 0, 0, 1);
            CnZn.IsEnabled = true;
            CnZn.Tick += checkni;

            portal.Interval = new TimeSpan(0, 0, 0, 0, 100);
            portal.IsEnabled = true;
            portal.Tick += move;

            open_.Visibility = Visibility.Hidden;
            x = 0;
            y = 200;
            first.Visibility = Visibility.Hidden;
            bob.Height = 130;
            bob.Width = 130;
            Canvas.SetTop(bob, y);
            Canvas.SetLeft(bob, x);
            cnvs.Children.Add(bob);

            mmm.Visibility = Visibility.Hidden;
            mmuse.Visibility = Visibility.Hidden;
            fon_p.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            con.Visibility = Visibility.Hidden;
            key.Visibility = Visibility.Hidden;

            mmuse.Value = 0.5;
        }
        void muz(object sender, EventArgs e)
        {
            music.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void win_Click(object sender, RoutedEventArgs e)
        {
            if (Data.nameLVLs.IndexOf("LvlGubkaBob") == -1)
            {
                Data.countLVLs++;
                Data.nameLVLs += " LvlGubkaBob";
            }
            music.Stop();
            MainWindow.progress[2] = true;
            this.Close();
        }

        void Clock(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.D)&&x<430)
            {
                x += 2;
               if (x > 42 && y ==200&&x<155) x -= 2;
               // if (x>150) temp_ControlZn = 200;
                
            }
            if (Keyboard.IsKeyDown(Key.A)&&x>-15)
            {
                x -= 2;
                if (x > 42 && y == 200 && x < 155) x += 2;
                // if (x <46 )  temp_ControlZn = 200;

            }
            if (Keyboard.IsKeyDown(Key.W) && y > 0 && stop == 0)
            {
                y -= 40;
                stop = 40;
              /*  if (x > 46 && y < 170&&x<150) temp_ControlZn = 170;
                if (x > 150 && y < 140 && x < 180) temp_ControlZn = 140;*/
            }
            else if (stop != 0) stop--;
            if (y != temp_ControlZn)
            {
               
                y++;
                Canvas.SetTop(bob, y);
              /*  if (x > 46 && y < 170 && x < 150) temp_ControlZn = 170;*/
            }
            Canvas.SetLeft(bob, x);
            Canvas.SetTop(bob, y);
        }

        void checkni(object sender, EventArgs e)
        {
            if (x >= 46 && x <= 150 && y > 100 && y < 190) temp_ControlZn = 170;
            else if (x >= 150 && x <= 200 && y > 100 && y < 190) temp_ControlZn = 140;
            else if (x >= 210 && x <= 260 && y > 100 && y < 190) temp_ControlZn = 110;
            else if (x >= 260 && x <= 285 && y > 30 && y < 190) temp_ControlZn =80;
            else if (x >= 285 && x <= 310 && y > 30 && y < 190) temp_ControlZn = 50;
            else if (x >= 160 && x <= 260 && y > 30 && y < 190) temp_ControlZn = 50;
            else if (x >= 320 && x <= 420 && y > 0 && y < 190) temp_ControlZn = 20;
            else if (x >= 80 && x <= 180 && y > 0 && y < 190) temp_ControlZn = 20;
            else if (x >= -10 && x <= 80 && y > -20 && y < 190) temp_ControlZn = -10;
            else temp_ControlZn = 200;
            if (is_key == 1 && x > 420 && temp_ControlZn == 200)
            {
                win.Visibility = Visibility.Visible;
                fon_p.Visibility = Visibility.Visible;
                flow1.Visibility = Visibility.Visible;
                flow2.Visibility = Visibility.Visible;
            }
            if (y < 100 && x >= -10 && x < 20&& is_key==0)
            {
                key.Visibility = Visibility.Hidden;
                close.Visibility = Visibility.Hidden;
                open_.Visibility = Visibility.Visible;
                is_key = 1;
                MediaPlayer zv = new MediaPlayer();
                zv.Open(new Uri("pick_up_key.mp3", UriKind.Relative));
                zv.Position = new TimeSpan(0, 0, 0, 1, 0);
                zv.Volume = 1;
                zv.Play();
            }
            if (y < 50 && x >= 360 && x <380&& is_button == 0)
            {
                kr_knopka.Visibility = Visibility.Hidden;
                is_button = 1;
                key.Visibility = Visibility.Visible;
                MediaPlayer zv1 = new MediaPlayer();
                zv1.Open(new Uri("pick_up_key.mp3", UriKind.Relative));
                zv1.Position = new TimeSpan(0, 0, 0, 1, 0);
                zv1.Volume = 1;
                zv1.Play();
            }
        }
        void move(object sender, EventArgs e)
        {
            if (on == 0)
            {
                first.Visibility = Visibility.Visible;
                sec.Visibility = Visibility.Hidden;
                on = 1;
            }
            else{
                sec.Visibility = Visibility.Visible;
                first.Visibility = Visibility.Hidden;
                on = 0;
            }
            
        }
    }
}
