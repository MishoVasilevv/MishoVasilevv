using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1.CommandClasses
{
    class DeleteCommand : ICommand
    {
        private List<Shape> shapeList;
        private Shape shape;
        private Action onUpdate;

        public DeleteCommand(List<Shape> shapeList, Shape shape, Action onUpdate)
        {
            this.shapeList = shapeList;
            this.shape = shape;
            this.onUpdate = onUpdate;
        }

        public void Execute()
        {
            shapeList.Remove(shape);
            onUpdate?.Invoke();
        }

        public void Undo()
        {
            shapeList.Add(shape);
            onUpdate?.Invoke();
        }
    }
}
