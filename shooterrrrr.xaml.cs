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
using System.Windows.Media.Animation;

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для shooterrrrr.xaml
    /// </summary>
    public partial class shooterrrrr : Window
    {
        List<Ellipse> els = new List<Ellipse>();
        List<TextBlock> prs = new List<TextBlock>();
        List<Image> oblachka = new List<Image>();
        double x, y;
        bool movin = true;
        int els_count = 0, prs_count = 0, count = 0, lives = 3;
        Random Rand = new Random();
        private MediaPlayer player = new MediaPlayer();
        private MediaPlayer hooray = new MediaPlayer();
        private MediaPlayer s1 = new MediaPlayer();
        private MediaPlayer s2 = new MediaPlayer();
        public shooterrrrr()
        {
            InitializeComponent();
            y = Canvas.GetTop(gun);
            System.Windows.Threading.DispatcherTimer piu = new System.Windows.Threading.DispatcherTimer(); //eliipses creation
            piu.Tick += new EventHandler(shoot_cr);
            piu.Interval = new TimeSpan(0, 0, 0, 0, 500);
            piu.Start();

            System.Windows.Threading.DispatcherTimer ch = new System.Windows.Threading.DispatcherTimer(); // ellipses up
            ch.Tick += new EventHandler(shoot_do);
            ch.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ch.Start();

            System.Windows.Threading.DispatcherTimer cheeeck = new System.Windows.Threading.DispatcherTimer(); //tbs down
            cheeeck.Tick += new EventHandler(tbs_down);
            cheeeck.Interval = new TimeSpan(0, 0, 0, 0, 1);
            cheeeck.Start();


            System.Windows.Threading.DispatcherTimer create = new System.Windows.Threading.DispatcherTimer(); //tbs creat
            create.Tick += new EventHandler(preps_cr);
            create.Interval = new TimeSpan(0, 0, 0, 2, 0);
            create.Start();


            System.Windows.Threading.DispatcherTimer clouds = new System.Windows.Threading.DispatcherTimer(); //yay
            clouds.Tick += new EventHandler(clouds_move);
            clouds.Interval = new TimeSpan(0, 0, 0, 0, 1);
            clouds.Start();


            System.Windows.Threading.DispatcherTimer clouds2 = new System.Windows.Threading.DispatcherTimer(); //yay
            clouds2.Tick += new EventHandler(clouds_create);
            clouds2.Interval = new TimeSpan(0, 0, 0, 4, 0);
            clouds2.Start();

            System.Windows.Threading.DispatcherTimer music = new System.Windows.Threading.DispatcherTimer(); //yay
            music.Tick += new EventHandler(mus);
            music.Interval = new TimeSpan(0, 0, 2, 28, 0);
            music.Start();

            els.Add(eeeeel);
            prs.Add(prep);
            oblachka.Add(obla4ko);

            player.Open(new Uri("shooter_soundtrack.mp3", UriKind.Relative));
            player.Play();

            s1.Open(new Uri("shooter_s_victory.mp3", UriKind.Relative));
            s1.Volume = 0.5;
            s2.Open(new Uri("shooter_s_lose.mp3", UriKind.Relative));

        }
        private void mus(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        private void clouds_create(object sender, EventArgs e)
        {
            Image cl = new Image();
            cl.Source = obla4ko.Source;
            cl.Width = obla4ko.Width;
            cl.Height = obla4ko.Height;
            oblachka.Add(cl);
            oblachniy_cnvs.Children.Add(oblachka[oblachka.Count - 1]);
            Canvas.SetLeft(oblachka[oblachka.Count - 1], -70);
            Canvas.SetTop(oblachka[oblachka.Count - 1], Rand.Next(0, 130) + 1);

        }
        private void move_obl(Image Hero)
        {
            DoubleAnimation ANIMA = new DoubleAnimation();
            ANIMA.From = Canvas.GetLeft(Hero);
            ANIMA.To = Canvas.GetLeft(Hero) + 50;
            ANIMA.Duration = TimeSpan.FromSeconds(1.75);
            ANIMA.AutoReverse = true;
            //  ANIMA.RepeatBehavior = RepeatBehavior.Forever;
            PowerEase XBATITi = new PowerEase();
            XBATITi.Power = 2;
            XBATITi.EasingMode = EasingMode.EaseInOut;
            Hero.BeginAnimation(Canvas.LeftProperty, ANIMA);
        }
        private void clouds_move(object sender, EventArgs e)
        {
            foreach (Image o in oblachka) move_obl(o);
        }
        bool checker(Ellipse el)
        {
            double xx1 = Canvas.GetLeft(el), xx2 = Canvas.GetLeft(el) + el.Width,
                   yy1 = Canvas.GetTop(el);
            for (int k = 0; k <= prs_count;)
            {
                double x1 = Canvas.GetLeft(prs[k]), x2 = Canvas.GetLeft(prs[k]) + prs[k].Width,
                    y1 = Canvas.GetTop(prs[k]);

                if (yy1 - y1 >= 0 && yy1 - y1 <= prs[k].Height && xx1 >= x1 && xx2 <= x2)
                {
                    int n = Convert.ToInt32(prs[k].Text);
                    n--;
                    count++;
                    count_tbl.Text = count.ToString();
                    s1.Play();
                    s1.Position = new TimeSpan(0, 0, 0, 0, 1);
                    if (count >= 10)
                    {
                        movin = false;
                        result_tb.Text = "You Won :)";
                        result_btn.Content = "HOORAY!";

                        pause.Visibility = Visibility.Hidden;
                        player.Stop();
                        //  hooray.Play();
                        result_tb.Visibility = Visibility.Visible;
                        result_btn.Visibility = Visibility.Visible;
                    }
                    if (n == 0)
                    {
                        norm_cnvs.Children.Remove(prs[k]);
                        prs.RemoveAt(k);
                        prs_count--;
                    }
                    else
                    {
                        prs[k].Text = n.ToString();
                    }
                    return false;
                }
                else
                {
                    k++;
                }
            }
            return true;
        }
        private void preps_cr(object sender, EventArgs e)
        {
            if (movin)
            {
                double x1 = Rand.Next(0, 390), y1 = 0;
                int num = Rand.Next(0, 5) + 1;
                double s = Rand.Next(0, 90);
                prs_count++;
                TextBlock newHero = new TextBlock();
                newHero.Height = (num >= 3 ? 40 : 30);
                newHero.Width = (num >= 3 ? 40 : 30);
                newHero.Text = num.ToString();
                if (num == 1) newHero.FontSize = 20;
                else newHero.FontSize = 24;
                newHero.Foreground = prep.Foreground;
                newHero.Background = prep.Background;
                newHero.FontWeight = FontWeights.Bold;
                newHero.TextAlignment = TextAlignment.Center;
                newHero.OpacityMask = prep.OpacityMask;
                newHero.LineHeight = prep.LineHeight;
                prs.Add(newHero);
                Canvas.SetLeft(newHero, x1);
                Canvas.SetTop(newHero, y1);
                norm_cnvs.Children.Add(newHero);
            }
        }
        private void tbs_down(object sender, EventArgs e)
        {
            if (movin)
            {
                double xx1 = Canvas.GetLeft(gun) + 9, xx2 = Canvas.GetLeft(gun) + gun.Width - 9,
                 yy1 = Canvas.GetTop(gun) + 9;
                for (int k = 0; k <= prs_count;)
                {
                    double x1 = Canvas.GetLeft(prs[k]), x2 = Canvas.GetLeft(prs[k]) + prs[k].Width,
                   y1 = Canvas.GetTop(prs[k]);
                    if (Canvas.GetTop(prs[k]) > 420 || (yy1 - y1 >= 0 && yy1 - y1 <= prs[k].Height && xx1 <= x1 && xx2 >= x2))
                    {
                        lives--;
                        s2.Play();
                        s2.Position = new TimeSpan(0, 0, 0, 0, 1);
                        if (lives == 2) herz1.Visibility = Visibility.Hidden;
                        else if (lives == 1) herz2.Visibility = Visibility.Hidden;
                        else if (lives == 0) herz3.Visibility = Visibility.Hidden;
                        else if (lives == -1)
                        {
                            gun.Visibility = Visibility.Hidden;
                            movin = false;
                            result_tb.Text = "You Lost :(";
                            result_btn.Content = "OKAY";
                            result_tb.Visibility = Visibility.Visible;
                            result_btn.Visibility = Visibility.Visible;
                            pause.Visibility = Visibility.Hidden;
                        }
                        norm_cnvs.Children.Remove(prs[k]);
                        prs.RemoveAt(k);
                        prs_count--;
                    }
                    else
                    {
                        Canvas.SetTop(prs[k], Canvas.GetTop(prs[k]) + 2);
                        k++;
                    }



                }
            }

        }
        private void result_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Data.nameLVLs.IndexOf("LvlShooter") == -1)
            {
                Data.countLVLs++;
                Data.nameLVLs += " LvlShooter";
            }
            player.Stop();
            hooray.Stop();
            MainWindow.progress[4] = true;
            this.Close();
        }
        private void exittttt_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            hooray.Stop();
            this.Close();
        }
        private void shoot_do(object sender, EventArgs e)
        {
            if (movin)
            {
                for (int j = 0; j <= els_count;)
                {

                    if (Canvas.GetTop(els[j]) < 0 || checker(els[j]) == false)
                    {
                        norm_cnvs.Children.Remove(els[j]);
                        els.RemoveAt(j);
                        els_count--;
                    }
                    else
                    {
                        Canvas.SetTop(els[j], Canvas.GetTop(els[j]) - 3);
                        j++;
                    }
                }
            }
        }
        private void shoot_cr(object sender, EventArgs e)
        {
            if (movin)
            {
                double x1 = slider.Value, y1 = Canvas.GetTop(gun);
                els_count++;
                Ellipse newHero = new Ellipse();
                newHero.Height = eeeeel.Height;
                newHero.Width = eeeeel.Width;
                newHero.Fill = eeeeel.Fill;
                newHero.Stroke = eeeeel.Stroke;
                els.Add(newHero);
                Canvas.SetLeft(newHero, x1);
                Canvas.SetTop(newHero, y1);
                norm_cnvs.Children.Add(newHero);
            }
        }
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            movin = !movin;
            if (movin == true) pause.Content = "pause";
            else pause.Content = "play";
        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            x = slider.Value - 37.5;
            Canvas.SetLeft(gun, x);
        }
    }
}
