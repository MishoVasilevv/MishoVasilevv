using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class MoveCommand : ICommand
    {
        private Shape shape;
        private float oldX, oldY;
        private float newX, newY;

        public MoveCommand(Shape shape, float newX, float newY)
        {
            this.shape = shape;
            this.oldX = shape.X;
            this.oldY = shape.Y;
            this.newX = newX;
            this.newY = newY;
        }

        public void Execute()
        {
            shape.X = newX;
            shape.Y = newY;
        }

        public void Undo()
        {
            shape.X = oldX;
            shape.Y = oldY;
        }
    }
}
