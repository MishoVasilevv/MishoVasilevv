using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    public class UndoRedoManager
    {
        private Stack<ICommand> undoStack = new();
        private Stack<ICommand> redoStack = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            undoStack.Push(command);
            redoStack.Clear();
        }

        public void Undo()
        {
            if (undoStack.Count > 0)
            {
                var command = undoStack.Pop();
                command.Undo();
                redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                var command = redoStack.Pop();
                command.Execute();
                undoStack.Push(command);
            }
        }
    }
}
