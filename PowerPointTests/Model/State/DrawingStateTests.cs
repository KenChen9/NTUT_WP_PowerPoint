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
    public class DrawingStateTests
    {
        [TestMethod()]
        public void DrawingStateTest()
        {
            Model model = new Model();
            DrawingState drawingState = new DrawingState(model);
            PrivateObject privateObject = new PrivateObject(drawingState);
            Assert.AreEqual(model, privateObject.GetField("_model"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_endPoint"));
            Assert.AreEqual(false, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));
    }

        [TestMethod()]
        public void PressMouseTest()
        {
            Model model = new Model();
            DrawingState drawingState = new DrawingState(model);
            PrivateObject privateObject = new PrivateObject(drawingState);
            Assert.AreEqual(false, privateObject.GetField("_pressed"));
            privateObject.Invoke("PressMouse", new Point(0, 0));
            Assert.AreEqual(true, privateObject.GetField("_pressed"));
        }

        [TestMethod()]
        public void MoveMouseTest()
        {
            Model model = new Model();
            DrawingState drawingState = new DrawingState(model);
            PrivateObject privateObject = new PrivateObject(drawingState);

            privateObject.Invoke("MoveMouse", new Point(5, 5));
            Assert.AreEqual(new Point(5, 5), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_endPoint"));
            Assert.AreEqual(false, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));

            privateObject.Invoke("MoveMouse", new Point(10, 10));
            privateObject.Invoke("PressMouse", new Point(10, 10));
            Assert.AreEqual(new Point(10, 10), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_endPoint"));
            Assert.AreEqual(true, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));

            privateObject.Invoke("MoveMouse", new Point(5, 5));
            Assert.AreEqual(new Point(10, 10), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(5, 5), privateObject.GetField("_endPoint"));
            Assert.AreEqual(true, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));
        }

        [TestMethod()]
        public void ReleaseMouseTest()
        {
            Model model = new Model();
            DrawingState drawingState = new DrawingState(model);
            PrivateObject privateObject = new PrivateObject(drawingState);

            privateObject.Invoke("MoveMouse", new Point(10, 10));
            privateObject.Invoke("PressMouse", new Point(10, 10));
            Assert.AreEqual(new Point(10, 10), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_endPoint"));
            Assert.AreEqual(true, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));

            privateObject.Invoke("ReleaseMouse", new Point(10, 10));
            Assert.AreEqual(new Point(10, 10), privateObject.GetField("_startPoint"));
            Assert.AreEqual(new Point(0, 0), privateObject.GetField("_endPoint"));
            Assert.AreEqual(false, privateObject.GetField("_pressed"));
            Assert.IsNull(privateObject.GetField("_preview"));
        }

        [TestMethod()]
        public void DrawTest()
        {
            Model model = new Model();
            DrawingState drawingState = new DrawingState(model);
            PrivateObject privateObject = new PrivateObject(drawingState);

            privateObject.SetField("_preview", Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
            TestGraphics graphics = new TestGraphics();
            privateObject.Invoke("Draw", graphics);
            Assert.AreEqual(ShapeColor.Black, graphics.ShapeColor);
            Assert.AreEqual(1, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
        }
    }
}