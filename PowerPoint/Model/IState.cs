﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IState
    {
        void PressMouse();
        void MoveMouse();
        void ReleaseMouse();
        void EnterPanel();
        void LeavePanel();
    }
}
