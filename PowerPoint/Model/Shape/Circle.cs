using System.Diagnostics;

namespace PowerPoint
{
    public class Circle : Shape
    {
        public override string Name
        {
            get
            {
                const string CIRCLE = "圓";
                return CIRCLE;
            }
        }

        public Circle(MyPoint first, MyPoint second) : base(first, second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
        }

        public Circle(Circle other) : base(other)
        {
            Debug.Assert(other != null);
        }

        // Comment
        public override Shape Clone()
        {
            return new Circle(this);
        }

        // Comment
        public override Shape Offset(MyPoint delta)
        {
            Debug.Assert(delta != null);
            return new Circle(_first + delta, _second + delta);
        }

        // Comment
        public override Shape Scale(MyPoint scalar)
        {
            Debug.Assert(scalar != null);
            return new Circle(_first.MultiplyElementwise(scalar), _second.MultiplyElementwise(scalar));
        }

        // Comment
        public override Shape Resize(MyPoint point, MyPoint destination)
        {
            Debug.Assert(point != null);
            Debug.Assert(destination != null);
            if (_first.IsNear(point))
            {
                return new Circle(destination, _second);
            }
            if (_second.IsNear(point))
            {
                return new Circle(_first, destination);
            }
            return Clone();
        }

        // Comment
        public override bool IsOverlap(MyPoint other)
        {
            Debug.Assert(other != null);
            return other.IsInCircle(_first, _second);
        }

        // Comment
        public override void Draw(IGraphics graphics, bool selected)
        {
            Debug.Assert(graphics != null);
            graphics.DrawCircle(selected, _first, _second);
        }
    }
}
