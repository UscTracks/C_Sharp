// C# Core Concepts: checked, Formatting, Object, Types, Nullable, Enums, params, dynamic, and Arrays

using System.Globalization;

namespace CSharpCoreConcepts
{
    internal class Program
    {
        static void Main()
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            CheckedAndUnchecked();
            //ToStringAndFormatting();
            //ObjectAndOverride();
            //ValueTypesAndReferenceTypes();
            //NullableTypesAndNullOperators();
            //EnumsAndCasting();
            //ParamsKeyword();
            //DynamicKeyword();
            //Arrays();

        }

        // 1. checked and unchecked
        // Integer arithmetic can overflow. In a checked context, overflow throws
        // OverflowException. In an unchecked context, integral overflow wraps around.
        static void CheckedAndUnchecked()
        {
            Console.WriteLine("\n=== checked / unchecked ===");

            int max = int.MaxValue;
            Console.WriteLine($"int.MaxValue = {max}");

            try
            {
                checked
                {
                    int result = max + 1;
                    Console.WriteLine(result); // This line will not execute.
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow detected in checked context.");
            }

            unchecked
            {
                int wrapped = int.MaxValue + 1;
                Console.WriteLine($"Unchecked overflow result = {wrapped}");
            }

            // checked is useful when overflow would make a calculation incorrect.
            // Note: checked behavior is about integral arithmetic/conversions; it does
            // not make floating-point arithmetic throw on infinity or NaN.
        }

        // 2. ToString() and formatting
        // ToString() converts a value into a string representation.
        // Format specifiers control how numbers, dates, and other values are displayed.
        static void ToStringAndFormatting()
        {
            Console.WriteLine("\n=== ToString and formatting ===");

            int age = 21;
            string ageText = age.ToString();
            Console.WriteLine($"Age as text: {ageText}");

            double price = 1234.5;
            Console.WriteLine(price.ToString("F2", CultureInfo.InvariantCulture)); // 1234.50
            Console.WriteLine(price.ToString("C2", CultureInfo.GetCultureInfo("en-US"))); // Currency
            Console.WriteLine(price.ToString("N2", CultureInfo.InvariantCulture)); // 1,234.50

            int number = 42;
            Console.WriteLine(number.ToString("D5")); // 00042

            DateTime today = new DateTime(2026, 10, 26);
            Console.WriteLine(today.ToString("yyyy-MM-dd")); // 2026-10-26
            Console.WriteLine(today.ToString("dd MMM yyyy", CultureInfo.InvariantCulture));

            // Common numeric formats:
            // C = currency, F = fixed-point, N = number with separators, P = percentage,
            // D = decimal integer with optional leading zeros, X = hexadecimal.
            // Prefer explicit CultureInfo when output must be consistent across machines.
        }

        // 3. Every C# type ultimately derives from System.Object (also written as object),
        // except pointer types. Value types derive through System.ValueType.
        // Object defines methods such as ToString(), Equals(), GetHashCode(), and GetType().
        // override lets a derived class replace a virtual/abstract inherited implementation.
        static void ObjectAndOverride()
        {
            Console.WriteLine("\n=== object and override ===");

            object first = 123;
            object second = "Hello";
            Console.WriteLine(first.ToString()); // "123"
            Console.WriteLine(second.ToString()); // "Hello"
            Console.WriteLine(first.GetType().Name); // Int32
            Console.WriteLine(second.GetType().Name); // String

            Person person = new Person("Mona", 25);
            Console.WriteLine(person.ToString()); // Uses Person's override.
        }

        class Person
        {
            public string Name { get; }
            public int Age { get; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name}, age {Age}";
            }
        }

        // 4. Value types vs reference types
        // Value types store their value directly. Assigning one variable to another copies it.
        // Examples: int, double, bool, char, decimal, enum, and struct.
        // Reference-type variables store a reference to an object. Assigning the variable
        // copies the reference, so both variables can refer to the same object.
        // Examples: class, string, array, delegate, and interface variables.
        static void ValueTypesAndReferenceTypes()
        {
            Console.WriteLine("\n=== value types and reference types ===");

            int a = 10;
            int b = a;
            b = 99;
            Console.WriteLine($"a = {a}, b = {b}"); // a remains 10

            int[] array1 = { 1, 2, 3 };
            int[] array2 = array1;
            array2[0] = 100;
            Console.WriteLine($"array1[0] = {array1[0]}"); // 100: same array object

            // string is a reference type, but strings are immutable.
            // Operations that seem to modify a string create another string instead.
            string text1 = "Hello";
            string text2 = text1;
            text2 += " World";
            Console.WriteLine($"text1 = {text1}");
            Console.WriteLine($"text2 = {text2}");

            // Reference types can also be null. A non-nullable value type such as int
            // cannot be null unless it is made nullable (int?).
        }

        // 5. Nullable value types, ?, and ??
        // int? is shorthand for Nullable<int>. It can contain an int or null.
        // ?. is the null-conditional operator: access a member only if the left side isn't null.
        // ?? is the null-coalescing operator: use a fallback when the left side is null.
        static void NullableTypesAndNullOperators()
        {
            Console.WriteLine("\n=== nullable and null operators ===");

            int? score = null;
            Console.WriteLine(score.HasValue); // False
            Console.WriteLine(score ?? 0);     // 0

            score = 85;
            Console.WriteLine(score.Value);    // 85
            Console.WriteLine(score ?? 0);     // 85

            string? nickname = null; // Nullable reference annotation (with nullable enabled).
            Console.WriteLine(nickname?.ToUpper() ?? "NO NICKNAME");

            nickname = "Lina";
            Console.WriteLine(nickname?.ToUpper() ?? "NO NICKNAME");

            // ?: is the conditional (ternary) operator, not the same as nullable syntax:
            int mark = 70;
            string result = mark >= 50 ? "Passed" : "Failed";
            Console.WriteLine(result);

            // For nullable value types, avoid .Value unless you know HasValue is true.
            // Nullable reference annotations (string?) are compile-time warnings/analysis;
            // they do not create a different runtime string type.
        }

        // 6. Enums and casting
        // An enum defines a named set of integral constants.
        enum OrderStatus
        {
            Pending = 0,
            Processing = 1,
            Shipped = 2,
            Delivered = 3
        }

        static void EnumsAndCasting()
        {
            Console.WriteLine("\n=== enums and casting ===");

            OrderStatus status = OrderStatus.Shipped;
            Console.WriteLine(status);              // Shipped
            Console.WriteLine((int)status);         // 2

            int statusNumber = 3;
            OrderStatus converted = (OrderStatus)statusNumber;
            Console.WriteLine(converted);           // Delivered

            int unknownNumber = 99;
            OrderStatus unknown = (OrderStatus)unknownNumber;
            Console.WriteLine(unknown);             // 99, even though it isn't a declared member
            Console.WriteLine(Enum.IsDefined(typeof(OrderStatus), unknownNumber)); // False

            if (Enum.TryParse<OrderStatus>("Processing", out OrderStatus parsed))
            {
                Console.WriteLine($"Parsed status: {parsed}");
            }

            // Casting converts between compatible types. Explicit casts may lose information
            // (for example, double to int truncates the fractional part).
            double decimalNumber = 12.8;
            int wholeNumber = (int)decimalNumber;
            Console.WriteLine(wholeNumber); // 12
        }

        // 7. params keyword
        // params allows a method to accept zero or more arguments of the same array element type.
        // It must be the last parameter in the method's parameter list.
        static void ParamsKeyword()
        {
            Console.WriteLine("\n=== params keyword ===");

            Console.WriteLine(Sum(1, 2, 3)); // 6
            Console.WriteLine(Sum(10, 20));  // 30
            Console.WriteLine(Sum());        // 0

            int[] values = { 4, 5, 6 };
            Console.WriteLine(Sum(values));  // 15: an array can be passed too
        }

        static int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int number in numbers)
            {
                total += number;
            }
            return total;
        }

        // 8. dynamic keyword
        // dynamic postpones member/type checking until runtime.
        // It can be useful with dynamic APIs or interop, but errors may appear only while running.
        // Prefer var for normal local variables when the type is known at compile time.
        static void DynamicKeyword()
        {
            Console.WriteLine("\n=== dynamic keyword ===");

            dynamic value = 10;
            Console.WriteLine(value + 5); // 15

            value = "Hello";
            Console.WriteLine(value.ToUpper()); // HELLO

            // The following would compile, but fail at runtime because string has no MissingMethod():
            // value.MissingMethod();

            // var is different: var value = 10; is inferred as int and remains int.
        }

        // 9. Arrays
        // An array stores a fixed-size sequence of elements of one declared type.
        // Indexes are zero-based: the first element is at index 0.
        static void Arrays()
        {
            Console.WriteLine("\n=== arrays ===");

            int[] numbers = { 10, 20, 30 };
            Console.WriteLine(numbers[0]); // 10
            numbers[1] = 25;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"numbers[{i}] = {numbers[i]}");
            }

            string[] names = new string[3];
            names[0] = "Ali";
            names[1] = "Mona";
            names[2] = "Sara";

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            int[,] matrix = new int[2, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            Console.WriteLine(matrix[1, 2]); // 6

            // Array.Length returns the total number of elements.
            // Arrays have a fixed length after creation. Use List<T> when a resizable collection is needed.
        }
    }
}

/*
====================================
PRACTICE TASKS
====================================

1. checked:
   Create an int with the value int.MaxValue. Add 1 inside checked and handle the exception.

2. Formatting:
   Display 9876.5 as currency with two decimal places and display today's date as yyyy-MM-dd.

3. Object and override:
   Create a Product class with Name and Price. Override ToString() to return both values.

4. Value vs reference:
   Copy an int into another variable and change the copy. Then copy an int[] reference and change
   an element. Explain why the results differ.

5. Nullable:
   Create int? age = null. Print age ?? 18. Then assign 24 and print it again.
   Use ?. and ?? with a nullable string.

6. Enums:
   Create a TrafficLight enum with Red, Yellow, and Green. Convert Green to int and convert 0 back.
   Check whether an integer is a declared enum value using Enum.IsDefined.

7. params:
   Write a method called MultiplyAll(params int[] numbers) that returns the product.
   Test it with 2, 3, 4 and with no arguments.

8. dynamic:
   Store an integer in a dynamic variable, then assign a string. Try valid operations for both.
   In a comment, explain why an invalid member call may fail only at runtime.

9. Arrays:
   Create an array of five integers, fill it using a loop, then print the sum and the largest value.

10. Mixed challenge:
    Create an enum for a student's grade status, an array of marks, and a method using params
    to calculate a total. Format the average to two decimal places.
*/
