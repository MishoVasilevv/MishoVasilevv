using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();

        void DrawShape(Graphics g);

        bool SelectShape(Point mousePoint);

    }
}
