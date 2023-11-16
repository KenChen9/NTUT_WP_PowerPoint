using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PowerPoint
{
    public class WindowsFormsGraphics : IGraphics
    {
        private Graphics _graphics;

        public WindowsFormsGraphics(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// Get the expected color pen by ShapeColor enum.
        /// </summary>
        private Pen GetPen(ShapeColor shapeColor, int penWidth)
        {
            switch (shapeColor)
            {
                case ShapeColor.Black:
                    return new Pen(Color.Black, penWidth);
                case ShapeColor.Red:
                    return new Pen(Color.Red, penWidth);
                default:
                    return null;
            }
        }

        /// <summary>
        /// GetTopLeftPoint
        /// </summary>
        private Point GetTopLeftPoint(Point point1, Point point2)
        {
            return new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
        }

        /// <summary>
        /// GetBottomRightPoint
        /// </summary>
        private Size GetTwoPointsRectangleSize(Point point1, Point point2)
        {
            return new Size(Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
        }

        /// <summary>
        /// GetLocationRectangle
        /// </summary>
        private Rectangle GetLocationRectangle(Point point1, Point point2)
        {
            return new Rectangle(GetTopLeftPoint(point1, point2), GetTwoPointsRectangleSize(point1, point2));
        }

        /// <summary>
        /// Draws a line with the specified shape color and coordinates.
        /// </summary>
        public void DrawLine(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    _graphics.DrawLine(pen, point1, point2);
                }
            }
        }

        /// <summary>
        /// Draws a rectangle with the specified shape color and coordinates.
        /// </summary>
        public void DrawRectangle(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    _graphics.DrawRectangle(pen, GetLocationRectangle(point1, point2));
                }
            }
        }

        /// <summary>
        /// Draws a circle with the specified shape color and coordinates.
        /// </summary>
        public void DrawCircle(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            DrawCircle(shapeColor, penWidth, GetLocationRectangle(point1, point2));
        }

        /// <summary>
        /// Draws a circle with the specified shape color and coordinates.
        /// </summary>
        public void DrawCircle(ShapeColor shapeColor, int penWidth, Rectangle location)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    _graphics.DrawEllipse(pen, location);
                }
            }
        }

        /// <summary>
        /// GetSupportCircleLocationPoint
        /// </summary>
        private Rectangle GetSupportCircleLocationRectangle(Point center, int radius)
        {
            int diameter = radius + radius;
            return new Rectangle(center.X - radius, center.Y - radius, diameter, diameter);
        }

        /// <summary>
        /// DrawSupportCircle
        /// </summary>
        private void DrawSupportCircle(Point center, int penWidth)
        {
            const int SUPPORT_CIRCLE_RADIUS = 4;
            DrawCircle(ShapeColor.Red, penWidth, GetSupportCircleLocationRectangle(center, SUPPORT_CIRCLE_RADIUS));
        }

        /// <summary>
        /// DrawDottedLine
        /// </summary>
        private void DrawDottedLine(ShapeColor shapeColor, int penWidth, Point point1, Point point2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    pen.DashStyle = DashStyle.Dot;
                    _graphics.DrawLine(pen, point1, point2);
                }
            }
        }

        /// <summary>
        /// DrawSupportLine
        /// </summary>
        private void DrawSupportLine(Point point1, Point point2, int penWidth)
        {
            DrawDottedLine(ShapeColor.Red, penWidth, point1, point2);
        }

        /// <summary>
        /// DrawLineSupportCircles
        /// </summary>
        public void DrawLineFrame(int penWidth, Point point1, Point point2)
        {
            const int TWO = 2;
            Point center = new Point((point1.X + point2.X) / TWO, (point1.Y + point2.Y) / TWO);
            DrawSupportCircle(center, penWidth);
            DrawSupportCircle(point1, penWidth);
            DrawSupportCircle(point2, penWidth);
        }

        /// <summary>
        /// DrawRectangleSupportCircles
        /// </summary>
        public void DrawRectangleFrame(int penWidth, Point point1, Point point2)
        {
            Point topRight = new Point(point2.X, point1.Y);
            Point bottomLeft = new Point(point1.X, point2.Y);
            DrawSupportCircle(topRight, penWidth);
            DrawSupportCircle(bottomLeft, penWidth);
            DrawSupportCircle(point1, penWidth);
            DrawSupportCircle(point2, penWidth);
        }

        /// <summary>
        /// DrawCircleSupportCircle
        /// </summary>
        public void DrawCircleFrame(int penWidth, Point point1, Point point2)
        {
            Point topRight = new Point(point2.X, point1.Y);
            Point bottomLeft = new Point(point1.X, point2.Y);
            DrawSupportLine(point1, topRight, penWidth);
            DrawSupportLine(topRight, point2, penWidth);
            DrawSupportLine(point2, bottomLeft, penWidth);
            DrawSupportLine(bottomLeft, point1, penWidth);
            DrawSupportCircle(topRight, penWidth);
            DrawSupportCircle(bottomLeft, penWidth);
            DrawSupportCircle(point1, penWidth);
            DrawSupportCircle(point2, penWidth);
        }
    }
}
