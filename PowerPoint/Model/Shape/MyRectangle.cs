using System.Diagnostics;

namespace PowerPoint
{
    public class MyRectangle : Shape
    {
        public override string Name
        {
            get
            {
                const string RECTANGLE = "矩形";
                return RECTANGLE;
            }
        }

        public MyRectangle(MyPoint first, MyPoint second) : base(first, second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
        }

        public MyRectangle(MyRectangle other) : base(other)
        {
            Debug.Assert(other != null);
        }

        // Comment
        public override Shape Clone()
        {
            return new MyRectangle(this);
        }

        // Comment
        public override Shape Offset(MyPoint delta)
        {
            Debug.Assert(delta != null);
            return new MyRectangle(_first + delta, _second + delta);
        }

        // Comment
        public override Shape Scale(MyPoint scalar)
        {
            Debug.Assert(scalar != null);
            return new MyRectangle(_first.MultiplyElementwise(scalar), _second.MultiplyElementwise(scalar));
        }

        // Comment
        public override Shape Resize(MyPoint point, MyPoint destination)
        {
            Debug.Assert(point != null);
            Debug.Assert(destination != null);
            if (_first.IsNear(point))
            {
                return new MyRectangle(destination, _second);
            }
            if (_second.IsNear(point))
            {
                return new MyRectangle(_first, destination);
            }
            return this;
        }

        // Comment
        public override bool IsOverlap(MyPoint other)
        {
            Debug.Assert(other != null);
            return other.IsBetweenX(_first, _second) && other.IsBetweenY(_first, _second);
        }

        // Comment
        public override void Draw(IGraphics graphics, bool selected)
        {
            Debug.Assert(graphics != null);
            graphics.DrawRectangle(selected, MyPoint.CreateRectangle(_first, _second));
        }
    }
}
