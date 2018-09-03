using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.MathUtil.Randomness
{
    public static class RandomUtil
    {
        private const string EndOfFunctionErrorMessage = "GetWeightedRandomValue, shouldnt ever reach the end of the function. Something has gone wrong";
        private const string ZeroWeightErrorMessage    = "At least one item must have weight";
        
        /// <summary>
        /// Where Key is any value, and the Value is a random weight. The higher the value the more randomness is weight toward that value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static T GetWeightedRandomValue<T>(Dictionary<T, int> dictionary) {
            int max = dictionary.Sum(entry => entry.Value);
            if (max <= 0)
                throw new ArgumentException(ZeroWeightErrorMessage);
            int random = StaticRandom.Next(0, max);

            foreach (var entry in dictionary) {
                if (random < entry.Value)
                    return entry.Key;
                random -= entry.Value;
            }

            throw new Exception(EndOfFunctionErrorMessage);
        }

        public static T GetWeightedRandomValue<T>(IEnumerable<T> list, Func<T, int> weightFunc) {

            int max = list.Sum(item => weightFunc(item));
            if (max <= 0)
                throw new ArgumentException(ZeroWeightErrorMessage);
            int random = StaticRandom.Next(0, max);

            foreach (var item in list) {
                if (random < weightFunc(item))
                    return item;
                random -= weightFunc(item);
            }

            throw new Exception(EndOfFunctionErrorMessage);
        }
    }
}
