using System.Diagnostics;

namespace PowerPoint
{
    public class Line : Shape
    {
        public override string Name
        {
            get
            {
                const string LINE = "線";
                return LINE;
            }
        }

        public Line(MyPoint first, MyPoint second) : base(first, second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
        }

        public Line(Line other) : base(other)
        {
            Debug.Assert(other != null);
        }

        // Comment
        public override Shape Clone()
        {
            return new Line(this);
        }

        // Comment
        public override Shape Offset(MyPoint delta)
        {
            Debug.Assert(delta != null);
            return new Line(_first + delta, _second + delta);
        }

        // Comment
        public override Shape Scale(MyPoint scalar)
        {
            Debug.Assert(scalar != null);
            return new Line(_first.MultiplyElementwise(scalar), _second.MultiplyElementwise(scalar));
        }

        // Comment
        public override Shape Resize(MyPoint point, MyPoint destination)
        {
            Debug.Assert(point != null);
            Debug.Assert(destination != null);
            if (_first.IsNear(point))
            {
                return new Line(destination, _second);
            }
            if (_second.IsNear(point))
            {
                return new Line(_first, destination);
            }
            return Clone();
        }

        // Comment
        public override bool IsOverlap(MyPoint other)
        {
            Debug.Assert(other != null);
            if (_first.HasSameX(_second))
            {
                return other.IsBetweenY(_first, _second);
            }
            if (_first.HasSameY(_second))
            {
                return other.IsBetweenX(_first, _second);
            }
            return other.IsOnLine(_first, _second);
        }

        // Comment
        public override void Draw(IGraphics graphics, bool selected)
        {
            Debug.Assert(graphics != null);
            graphics.DrawLine(selected, _first, _second);
        }
    }
}
