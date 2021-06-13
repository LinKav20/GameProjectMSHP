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
using System.IO;
using Microsoft.Win32;

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindoww.xaml
    /// </summary>
    public partial class MainWindoww : Window
    {

        private MediaPlayer player = new MediaPlayer();
        private MediaPlayer knopki = new MediaPlayer();
        private bool alisok = true;
          System.Windows.Threading.DispatcherTimer music = new System.Windows.Threading.DispatcherTimer();
       System.Windows.Threading.DispatcherTimer checker = new System.Windows.Threading.DispatcherTimer();
      System.Windows.Threading.DispatcherTimer timercreateheroes = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer timerMove = new System.Windows.Threading.DispatcherTimer();
        Random random = new Random();
        public MainWindoww()
        {
            InitializeComponent();
            
            timerMove.Tick += new EventHandler(moveHeroes);
            timerMove.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerMove.Start();

            
            timercreateheroes.Tick += new EventHandler(createhero);
            timercreateheroes.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timercreateheroes.Start();

           
            checker.Tick += new EventHandler(checkk);
            checker.Interval = new TimeSpan(0, 0, 0, 0, 100);
            checker.Start();


            
            music.Tick += new EventHandler(mus);
            music.Interval = new TimeSpan(0, 0, 1, 15, 0);
            music.Start();

            player.Open(new Uri("gravityfallssong.mp3", UriKind.Relative));
            player.Play();





        }

        private void mus(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        void remove()
        {
            final_project.Height = 0;
            final_project.Width = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                final_project.HeroPhoto = openFileDialog.FileName;
            knopki.Play();
        }

        private void setName_TextChanged(object sender, TextChangedEventArgs e)
        {
            final_project.HeroName = setName.Text;
        }



        //massive geroev
        List<HeroInterface> heroes = new List<HeroInterface>();
        List<int> pos_x = new List<int>();
        List<int> pos_y = new List<int>();



        private void checkk(object sender, EventArgs e)
        {
            int kolvo2 = 0; //мёртвых
            int kolvo3 = 0; //живых
            for (int i = tuta; i < kolvoobotov; i++)
            {
                if (heroes[i].hp.Value <= 0)
                {
                    kolvo2++;
                }
                else
                {
                    kolvo3++;
                }
            }

            tbjivih.Text = "Живых: " + kolvo3;
            tbubito.Text = "Убито: " + kolvo2;
            if (kolvo2 > 0 && kolvo3 == 0)
            {
                winbtn.Visibility = Visibility.Visible;
                alisok = false;
            }
        }


        private void moveHeroes(object sender, EventArgs e)
        {
            if (ALLISOK == true)
            {
                for (int i = tuta; i < kolvoobotov; i++)
                {
                    //x
                    int new_pos_x = pos_x[i] + random.Next(-10, 10);
                    Canvas.SetLeft(heroes[i], new_pos_x);

                    //y
                    int new_pos_y = pos_y[i] + random.Next(-10, 10);
                    Canvas.SetTop(heroes[i], new_pos_y);
                }
            }
        }
        private void updatee(object sender, EventArgs e)
        {
            tbjivih.Text = "Живых: " + kolvojivih;
            tbubito.Text = "Убито: " + kolvoubitih;
        }


        int kolvoobotov = 0;
        int kolvoubitih = 0;
        int kolvojivih = 0;
        bool ALLISOK = true;
        int tuta = 0;
        int randomyadro = 10;

        private void createhero(object sender, EventArgs e)
        {
            if (ALLISOK == true && alisok == true)
            {
                if (random.Next(1, randomyadro) == 1)
                {
                    HeroInterface myNewHero = new HeroInterface();
                    heroes.Add(myNewHero);
                    pos_x.Insert(kolvoobotov, random.Next(100, 500));
                    pos_y.Insert(kolvoobotov, random.Next(20, 300));

                    heroes[kolvoobotov].Height = random.Next(50, 250);
                    heroes[kolvoobotov].Width = random.Next(50, 250);
                    heroes[kolvoobotov].HeroHP = random.Next(50, 250);
                    heroes[kolvoobotov].HeroName = "yay";
                    heroes[kolvoobotov].HeroPhoto = "test.png.jpg";



                    heroes[kolvoobotov].HeroPower = random.Next(5, 250);

                    canvas.Children.Add(heroes[kolvoobotov]);
                    Canvas.SetLeft(heroes[kolvoobotov], pos_x[kolvoobotov]);
                    Canvas.SetTop(heroes[kolvoobotov], pos_y[kolvoobotov]);
                    kolvoobotov++;


                }
            }
        }



        private void doCopy_Click(object sender, RoutedEventArgs e)
        {

            HeroInterface myNewHero = new HeroInterface();
            heroes.Insert(kolvoobotov, myNewHero);
            pos_x.Insert(kolvoobotov, random.Next(100, 500));
            pos_y.Insert(kolvoobotov, random.Next(20, 500));

            heroes[kolvoobotov].Height = random.Next(50, 250);
            heroes[kolvoobotov].Width = random.Next(50, 250);
            heroes[kolvoobotov].HeroHP = random.Next(5, 250);
            heroes[kolvoobotov].HeroName = "yay";
            heroes[kolvoobotov].HeroPhoto = "file:///C:/Users/72975/Desktop/test.png.jpg";
            heroes[kolvoobotov].HeroPower = random.Next(5, 250);

            canvas.Children.Add(heroes[kolvoobotov]);
            Canvas.SetLeft(heroes[kolvoobotov], pos_x[kolvoobotov]);
            Canvas.SetTop(heroes[kolvoobotov], pos_y[kolvoobotov]);
            kolvoobotov++;
        }


        private void setHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            final_project.HeroHP = Convert.ToInt32(setHP.Value);
        }

        private void setPower_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            final_project.HeroPower = Convert.ToInt32(setPower.Value);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ALLISOK = false;

            for (int i = tuta; i < kolvoobotov; i++)
            {
                //x
                int new_pos_x = -1000;
                Canvas.SetLeft(heroes[i], new_pos_x);

                //y
                int new_pos_y = -1000;
                Canvas.SetTop(heroes[i], new_pos_y);
            }

            tuta = kolvoobotov;
            kolvoubitih = 0;
            kolvojivih = 0;
            tbjivih.Text = "Живых: " + kolvojivih;
            tbubito.Text = "Убито: " + kolvoubitih;
            ALLISOK = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            randomyadro = 30;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            randomyadro = 5;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            randomyadro = 1;
        }

        private void Winbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Data.nameLVLs.IndexOf("LvlCreateArmy") == -1)
            {
                Data.countLVLs++;
                Data.nameLVLs += " LvlCreateArmy";
            }
            MainWindow.progress[0] = true;
            player.Stop();
            timercreateheroes.Stop();
            timerMove.Stop();
            checker.Stop();
            music.Stop();
            this.Close();
            player.Stop();
            
            //System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            player.Stop();
            player.Stop();
            timercreateheroes.Stop();
            timerMove.Stop();
            checker.Stop();
            music.Stop();
            this.Close();
        }
    }
}

