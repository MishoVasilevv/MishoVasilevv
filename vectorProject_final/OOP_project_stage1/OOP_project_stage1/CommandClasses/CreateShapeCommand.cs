using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class CreateShapeCommand : ICommand
    {
        private List<Shape> shapes;
        private Shape shape;

        public CreateShapeCommand(List<Shape> shapes, Shape shape)
        {
            this.shapes = shapes;
            this.shape = shape;
        }

        public void Execute()
        {
            shapes.Add(shape);
        }

        public void Undo()
        {
            shapes.Remove(shape);
        }
    }
}
