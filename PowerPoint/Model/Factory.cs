using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Random random = new Random();
            int x1 = random.Next(0, 500);
            int y1 = random.Next(0, 500);
            int x2 = random.Next(x1, 500);
            int y2 = random.Next(y1, 500);
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(x1, y1, x2, y2);
                case ShapeType.Rectangle:
                    return new MyRectangle(x1, y1, x2, y2);
                case ShapeType.Circle:
                    return new Circle(x1, y1, x2, y2);
                default:
                    return null;
            }
        }
    }
}
