using System;
using System.Diagnostics;

namespace PowerPoint
{
    public class MyPoint
    {
        private double _x, _y;

        public string Information
        {
            get => $"({_x}, {_y})";
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

        public MyPoint Clone()
        {
            return new MyPoint(this);
        }

        public MyPoint MultiplyElementwise(MyPoint other)
        {
            Debug.Assert(other != null);
            return new MyPoint(_x * other._x, _y * other._y);
        }

        public bool IsNear(MyPoint other)
        {
            Debug.Assert(other != null);
            return Math.Sqrt(Math.Pow(_x - other._x, 2) + Math.Pow(_y - other._y, 2)) <= 6;
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
