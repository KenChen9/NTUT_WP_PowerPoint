using System;
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
            return new Line(First + delta, Second + delta);
        }

        // Comment
        public override Shape Scale(MyPoint scalar)
        {
            Debug.Assert(scalar != null);
            return new Line(First.MultiplyElementwise(scalar), Second.MultiplyElementwise(scalar));
        }

        // Comment
        public override Shape Resize(MyPoint point, MyPoint destination)
        {
            Debug.Assert(point != null);
            Debug.Assert(destination != null);
            if (First.IsNear(point))
            {
                return new Line(destination, Second);
            }
            if (Second.IsNear(point))
            {
                return new Line(First, destination);
            }
            return this;
        }

        // Comment
        public override bool IsOverlap(MyPoint other)
        {
            Debug.Assert(other != null);
            throw new NotImplementedException();
        }

        // Comment
        public override void Draw(IGraphics graphics, bool selected)
        {
            Debug.Assert(graphics != null);
            throw new NotImplementedException();
        }
    }
}
