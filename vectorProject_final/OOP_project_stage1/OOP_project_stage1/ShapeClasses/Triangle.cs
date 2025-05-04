using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    class Triangle : Shape
    {
        public Triangle(float x, float y, double height, double width, double area, double perimeter, Color outlineColor, Color fillColor) : base(x, y, height, width, area, perimeter, outlineColor, fillColor)
        {
        }

        public override double CalculateArea()
        {
            Area = (Height * Width) / 2;
            return Area;
        }

        public override double CalculatePerimeter()
        {
            double hypotenuse = Math.Sqrt(Width * Width + Height * Height);

            Perimeter = Width + Height + hypotenuse;
            return Perimeter;
        }

        public static PointF[] GetTrianglePoints(PointF start, int width, int height)
        {
            return new PointF[]
            {
                new PointF(start.X + width / 2, start.Y),//top
                new PointF(start.X, start.Y + height),//bottom left
                new PointF(start.X + width, start.Y + height)//bottom right
            };
        }

        public override void DrawShape(Graphics g)
        {
            using (Pen pen = new Pen(OutlineColor, 2))
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillPolygon(brush, Triangle.GetTrianglePoints(new PointF(X, Y), (int)Width, (int)Height));
                g.DrawPolygon(pen, Triangle.GetTrianglePoints(new PointF(X, Y), (int)Width, (int)Height));
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
