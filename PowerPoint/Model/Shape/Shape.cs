using System;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Abstract base class representing a shape in a PowerPoint presentation.
    /// </summary>
    public abstract class Shape
    {
        protected Point Point1
        {
            get;
            set; 
        }

        protected Point Point2
        {
            get;
            set; 
        }

        public abstract string Name
        {
            get;
        }

        public string Information
        {
            get
            {
                const string FORMAT_PART1 = "(";
                const string FORMAT_PART2 = ", ";
                const string FORMAT_PART3 = "), (";
                const string FORMAT_PART4 = ", ";
                const string FORMAT_PART5 = ")";
                return FORMAT_PART1 + Point1.X + FORMAT_PART2 + Point1.Y + FORMAT_PART3 + Point2.X + FORMAT_PART4 + Point2.Y + FORMAT_PART5;
            }
        }

        protected Shape(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        /// <summary>
        /// MoveDelta
        /// </summary>
        public void MoveDelta(Point deltaDirection)
        {
            Point1 = new Point(Point1.X + deltaDirection.X, Point1.Y + deltaDirection.Y);
            Point2 = new Point(Point2.X + deltaDirection.X, Point2.Y + deltaDirection.Y);
        }

        /// <summary>
        /// Transform
        /// </summary>
        public void Resize(int supportCircleIndex, Point point)
        {
            switch (supportCircleIndex)
            {
                case 1:
                    Point1 = point;
                    break;
                case 2:
                    Point2 = point;
                    break;
            }
        }

        /// <summary>
        /// GetTwoPointDistance
        /// </summary>
        protected static double GetTwoPointDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        /// <summary>
        /// Draws the shape using the specified graphics object and shape color.
        /// </summary>
        public abstract void Draw(IGraphics graphics, bool selected);

        /// <summary>
        /// IsOverlap
        /// </summary>
        public abstract bool IsOverlap(Point cursorPoint);

        /// <summary>
        /// FindSupportCircleOverlapIndex
        /// </summary>
        public abstract int FindSupportCircleOverlapIndex(Point cursorPoint);
    }
}
