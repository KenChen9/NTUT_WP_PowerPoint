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
    public class CircleTests
    {
        [TestMethod()]
        public void CircleTest()
        {
            // Test Name
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("圓", circle.Name);
            }

            // Test Information
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("(3, 4), (5, 6)", circle.Information);
            }

            // Test MoveDelta
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                circle.MoveDelta(new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", circle.Information);
            }

            // Test Resize
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                circle.Resize(-1, new Point(6, 6));
                Assert.AreEqual("(3, 4), (5, 6)", circle.Information);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                circle.Resize(0, new Point(7, 7));
                Assert.AreEqual("(3, 4), (5, 6)", circle.Information);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                circle.Resize(1, new Point(8, 8));
                Assert.AreEqual("(8, 8), (5, 6)", circle.Information);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                circle.Resize(2, new Point(9, 9));
                Assert.AreEqual("(3, 4), (9, 9)", circle.Information);
            }
        }

        [TestMethod()]
        public void DrawTest()
        {
            Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
            TestGraphics graphics = new TestGraphics();
            circle.Draw(graphics, false);
            Assert.AreEqual(ShapeColor.Black, graphics.ShapeColor);
            Assert.AreEqual(1, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
        }

        [TestMethod()]
        public void IsOverlapTest()
        {
            Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
            Assert.IsTrue(circle.IsOverlap(new Point(4, 4)));
            Assert.IsFalse(circle.IsOverlap(new Point(0, 10)));
        }

        [TestMethod()]
        public void FindSupportCircleOverlapIndexTest()
        {
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = circle.FindSupportCircleOverlapIndex(new Point(3, 4));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = circle.FindSupportCircleOverlapIndex(new Point(5, 6));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = circle.FindSupportCircleOverlapIndex(new Point(9, 10));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                Circle circle = new Circle(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = circle.FindSupportCircleOverlapIndex(new Point(0, 10));
                Assert.AreEqual(-1, supportCircleOverlapIndex);
            }
        }
    }
}