using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PowerPoint
{
    public class CommandManager
    {
        private Stack<ICommand> _undo = new Stack<ICommand>();
        private Stack<ICommand> _redo = new Stack<ICommand>();

        public void Execute(ICommand command)
        {
            Debug.Assert(command != null);
            command.Execute();
            _undo.Push(command);
        }

        public void Undo()
        {
            Debug.Assert(_undo.Count >= 1);
            ICommand command = _undo.Pop();
            command.Undo();
            _redo.Push(command);
        }

        public void Redo()
        {
            Debug.Assert(_redo.Count >= 1);
            Execute(_redo.Pop());
        }
    }
}
