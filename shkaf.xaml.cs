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
    /// Логика взаимодействия для shkaf.xaml
    /// </summary>
    public partial class shkaf : Window
    {
        private MediaPlayer knopki = new MediaPlayer();
        public shkaf()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer timerch = new System.Windows.Threading.DispatcherTimer();
            timerch.Tick += new EventHandler(ch);
            timerch.Interval = new TimeSpan(0, 0, 0, 0, 1);

            knopki.Open(new Uri("knopka.mp3", UriKind.Relative));

            timerch.Start();
        }

        private void ch(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                this.Close();

            }
        }

        public bool s = false;


        private void KNOPKA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            knopki.Play();
            knopki.Position = new TimeSpan(0, 0, 0, 0, 1);
            if (tb1.Text == "P" && tb2.Text == "S" && tb3.Text == "D")
            {

                s = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("invalid password");
            }
        }
    }
}
