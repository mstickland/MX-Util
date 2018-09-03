using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.MathUtil.Sets
{
    public struct Range<T> where T : IComparable<T>
    {
        public T Min { get; private set; }
        public T Max { get; private set; }

        public Range(T min, T max) {
            Min = min;
            Max = max;
        }

        public static Range<T> RangeAddSomething(T min, T max) {
            if (min.CompareTo(max) < 0)
                throw new ArgumentException("Max must be greater than min");
            return new Range<T>(min, max);
        }

        public bool Contains(T num) {
            return num.CompareTo(Min) >= 0 && num.CompareTo(Max) <= 0;
        }

        public bool ContainsExclusive(T num) {
            return num.CompareTo(Min) > 0 && num.CompareTo(Max) < 0;
        }

        public bool ContainsMaxExclusive(T num) {
            return num.CompareTo(Min) >= 0 && num.CompareTo(Max) < 0;
        }

        public bool ContainsMinExclusive(T num) {
            return num.CompareTo(Min) >= 0 && num.CompareTo(Max) <= 0;
        }

        public bool IsInside(Range<T> range) {
            return range.Contains(Min) && range.Contains(Max);
        }

        public bool Contains(Range<T> range) {
            return Contains(range.Min) && this.Contains(range.Max);
        }

    }

}
