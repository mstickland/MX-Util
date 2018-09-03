using System;

namespace MX.Util.MathUtil.Geometery {


    public struct Hex {

        public int Q { get; private set; }
        public int R { get; private set; }
        public int S => -Q - S;

        public Hex(int q, int r, int s)
        {
            if(q + r + s != 0)
                throw new Exception("x+y+z must equal 0");
            Q = q;
            R = r;            
        }

        public Hex(int q, int r)
        {            
            Q = q;
            R = r;
        }

        public PointF ToPixel() { 

            Orientation orient = Orientation.FlatTop;
            double x = (orient.f0 * Q + orient.f1 * R) * 1;//layout.size.x;
            double y = (orient.f2 * Q + orient.f3 * R) * 1;//layout.size.y;

            return new PointF();
        }

    }

    internal struct Orientation
    {
        public readonly float f0, f1, f2, f3;
        public readonly float b0, b1, b2, b3;

        public static readonly Orientation FlatTop = new Orientation(
                3.0f / 2.0f, 0.0f, (float)System.Math.Sqrt(3.0) / 2.0f, (float)System.Math.Sqrt(3.0f),
                2.0f / 3.0f, 0.0f, -1.0f / 3.0f, (float)System.Math.Sqrt(3.0) / 3.0f
        );

        internal Orientation(float f0_, float f1_, float f2_, float f3_,
                    float b0_, float b1_, float b2_, float b3_)
        {
            f0 = f0_;f1 = f1_;f2 = f2_;f3 = f3_;
            b0 = b0_; b1 = b1_; b2 = b2_; b3 = b3_;
        }

    }
}
