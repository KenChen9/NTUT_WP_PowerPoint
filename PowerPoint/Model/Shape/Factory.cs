using System;

namespace PowerPoint
{
    public static class Factory
    {
        public static Shape CreateShape(string shapeType)
        {
            switch (shapeType)
            {
                case "線":
                    return CreateShape(ShapeType.Line);
                case "矩形":
                    return CreateShape(ShapeType.Rectangle);
                case "圓":
                    return CreateShape(ShapeType.Circle);
                default:
                    return null;
            }
        }

        public static Shape CreateShape(ShapeType shapeType)
        {
            int randomMin = 0;
            int randomMax = 500;
            Random random = new Random();
            int x1 = random.Next(randomMin, randomMax);
            int y1 = random.Next(randomMin, randomMax);
            int x2 = random.Next(randomMin, randomMax);
            int y2 = random.Next(randomMin, randomMax);
            return CreateShape(shapeType, x1, y1, x2, y2);
        }

        public static Shape CreateShape(ShapeType shapeType, int x1, int y1, int x2, int y2)
        {
            int topLeftX = Math.Min(x1, x2);
            int topLeftY = Math.Min(y1, y2);
            int bottomRightX = Math.Max(x1, x2);
            int bottomRightY = Math.Max(y1, y2);
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(x1, y1, x2, y2);
                case ShapeType.Rectangle:
                    return new MyRectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);
                case ShapeType.Circle:
                    return new Circle(topLeftX, topLeftY, bottomRightX, bottomRightY);
                default:
                    return null;
            }
        }
    }
}
