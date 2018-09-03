using MX.Util.MathUtil.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MX.Util.MathUtil.Randomness {

    public static class StaticRandom {

        private static Random _random;

        static StaticRandom() {
            _random = new Random();
        }

        public static void Seed(int seed) {
            _random = new Random(seed);
        }

        public static int Next() {
            return _random.Next();
        }


        public static int Next(IntRange range) {
            return _random.Next(range.Min, range.Max);
        }

        public static int Next(int maxVal) {
            return _random.Next(maxVal);
        }

        public static int Next(int minVal, int maxVal) {
            return _random.Next(minVal, maxVal);
        }

        public static double NextDouble() {
            return _random.NextDouble();
        }

        public static float NextFloat() {
            return (float)_random.NextDouble();
        }

        public static double NextDoubleWeighted() {
            double d = _random.NextDouble();
            return d * d;
        }

        public static float NextFloatWeighted() {
            float f = (float)_random.NextDouble();
            return f * f;
        }

        public static double NextDoubleWeighted(double weight) {
            return System.Math.Pow(_random.NextDouble(), weight);
        }

        public static float NextFloatWeighted(double weight) {
            return (float)System.Math.Pow(_random.NextDouble(), weight);
        }


    }
}
