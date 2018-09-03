using System;

namespace MX.Util.MathUtil.Geometery {

    public static class GeoMath {

        /// <summary>
        /// Determines if a point is in a rect
        /// </summary>
        /// <param name="p">The point in question</param>
        /// <param name="rPos">the top-right position of the rect</param>
        /// <param name="rWidth">rect width</param>
        /// <param name="rHeight">rect height</param>
        /// <returns>true if the point is in the rect</returns>
        public static bool IsInRect(PointF p, PointF rPos, int rWidth, int rHeight)
        {
            return (p.X > rPos.X && p.X < (rPos.X + rWidth)) &&
                   (p.Y > rPos.Y && p.Y < (rPos.Y + rHeight));

        }

        /// <summary>
        /// Gets the squared distance between two points.
        /// 
        /// Often the squared distance is faster to calculate, 
        /// and squared distances can be compared relatively
        /// </summary>
        /// <param name="p1">point 1 </param>
        /// <param name="p2">point2</param>
        /// <returns>The squared distance between the points</returns>
        public static double GetDistanceSq(PointF p1, PointF p2)
        {

            double dx = (p2.X - p1.X);
            double dy = (p2.Y - p1.Y);

            return (dx * dx) + (dy * dy);
        }


        /// <summary>
        /// Gets the distance between two points
        /// </summary>
        /// <param name="p1">point 1 </param>
        /// <param name="p2">point2</param>
        /// <returns>The distance between the points</returns>
        public static double GetDistance(PointF p1, PointF p2)
        {

            double dx = (p2.X - p1.X);
            double dy = (p2.Y - p1.Y);

            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        /// <summary>
        /// Determines if a given point is within a circle
        /// </summary>
        /// <param name="p">The point in question</param>
        /// <param name="cPos">center of the circle</param>
        /// <param name="r">radius of the circle</param>
        /// <returns></returns>
        public static bool IsInCircle(PointF p, PointF cPos, float r)
        {
            return GetDistanceSq(p, cPos) < (r * r);
        }
    }
}

