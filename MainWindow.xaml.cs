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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace final_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int i = 0;
        void http_work()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/HEROstatus/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string responseString = "<html><head><meta charset='utf8'>" 
                    + "<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css\">" 
                    + "<script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js\"></script>"
                    + "<title> Статус Прохождения </title>"
                +"</head>"
                    +"<body><br><br>"
                    +"<div class=\"container\">"
                    +"<br><br><h2 class =\"text-warning text-center\"> Статус прохождения нашей замечательной игры </h2>"
                    + "<div class =\" row\"> <div class\"col - sm - 2\">  </div> <div class=\"col - sm - 4 strong text-success h3\">Пройдено уровней:  "+ Data.countLVLs.ToString() + "</div><div class=\"col - sm - 4 strong text-danger h3\">Уровней всего:   7</div>" + "<div class=\"col - sm - 2 strong text-primary\"> Пройденные Уровни: "+ Data.nameLVLs +"</div></div>"
                         + " </div>"
                    +"</body></html>" ;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }

        DispatcherTimer time = new DispatcherTimer();
        DispatcherTimer time1 = new DispatcherTimer();
        DispatcherTimer time2 = new DispatcherTimer();
        DispatcherTimer time3 = new DispatcherTimer();
        private MediaPlayer player = new MediaPlayer();
        public int RADIUS = 20, KOLVO = 0;
        public double x =27;
        public double y = 10;
        public double z = 23;
        public static bool[] progress = new bool[7] { false, false, false, false, false, false, false};
        
        public int isitend = 0;
        Thread t;

        public MainWindow()
        {
            t = new Thread(http_work);
            t.Start();
            
            InitializeComponent();
        }
        
        void music(object sender, EventArgs e)
        {
            player.Position = new TimeSpan(0, 0, 0, 0, 1);
        }

        public static void drawTriangle(Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport)
        {
            // функция рисования тругольника
            MeshGeometry3D mesh = new MeshGeometry3D();

            // добавляем координаты вершин треугольника
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);

            // настраиваем правило буравчика
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // закрашиваем треугольник и делаем его материал матовым - DiffuseMaterial
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new DiffuseMaterial(brush);
            // при желании можно сделать материал блестящим - SpecularMaterial или светящимся - EmissiveMaterial

            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            ModelUIElement3D model = new ModelUIElement3D();
            model.Model = geometry;

            viewport.Children.Add(model);
        }

        private void Tri(double x1, double y1, double z1,
                        double x2, double y2, double z2,
                        double x3, double y3, double z3, Color color, Viewport3D viewport)
        {
            Point3D[] p = new Point3D[3];
            p[0] = new Point3D(x1, y1, z1);
            p[1] = new Point3D(x2, y2, z2);
            p[2] = new Point3D(x3, y3, z3);
            drawTriangle(p[0], p[1], p[2], color, viewport);
        }

        private void Quad(double x1, double y1, double z1,
                         double x2, double y2, double z2,
                         double x3, double y3, double z3,
                         double x4, double y4, double z4, Color color, Viewport3D viewport)
        {

            Tri(x1, y1, z1, x2, y2, z2, x4, y4, z4, color, viewport);
            Tri(x2, y2, z2, x3, y3, z3, x4, y4, z4, color, viewport);

        }

        private void pr_prisma(double x1, double y1, double z1,
                               double a, double b, double c, Color color, Viewport3D viewport)
        {

            Quad(x1, y1 + c, z1, x1, y1, z1, x1 + b, y1, z1, x1 + b, y1 + c, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1 + c, z1, x1, y1 + c, z1 + a, x1, y1, z1 + a, color, viewport);
            Quad(x1, y1 + c, z1, x1, y1 + c, z1 + a, x1 + b, y1 + c, z1 + a, x1 + b, y1 + c, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1, z1 + a, x1 + b, y1, z1 + a, x1 + b, y1, z1, color, viewport);
            Quad(x1, y1 + c, z1 + a, x1, y1, z1 + a, x1 + b, y1, z1 + a, x1 + b, y1 + c, z1 + a, color, viewport);
            Quad(x1 + b, y1 + c, z1, x1 + b, y1 + c, z1 + a, x1 + b, y1, z1 + a, x1 + b, y1, z1, color, viewport);
        }

        private void cube(double x, double y, double z, double a, Color color, Viewport3D viewport)
        {
            double x1 = x;
            double y1 = y;
            double z1 = z;

            double x2 = x + a;
            double y2 = y;
            double z2 = z;

            double x3 = x + a;
            double y3 = y + a;
            double z3 = z;

            double x4 = x;
            double y4 = y + a;
            double z4 = z;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + a;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + a;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + a;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 + a;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);



        }

        private void piramida(double x, double y, double z, double a, Color color, Viewport3D viewport)
        {
            double x1 = x;
            double y1 = y;
            double z1 = z;

            double x2 = x + a;
            double y2 = y;
            double z2 = z;

            double x3 = x + a / 2;
            double y3 = y + a;
            double z3 = z + a / 2;

            double x4 = x + a / 2;
            double y4 = y + a;
            double z4 = z + a / 2;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + a;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + a;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);



        }

        private void r_piramida(double x, double y, double z, double a, Color color, Viewport3D viewport)
        {
            double x1 = x + a / 2;
            double y1 = y;
            double z1 = z + a / 2;

            double x2 = x + a / 2;
            double y2 = y;
            double z2 = z + a / 2;

            double x3 = x + a;
            double y3 = y + a;
            double z3 = z;

            double x4 = x;
            double y4 = y + a;
            double z4 = z;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + a;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 + a;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);



        }

        public void redro()
        {
            cam.Position = new Point3D(x, y, z);
        }

        void move(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.LeftShift) && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.C))
            {
                TextBoxx.Visibility = Visibility.Visible;
                enter_btn.Visibility = Visibility.Visible;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                if (z > -95) z -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (z < 100) z += 1;
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (x > -25) x -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                if (x < 50) x += 1;
            }
            
            redro();
        }
        void also_checker()
        {
            if(progress[0] && progress[1] && progress[2] && progress[3] && progress[4] && progress[5] && progress[6])
            {
                double h1 = -20 * Math.Sin(2 * Math.PI + Math.PI / 4);
                double h2 = -50 * Math.Cos(2 * Math.PI + Math.PI / 4);
                isitend = 1;

                piramida(h1, 8, h2, 5, Colors.SpringGreen, mainViewport);
                r_piramida(h1, 3, h2, 5, Colors.SpringGreen, mainViewport);
            }
        }
        void checker(object sender, EventArgs e)
        {
            double h1 = -20 * Math.Sin(Math.PI / 2), h2 = -50 * Math.Cos(Math.PI / 2);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl1.Visibility = Visibility.Visible;
                for_lvl1.Visibility = Visibility.Visible;
                description_lvl1.Visibility = Visibility.Visible;
                label_lvl1.Visibility = Visibility.Visible;
            }
            else
            {
                lvl1.Visibility = Visibility.Hidden;
                description_lvl1.Visibility = Visibility.Hidden;
                label_lvl1.Visibility = Visibility.Hidden;
                for_lvl1.Visibility = Visibility.Hidden;
            }
            h1 = -20 * Math.Sin(Math.PI / 2 + Math.PI / 4);
            h2 = -50 * Math.Cos(Math.PI / 2+ Math.PI / 4);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl2.Visibility = Visibility.Visible;
                for_lvl2.Visibility = Visibility.Visible;
                description_lvl2.Visibility = Visibility.Visible;
                label_lvl2.Visibility = Visibility.Visible;
            }
            else
            {
                lvl2.Visibility = Visibility.Hidden;
                description_lvl2.Visibility = Visibility.Hidden;
                label_lvl2.Visibility = Visibility.Hidden;
                for_lvl2.Visibility = Visibility.Hidden;
            }
            h1 = -20 * Math.Sin(Math.PI);
            h2 = -50 * Math.Cos(Math.PI );
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl3.Visibility = Visibility.Visible;
                for_lvl3.Visibility = Visibility.Visible;
                description_lvl3.Visibility = Visibility.Visible;
                label_lvl3.Visibility = Visibility.Visible;
                
            }
            else
            {
                lvl3.Visibility = Visibility.Hidden;
                description_lvl3.Visibility = Visibility.Hidden;
                label_lvl3.Visibility = Visibility.Hidden;
                for_lvl3.Visibility = Visibility.Hidden;
               
            }
            h1 = -20 * Math.Sin((5*Math.PI)/4);
            h2 = -50 * Math.Cos((5 * Math.PI) / 4);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl4.Visibility = Visibility.Visible;
                for_lvl4.Visibility = Visibility.Visible;
                description_lvl4.Visibility = Visibility.Visible;
                label_lvl4.Visibility = Visibility.Visible;
            }
            else
            {
                lvl4.Visibility = Visibility.Hidden;
                description_lvl4.Visibility = Visibility.Hidden;
                label_lvl4.Visibility = Visibility.Hidden;
                for_lvl4.Visibility = Visibility.Hidden;
            }
            h1 = -20 * Math.Sin((6 * Math.PI) / 4);
            h2 = -50 * Math.Cos((6 * Math.PI) / 4);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl5.Visibility = Visibility.Visible;
                for_lvl5.Visibility = Visibility.Visible;
                description_lvl5.Visibility = Visibility.Visible;
                label_lvl5.Visibility = Visibility.Visible;
            }
            else
            {
                lvl5.Visibility = Visibility.Hidden;
                description_lvl5.Visibility = Visibility.Hidden;
                label_lvl5.Visibility = Visibility.Hidden;
                for_lvl5.Visibility = Visibility.Hidden;
            }
            h1 = -20 * Math.Sin((7 * Math.PI) / 4);
            h2 = -50 * Math.Cos((7 * Math.PI) / 4);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl6.Visibility = Visibility.Visible;
                for_lvl6.Visibility = Visibility.Visible;
                description_lvl6.Visibility = Visibility.Visible;
                label_lvl6.Visibility = Visibility.Visible;
            }
            else
            {
                lvl6.Visibility = Visibility.Hidden;
                description_lvl6.Visibility = Visibility.Hidden;
                label_lvl6.Visibility = Visibility.Hidden;
                for_lvl6.Visibility = Visibility.Hidden;
            }
            
            h1 = -20 * Math.Sin(2 * Math.PI);
            h2 = -50 * Math.Cos(2 * Math.PI);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
                lvl7.Visibility = Visibility.Visible;
                for_lvl7.Visibility = Visibility.Visible;
                description_lvl7.Visibility = Visibility.Visible;
                label_lvl7.Visibility = Visibility.Visible;
            }
            else
            {
                lvl7.Visibility = Visibility.Hidden;
                description_lvl7.Visibility = Visibility.Hidden;
                label_lvl7.Visibility = Visibility.Hidden;
                for_lvl7.Visibility = Visibility.Hidden;
            }
            h1 = -20 * Math.Sin(2 * Math.PI+Math.PI/4);
            h2 = -50 * Math.Cos(2 * Math.PI+Math.PI / 4);
            if ((x - h1) * (x - h1) + (z - h2) * (z - h2) < 200)
            {
               
                for_lvl8.Visibility = Visibility.Visible;
                description_lvl8.Visibility = Visibility.Visible;
                label_lvl8.Visibility = Visibility.Visible;
                if (isitend == 1) end.Visibility = Visibility.Visible;
            }
            else
            {
               
                description_lvl8.Visibility = Visibility.Hidden;
                label_lvl8.Visibility = Visibility.Hidden;
                for_lvl8.Visibility = Visibility.Hidden;
                 end.Visibility = Visibility.Hidden;
            }
            
            if (RADIUS == 11000) time2.Stop();

        }

        private void lvl1_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            MainWindoww mainWindoww = new MainWindoww(); // создаем новый экземпляр второго окна
            mainWindoww.ShowDialog();
            player.Play();
            also_checker();
            x = 27;
            z = 23;
            redro();
            double h1 = -20 * Math.Sin(2*Math.PI / 4), h2 = -50 * Math.Cos(2*Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = -50; i < 50; i += 5)
                for (int j = -50; j < 150; j += 5)
                    pr_prisma(0 + i, 0, -50 + j, 5, 5, 1, Colors.Beige, mainViewport);


            for (double i = Math.PI / 2; i < 5 * (Math.PI / 2); i += Math.PI / 4)
            {
                double h1 = -20 * Math.Sin(i), h2 = -50 * Math.Cos(i);
                pr_prisma(h1, 1, h2, 5, 5, 0.5, Colors.Brown, mainViewport);
                pr_prisma(h1 + 0.5, 1.5, h2 + 0.5, 4, 4, 0.5, Colors.BurlyWood, mainViewport);
                piramida(h1, 8, h2, 5, Colors.LightBlue, mainViewport);
                r_piramida(h1, 3, h2, 5, Colors.LightBlue, mainViewport);
            }


            time.Interval = new TimeSpan(0, 0, 0, 0, 1);
            time.IsEnabled = true;
            time.Tick += move;

            time1.Interval = new TimeSpan(0, 0, 0, 0, 1);
            time1.IsEnabled = true;
            time1.Tick += checker;

            time3.Interval = new TimeSpan(0, 0, 9, 50, 0);
            time3.IsEnabled = true;
            time3.Tick += music;

            player.Open(new Uri("feralas.mp3", UriKind.Relative));
            player.Volume = 0.5;
            player.Play();

            mmm.Visibility = Visibility.Hidden;
            formenu.Visibility = Visibility.Hidden;
            statusbtn.Visibility = Visibility.Visible;
            //MENU.Visibility = Visibility.Hidden;

            musss_volume.Value = 0.5;

            begin1.Visibility = Visibility.Hidden;
            begin.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
            custom_btn.Visibility = Visibility.Hidden;
            mortyy.img = custom_window.dataa.src;
            mortyy.Name = custom_window.dataa.nm;
            mortyy_2.img = custom_window.dataa.src;
            mortyy_2.Name = custom_window.dataa.nm;
            if (custom_window.dataa.vis)
            {
                
                mortyy.Visibility = Visibility.Visible;
                visib_ch.IsChecked = true;
            }

        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            for (double i = Math.PI / 2; i < 5 * (Math.PI / 2); i += Math.PI / 4)
            {
                double h1 = -20 * Math.Sin(i), h2 = -50 * Math.Cos(i);
                pr_prisma(h1, 1, h2, 5, 5, 0.5, Colors.Black, mainViewport);
                pr_prisma(h1 + 0.5, 1.5, h2 + 0.5, 4, 4, 0.5, Colors.DarkGray, mainViewport);
                piramida(h1, 8, h2, 5, Colors.MediumVioletRed, mainViewport);
                r_piramida(h1, 3, h2, 5, Colors.MediumVioletRed, mainViewport);
            }
            ImageBrush new_game = new ImageBrush();
            new_game.ImageSource = new BitmapImage(new Uri("6491.jpg", UriKind.Relative));
            kheh.Background = new_game;
            time2.Interval = new TimeSpan(0, 0, 0, 0, 10);
            time2.IsEnabled = true;
            time2.Tick += endgame;
            x = 27;
            z = 23;
            redro();
            end.Visibility = Visibility.Hidden;
            description_lvl8.Visibility = Visibility.Hidden;
            label_lvl8.Visibility = Visibility.Hidden;
            for_lvl8.Visibility = Visibility.Hidden;
            time.Stop();
            time1.Stop();
            konets.Visibility = Visibility.Visible;
            
        }
        void endgame(object sender, EventArgs e)
        {

            for (int i = -50; i < 50; i += 5)
            {
                for (int j = -50; j < 150; j += 5)
                {
                    if (((0 + i - 0) * (0 + i - 0) + (-50 + j - 0) * (-50 + j - 0) < RADIUS) && ((0 + i - 0) * (0 + i - 0) + (-50 + j - 0) * (-50 + j - 0) > RADIUS - 20))
                    {
                        pr_prisma(0 + i, 0, -50 + j, 5, 5, 1, Colors.Azure, mainViewport);
                    }
                }
            }
            RADIUS += 10;

        }

        private void MENU_Click(object sender, RoutedEventArgs e)
        {
            mmm.Visibility = Visibility.Visible;
            formenu.Visibility = Visibility.Visible;
            statusbtn.Visibility = Visibility.Visible;
        }

        private void musss_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = musss_volume.Value;
        }

        private void closeddd_Click(object sender, RoutedEventArgs e)
        {
            mmm.Visibility = Visibility.Hidden;
            formenu.Visibility = Visibility.Hidden;
            statusbtn.Visibility = Visibility.Hidden;
        }

        private void lvl4_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            lvl3 lvl4 = new lvl3();
            lvl4.ShowDialog();
            player.Play();
            also_checker();
            x = 27;
            z = 23;
            redro();
            double h1 = -20 * Math.Sin(5 * Math.PI / 4), h2 = -50 * Math.Cos(5 * Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void lvl3_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            //тут открывается уровень от лины
            MainWindowGB lvl4 = new MainWindowGB();
            lvl4.ShowDialog();
            also_checker();
            player.Play();
            x = 27;
            z = 23;
            redro();
            double h1 = -20 * Math.Sin(4 * Math.PI / 4), h2 = -50 * Math.Cos(4 * Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void Lvl6_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            MainWindowSnakegame lvl4 = new MainWindowSnakegame(); // спасибо артем 
            lvl4.ShowDialog();
            also_checker();
            player.Play();
            x = 27;
            z = 23;
            redro();
            double h1 = -20 * Math.Sin(7 * Math.PI / 4), h2 = -50 * Math.Cos(7 * Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);

        }

        private void lvl5_Click(object sender, RoutedEventArgs e)
        {
            shooterrrrr shooter = new shooterrrrr();
            player.Pause();
            shooter.ShowDialog();
            player.Play();
            also_checker();
            x = 27;
            z = 23;
            double h1 = -20 * Math.Sin(6 * Math.PI / 4), h2 = -50 * Math.Cos(6 * Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void TextBoxx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxx.Text == "skip1") progress[0] = true;
            else if (TextBoxx.Text == "skip2") progress[1] = true;
            else if (TextBoxx.Text == "skip3") progress[2] = true;
            else if (TextBoxx.Text == "skip4") progress[3] = true;
            else if (TextBoxx.Text == "skip5") progress[4] = true;
            else if (TextBoxx.Text == "skip6") progress[5] = true;
            else if (TextBoxx.Text == "skip7") progress[6] = true;

            else if (TextBoxx.Text == "skipall")
            {
                progress[0] = true;
                progress[1] = true;
                progress[2] = true;
                progress[3] = true;
                progress[4] = true;
                progress[5] = true;
                progress[6] = true;
                end.Visibility = Visibility.Visible;
            }
            for (int i = 0; i < 7; i++) {
                if (progress[i] == true && Data.nameLVLs.IndexOf(Data.lvls[i]) == -1) { Data.countLVLs++; Data.nameLVLs += Data.lvls[i]; }
            }
        }

        private void konets_Click(object sender, RoutedEventArgs e)
        {
            

            Process.Start("index.html");
            player.Stop();
            System.Windows.Application.Current.Shutdown();
        }

        private void enter_btn_Click(object sender, RoutedEventArgs e)
        {
            TextBoxx.Visibility = Visibility.Hidden;
            enter_btn.Visibility = Visibility.Hidden;
        }

        private void lvl7_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            musision musision = new musision();
            musision.ShowDialog();
            player.Play();
            double h1 = -20 * Math.Sin(8 * Math.PI / 4), h2 = -50 * Math.Cos(8 * Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void lvl8_Click(object sender, RoutedEventArgs e)
        {
            double h1 = -20 * Math.Sin((9 * Math.PI) / 4);
            double h2 = -50 * Math.Cos((9 * Math.PI) / 4);

            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }

        private void Statusbtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:8888/HEROstatus/");
        }

        private void custom_btn_Click(object sender, RoutedEventArgs e)
        {
            custom_window custom = new custom_window();
            custom.ShowDialog();
            if (custom_window.dataa.state)
            {
                start.IsEnabled = true;
            }
        }

        private void visib_ch_Checked(object sender, RoutedEventArgs e)
        {
            mortyy.img = custom_window.dataa.src;
            mortyy.Name = custom_window.dataa.nm;
            mortyy.Visibility = Visibility.Visible;
        }

        private void visib_ch_Unchecked(object sender, RoutedEventArgs e)
        {
            mortyy.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void lvl2_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
            lvl2 Lvl2 = new lvl2();
            Lvl2.ShowDialog();
            player.Play();
            also_checker();
            x = 27;
            z = 23;
            redro();
            double h1 = -20 * Math.Sin(3*Math.PI / 4), h2 = -50 * Math.Cos(3*Math.PI / 4);
            piramida(h1, 8, h2, 5, Colors.DodgerBlue, mainViewport);
            r_piramida(h1, 3, h2, 5, Colors.DodgerBlue, mainViewport);
        }
    }
}
