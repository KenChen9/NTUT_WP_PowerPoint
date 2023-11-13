﻿using System;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Represents a circle shape in a PowerPoint presentation.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Gets the name of the circle shape, which is "圓".
        /// </summary>
        public override string Name
        {
            get
            {
                const string CIRCLE = "圓";
                return CIRCLE;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Circle class with specified coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the starting point.</param>
        /// <param name="y1">The y-coordinate of the starting point.</param>
        /// <param name="x2">The x-coordinate of the ending point.</param>
        /// <param name="y2">The y-coordinate of the ending point.</param>
        public Circle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
            // Constructor logic, if any.
        }

        /// <summary>
        /// Draws the circle shape.
        /// </summary>
        public override void Draw(IGraphics graphics, bool selected)
        {
            if (selected)
            {
                const int PEN_WIDTH = 2;
                graphics.DrawCircle(ShapeColor.Red, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
                graphics.DrawCircleSupportCircle(ShapeColor.Red, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
            }
            else
            {
                const int PEN_WIDTH = 1;
                graphics.DrawCircle(ShapeColor.Black, PEN_WIDTH, new Point(_x1, _y1), new Point(_x2, _y2));
            }
        }

        /// <summary>
        /// IsOverlap
        /// </summary>
        public override bool IsOverlap(int cursorX, int cursorY)
        {
            const int ONE = 1;
            const int TWO = 2;
            double centerX = (_x1 + _x2) / TWO;
            double centerY = (_y1 + _y2) / TWO;
            double horizontalRadius = Math.Abs(_x1 - _x2) / TWO;
            double verticalRadius = Math.Abs(_y1 - _y2) / TWO;
            return Math.Pow((cursorX - centerX) / horizontalRadius, TWO) + Math.Pow((cursorY - centerY) / verticalRadius, TWO) <= ONE;
        }
    }
}
