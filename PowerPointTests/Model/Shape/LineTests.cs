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
    public class LineTests
    {
        [TestMethod()]
        public void LineTest()
        {
            // Test Name
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("線", line.Name);
            }

            // Test Information
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                Assert.AreEqual("(3, 4), (5, 6)", line.Information);
            }

            // Test MoveDelta
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                line.MoveDelta(new Point(1, 1));
                Assert.AreEqual("(4, 5), (6, 7)", line.Information);
            }

            // Test Resize
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                line.Resize(-1, new Point(6, 6));
                Assert.AreEqual("(3, 4), (5, 6)", line.Information);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                line.Resize(0, new Point(7, 7));
                Assert.AreEqual("(3, 4), (5, 6)", line.Information);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                line.Resize(1, new Point(8, 8));
                Assert.AreEqual("(8, 8), (5, 6)", line.Information);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                line.Resize(2, new Point(9, 9));
                Assert.AreEqual("(3, 4), (9, 9)", line.Information);
            }
        }

        [TestMethod()]
        public void DrawTest()
        {
            Line line = new Line(new Point(3, 4), new Point(5, 6));
            TestGraphics graphics = new TestGraphics();
            line.Draw(graphics, false);
            Assert.AreEqual(ShapeColor.Black, graphics.ShapeColor);
            Assert.AreEqual(1, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
            line.Draw(graphics, true);
            Assert.AreEqual(ShapeColor.Red, graphics.ShapeColor);
            Assert.AreEqual(2, graphics.PenWidth);
            Assert.AreEqual(new Point(3, 4), graphics.Point1);
            Assert.AreEqual(new Point(5, 6), graphics.Point2);
        }

        [TestMethod()]
        public void IsOverlapTest()
        {
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                Assert.IsTrue(line.IsOverlap(new Point(1, 2)));
                Assert.IsTrue(line.IsOverlap(new Point(0, 0)));
                Assert.IsFalse(line.IsOverlap(new Point(0, 10)));
            }
            {
                Line line = new Line(new Point(7, 8), new Point(7, 10));
                Assert.IsTrue(line.IsOverlap(new Point(7, 9)));
                Assert.IsFalse(line.IsOverlap(new Point(7, 20)));
            }
            {
                Line line = new Line(new Point(8, 7), new Point(10, 7));
                Assert.IsTrue(line.IsOverlap(new Point(9, 7)));
                Assert.IsFalse(line.IsOverlap(new Point(20, 7)));
            }
        }

        [TestMethod()]
        public void FindSupportCircleOverlapIndexTest()
        {
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = line.FindSupportCircleOverlapIndex(new Point(3, 4));
                Assert.AreEqual(1, supportCircleOverlapIndex);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = line.FindSupportCircleOverlapIndex(new Point(5, 6));
                Assert.AreEqual(1, supportCircleOverlapIndex);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = line.FindSupportCircleOverlapIndex(new Point(9, 10));
                Assert.AreEqual(2, supportCircleOverlapIndex);
            }
            {
                Line line = new Line(new Point(3, 4), new Point(5, 6));
                int supportCircleOverlapIndex = line.FindSupportCircleOverlapIndex(new Point(0, 10));
                Assert.AreEqual(-1, supportCircleOverlapIndex);
            }
        }
    }
}