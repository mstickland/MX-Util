using System;
using System.Linq;

namespace MX.Util.MathUtil.String {

    public class StringGenerator {


        /// <summary>
        /// Generates a random string of length 'length'
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length) {

            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
