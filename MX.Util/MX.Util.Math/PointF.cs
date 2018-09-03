using System.Diagnostics;

namespace MX.Util.MathUtil {

    [DebuggerDisplay("[X={X},Y={Y}]")]
    public struct PointF {

        /// <summary>
        /// Horizontal component
        /// </summary>
        public float X { get; private set; }
        /// <summary>
        /// Vertical component
        /// </summary>
        public float Y { get; private set; }
        
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PointF(float x = 0.0f, float y = 0.0f) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// subtraction operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator -(PointF lhs, PointF rhs) {
            return new PointF(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        /// <summary>
        /// addition operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator +(PointF lhs, PointF rhs) {
            return new PointF(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        /// <summary>
        /// multiplication operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator *(PointF lhs, PointF rhs) {
            return new PointF(lhs.X * rhs.X, lhs.Y * rhs.Y);
        }

        /// <summary>
        /// division operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator /(PointF lhs, PointF rhs) {
            return new PointF(lhs.X / rhs.X, lhs.Y / rhs.Y);
        }

        /// <summary>
        /// subtraction operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator -(PointF lhs, float rhs) {
            return new PointF(lhs.X - rhs, lhs.Y - rhs);
        }

        /// <summary>
        /// addition operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator +(PointF lhs, float rhs) {
            return new PointF(lhs.X + rhs, lhs.Y + rhs);
        }

        /// <summary>
        /// multiplication operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator *(PointF lhs, float rhs) {
            return new PointF(lhs.X * rhs, lhs.Y * rhs);
        }

        /// <summary>
        /// division operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static PointF operator /(PointF lhs, float rhs) {
            return new PointF(lhs.X / rhs, lhs.Y / rhs);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(PointF lhs, PointF rhs) {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(PointF lhs, PointF rhs) {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }

        public override bool Equals(object obj) {
            return obj != null && obj is PointF && this == (PointF)obj;
        }

        public override int GetHashCode() {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString() {
            return string.Format("[X: {0}, Y: {1}]", X, Y); 
        }

    }
}
