using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.MathUtil.Sets
{
    [DebuggerDisplay("[{Min}-{Max}]")]
    public struct IntRange
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public static IntRange Any { get; } = new IntRange(int.MinValue, int.MaxValue);


        public IntRange(int max) : this(0, max) { }

        public IntRange(int min, int max) {
            Min = min;
            Max = max;
        }

        public static IntRange Range(int max) {
            if (max < 0)
                throw new ArgumentException("Max must be greater than min. Default min is 0. Try explicitly setting a min if you wish to have a max less than 0.");
            return new IntRange(max);
        }

        public static IntRange Range(int min, int max) {
            if (min > max)
                throw new ArgumentException("Max must be greater than min");
            return new IntRange(min, max);
        }

        public bool Contains(int num) {
            return num >= Min && num <= Max;
        }

        public bool ContainsExclusive(int num) {
            return num > Min && num < Max;
        }

        public bool ContainsMaxExclusive(int num) {
            return num >= Min && num < Max;
        }

        public bool ContainsMinExclusive(int num) {
            return num > Min && num <= Max;
        }

        public bool IsInside(IntRange range) {
            return range.Contains(Min) && range.Contains(Max);
        }

        public bool Contains(IntRange range) {
            return Contains(range.Min) && Contains(range.Max);
        }

        public IEnumerable<int> ToEnumerable() {
            return Enumerable.Range(Min, Max - Min);
        }

        public override string ToString() {
            return string.Format("[{0}-{1}]", Min, Max);
        }
    }

    public static class IntRangeUtil 
    {
        public static bool IsIn(this int @this, IntRange range) {
            return range.Contains(@this);
        }

        public static bool IsInExclusive(this int @this, IntRange range) {
            return range.ContainsExclusive(@this);
        }

        public static bool IsInMaxExclusive(this int @this, IntRange range) {
            return range.ContainsMaxExclusive(@this);
        }
    }
}
