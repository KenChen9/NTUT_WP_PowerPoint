using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    class TestGraphics : IGraphics
    {
        public ShapeColor ShapeColor
        {
            get;
            set;
        } = ShapeColor.Black;

        public int PenWidth
        {
            get;
            set;
        } = 0;

        public Point Point1
        {
            get;
            set;
        } = new Point(0, 0);

        public Point Point2
        {
            get;
            set;
        } = new Point(0, 0);

        public void DrawCircle(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            ShapeColor = shapeColor;
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }

        public void DrawCircleFrame(int penWidth, Point point1, Point point2)
        {
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }

        public void DrawLine(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            ShapeColor = shapeColor;
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }

        public void DrawLineFrame(int penWidth, Point point1, Point point2)
        {
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }

        public void DrawRectangle(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            ShapeColor = shapeColor;
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }

        public void DrawRectangleFrame(int penWidth, Point point1, Point point2)
        {
            PenWidth = penWidth;
            Point1 = point1;
            Point2 = point2;
        }
    }
}
