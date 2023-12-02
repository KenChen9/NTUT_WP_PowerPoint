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
    public class ShapesTests
    {
        [TestMethod()]
        public void AddTest()
        {
            {
                Shapes shapes = new Shapes();
                shapes.Add("線");
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Line));
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add("矩形");
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(MyRectangle));
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add("圓");
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Circle));
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add("A");
                Assert.AreEqual(0, shapes.ShapeList.Count);
            }
        }

        [TestMethod()]
        public void AddTest1()
        {
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Line));
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Line));
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Rectangle));
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(MyRectangle));
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Circle));
                Assert.AreEqual(1, shapes.ShapeList.Count);
                Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Circle));
            }
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Line));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle));
            shapes.Add(Factory.CreateShape(ShapeType.Circle));
            Assert.AreEqual(3, shapes.ShapeList.Count);
            Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Line));
            Assert.IsInstanceOfType(shapes.ShapeList[1], typeof(MyRectangle));
            Assert.IsInstanceOfType(shapes.ShapeList[2], typeof(Circle));
            shapes.RemoveAt(1);
            Assert.AreEqual(2, shapes.ShapeList.Count);
            Assert.IsInstanceOfType(shapes.ShapeList[0], typeof(Line));
            Assert.IsInstanceOfType(shapes.ShapeList[1], typeof(Circle));
        }

        [TestMethod()]
        public void ClearAllTest()
        {
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Line));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle));
            shapes.Add(Factory.CreateShape(ShapeType.Circle));
            Assert.AreEqual(3, shapes.ShapeList.Count);
            shapes.ClearAll();
            Assert.AreEqual(0, shapes.ShapeList.Count);
        }

        [TestMethod()]
        public void IsShapeOverlapTest()
        {
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6)));
            Assert.IsTrue(shapes.IsShapeOverlap(0, new Point(1, 2)));
            Assert.IsTrue(shapes.IsShapeOverlap(1, new Point(4, 4)));
            Assert.IsTrue(shapes.IsShapeOverlap(2, new Point(4, 4)));
        }

        [TestMethod()]
        public void FindShapeSupportCircleOverlapIndexTest()
        {
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6)));

            Assert.AreEqual(1, shapes.FindShapeSupportCircleOverlapIndex(0, new Point(3, 4)));
            Assert.AreEqual(1, shapes.FindShapeSupportCircleOverlapIndex(0, new Point(5, 6)));
            Assert.AreEqual(-1, shapes.FindShapeSupportCircleOverlapIndex(0, new Point(0, 10)));

            Assert.AreEqual(2, shapes.FindShapeSupportCircleOverlapIndex(1, new Point(3, 4)));
            Assert.AreEqual(2, shapes.FindShapeSupportCircleOverlapIndex(1, new Point(5, 6)));
            Assert.AreEqual(-1, shapes.FindShapeSupportCircleOverlapIndex(1, new Point(0, 10)));

            Assert.AreEqual(2, shapes.FindShapeSupportCircleOverlapIndex(2, new Point(3, 4)));
            Assert.AreEqual(2, shapes.FindShapeSupportCircleOverlapIndex(2, new Point(5, 6)));
            Assert.AreEqual(-1, shapes.FindShapeSupportCircleOverlapIndex(2, new Point(0, 10)));
        }

        [TestMethod()]
        public void ResizeShapeTest()
        {
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
                shapes.ResizeShape(-1, -1, new Point(5, 5));
                shapes.ResizeShape(0, -1, new Point(6, 6));
                Assert.AreEqual("(3, 4), (5, 6)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
                shapes.ResizeShape(0, 1, new Point(7, 7));
                Assert.AreEqual("(7, 7), (5, 6)", shapes.ShapeList[0].Information);
                shapes.ResizeShape(0, 2, new Point(8, 8));
                Assert.AreEqual("(7, 7), (8, 8)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
                shapes.ResizeShape(0, 1, new Point(7, 7));
                Assert.AreEqual("(7, 7), (5, 6)", shapes.ShapeList[0].Information);
                shapes.ResizeShape(0, 2, new Point(8, 8));
                Assert.AreEqual("(7, 7), (8, 8)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6)));
                shapes.ResizeShape(0, 1, new Point(7, 7));
                Assert.AreEqual("(7, 7), (5, 6)", shapes.ShapeList[0].Information);
                shapes.ResizeShape(0, 2, new Point(8, 8));
                Assert.AreEqual("(7, 7), (8, 8)", shapes.ShapeList[0].Information);
            }
        }

        [TestMethod()]
        public void MoveShapeDeltaTest()
        {
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
                shapes.MoveShapeDelta(-1, new Point(1, 1));
                Assert.AreEqual("(3, 4), (5, 6)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
                shapes.MoveShapeDelta(0, new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
                shapes.MoveShapeDelta(0, new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", shapes.ShapeList[0].Information);
            }
            {
                Shapes shapes = new Shapes();
                shapes.Add(Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6)));
                shapes.MoveShapeDelta(0, new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", shapes.ShapeList[0].Information);
            }
        }

        [TestMethod()]
        public void SelectShapeIndexTest()
        {
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(5, 6), new Point(7, 8)));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(7, 8), new Point(9, 10)));
            Assert.AreEqual(-1, shapes.SelectShapeIndex(new Point(2, 3)));
            Assert.AreEqual(0, shapes.SelectShapeIndex(new Point(4, 5)));
            Assert.AreEqual(1, shapes.SelectShapeIndex(new Point(6, 7)));
            Assert.AreEqual(2, shapes.SelectShapeIndex(new Point(8, 9)));
        }

        [TestMethod()]
        public void DrawTest()
        {
            TestGraphics graphics = new TestGraphics();
            Shapes shapes = new Shapes();
            shapes.Add(Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6)));
            shapes.Add(Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6)));
            shapes.Draw(graphics, 2);

            Assert.AreEqual(ShapeColor.Red, graphics.ShapeColor);
            Assert.AreEqual(2, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
        }
    }
}