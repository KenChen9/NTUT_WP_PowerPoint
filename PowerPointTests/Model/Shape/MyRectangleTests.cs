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
    public class MyRectangleTests
    {
        [TestMethod()]
        public void MyRectangleTest()
        {
            // Test Name
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("矩形", rectangle.Name);
            }

            // Test Information
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("(3, 4), (5, 6)", rectangle.Information);
            }

            // Test MoveDelta
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                rectangle.MoveDelta(new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", rectangle.Information);
            }

            // Test Resize
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                rectangle.Resize(-1, new Point(6, 6));
                Assert.AreEqual("(3, 4), (5, 6)", rectangle.Information);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                rectangle.Resize(0, new Point(7, 7));
                Assert.AreEqual("(3, 4), (5, 6)", rectangle.Information);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                rectangle.Resize(1, new Point(8, 8));
                Assert.AreEqual("(8, 8), (5, 6)", rectangle.Information);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                rectangle.Resize(2, new Point(9, 9));
                Assert.AreEqual("(3, 4), (9, 9)", rectangle.Information);
            }
        }

        [TestMethod()]
        public void DrawTest()
        {
            MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
            TestGraphics graphics = new TestGraphics();
            rectangle.Draw(graphics, false);
            Assert.AreEqual(ShapeColor.Black, graphics.ShapeColor);
            Assert.AreEqual(1, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
            rectangle.Draw(graphics, true);
            Assert.AreEqual(ShapeColor.Red, graphics.ShapeColor);
            Assert.AreEqual(2, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
        }

        [TestMethod()]
        public void IsOverlapTest()
        {
            MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
            Assert.IsTrue(rectangle.IsOverlap(new Point(4, 4)));
            Assert.IsFalse(rectangle.IsOverlap(new Point(0, 10)));
        }

        [TestMethod()]
        public void FindSupportCircleOverlapIndexTest()
        {
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = rectangle.FindSupportCircleOverlapIndex(new Point(3, 4));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = rectangle.FindSupportCircleOverlapIndex(new Point(5, 6));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = rectangle.FindSupportCircleOverlapIndex(new Point(9, 10));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                MyRectangle rectangle = new MyRectangle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = rectangle.FindSupportCircleOverlapIndex(new Point(0, 10));
                Assert.AreEqual(-1, supportCircleOverlapIndex);
            }
        }
    }
}