using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawingMode : IState
    {
        private Model _model;
        private int _startX = 0;
        private int _startY = 0;
        private int _endX = 0;
        private int _endY = 0;
        
        public DrawingMode(Model model)
        {
            _model = model;
        }
        
        public void PressMouse()
        {
            
        }

        public void MoveMouse()
        {

        }

        public void ReleaseMouse()
        {

        }

        public void EnterPanel()
        {

        }

        public void LeavePanel()
        {

        }
    }
}
