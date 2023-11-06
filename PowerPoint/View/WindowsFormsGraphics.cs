﻿using System;
using System.Drawing;

namespace PowerPoint
{
    /// <summary>
    /// Graphics class for drawing shapes using Windows Forms Graphics object.
    /// </summary>
    public class WindowsFormsGraphics : IGraphics
    {
        private Graphics _graphics;

        /// <summary>
        /// Initializes a new instance of the WindowsFormsGraphics class with the specified Graphics object.
        /// </summary>
        /// <param name="graphics">The Graphics object used for drawing.</param>
        public WindowsFormsGraphics(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// Get the expected color pen by ShapeColor enum.
        /// </summary>
        /// <param name="shapeColor">The expected color.</param>
        /// <returns>The pen by color.</returns>
        private Pen GetPen(ShapeColor shapeColor, int width)
        {
            switch (shapeColor)
            {
                case ShapeColor.Black:
                    return new Pen(Color.Black, width);
                case ShapeColor.Red:
                    return new Pen(Color.Red, width);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Draws a line with the specified shape color and coordinates.
        /// </summary>
        public void DrawLine(ShapeColor shapeColor, int penWidth, int x1, int y1, int x2, int y2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    _graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        /// <summary>
        /// Draws a rectangle with the specified shape color and coordinates.
        /// </summary>
        public void DrawRectangle(ShapeColor shapeColor, int penWidth, int x1, int y1, int x2, int y2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    int topLeftX = Math.Min(x1, x2);
                    int topLeftY = Math.Min(y1, y2);
                    int shapeWidth = Math.Abs(x1 - x2);
                    int shapeHeight = Math.Abs(y1 - y2);
                    _graphics.DrawRectangle(pen, topLeftX, topLeftY, shapeWidth, shapeHeight);
                }
            }
        }

        /// <summary>
        /// Draws a circle with the specified shape color and coordinates.
        /// </summary>
        public void DrawCircle(ShapeColor shapeColor, int penWidth, int x1, int y1, int x2, int y2)
        {
            using (Pen pen = GetPen(shapeColor, penWidth))
            {
                if (pen != null)
                {
                    int topLeftX = Math.Min(x1, x2);
                    int topLeftY = Math.Min(y1, y2);
                    int shapeWidth = Math.Abs(x1 - x2);
                    int shapeHeight = Math.Abs(y1 - y2);
                    _graphics.DrawEllipse(pen, topLeftX, topLeftY, shapeWidth, shapeHeight);
                }
            }
        }
    }
}
