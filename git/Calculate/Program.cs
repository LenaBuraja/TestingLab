using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate {
    class Program {

        static float summary(float x, float y) {
            return (x + y);
        }

        static float difference(float x, float y) {
            return (x - y);
        }

        static float multiplication(float x, float y) {
            return (x * y);
        }

        static float division(float x, float y) {
            return (x / y);
        }

        static void Main(string[ ] args) {
            float[ ] numbers = new float[10];
            numbers[0] = 4;
            numbers[1] = 6;
            String operation = "*";
            float result = 0;
            if (operation == "*") result = multiplication(numbers[0], numbers[1]);
            if (operation == "/" && numbers[1] != 0.0) result = division(numbers[0], numbers[1]);
            if (operation == "+") result = summary(numbers[0], numbers[1]);
            if (operation == "-") result = difference(numbers[0], numbers[1]);
            Console.WriteLine(result);
            Console.ReadLine( );
        }
    }
}
