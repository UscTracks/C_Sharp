
using System;

namespace USCTracks._1
{
    public static class TypeConversion
    {
        public static void Run()
        {
            // ============================================================
            // TOPIC 1: Implicit and Explicit Casting
            // ============================================================

            long x = 100;
            float y = x;

            // Implicit conversion from long to float.
            // float has a wider range than long. (exponent : بيسمحله يمثل أرقام كبيرة جدًا )
            // Precision may be lost.

            Console.WriteLine(y);

            double hh = 10;

            // double uses binary floating-point representation.
            // double has a much wider range than decimal.
            // double ممكن يحتوي على رقم كبير جدًا مش هيقدر decimal يستوعبه

            decimal yy = (decimal)hh;

            // Explicit casting is required because decimal
            // has a smaller range than double.

            Console.WriteLine(yy);


            /*
             * ============================================================
             * TOPIC 2: Difference Between Parse, Convert, and TryParse
             * ============================================================
             *
             * Parse:
             * - Converts valid text into a numeric value.
             * - Throws FormatException for invalid text.
             * - Throws ArgumentNullException for null.
             * - May throw OverflowException. (لو الرقم اللي بتحاولي تحوّليه أكبر أو أصغر من المدى)
             *
             * Convert:
             * - Converts between supported data types.
             * - Convert.ToInt32(null) returns 0.
             * - Throws FormatException for invalid numeric text.
             * - May throw OverflowException.
             *
             * TryParse:
             * - Returns true when parsing succeeds.
             * - Returns false for invalid numeric input.
             * - Uses an out parameter to store the result.
             * - Does not throw for invalid numeric text.
             */


            // ============================================================
            // EXAMPLE 1: Valid String
            // ============================================================

            string number = "123";

            int a = int.Parse(number);
            int b = Convert.ToInt32(number);
            bool success = int.TryParse(number, out int c);

            Console.WriteLine(a);       // 123
            Console.WriteLine(b);       // 123
            Console.WriteLine(success); // True
            Console.WriteLine(c);       // 123


            // ============================================================
            // EXAMPLE 2: Invalid String
            // ============================================================

            string invalidNumber = "Hello";

            // int p = int.Parse(invalidNumber);
            // Throws FormatException.

            // int z = Convert.ToInt32(invalidNumber);
            // Throws FormatException.

            bool isValid = int.TryParse(invalidNumber, out int result);

            Console.WriteLine(isValid); // False
            Console.WriteLine(result);  // 0


            // ============================================================
            // EXAMPLE 3: Null String
            // ============================================================

            string? nullValue = null;

            // int p = int.Parse(nullValue!);
            // Throws ArgumentNullException.

            int q = Convert.ToInt32(nullValue);
            Console.WriteLine(q); // 0

            bool parsed = int.TryParse(nullValue, out int r);

            Console.WriteLine(parsed); // False
            Console.WriteLine(r);      // 0


            // ============================================================
            // EXAMPLE 4: Convert Supports Other Data Types
            // ============================================================

            double price = 10.6;

            int converted = Convert.ToInt32(price);

            Console.WriteLine(converted); // 11

            // int parsedPrice = int.Parse(price);
            // Compile-time Error.


            // ============================================================
            // EXAMPLE 5: Practical User Input
            // ============================================================

            Console.Write("Enter your age: ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int age))
            {
                Console.WriteLine($"Your age is {age}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }


            /*
             * ============================================================
             * DISCUSSION QUESTIONS
             * ============================================================
             *
             * Q1: Which method is safer for user input?
             * Answer: TryParse.
             *
             * Q2: Difference between Parse and TryParse?
             * Answer:
             * Parse returns a value or throws an exception.
             * TryParse returns bool and uses an out parameter.
             *
             * Q3: Difference between Parse and Convert?
             * Answer:
             * Parse converts text into a target type.
             * Convert supports conversions between different types.
             *
             * Q4: Why does TryParse use out?
             * Answer:
             * To return the parsed value alongside the success status.
             *
             * Q5: When should we use each method?
             * Parse    -> Expected valid text.
             * Convert  -> Supported conversions between data types.
             * TryParse -> Potentially invalid user input.
             */
        }
    }
}
