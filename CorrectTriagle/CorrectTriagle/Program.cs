using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectTriagle {
    public class Program {

        public static bool isCorrectTriagle(float a, float b, float c) {
            if (float.IsNaN(a) || float.IsNaN(b) || float.IsNaN(c)) throw new Exception("Must be number");
            if (a <= 0 || b <= 0 || c <= 0) throw new Exception("Must be positive");
            if ((float.IsInfinity(a) && float.IsInfinity(b)) ||
                (float.IsInfinity(a) && float.IsInfinity(c)) ||
                (float.IsInfinity(b) && float.IsInfinity(c))) throw new Exception("Uncertainty");
            if (float.IsInfinity(a) || float.IsInfinity(b) || float.IsInfinity(c)) return false;
            if (a >= b && a >= c) return a < b + c;
            if (b >= a && b >= c) return b < a + c;
            return c < a + b;
        }

        static void Main(string[ ] args) {
            bool triagle1 = isCorrectTriagle((float)6.0, (float)3.0000000000009, (float)9.0);
            Console.WriteLine("6, (float)3.00000000000009, 9 - " + (triagle1 ? "is triagle" : "not triagle"));
            bool triagle2 = isCorrectTriagle((float)6.3, (float)3.20000000000009, (float)9.5);
            Console.WriteLine("6.3, (float)3.200000000000009, 9.5 - " + (triagle2 ? "is triagle" : "not triagle"));
            /*bool triagle2 = isCorrectTriagle(3, 4, 2);
             Console.WriteLine("3, 4, 2 - " + (triagle2 ? "is triagle" : "not triagle"));
             bool triagle3 = isCorrectTriagle(5, 2, 2);
             Console.WriteLine("5, 2, 2 - " + (triagle3 ? "is triagle" : "not triagle"));
             bool triagle4 = isCorrectTriagle(2, 2, 2);
             Console.WriteLine("2, 2, 2 - " + (triagle4 ? "is triagle" : "not triagle"));
             bool triagle5 = isCorrectTriagle(float.PositiveInfinity, float.PositiveInfinity, 2);*/
            Console.ReadLine( );
        }
    }
}
