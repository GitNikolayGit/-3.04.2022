using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkWpf
{
    internal class Utils
    {
        public static readonly Random random = new Random(Environment.TickCount);

        public static int GetRand(int lo, int hi) => random.Next(lo, hi + 1);
        public static double GetRand(double lo, double hi) => lo + (hi - lo) * random.NextDouble();
        public static char GetRand(char min = (char)0, char max = (char)255) =>
            (char)random.Next(min, max + 1);
    }
}
