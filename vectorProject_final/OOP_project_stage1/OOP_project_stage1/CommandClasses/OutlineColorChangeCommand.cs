using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class OutlineColorChangeCommand : ICommand
    {
        private Shape shape;
        private Color oldColor;
        private Color newColor;

        public OutlineColorChangeCommand(Shape shape, Color newColor)
        {
            this.shape = shape;
            this.oldColor = shape.OutlineColor;
            this.newColor = newColor;
        }

        public void Execute()
        {
            shape.OutlineColor = newColor;
        }

        public void Undo()
        {
            shape.OutlineColor = oldColor;
        }
    }
}
