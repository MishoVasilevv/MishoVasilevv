using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    class Circle : Shape
    {
        public Circle(float x, float y, double height, double width, double area, double perimeter, Color outlineColor, Color fillColor) : base(x, y, height, width, area, perimeter, outlineColor, fillColor)
        {
        }

        public override double CalculateArea()
        {
            Area = Math.PI * ((Height/2) * (Height/2));
            return Area;
        }

        public override double CalculatePerimeter()
        {
            Perimeter = 2 * Math.PI * (Height / 2);
            return Perimeter;
        }

        public override void DrawShape(Graphics g)
        {
            using (Pen pen = new Pen(OutlineColor, 2))
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillEllipse(brush, X, Y, (float)Width, (float)Height);
                g.DrawEllipse(pen, X, Y, (float)Width, (float)Height);
            }
        }

        public override bool SelectShape(Point mousePoint)
        {
            double dist = Math.Sqrt(Math.Pow(mousePoint.X - (X + Height / 2), 2) +
                            Math.Pow(mousePoint.Y - (Y + Height / 2), 2));
            //X + Height / 2 and Y + Height / 2 is the center of the circle
            IsSelected = dist <= Height / 2;

            return IsSelected;
        }
    }
}
