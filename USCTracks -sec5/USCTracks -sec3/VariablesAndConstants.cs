using System;
using System.Collections.Generic;
using System.Text;

namespace USCTracks__sec3
{
    public class VariablesAndConstants
    {
        // Constants
        // inline 
        // compile time
        public const double PI = 3.14159;

        // Readonly Fields
        // runtime
        public readonly int Id;
        public readonly DateTime CreatedAt = DateTime.Now;

        public VariablesAndConstants(int id)
        {
            Id = id;
        }

       

        public void ExplainVar()
        {
            // Explicitly Typed Variables
            int age = 20;
            // Implicitly Typed Variables
            // compile time
            var number = 10;
            var name = "Ahmed";
            var salary = 5000.5;

            Console.WriteLine(number.GetType());// System.Int32
            Console.WriteLine(number.GetType().Name); //Int32
            Console.WriteLine(name.GetType());
            Console.WriteLine(salary.GetType());

            number = 20; // Valid

            // number = "Ahmed"; // Compile Time Error
            // var x;           // Compile Time Error
            // var y = null;    // Compile Time Error
        }

        public void ExplainDynamic()
        {
            dynamic value = 10;

            Console.WriteLine(value.GetType());

            value = "Ahmed";
            Console.WriteLine(value.GetType());

            value = true;
            Console.WriteLine(value.GetType());

            value = "Hello";
            Console.WriteLine(value.Length);

            // value = 10;
            // Console.WriteLine(value.Length);
            // Runtime Error
        }

        public void ExplainObject()
        {
            object value = 10;
            Console.WriteLine(value.GetType());

            value = "Ahmed";
            Console.WriteLine(value.GetType());

            value = true;
            Console.WriteLine(value.GetType());

            object number = 100;

            // int x = number; // Compile Time Error

            int x = (int)number;
            Console.WriteLine(x);

            object name = "Ahmed";

            // Console.WriteLine(name.Length);
            // Compile Time Error

            Console.WriteLine(((string)name).Length);
        }

        public void ExplainConst()
        {
            // compile time
            const int MaxStudents = 30;

            Console.WriteLine(MaxStudents);
            Console.WriteLine(PI);

            // MaxStudents = 40; // Error
            // PI = 3.14;       // Error

            // const DateTime date = DateTime.Now;
            // Compile Time Error
        }

        public void ExplainReadonly()
        {
            Console.WriteLine(Id);
            Console.WriteLine(CreatedAt);

            // Id = 20; // Compile Time Error
        }

        public void Run()
        {
            Console.WriteLine("===== VAR =====");
            ExplainVar();

            Console.WriteLine("===== DYNAMIC =====");
            ExplainDynamic();

            Console.WriteLine("===== OBJECT =====");
            ExplainObject();

            Console.WriteLine("===== CONST =====");
            ExplainConst();

            Console.WriteLine("===== READONLY =====");
            ExplainReadonly();
        }
    }
}
