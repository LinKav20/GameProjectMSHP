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
    /// 
    /// Логика взаимодействия для level1.xaml
    /// </summary>
    public partial class level1 : Window
    {
        List<fruit> heroes = new List<fruit>();
        List<int> pos_x = new List<int>();
        List<int> pos_y = new List<int>();
        int i = 0, count = 0;
        public bool adding = true;
        Random rand = new Random();

   
        
        public level1()
        {
            InitializeComponent();
            heroes.Add(hero);
            pos_x.Add((int)(Canvas.GetLeft(hero)));
            pos_y.Add((int)(Canvas.GetTop(hero)));
            System.Windows.Threading.DispatcherTimer timerMove = new System.Windows.Threading.DispatcherTimer();
            timerMove.Tick += new EventHandler(moveHeroes);
            timerMove.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerMove.Start();

            System.Windows.Threading.DispatcherTimer timerCreate = new System.Windows.Threading.DispatcherTimer();
            timerMove.Tick += new EventHandler(createHeroes);
            timerMove.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timerMove.Start();



            System.Windows.Threading.DispatcherTimer timerCheckAlive = new System.Windows.Threading.DispatcherTimer();
            timerCheckAlive.Tick += new EventHandler(checkHeroes);
            timerCheckAlive.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerCheckAlive.Start();

        }

        private void checkHeroes(object sender, EventArgs e)
        {
            for (int j = 0; j <= i;)
            {

                if (heroes[j].alive == false)
                {
                    
                    canvas.Children.Remove(heroes[j]);
                    heroes.RemoveAt(j);
                    pos_x.RemoveAt(j);
                    pos_y.RemoveAt(j);
                    i--;
                  

                    if (heroes.Count <= 0)
                    {
                        
                        adding = false;
                        MessageBox.Show("Victory");
                        if (Data.nameLVLs.IndexOf("Lvl1") == -1)
                        {
                            Data.countLVLs++;
                            Data.nameLVLs += " Lvl1";
                        }
                        //System.Windows.Application.Current.Shutdown();
                        this.Close();
                    }
                }
                else
                {
                    j++;
                }
            }
        }

        private void createHeroes(object sender, EventArgs e)
        {
             if (adding)
            {
                fruit newHero = new fruit();
                newHero.Height = hero.Height;
                newHero.Width = hero.Width;
                newHero.HeroPhoto = hero.HeroPhoto;
                newHero.alive = true;
                heroes.Add(newHero);
                canvas.Children.Add(newHero);
                int x = rand.Next(0, 501);
                int y = rand.Next(0, 401);
                pos_x.Add(x);
                pos_y.Add(y);
                Canvas.SetLeft(newHero, pos_x[heroes.Count - 1]);
                Canvas.SetTop(newHero, pos_y[heroes.Count - 1]);
                i = heroes.Count - 1;
            }
        }

        private void hero_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hero.Visibility = Visibility.Hidden;
            hero.IsEnabled = false;
        }

        private void moveHeroes(object sender, EventArgs e)
        {
            for (int j = 0; j < heroes.Count; j++)
            {
                //x
                int new_pos_x = pos_x[i] + rand.Next(-20, 20);
                Canvas.SetLeft(heroes[i], new_pos_x);

                //y
                int new_pos_y = pos_y[i] + rand.Next(-20, 20);
                Canvas.SetTop(heroes[i], new_pos_y);
            }
        }
    }
}
