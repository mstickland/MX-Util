﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.MathUtil
{
    [DebuggerDisplay("[X={X},Y={Y}]")]
    public struct Point
    {

        /// <summary>
        /// Horizontal component
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Vertical component
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// subtraction operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator -(Point lhs, Point rhs)
        {
            return new Point(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        /// <summary>
        /// addition operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator +(Point lhs, Point rhs)
        {
            return new Point(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        /// <summary>
        /// multiplication operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator *(Point lhs, Point rhs)
        {
            return new Point(lhs.X * rhs.X, lhs.Y * rhs.Y);
        }

        /// <summary>
        /// division operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator /(Point lhs, Point rhs)
        {
            return new Point(lhs.X / rhs.X, lhs.Y / rhs.Y);
        }

        /// <summary>
        /// subtraction operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator -(Point lhs, int rhs)
        {
            return new Point(lhs.X - rhs, lhs.Y - rhs);
        }

        /// <summary>
        /// addition operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator +(Point lhs, int rhs)
        {
            return new Point(lhs.X + rhs, lhs.Y + rhs);
        }

        /// <summary>
        /// multiplication operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator *(Point lhs, int rhs)
        {
            return new Point(lhs.X * rhs, lhs.Y * rhs);
        }

        /// <summary>
        /// division operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Point operator /(Point lhs, int rhs)
        {
            return new Point(lhs.X / rhs, lhs.Y / rhs);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Point lhs, Point rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Point && this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[X: {0}, Y: {1}]", X, Y);
        }

    }
}
