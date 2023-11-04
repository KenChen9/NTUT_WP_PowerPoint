using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class PointerState : IState
    {
        private Model _model;

        public PointerState(Model model)
        {
            _model = model;
        }

        public void PressMouse()
        {

        }

        public void MoveMouse(int x, int y)
        {

        }

        public void ReleaseMouse()
        {

        }
    }
}
