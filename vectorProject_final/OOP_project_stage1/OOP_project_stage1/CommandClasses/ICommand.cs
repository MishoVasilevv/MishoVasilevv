using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_project_stage1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
