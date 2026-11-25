
using System;

public class ObjectDemo
{
    public void ExplainObjectType()
    {
        object x = 100;
        object y = "Ahmed";
        object z = true;
        object d = 15.5;

        Console.WriteLine(x.GetType().Name);
        Console.WriteLine(y.GetType());
        Console.WriteLine(z.GetType());
        Console.WriteLine(d.GetType());
    }

    public void ExplainBoxing()
    {
        int number = 100;

        object obj = number; // Boxing

        Console.WriteLine(obj);

        number = 200;

        Console.WriteLine(number); // 200
        Console.WriteLine(obj);    // 100
    }

    public void ExplainUnboxing()
    {
        object obj = 100;
        Console.WriteLine(obj.GetType().Name);

        int number = (int)obj; // Unboxing

        Console.WriteLine(number);
        // first we made type checking and then we did unboxing
        // double x = (double)obj;
        // InvalidCastException
    }

    public void ExplainReferenceCasting()
    {
        object obj = "Hello World";
       

        string message = (string)obj;

        Console.WriteLine(message.Length);
    }

    public void ExplainIs()
    {
        object obj = "Hello";

        Console.WriteLine(obj is string); // True
        Console.WriteLine(obj is int);    // False

        // Pattern Matching
        // Checks if obj is a string.
        // If true, declares a new variable called message of type string
        // and assigns the same reference to it.
        // Both variables reference the same object in memory.
        if (obj is string message)
        {
            Console.WriteLine(message.Length);
            Console.WriteLine(ReferenceEquals(message, obj));
        }
    }

    public void ExplainAs()
    {
        object obj = "Hello";

        // if true returns the reference to the object, otherwise returns null

        string? message = obj as string;

        Console.WriteLine(message);

        object number = 10;

        string? result = number as string;

        Console.WriteLine(result == null); // True
    }

    public void ExplainObjectMethods()
    {
        object obj = 100;

        Console.WriteLine(obj.GetType().Name);
        Console.WriteLine(obj.ToString());
        Console.WriteLine(obj.GetHashCode());

        object x = 10;
        object y = 10;

        Console.WriteLine(x.Equals(y)); // True

        Console.WriteLine(
           ReferenceEquals(x, y)
        ); // False

        object z = x;

        Console.WriteLine(
            ReferenceEquals(x, z)
        ); // True
    }

    public void Run()
    {
        Console.WriteLine("===== OBJECT TYPE =====");
        ExplainObjectType();

        Console.WriteLine("===== BOXING =====");
        ExplainBoxing();

        Console.WriteLine("===== UNBOXING =====");
        ExplainUnboxing();

        Console.WriteLine("===== CASTING =====");
        ExplainReferenceCasting();

        Console.WriteLine("===== IS =====");
        ExplainIs();

        Console.WriteLine("===== AS =====");
        ExplainAs();

        Console.WriteLine("===== OBJECT METHODS =====");
        ExplainObjectMethods();
    }
}
