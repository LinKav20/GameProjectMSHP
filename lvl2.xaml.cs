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
    /// Логика взаимодействия для lvl2.xaml
    /// </summary>
    public partial class lvl2 : Window
    {
        private MediaPlayer knopki = new MediaPlayer();
        // List<Rectangle> snake = new List<Rectangle>();     
        private MediaPlayer player = new MediaPlayer();

        // public int lengthSnake; 
        //  public bool existsFood;
        double x, y;
        bool movement = true;

        public Random rnd = new Random();
        ScaleTransform s = new ScaleTransform();
        SkewTransform sk = new SkewTransform();
        TransformGroup mtg = new TransformGroup();
        RotateTransform rt = new RotateTransform();
        public int addX, addY; // смещение координат

        public lvl2()
        {
            InitializeComponent();
            // course = Course.LEFT; // начальное направление
            // добавляем в змейку три начальных сегмента
            x = Canvas.GetLeft(head);
            y = Canvas.GetTop(head);

            System.Windows.Threading.DispatcherTimer timerMove = new System.Windows.Threading.DispatcherTimer();
            timerMove.Tick += new EventHandler(move);
            timerMove.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerMove.Start();

            System.Windows.Threading.DispatcherTimer timerch = new System.Windows.Threading.DispatcherTimer();
            timerch.Tick += new EventHandler(ch);
            timerch.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ctr_tbl.Text = count.ToString();
            timerch.Start();

            System.Windows.Threading.DispatcherTimer music = new System.Windows.Threading.DispatcherTimer();
            music.Tick += new EventHandler(mus);
            music.Interval = new TimeSpan(0, 0, 1, 4, 0);
            music.Start();

            player.Open(new Uri("svinpauk.mp3", UriKind.Relative));
            player.Play();

            knopki.Open(new Uri("knopka.mp3", UriKind.Relative));
            s.ScaleY = 1;
            s.ScaleX = 1;
            sk.AngleX = 0;
            sk.AngleY = 0;
            rt.Angle = 0;

            mtg.Children.Add(sk);
            mtg.Children.Add(rt);
            mtg.Children.Add(s);
            head.RenderTransform = mtg;
        }
        bool napr = true;
        private void mus(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void ch(object sender, EventArgs e)
        {
            if (((x <= 14 && x >= 0) || (x + 140 >= 770 && x + 140 <= 790)) && ((y <= 308) && (y >= 135)))
            {
                napr = !napr;
                if (napr) s.ScaleX = 1;
                else s.ScaleX = -1;
                // mtg.Children.Add(s); 
                head.RenderTransform = mtg;

                count++;
                ctr_tbl.Text = count.ToString();
                if (count == 10)
                {
                    movement = false;
                    if (Data.nameLVLs.IndexOf("Lvl2") == -1)
                    {
                        Data.countLVLs++;
                        Data.nameLVLs += " Lvl2";
                    }
                    win_lvl wl = new win_lvl();
                    MainWindow.progress[1] = true;
                    player.Stop();
                    wl.ShowDialog();

                    this.Close();
                }
            }
            else if (((x <= 14 && x >= 0) || (x >= 770 && x <= 790)) && ((y >= 308) && (y <= 135)) || y > 780)
            {
                movement = false;
                ctr_tbl.Visibility = Visibility.Hidden;
                lose.Visibility = Visibility.Visible;
                lose_ok.Visibility = Visibility.Visible;


            }


        }
        int count = 0;

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            this.Close();
        }

        private void lose_ok_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            this.Close();
        }


        // 1  or 2
        // по умолчанию напр = 4
        // bool f = true;
        private void move(object sender, EventArgs e)
        {
            if (movement)
            {

                if (Keyboard.IsKeyDown(Key.Space))
                {
                    knopki.Play();
                    knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
                    y -= 10;
                    Canvas.SetTop(head, y);

                }
                if (napr == true)
                {
                    y += 5;
                    x += 3;

                    Canvas.SetTop(head, y);
                    Canvas.SetLeft(head, x);
                }
                else
                {
                    y += 5;
                    x -= 3;

                    Canvas.SetTop(head, y);
                    Canvas.SetLeft(head, x);
                }
            }




        }



    }
}
