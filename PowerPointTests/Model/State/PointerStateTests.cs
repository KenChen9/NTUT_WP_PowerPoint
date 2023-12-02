using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        [TestMethod()]
        public void PointerStateTest()
        {
            PointerState pointerState = new PointerState(new Model());
            Assert.Fail();
        }

        [TestMethod()]
        public void PressMouseTest()
        {
            PointerState pointerState = new PointerState(new Model());
            pointerState.PressMouse(new Point());
            Assert.Fail();
        }

        [TestMethod()]
        public void MoveMouseTest()
        {
            PointerState pointerState = new PointerState(new Model());
            pointerState.MoveMouse(new Point());
            Assert.Fail();
        }

        [TestMethod()]
        public void ReleaseMouseTest()
        {
            PointerState pointerState = new PointerState(new Model());
            pointerState.ReleaseMouse(new Point());
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest()
        {
            PointerState pointerState = new PointerState(new Model());
            pointerState.Draw(new TestGraphics());
        }
    }
}