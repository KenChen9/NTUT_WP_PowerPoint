using System;
using System.Diagnostics;

namespace PowerPoint
{
    public class MyPoint
    {
        private double _x, _y;

        public string Information
        {
            get
            {
                const string FORMAT_PART1 = "(";
                const string FORMAT_PART2 = ", ";
                const string FORMAT_PART3 = ")";
                return FORMAT_PART1 + _x + FORMAT_PART2 + _y + FORMAT_PART3;
            }
        }

        public double Length
        {
            get => Math.Sqrt(_x * _x + _y * _y);
        }

        public MyPoint(double x, double y)
        {
            Debug.Assert(x >= 0 && x < 1);
            Debug.Assert(y >= 0 && y < 1);
            _x = x;
            _y = y;
        }

        public MyPoint(MyPoint other)
        {
            Debug.Assert(other != null);
            _x = other._x;
            _y = other._y;
        }

        // Comment
        public MyPoint Clone()
        {
            return new MyPoint(this);
        }

        // Comment
        public MyPoint MultiplyElementwise(MyPoint other)
        {
            Debug.Assert(other != null);
            return new MyPoint(_x * other._x, _y * other._y);
        }

        // Comment
        public bool HasSameX(MyPoint other)
        {
            Debug.Assert(other != null);
            return _x == other._x;
        }

        // Comment
        public bool HasSameY(MyPoint other)
        {
            Debug.Assert(other != null);
            return _y == other._y;
        }

        // Comment
        public bool IsBetweenX(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            return Math.Min(first._x, second._x) <= _x && _x <= Math.Max(first._x, second._x);
        }

        // Comment
        public bool IsBetweenY(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            return Math.Min(first._y, second._y) <= _y && _y <= Math.Max(first._y, second._y);
        }

        // Comment
        public bool IsOnLine(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            return (_y - first._y) * (second._x - first._x) == (_x - first._x) * (second._y - first._y);
        }

        // Comment
        public bool IsInCircle(MyPoint first, MyPoint second)
        {
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            throw new NotImplementedException();
        }

        // Comment
        public bool IsNear(MyPoint other)
        {
            Debug.Assert(other != null);
            const double TOLERANCE = 6;
            double distanceX = _x - other._x;
            double distanceY = _y - other._y;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY) <= TOLERANCE;
        }

        public static MyPoint operator +(MyPoint left, MyPoint right)
        {
            Debug.Assert(left != null);
            Debug.Assert(right != null);
            return new MyPoint(left._x + right._x, left._y + right._y);
        }

        public static MyPoint operator -(MyPoint right)
        {
            Debug.Assert(right != null);
            return new MyPoint(-right._x, -right._y);
        }

        public static MyPoint operator -(MyPoint left, MyPoint right)
        {
            Debug.Assert(left != null);
            Debug.Assert(right != null);
            return left + (-right);
        }

        public static MyPoint operator *(double scalar, MyPoint right)
        {
            Debug.Assert(right != null);
            return new MyPoint(scalar + right._x, scalar + right._y);
        }
    }
}
