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
                Console.WriteLine("Enter expression:");
                String mathExpression = Console.ReadLine( );
                float[ ] numbers = new float[10];
                String operation = "a";
                String number = "";
                int index = 0;
                float result = 0;
                for (int i = 0; i < mathExpression.Length; i++) {
                    if (mathExpression[i].ToString( ) == "-" && number == "") {
                        number = number.Insert(0, "-");
                        continue;
                    }
                    if (mathExpression[i].ToString( ) == "/" || mathExpression[i].ToString( ) == "*" || mathExpression[i].ToString( ) == "-" || mathExpression[i].ToString( ) == "+" || mathExpression[i].ToString( ) == "=") {
                        numbers[index] = (float)Convert.ToDouble(number);
                        index++;
                        operation = mathExpression[i].ToString( );
                        number = "";
                    } else {
                        number += mathExpression[i].ToString( );
                        if (i == mathExpression.Length - 1) numbers[index] = (float)Convert.ToDouble(number);

                    }
                }
                Console.WriteLine(numbers[0] + " *** " + numbers[1] + " *** " + operation);
                if (operation == "*") result = multiplication(numbers[0], numbers[1]);
                if (operation == "/" && numbers[1] != 0.0) result = division(numbers[0], numbers[1]);
                if (operation == "+") result = summary(numbers[0], numbers[1]);
                if (operation == "-") result = difference(numbers[0], numbers[1]);
                if (operation != "a") Console.WriteLine(result);
        }
    }
}
