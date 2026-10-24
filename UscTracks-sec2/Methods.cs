using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Channels;

namespace USCTracks._1
{
    public static class Methods
    {

        /* 
         * =========================================================================
         * TOPIC 1: Introduction to Methods
         * =========================================================================
         * What is a Method?
         * A method is a reusable block of code containing a series of statements 
         * that performs a specific task. It only runs when it is called/invoked.
         * 
         * Why do we use Methods?
         * 1. Code Reusability: Write code once and reuse it (DRY - Don't Repeat Yourself).
         * 2. Organization: Break complex problems into smaller, manageable sub-problems.
         * 3. Maintainability: Easy to debug, update, and test individual functionalities.
         * 4. Readability: Keeps the Main method clean, descriptive, and structured.
         * =========================================================================
         * 
         *  public static int AddNumbers(int number1, int number2)
         {
            // English Comment: Calculates and returns an integer
             return number1 + number2;
          }
         */

        public static void MethodDemo()
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("          C# METHODS MASTERCLASS GUIDED DEMO       ");
                Console.WriteLine("==================================================\n");

                // --- 1. Basic Method Call ---
                Console.WriteLine("--- 1. Basic Method Call ---");
                PrintWelcomeMessage(); // Calling a void method without parameters

                // --- 2. Parameters & Arguments ---
                Console.WriteLine("\n--- 2. Parameters & Arguments ---");
                GreetUser("Ahmed"); // "Ahmed" is an Argument
                DisplayAgeAndCity("Sara", 22, "Cairo");

                // --- 3. Return Types ---
                Console.WriteLine("\n--- 3. Return Types ---");
                int sum = AddNumbers(15, 25);
                Console.WriteLine($"AddNumbers(15, 25) returned int: {sum}");

                string greetingText = GetFormattedGreeting("Mohamed");
                Console.WriteLine($"GetFormattedGreeting returned string: {greetingText}");

                double area = CalculateCircleArea(5.0);
                Console.WriteLine($"CalculateCircleArea(5.0) returned double: {area:F2}");

                bool isEven = IsEvenNumber(10);
                Console.WriteLine($"IsEvenNumber(10) returned bool: {isEven}");

                // --- 4. Optional & Named Parameters ---
                Console.WriteLine("\n--- 4. Optional & Named Parameters ---");
                PrintInvoice("Laptop", 1000.0); // Uses default taxRate (0.14) and discount (0.0)
                PrintInvoice("Phone", 500.0, 0.10); // Overrides taxRate with 0.10


                PrintInvoice(price: 250.0, itemName: "Headphones", discount: 20.0); // Named Arguments

                // --- 5. Method Overloading ---
                Console.WriteLine("\n--- 5. Method Overloading ---");
                Console.WriteLine($"Multiply(4, 5) [int, int]: {Multiply(4, 5)}");
                Console.WriteLine($"Multiply(2.5, 4.0) [double, double]: {Multiply(2.5, 4.0)}");
                Console.WriteLine($"Multiply(2, 3, 4) [int, int, int]: {Multiply(2, 3, 4)}");

                // --- 6. Passing Parameters (Value vs Ref vs Out) ---
                Console.WriteLine("\n--- 6. Passing Parameters (Value, ref, out) ---");
                int originalValue = 10;
                Console.WriteLine($"Before PassByValue: {originalValue}");
                PassByValue(originalValue);
                Console.WriteLine($"After PassByValue: {originalValue} (Unchanged: copy was modified)");

                Console.WriteLine($"\nBefore PassByRef: {originalValue}");
                PassByRef(ref originalValue);
                Console.WriteLine($"After PassByRef: {originalValue} (Changed: direct reference modified)");

                int score1 = 85, score2 = 92;
                double calculatedAverage;
                bool isPassed;
                GetStudentStats(score1, score2, out calculatedAverage, out isPassed);
                Console.WriteLine($"\nStudent Stats via out parameters -> Avg: {calculatedAverage:F1}, Passed: {isPassed}");

            // --- 7. Variable Scope ---
            Console.WriteLine("\n--- 7. Variable Scope Demonstration ---");
            DemonstrateScope();

            // --- 8. Practice Tasks Executions ---
            Console.WriteLine("\n==================================================");
            Console.WriteLine("          PRACTICE TASKS SOLUTIONS DEMO          ");
            Console.WriteLine("==================================================");

            // Task 1: Sum of Two Numbers
            int task1Result = CalculateSum(45, 55);
            Console.WriteLine($"[Task 1] Sum of 45 and 55: {task1Result}");

            // Task 2: Student Pass Status
            bool task2Result = IsStudentPassed(65.0);
            Console.WriteLine($"[Task 2] Is score 65.0 passing? {task2Result}");

            // Task 3: Average of Grades
            double[] studentGrades = { 88.5, 92.0, 79.5, 95.0, 84.0 };
            double task3Avg = CalculateAverageGrade(studentGrades);
            Console.WriteLine($"[Task 3] Average of grades Array: {task3Avg:F2}");

            // Task 4: Student Grade Letter
            char task4Grade = DetermineGradeLetter(task3Avg);
            Console.WriteLine($"[Task 4] Grade Letter for average {task3Avg:F2}: {task4Grade}");

            // Task 5: Refactored Student Task Workflow
            Console.WriteLine("\n[Task 5] Refactored Student Task Workflow:");
            ProcessStudentWorkflow("Mariam", new double[] { 95.0, 88.0, 92.5 });
            ProcessStudentWorkflow("Omar", new double[] { 45.0, 52.0, 48.5 });
        }

        /* 
         * =========================================================================
         * TOPIC 2: Syntax & Void Method   
         * =========================================================================
         */
        public static void PrintWelcomeMessage()
        {
            // English Comment: Displays a simple welcome message with no return value
            Console.WriteLine("Hello! Welcome to the C# Methods Guide.");
        }

        /* 
         * =========================================================================
         * TOPIC 3: Parameters vs Arguments
         * =========================================================================
         */
        public static void GreetUser(string userName) // userName is a Parameter
        {
            // English Comment: Uses the string parameter to output a custom greeting
            Console.WriteLine($"Hello, {userName}! Great to have you here.");
        }

        public static void DisplayAgeAndCity(string name, int age, string city)
        {
            // English Comment: Method taking multiple parameters of different types
            Console.WriteLine($"User: {name} | Age: {age} | City: {city}");
        }

        /* 
         * =========================================================================
         * TOPIC 4: Return Types (int, string, double, bool)
         * =========================================================================
         */
        public static int AddNumbers(int number1, int number2)
        {
            // English Comment: Calculates and returns an integer
            return number1 + number2;
        }

        public static string GetFormattedGreeting(string name)
        {
            // English Comment: Formats and returns a string
            return $"Welcome to C# Programming, {name}!";
        }

        public static double CalculateCircleArea(double radius)
        {
            // English Comment: Calculates circle area and returns a double
            return Math.PI * radius * radius;
        }

        public static bool IsEvenNumber(int number)
        {
            // English Comment: Evaluates if a number is even and returns boolean
            return number % 2 == 0;
        }
        /* 
         * =========================================================================
         * TOPIC 5: Optional & Named Parameters
         * =========================================================================
         */
        public static void PrintInvoice(string itemName, double price, double taxRate = 0.14, double discount = 0.0)
        {
            // English Comment: Tax and discount have default values (optional parameters)
            double taxAmount = price * taxRate;
            double totalPrice = (price + taxAmount) - discount;
            Console.WriteLine($"Invoice -> Item: {itemName} | Base: ${price} | Tax: ${taxAmount:F2} | Discount: ${discount} | Total: ${totalPrice:F2}");
        }

        /* 
         * =========================================================================
         * TOPIC 6: Method Overloading
         * =========================================================================
         */
        public static int Multiply(int a, int b)
        {
            // English Comment: Overload 1 - Multiplies two integers
            return a * b;
        }

        public static double Multiply(double a, double b)
        {
            // English Comment: Overload 2 - Multiplies two doubles
            return a * b;
        }

        public static int Multiply(int a, int b, int c)
        {
            // English Comment: Overload 3 - Multiplies three integers
            return a * b * c;
        }

        /* 
         * =========================================================================
         * TOPIC 7: Passing Parameters (Value, ref, out)
         * =========================================================================
         */
     
        public static void PassByValue(int number)
        {
            // English Comment: Modifies local copy only (Pass-by-value)
            number = number + 50;
            Console.WriteLine($"   [Inside PassByValue] Modified local copy = {number}");
        }
      

        public static void PassByRef(ref int number)
        {
            // English Comment: Modifies original variable in memory (Pass-by-reference)
            number = number + 50;
            Console.WriteLine($"   [Inside PassByRef] Modified original reference = {number}");
        }

        public static void GetStudentStats(int score1, int score2, out double average, out bool isPassed)
        {
            // English Comment: 'out' parameters must be initialized/assigned inside this method
            average = (score1 + score2) / 2.0;
            isPassed = average >= 50.0;
        }
        //int score1 = 85, score2 = 92;

       
        //GetStudentStats(score1, score2, out var calculatedAverage, out var isPassed);

        // ref vs out in C#:
        //* Both ref and out pass variables by reference.
        //* This means the method can modify the original variable.
        //*
        //* 1. REF:
        //* - Variable MUST be initialized before passing it.
        //* - Method can READ and MODIFY the original value.
        //* - Method is NOT required to assign a new value.
        //* - Must use 'ref' in both declaration and method call.
        //*
        //* 2. OUT:
        //* - Variable does NOT need to be initialized before passing it.
        //* - Method MUST assign a value before returning normally.
        //* - Used when a method needs to return additional results.
        //* - Must use 'out' in both declaration and method call.
        //* - Can declare the variable directly in the method cal

        /* 
         * =========================================================================
         * TOPIC 8: Variable Scope
         * =========================================================================
         */
        public static void DemonstrateScope()
        {
            int localVariableInScope = 100;
            Console.WriteLine($"Local Variable inside DemonstrateScope: {localVariableInScope}");

            // English Explanation:
            // Local variables exist ONLY within the block {} they are defined in.
            // When a method finishes execution, its stack memory is cleared.
            // Therefore, Method A cannot directly access variables declared in Method B.
        }
        /*
         class Program{
        
        int x=10;
         int add (int a,int b){
        int x=20;
            int sum=a+b+this.x;
            return sum;
         }
        }
         */

        /* 
         * =========================================================================
         * TOPIC 9: Practice Tasks Solutions
         * =========================================================================
         */

        // Task 1: Calculate sum of two numbers
        public static int CalculateSum(int a, int b)
        {
            // English Comment: Returns the sum of two integer parameters
            return a + b;
        }
        // Task 2: Determine student pass/fail status
        public static bool IsStudentPassed(double score, double passingThreshold = 50.0)
        {
            // English Comment: Returns true if score is greater than or equal to threshold
            return score >= passingThreshold;
        }

        // Task 3: Calculate average of grades array
        public static double CalculateAverageGrade(double[] grades)
        {
            // English Comment: Computes the arithmetic mean of an array of double grades
            if (grades == null || grades.Length == 0) return 0.0;

            double sum = 0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return sum / grades.Length;
        }

        // Task 4: Determine grade letter based on average score
        public static char DetermineGradeLetter(double average)
        {
            // English Comment: Evaluates average score and returns letter grade ('A' through 'F')
            if (average >= 90) return 'A';
            if (average >= 80) return 'B';
            if (average >= 70) return 'C';
            if (average >= 60) return 'D';
            return 'F';
        }

        // Task 5: Refactored Student Task Workflow using modular methods
        public static void ProcessStudentWorkflow(string studentName, double[] scores)
        {
            // English Comment: Modular method that orchestrates previous student functions
            double average = CalculateAverageGrade(scores);
            bool passed = IsStudentPassed(average);
            char letterGrade = DetermineGradeLetter(average);

            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($" - Average Score: {average:F2}");
            Console.WriteLine($" - Status: {(passed ? "PASSED" : "FAILED")}");
            Console.WriteLine($" - Letter Grade: {letterGrade}");
        }
    }
}

