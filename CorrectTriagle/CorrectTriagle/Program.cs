using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectTriagle {
    public class Program {

        public static bool isTriagle(float a, float b, float c) {
            if (float.IsNaN(a) || float.IsNaN(b) || float.IsNaN(c)) return false;
            if (a <= 0 || b <= 0 || c <= 0) return false;
            if ((float.IsInfinity(a) && float.IsInfinity(b)) ||
                (float.IsInfinity(a) && float.IsInfinity(c)) ||
                (float.IsInfinity(b) && float.IsInfinity(c))) return false;
            if (float.IsInfinity(a) || float.IsInfinity(b) || float.IsInfinity(c)) return false;
            if (a >= b && a >= c) return a < b + c;
            if (b >= a && b >= c) return b < a + c;
            return c < a + b;
        }

        static void Main(string[ ] args) {
            bool triagle1 = isTriagle((float)6.3, (float)3.20000000000009, (float)9.5);
            Console.WriteLine("6.3, (float)3.200000000000009, 9.5 - " + (triagle1 ? "is triagle" : "not triagle"));
            bool triagle2 = isTriagle(3, 4, 2);
             Console.WriteLine("3, 4, 2 - " + (triagle2 ? "is triagle" : "not triagle"));
             bool triagle3 = isTriagle(5, 2, 2);
             Console.WriteLine("5, 2, 2 - " + (triagle3 ? "is triagle" : "not triagle"));
             bool triagle4 = isTriagle(2, 2, 2);
             Console.WriteLine("2, 2, 2 - " + (triagle4 ? "is triagle" : "not triagle"));
             bool triagle5 = isTriagle(float.PositiveInfinity, float.PositiveInfinity, 2);
            Console.ReadLine( );
        }
    }
}
