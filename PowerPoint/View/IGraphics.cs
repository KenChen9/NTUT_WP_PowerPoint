﻿namespace PowerPoint
{
    public interface IGraphics
    {
        void DrawLine(ShapeColor shapeColor, int x1, int y1, int x2, int y2);
        void DrawRectangle(ShapeColor shapeColor, int x1, int y1, int x2, int y2);
        void DrawCircle(ShapeColor shapeColor, int x1, int y1, int x2, int y2);
    }
}
