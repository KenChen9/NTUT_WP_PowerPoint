using System;
using System.Diagnostics;

namespace PowerPoint
{
    public static class Factory
    {
        // Comment
        public static Shape CreateRandomShape(string shapeType)
        {
            const string LINE = "線";
            const string RECTANGLE = "矩形";
            const string CIRCLE = "圓";
            Debug.Assert(shapeType == LINE || shapeType == RECTANGLE || shapeType == CIRCLE);
            switch (shapeType)
            {
                case LINE:
                    return CreateRandomShape(ShapeType.Line);
                case RECTANGLE:
                    return CreateRandomShape(ShapeType.Rectangle);
                case CIRCLE:
                    return CreateRandomShape(ShapeType.Circle);
                default:
                    throw new Exception("未知的形狀類型。");
            }
        }

        // Comment
        public static Shape CreateRandomShape(ShapeType shapeType)
        {
            return CreateShape(shapeType, MyPoint.CreateRandom(), MyPoint.CreateRandom());
        }

        // Comment
        public static Shape CreateShape(ShapeType shapeType, MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(first, second);
                case ShapeType.Rectangle:
                    return new MyRectangle(first, second);
                case ShapeType.Circle:
                    return new Circle(first, second);
                default:
                    throw new Exception("未知的形狀類型。");
            }
        }
    }
}
