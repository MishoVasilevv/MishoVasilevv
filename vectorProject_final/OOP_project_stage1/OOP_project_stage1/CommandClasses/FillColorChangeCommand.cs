using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class FillColorChangeCommand : ICommand
    {
        private Shape shape;
        private Color oldColor;
        private Color newColor;

        public FillColorChangeCommand(Shape shape, Color newColor)
        {
            this.shape = shape;
            this.oldColor = shape.FillColor;
            this.newColor = newColor;
        }

        public void Execute()
        {
            shape.FillColor = newColor;
        }

        public void Undo()
        {
            shape.FillColor = oldColor;
        }
    }
}
