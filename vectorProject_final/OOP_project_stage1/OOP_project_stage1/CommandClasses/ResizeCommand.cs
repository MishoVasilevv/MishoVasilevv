using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class ResizeCommand : ICommand
    {
        private Shape shape;
        private Action onUpdate;
        private double oldWidth, oldHeight;
        private double newWidth, newHeight;

        public ResizeCommand(Shape shape, double newWidth, double newHeight, Action onUpdate)
        {
            this.shape = shape;
            this.oldWidth = shape.Width;
            this.oldHeight = shape.Height;
            this.newWidth = newWidth;
            this.newHeight = newHeight;
            this.onUpdate = onUpdate;
        }

        public void Execute()
        {
            shape.Width = newWidth;
            shape.Height = newHeight;
            onUpdate?.Invoke();
        }

        public void Undo()
        {
            shape.Width = oldWidth;
            shape.Height = oldHeight;
            onUpdate?.Invoke();
        }
    }
}
