using System;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Abstract base class representing a shape in a PowerPoint presentation.
    /// </summary>
    public abstract class Shape
    {
        protected Point First
        {
            get;
            set; 
        }

        protected Point Second
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
                return FORMAT_PART1 + First.X + FORMAT_PART2 + First.Y + FORMAT_PART3 + Second.X + FORMAT_PART4 + Second.Y + FORMAT_PART5;
            }
        }

        protected Shape(Point point1, Point point2)
        {
            First = point1;
            Second = point2;
        }

        /// <summary>
        /// MoveDelta
        /// </summary>
        public void MoveDelta(Point deltaDirection)
        {
            First = new Point(First.X + deltaDirection.X, First.Y + deltaDirection.Y);
            Second = new Point(Second.X + deltaDirection.X, Second.Y + deltaDirection.Y);
        }

        /// <summary>
        /// Transform
        /// </summary>
        public void Resize(int supportCircleIndex, Point point)
        {
            switch (supportCircleIndex)
            {
                case 1:
                    First = point;
                    break;
                case 2:
                    Second = point;
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
