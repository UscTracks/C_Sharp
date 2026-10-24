
using System;
using System.Threading.Channels;
using USCTracks._1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntroductionToExceptionHandling
{
    class Program
    {
       
        /*
         * ================================================================
         * TOPIC 1: Errors vs Exceptions
         * ================================================================
         *
         * 1. Compile-Time Error:
         *    - Detected by the compiler before execution.
         *    - Example: int number = "Hello";
         *
         * 2. Runtime Exception:
         *    - Occurs while the application is running.
         *    - Example: int.Parse("abc");
         *
         * 3. Logical Error:
         *    - The program runs but produces incorrect results.
         *    - Example: using + instead of * in a calculation.
         *
         * What is Exception Handling?
         * - A mechanism for handling runtime exceptions.
         * - Allows the application to respond to failures.
         * - Helps prevent unexpected termination.
         *
         * Keywords:
         * try, catch, finally, throw
         * ================================================================
         */

        static void Main(string[] args)
        {
            // to run the code in type conversion and methods folder, uncomment the following lines:
            //TypeConversion.Run();
            //Methods.MethodDemo();

            Console.WriteLine("=======================================");
            Console.WriteLine("   C# EXCEPTION HANDLING MASTERCLASS");
            Console.WriteLine("=======================================");

            // 1. Basic Try & Catch
            Console.WriteLine("\n--- 1. Basic Try & Catch ---");
            BasicTryCatch();

            // 2. Multiple Catch Blocks
            Console.WriteLine("\n--- 2. Multiple Catch Blocks ---");
            MultipleCatchBlocks();

            // 3. Exception Object Properties
            Console.WriteLine("\n--- 3. Exception Properties ---");
            ExceptionProperties();

            // 4. Finally Block
            Console.WriteLine("\n--- 4. Finally Block ---");
            FinallyExample();

            // 5. Throw New Exception
            Console.WriteLine("\n--- 5. Throw New Exception ---");
            try
            {
                ValidateAge(-5);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 6. Throw vs Throw Ex
            Console.WriteLine("\n--- 6. Throw vs Throw Ex ---");
            ThrowVsThrowEx();

            // 7. Exception Propagation
            Console.WriteLine("\n--- 7. Exception Propagation ---");
            try
            {
                FirstMethod();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Handled in Main:");
                Console.WriteLine(ex.Message);
            }

            // 8. Custom Exception
            Console.WriteLine("\n--- 8. Custom Exception ---");
            try
            {
                Withdraw(100, 500);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            // 10. Exception Filters
            Console.WriteLine("\n--- 10. Exception Filters ---");
            ExceptionFilterExample();

            Console.WriteLine("\nAll demos completed.");
        }

        /*
         * ================================================================
         * TOPIC 2: Basic Try & Catch
         * ================================================================
         *
         * try:
         * - Contains code that might throw an exception.
         *
         * catch:
         * - Handles a matching exception thrown inside try.
         *
         * Flow:
         * 1. Execute try statements.
         * 2. If an exception occurs, normal execution stops.
         * 3. Search for a matching catch.
         * 4. Execute the matching catch block.
         * 5. Continue after the try/catch statement.
         * ================================================================
         */

        static void BasicTryCatch()
        {
            try
            {
                Console.WriteLine("Before exception");

                int number = int.Parse("abc");

                Console.WriteLine("After exception");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Exception caught!");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Program continues...");
        }
      
        /*
         * ================================================================
         * TOPIC 3: Multiple Catch Blocks
         * ================================================================
         *
         * Different exceptions can be handled differently.
         *
         *
         * Common Exceptions:
         * - DivideByZeroException
         * - FormatException
         * - IndexOutOfRangeException
         * - NullReferenceException
         * 
         * int x=null; 
         * - ArgumentException
         * 
         * 
         *
         * Important:
         * - Specific catch blocks come before general catch blocks.
         * - Only the first matching catch executes.
         * - Exception is the base class for standard exceptions.
         * ================================================================
         */

        static void MultipleCatchBlocks()
        {
            try
            {
                int[] numbers = { 10, 20, 30 };

                Console.WriteLine(numbers[5]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid array index!");
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General exception:");
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * ================================================================
         * TOPIC 4: Exception Object Properties
         * ================================================================
         *
         * ex.Message:
         * - Describes the error.
         *
         * ex.StackTrace:
         * - Shows the execution path where the error occurred.
         *
         * ex.InnerException:
         * - Contains the original exception if one was wrapped.
         *
         * ex.GetType():
         * - Returns the exception type.
         * ================================================================
         */

        static void ExceptionProperties()
        {
            try
            {
                int number = int.Parse("Hello");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Type: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.WriteLine($"InnerException: {ex.InnerException?.Message}");
            }
        }

        public static void InnerExceptionn() {
            try
            {
                try
                {
                    int number = int.Parse("Hello");

                   
                }
                catch (FormatException ex)
                {
                    throw new Exception(
                        "Error while processing user data",
                        ex
                    );
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.InnerException?.GetType().Name);
            }
           
        }

           //Error while processing user data
           //The input string 'Hello' was not in a correct format.
           //FormatException


        /*
         * ================================================================
         * TOPIC 5: Finally Block
         * ================================================================
         *
         * finally:
         * - Normally executes whether an exception occurs or not.
         * - Useful for cleanup operations.
         *
         * Examples:
         * - Closing files
         * - Releasing resources
         * - Cleaning up connections
         *
         * Important:
         * - finally does not handle exceptions.
         * - It is not guaranteed to run if the process terminates.
         * ================================================================
         */

        static void FinallyExample()
        {
            try
            {
                Console.WriteLine("Inside try");

                int number = int.Parse("abc");
            }
            catch (FormatException)
            {
                Console.WriteLine("Inside catch");
            }
            finally
            {
                Console.WriteLine("Inside finally");
            }

            Console.WriteLine("After try-catch-finally");
        }

        /*
         * ================================================================
         * TOPIC 6: Throw New Exception
         * ================================================================
         *
         * throw:
         * - Used to explicitly throw an exception.
         *
         * We can throw exceptions when input violates a rule.
         *
         * Example:
         * - Age cannot be negative.
         * - Price cannot be negative.
         * - Required argument cannot be null.
         * ================================================================
         */

        static void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(age),
                    "Age cannot be negative."
                );
            }

            Console.WriteLine($"Valid age: {age}");
        }

        /*
         * ================================================================
         * TOPIC 7: throw vs throw ex
         * ================================================================
         *
         * throw;
         * - Rethrows the currently handled exception.
         * - Preserves the original stack trace.
         *
         * throw ex;
         * - Throws the exception object again.
         * - Resets the stack trace at the rethrow location.
         * - Makes debugging more difficult.
         *
         * Best Practice:
         * - Use throw; when rethrowing inside catch.
         *
         * Demonstration:
         * - Call both methods.
         * - Compare the StackTrace output.
         * ================================================================
         */

        static void ThrowVsThrowEx()
        {
            Console.WriteLine("\nUsing throw:");

            try
            {
                RethrowCorrectly();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nUsing throw ex:");

            try
            {
                RethrowIncorrectly();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void OriginalMethod()
        {
            throw new InvalidOperationException(
                "Original error occurred here."
            );
        }

        static void RethrowCorrectly()
        {
            try
            {
                OriginalMethod();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught, then rethrowing...");
                throw;
            }
        }

        static void RethrowIncorrectly()
        {
            try
            {
                OriginalMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught, then throwing ex...");


                throw ex; // Demonstration only - avoid in real code.

            }
        }

        /*
         * ================================================================
         * TOPIC 8: Exception Propagation
         * ================================================================
         *
         * If a method does not handle an exception:
         * - The exception propagates to its caller.
         * - The runtime searches up the call stack for a handler.
         * - نفضل نرجع لورا لحد ما نلاقي catch مناسبة
         *
         * Example:
         *
         * Main()
         *   |
         * FirstMethod()
         *   |
         * SecondMethod()
         *   |
         * ThirdMethod() -> Exception!
         *
         * Exception propagates back until a matching catch is found.
         * ================================================================
         */

        static void FirstMethod()
        {
            SecondMethod();
        }

        static void SecondMethod()
        {
            ThirdMethod();
        }

        static void ThirdMethod()
        {
            throw new DivideByZeroException(
                "Demo exception from ThirdMethod."
            );
        }

        // ---------------------------------

        public static void ExceptionPropagationDemo()
        {
            Console.WriteLine("1- Demo Started");

            try
            {
                Console.WriteLine("2- Before FirstMethod");

                FirstMethod1();

                Console.WriteLine("3- After FirstMethod");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("4- Exception Handled in Demo");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("5- Demo Ended");
        }

        static void FirstMethod1()
        {
            Console.WriteLine("6- FirstMethod Started");

            SecondMethod1();

            Console.WriteLine("7- FirstMethod Ended");
        }

        static void SecondMethod1()
        {
            Console.WriteLine("8- SecondMethod Started");

            ThirdMethod1();

            Console.WriteLine("9- SecondMethod Ended");
        }

        static void ThirdMethod1()
        {
            Console.WriteLine("10- ThirdMethod Started");

            int x = 10;
            int y = 0;

            int result = x / y; // DivideByZeroException occurs here.

            Console.WriteLine("11- Result: " + result);
        }

        // output of ExceptionPropagationDemo():
        // * 1- Demo Started
        //*2 - Before FirstMethod
        //* 6- FirstMethod Started
        //*8 - SecondMethod Started
        //* 10- ThirdMethod Started
        //*4 - Exception Handled in Demo
        //* Attempted to divide by zero.
        //* 5- Demo Ended

        /*
         * ================================================================
         * TOPIC 9: Custom Exceptions
         * ================================================================
         *
         * We can create our own exception types.
         *
         * Steps:
         * 1. Create a class inheriting from Exception.
         * 2. Define a constructor.
         * 3. Throw the custom exception.
         * 4. Catch and handle it.
         *
         * Useful when:
         * - Representing meaningful application failures.
         * - Callers need to handle a specific failure type.
         * ================================================================
         */

        public class InsufficientBalanceException : Exception 
        {
            public InsufficientBalanceException(string message)
                : base(message)
            {
            }
        }
        static void Withdraw(decimal balance, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Amount must be positive."
                );
            }

            if (amount > balance)
            {
                throw new InsufficientBalanceException(
                    "Insufficient balance for withdrawal."
                );
            }

            Console.WriteLine("Withdrawal successful.");
        }


        /*
         * ================================================================
         * TOPIC 10: Exception Filters
         * ================================================================
         *
         * catch (...) when (condition)
         *
         * - Handles an exception only if the condition is true.
         * - Helps handle the same exception type differently.
         * ================================================================
         */

        static void ExceptionFilterExample()
        {
            int errorCode = 404;

            try
            {
                throw new InvalidOperationException(
                    "Request failed."
                );
            }
            catch (InvalidOperationException ex)  when (errorCode == 404)
            {
                Console.WriteLine($"Not Found: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Other error: {ex.Message}");
            }
        }
    }

    
   
}
