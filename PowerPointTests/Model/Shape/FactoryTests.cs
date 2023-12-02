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
    public class FactoryTests
    {
        [TestMethod()]
        public void CreateShapeTest()
        {
            Assert.IsInstanceOfType(Factory.CreateShape("線"), typeof(Line));
            Assert.IsInstanceOfType(Factory.CreateShape("矩形"), typeof(MyRectangle));
            Assert.IsInstanceOfType(Factory.CreateShape("圓"), typeof(Circle));
            Assert.IsNull(Factory.CreateShape("A"));
        }

        [TestMethod()]
        public void CreateShapeTest1()
        {
            Assert.IsInstanceOfType(Factory.CreateShape(ShapeType.Line), typeof(Line));
            Assert.IsInstanceOfType(Factory.CreateShape(ShapeType.Rectangle), typeof(MyRectangle));
            Assert.IsInstanceOfType(Factory.CreateShape(ShapeType.Circle), typeof(Circle));
            Assert.IsNull(Factory.CreateShape(ShapeType.Arrow));
        }

        [TestMethod()]
        public void CreateShapeTest2()
        {
            {
                Shape line = Factory.CreateShape(ShapeType.Line, new Point(3, 4), new Point(5, 6));
                Assert.IsInstanceOfType(line, typeof(Line));
                Assert.AreEqual("(3, 4), (5, 6)", line.Information);
            }
            {
                Shape rectangle = Factory.CreateShape(ShapeType.Rectangle, new Point(3, 4), new Point(5, 6));
                Assert.IsInstanceOfType(rectangle, typeof(MyRectangle));
                Assert.AreEqual("(3, 4), (5, 6)", rectangle.Information);
            }
            {
                Shape circle = Factory.CreateShape(ShapeType.Circle, new Point(3, 4), new Point(5, 6));
                Assert.IsInstanceOfType(circle, typeof(Circle));
                Assert.AreEqual("(3, 4), (5, 6)", circle.Information);
            }
        }
    }
}