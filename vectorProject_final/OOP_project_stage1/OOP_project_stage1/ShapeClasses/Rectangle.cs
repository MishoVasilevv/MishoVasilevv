using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    class Rectangle : Shape
    {
        public Rectangle(float x, float y, double height, double width, double area, double perimeter, Color outlineColor, Color fillColor) : base(x, y, height, width, area, perimeter, outlineColor, fillColor)
        {
        }

        public override double CalculateArea()
        {
            Area = Width * Height;
            return Area;
        }

        public override double CalculatePerimeter()
        {
            Perimeter = 2 * (Width * Height);
            return Perimeter;
        }

        public override void DrawShape(Graphics g)
        {
            using (Pen pen = new Pen(OutlineColor, 2))
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillRectangle(brush, X, Y, (float)Width, (float)Height);
                g.DrawRectangle(pen, X, Y, (float)Width, (float)Height);
            }
        }

        public override bool SelectShape(Point mousePoint)
        {
            IsSelected = (mousePoint.X >= X && mousePoint.X <= X + Width &&
                  mousePoint.Y >= Y && mousePoint.Y <= Y + Height);
            //checks if the mouse point is between top corner and bottom corner
            //and also between most left and most right
            return IsSelected;
        }
    }
}
