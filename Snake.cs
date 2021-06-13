using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace final_project
{
    class Snake
    {
        public bool z = false;
        public double x, y;
        public Rectangle rec = new Rectangle();
        public Snake(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
        public void setsnakeposition()
        {
            rec.Width = rec.Height = 10;
            if (z == false)
            {
                rec.Fill = Brushes.Black;
                z = true;
            }
            else
            {
                rec.Fill = Brushes.Green;
            }
            Canvas.SetLeft(rec, x);
            Canvas.SetTop(rec, y);
        }
    }
}
