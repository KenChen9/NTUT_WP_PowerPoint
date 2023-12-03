using System.Diagnostics;

namespace PowerPoint
{
    public abstract class Shape
    {
        protected MyPoint _first, _second;

        public string Information
        {
            get
            {
                const string FORMAT_PART = ", ";
                return _first.Information + FORMAT_PART + _second.Information;
            }
        }

        public abstract string Name
        {
            get;
        }

        protected Shape(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            _first = first;
            _second = second;
        }

        public Shape(Shape other) : this(other._first.Clone(), other._second.Clone())
        {
            Debug.Assert(other != null);
        }

        // Comment
        public Shape Move(MyPoint first)
        {
            Debug.Assert(first != null);
            return Offset(first - _first);
        }

        // Comment
        public abstract Shape Clone();

        // Comment
        public abstract Shape Offset(MyPoint delta);

        // Comment
        public abstract Shape Scale(MyPoint scalar);

        // Comment
        public abstract Shape Resize(MyPoint point, MyPoint destination);

        // Comment
        public abstract bool IsOverlap(MyPoint other);

        // Comment
        public abstract void Draw(IGraphics graphics, bool selected);
    }
}
