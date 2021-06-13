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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowSnakegame : Window
    {
        DispatcherTimer time;
        List<Snake> snakebody;
        List<Food> food;
        private MediaPlayer mus = new MediaPlayer();
        Random rd = new Random();
        double x = 100;
        double y = 100;
        int direction = 0;
        int left = 4;
        int right = 6;
        int up = 8;
        int down = 2;
        int score = 0;
        int count = 0;
        public MainWindowSnakegame()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            snakebody = new List<Snake>();
            food = new List<Food>();
            snakebody.Add(new Snake(x, y));
            food.Add(new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10));
            time.Interval = new TimeSpan(0, 0, 0, 0, 150);   /*you can change speed of the snake here */
            time.Tick += time_Tick;
            mus.Open(new Uri("Led Zeppelin - Immigrant Song.mp3", UriKind.Relative));
            mus.Play();
            System.Windows.Threading.DispatcherTimer music = new System.Windows.Threading.DispatcherTimer();

            music.Tick += new EventHandler(musi);
            music.Interval = new TimeSpan(0, 0, 2, 26, 0);
            music.Start();
        }
        void musi(object sender, EventArgs e)
        {
            mus.Position = new TimeSpan(0, 0, 0, 0, 1);
        }
        void addfoodincanvas()
        {
            food[0].setfoodposition();
            mycanvas.Children.Insert(0,food[0].ell);
        }


        void addsnakeincanvas()
        {
            foreach (Snake snake in snakebody)
            {
                snake.setsnakeposition();
                mycanvas.Children.Add(snake.rec);
            }
        }
        bool movin = true;

        void time_Tick(object sender, EventArgs e)
        {
            if (movin)
            {
                if (direction != 0)
                {
                    for (int i = snakebody.Count - 1; i > 0; i--)
                    {
                        snakebody[i] = snakebody[i - 1];
                    }
                }


                if (direction == up)
                    y -= 10;
                if (direction == down)
                    y += 10;
                if (direction == left)
                    x -= 10;
                if (direction == right)
                    x += 10;


            }
            if(snakebody[0].x== food[0].x && snakebody[0].y== food[0].y)
            {
                snakebody.Add(new Snake(food[0].x, food[0].y));
                food[0] = new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10);
                mycanvas.Children.RemoveAt(0);
                addfoodincanvas();
                score++;
                txtbScore.Text = score.ToString();
                if ( score > 10)
                {
                    if (Data.nameLVLs.IndexOf("LvlSnake") == -1)
                    {
                Data.countLVLs++;
                Data.nameLVLs += " LvlSnake";
                    }
                    MainWindow.progress[5] = true;
                    mus.Stop();
                    movin = false;
                    vic_tbl.Visibility = Visibility.Visible;
                   
                    
                }
            }


            snakebody[0] = new Snake(x, y);

            if (snakebody[0].x > 370 || snakebody[0].y > 350 || snakebody[0].x < 0 || snakebody[0].y < 0)
            {
                mus.Stop();
                lose_tbl.Visibility = Visibility.Visible;
                movin = false;
            }


           


            for (int i = 0; i < mycanvas.Children.Count; i++)
            {
                if (mycanvas.Children[i] is Rectangle)
                    count++;
            }




            mycanvas.Children.RemoveRange(1, count);
            count = 0;
            addsnakeincanvas();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W && direction != down)
                direction = up;
            if (e.Key == Key.S && direction != up)
                direction = down;
            if (e.Key == Key.A && direction != right)
                direction = left;
            if (e.Key == Key.D && direction != left)
                direction = right;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addsnakeincanvas();
            addfoodincanvas();
            time.Start();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            mus.Stop();

            this.Close();
        }
    }
}
