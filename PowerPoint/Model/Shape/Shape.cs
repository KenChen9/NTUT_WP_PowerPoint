using System.Diagnostics;

namespace PowerPoint
{
    public abstract class Shape
    {
        protected MyPoint First
        {
            get;
            set; 
        }

        protected MyPoint Second
        {
            get;
            set; 
        }

        public string Information
        {
            get => $"{First.Information}, {Second.Information}";
        }

        public abstract string Name
        {
            get;
        }

        protected Shape(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            First = first;
            Second = second;
        }

        protected Shape(Shape other)
        {
            Debug.Assert(other != null);
            First = other.First;
            Second = other.Second;
        }

        // Comment
        public Shape Move(MyPoint first)
        {
            Debug.Assert(first != null);
            return Offset(first - First);
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
        public abstract void Draw(IGraphics graphics, bool selected);

        // Comment
        public abstract bool IsOverlap(MyPoint cursorPoint);
    }
}
