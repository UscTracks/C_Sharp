// ============================================================
// C# BASICS - STUDY NOTES (Before Methods)
// A beginner-friendly file: variables, types, input/output,
// conversions, operators, conditions, loops, break/continue,
// arrays, and foreach.
// ============================================================

using System;

class Program
{
    static void Main()
    {
        // --------------------------------------------------------
        // 1. OUTPUT
        // --------------------------------------------------------
        Console.WriteLine("Hello, World!"); // Prints text and moves to a new line.
        Console.Write("This stays on the same line. ");
        Console.WriteLine("This continues on that line.");

        // --------------------------------------------------------
        // 2. INPUT
        // --------------------------------------------------------
        // Console.ReadLine() reads a line from the user and returns string?.
        // Uncomment these lines to try input:
        // Console.Write("Enter your name: ");
        // string? userName = Console.ReadLine();
        // Console.WriteLine($"Hello, {userName}!");

        // Reading a number safely:
        // Console.Write("Enter your age: ");
        // string? ageInput = Console.ReadLine();
        // if (int.TryParse(ageInput, out int userAge))
        // {
        //     Console.WriteLine($"Next year, you will be {userAge + 1}.");
        // }
        // else
        // {
        //     Console.WriteLine("Please enter a valid whole number.");
        // }

        // --------------------------------------------------------
        // 3. VARIABLES: DECLARATION, ASSIGNMENT, INITIALIZATION
        // --------------------------------------------------------
        int number;       // Declaration: create a variable.
        number = 5;       // Assignment: give it a value.
        int age = 20;     // Initialization: declaration + assignment.

        int x = 2, y = 3, z = 4; // Multiple variables of the same type.
        int first, second = 10;  // Only second is initialized here.
        // first = 5; // Initialize first before reading its value.

        Console.WriteLine($"number = {number}, age = {age}");
        Console.WriteLine($"x + y + z = {x + y + z}");
        Console.WriteLine($"second = {second}");

        // --------------------------------------------------------
        // 4. COMMON DATA TYPES
        // --------------------------------------------------------
        int wholeNumber = 25;          // Whole numbers.
        long largeNumber = 5_000_000L; // Larger whole numbers.
        float temperature = 36.5F;     // Floating-point; suffix F.
        double price = 19.99;          // Common floating-point type.
        decimal salary = 12500.50M;    // Decimal; useful for money.
        char grade = 'A';              // One character: single quotes.
        string personName = "Doha";    // Text: double quotes.
        bool isStudent = true;         // true or false.

        Console.WriteLine($"{wholeNumber}, {largeNumber}, {temperature}, {price}, {salary}");
        Console.WriteLine($"{grade}, {personName}, {isStudent}");

        // --------------------------------------------------------
        // 5. CONSTANTS
        // --------------------------------------------------------
        const double Pi = 3.14159;
        Console.WriteLine($"Pi = {Pi}");
        // Pi = 3.14; // ERROR: a const value cannot be changed.

        // --------------------------------------------------------
        // 6. var KEYWORD
        // --------------------------------------------------------
        // var asks the compiler to infer the type from the initial value.
        // The type is fixed at compile time; it is NOT dynamic.
        var city = "Cairo"; // Inferred as string.
        var count = 10;    // Inferred as int.
        // city = 100;      // ERROR: city is a string.
        count = 15;        // OK: count is an int.
        Console.WriteLine($"{city}: {count}");

        // var must have an initial value so the compiler can infer its type.
        // var unknown; // ERROR

        // --------------------------------------------------------
        // 7. dynamic KEYWORD
        // --------------------------------------------------------
        // dynamic postpones type checking until runtime.
        // It can hold values of different types, but invalid operations
        // may fail while the program is running.
        dynamic value = 10;
        Console.WriteLine(value);
        value = "Now I am text";
        Console.WriteLine(value);
        // dynamic is different from var:
        // var a = 10;  // Compile-time type is int and cannot become string.
        // dynamic b = 10; b = "text"; // Allowed; type can change at runtime.

        // --------------------------------------------------------
        // 8. NAMING CONVENTIONS
        // --------------------------------------------------------
        // Common rules:
        // - Names can contain letters, digits, and underscores.
        // - A name cannot start with a digit.
        // - No spaces are allowed.
        // - Names are case-sensitive: myName and MyName are different.
        // - C# keywords (such as int, class, if) cannot normally be names.
        // - Local variables commonly use camelCase: studentName.
        // - Constants commonly use PascalCase: MaxAttempts.
        // Good: studentName, totalPrice, number2, _counter
        // Bad: 2number, student name, class

        // --------------------------------------------------------
        // 9. STRINGS: CONCATENATION AND INTERPOLATION
        // --------------------------------------------------------
        string name = "Doha";
        int studentAge = 21;

        string fullName = name + " Harby"; // Concatenation: use + to join.
        string message = $"{fullName} is {studentAge} years old."; // Interpolation.
        Console.WriteLine(fullName);
        Console.WriteLine(message);

        // --------------------------------------------------------
        // 10. OPERATORS
        // --------------------------------------------------------
        int a = 10;
        int b = 3;

        // Arithmetic: + - * / %
        Console.WriteLine(a + b); // 13
        Console.WriteLine(a - b); // 7
        Console.WriteLine(a * b); // 30
        Console.WriteLine(a / b); // 3 (integer division)
        Console.WriteLine(a % b); // 1 (remainder)

        // To get decimal division, make at least one operand a double:
        Console.WriteLine((double)a / b); // 3.333...

        // Comparison: == != > < >= <= (result is bool)
        Console.WriteLine(a > b);  // True
        Console.WriteLine(a == b); // False

        // Logical: && (AND), || (OR), ! (NOT)
        bool hasID = true;
        bool isAllowedAge = studentAge >= 18;
        Console.WriteLine(hasID && isAllowedAge);
        Console.WriteLine(!hasID);

        // Assignment shortcuts: += -= *= /= %=
        int score = 10;
        score += 5; // Same as score = score + 5.
        score -= 2;
        score *= 2;
        Console.WriteLine(score);

        // Increment/decrement: ++ and --
        score++;
        score--;
        Console.WriteLine(score);

        // --------------------------------------------------------
        // 11. TYPE CASTING AND CONVERSION
        // --------------------------------------------------------
        // Implicit conversion: generally a compatible smaller range/type
        // converts to a wider type automatically.
        int smallNumber = 12;
        double widerNumber = smallNumber;
        Console.WriteLine(widerNumber);

        // Explicit cast: write the target type in parentheses.
        double decimalNumber = 9.78;
        int truncatedNumber = (int)decimalNumber; // Becomes 9; decimals are removed.
        Console.WriteLine(truncatedNumber);

        // Convert methods:
        int integerValue = 10;
        double doubleValue = Convert.ToDouble(integerValue);
        string integerText = Convert.ToString(integerValue) ?? "";
        string boolText = Convert.ToString(true) ?? "";
        int roundedValue = Convert.ToInt32(5.6); // Rounds to nearest integer (6).
        Console.WriteLine($"{doubleValue}, {integerText}, {boolText}, {roundedValue}");

        // Parse converts text to a value but throws an exception if invalid:
        int parsedNumber = int.Parse("123");
        Console.WriteLine(parsedNumber);

        // TryParse is safer for user input because it reports success/failure:
        bool parsedSuccessfully = int.TryParse("123", out int parsedResult);
        Console.WriteLine($"{parsedSuccessfully}: {parsedResult}");

        // --------------------------------------------------------
        // 12. if / else if / else
        // --------------------------------------------------------
        int mark = 85;

        if (mark >= 90)
        {
            Console.WriteLine("Excellent");
        }
        else if (mark >= 75)
        {
            Console.WriteLine("Very Good");
        }
        else if (mark >= 50)
        {
            Console.WriteLine("Pass");
        }
        else
        {
            Console.WriteLine("Fail");
        }

        // A condition must evaluate to bool.
        // Use == to compare values; a single = assigns a value.
        bool isRaining = false;
        if (!isRaining)
        {
            Console.WriteLine("You can go out.");
        }

        // --------------------------------------------------------
        // 13. switch
        // --------------------------------------------------------
        int dayNumber = 3;

        switch (dayNumber)
        {
            case 1:
                Console.WriteLine("Sunday");
                break; // Exits the switch.
            case 2:
                Console.WriteLine("Monday");
                break;
            case 3:
                Console.WriteLine("Tuesday");
                break;
            case 4:
                Console.WriteLine("Wednesday");
                break;
            case 5:
                Console.WriteLine("Thursday");
                break;
            case 6:
                Console.WriteLine("Friday");
                break;
            case 7:
                Console.WriteLine("Saturday");
                break;
            default:
                Console.WriteLine("Invalid day number");
                break;
        }

        // --------------------------------------------------------
        // 14. for LOOP
        // --------------------------------------------------------
        // for (initialization; condition; update)
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"for loop: {i}");
        }

        // Count backwards:
        for (int i = 5; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        // --------------------------------------------------------
        // 15. while LOOP
        // --------------------------------------------------------
        // Checks the condition BEFORE each iteration.
        int whileCounter = 1;
        while (whileCounter <= 3)
        {
            Console.WriteLine($"while loop: {whileCounter}");
            whileCounter++;
        }

        // --------------------------------------------------------
        // 16. do-while LOOP
        // --------------------------------------------------------
        // Runs at least once because the condition is checked AFTER the body.
        int doCounter = 1;
        do
        {
            Console.WriteLine($"do-while loop: {doCounter}");
            doCounter++;
        } while (doCounter <= 3);

        // --------------------------------------------------------
        // 17. break AND continue
        // --------------------------------------------------------
        // break exits the nearest loop (or switch).
        for (int i = 1; i <= 10; i++)
        {
            if (i == 4)
            {
                break; // Stop the loop when i reaches 4.
            }
            Console.WriteLine($"break example: {i}");
        }

        // continue skips the rest of the CURRENT iteration.
        for (int i = 1; i <= 5; i++)
        {
            if (i == 3)
            {
                continue; // Skip printing 3 and move to the next iteration.
            }
            Console.WriteLine($"continue example: {i}");
        }

        // --------------------------------------------------------
        // 18. NESTED LOOPS
        // --------------------------------------------------------
        // A loop inside another loop.
        for (int row = 1; row <= 3; row++)
        {
            for (int column = 1; column <= 2; column++)
            {
                Console.WriteLine($"Row {row}, Column {column}");
            }
        }

        // --------------------------------------------------------
        // 19. ARRAYS
        // --------------------------------------------------------
        // An array stores a fixed number of values of the same type.
        int[] numbers = { 10, 20, 30, 40 };
        Console.WriteLine(numbers[0]); // First item; indexes start at 0.
        Console.WriteLine(numbers[3]); // Fourth item.

        numbers[1] = 25; // Change the second item.
        Console.WriteLine(numbers.Length); // Number of items.

        // Create an array with a fixed length (default values initially):
        int[] emptyNumbers = new int[3];
        emptyNumbers[0] = 100;

        // --------------------------------------------------------
        // 20. foreach LOOP
        // --------------------------------------------------------
        // Convenient for reading every item in a collection.
        foreach (int item in numbers)
        {
            Console.WriteLine($"Array item: {item}");
        }

        // --------------------------------------------------------
        // 21. QUICK REVISION
        // --------------------------------------------------------
        // =   assignment                 ==  equality comparison
        // if  chooses based on a condition
        // switch selects among matching cases
        // for / while / do-while repeat code
        // break exits a loop or switch
        // continue skips to the next loop iteration
        // var infers a compile-time type from the initial value
        // dynamic defers type checking until runtime
        // int.Parse can throw; int.TryParse is safer for user input
        // Arrays use zero-based indexes and have a fixed length.

        Console.WriteLine("C# basics revision completed!");
    }
}
