
using System;
using System.Text;

public class StringDemo
{


    // string is immutable, reference type, stored in heap
    // string builder is mutable, reference type, stored in heap
    public void ExplainDeclaration()
    {
        string name = "Ahmed";

        string name2 = "Ahmed";
        Console.WriteLine(ReferenceEquals(name, name2)); // string 

        char[] letters = { 'H', 'e', 'l', 'l', 'o' };

        // ctor take array of chars and create string from it
        string message = new string(letters);

        Console.WriteLine(name);
        Console.WriteLine(name2);
        Console.WriteLine(message);
    }

    public void ExplainLengthAndIndex()
    {
        string text = "Hello World";

        Console.WriteLine(text.Length); // 11
        Console.WriteLine(text[0]);     // H
        Console.WriteLine(text[1]);     // e

        foreach (char letter in text)
        {
            Console.WriteLine(letter);
        }
    }

    public void ExplainImmutability()
    {
        string text = "Hello";

        text.ToUpper();

        Console.WriteLine(text); // Hello

        text = text.ToUpper();

        Console.WriteLine(text); // HELLO

        // text[0] = 'A'; // Compile Time Error
    }

    public void ExplainCaseMethods()
    {
        string text = "Hello World";

        Console.WriteLine(text.ToUpper());
        Console.WriteLine(text.ToLower());

        // search ??
        //Console.WriteLine(text.ToUpperInvariant());
        //Console.WriteLine(text.ToLowerInvariant());
    }

    public void ExplainTrimMethods()
    {
        string text = "   Hello World   ";

        Console.WriteLine($"[{text.Trim()}]");
        Console.WriteLine($"[{text.TrimStart()}]");
        Console.WriteLine($"[{text.TrimEnd()}]");

        string value = "###Hello###";

        Console.WriteLine(value.Trim('#'));
    }

    public void ExplainSearchingMethods()
    {
        string text = "Hello World";

        Console.WriteLine(text.Contains("World")); // True
        Console.WriteLine(text.Contains("world")); // False

        Console.WriteLine(text.StartsWith("Hello")); // True
        Console.WriteLine(text.EndsWith("World"));   // True

        Console.WriteLine(text.IndexOf("World")); // 6
        Console.WriteLine(text.IndexOf('o'));     // 4
        Console.WriteLine(text.LastIndexOf('o')); // 7

        Console.WriteLine(text.IndexOf("Ahmed")); // -1

        Console.WriteLine(
            text.Contains(
                "world",
                StringComparison.OrdinalIgnoreCase
            )
        ); // True
    }

    public void ExplainSubstring()
    {
        string text = "Hello World";
        // Substring(startIndex) to the end of the string

        Console.WriteLine(text.Substring(6));    // World
        // Substring(startIndex, length)
        Console.WriteLine(text.Substring(0, 5)); // Hello

        // Range Operator
        // text[startIndex..endIndex(exclusive)]
        Console.WriteLine(text[0..5]); // Hello
        Console.WriteLine(text[6..]);  // World
        Console.WriteLine(text[..5]);  // Hello
        Console.WriteLine(text[^5..]); // World
    }

    public void ExplainModificationMethods()
    {
        string text = "Hello World";

        Console.WriteLine(
            text.Replace("World", "Ahmed")
        ); // Hello Ahmed

        // text.Insert(startIndex, value);
        Console.WriteLine(
            text.Insert(5, " Beautiful")
        ); // Hello Beautiful World

        // Remove(startIndex) to the end 
        Console.WriteLine(
            text.Remove(5)
        ); // Hello

        // Remove(startIndex, count)
        Console.WriteLine(
            text.Remove(0, 6)
        ); // World
    }

    public void ExplainSplitAndJoin()
    {
        string text = "Ahmed,Ali,Mohamed";

        string[] names = text.Split(',');

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        string result = string.Join(" - ", names);

        Console.WriteLine(result);
        // Ahmed - Ali - Mohamed

        string sentence = "Hello   World";

        // Hello|""|""|World

        string[] words = sentence.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        Console.WriteLine(words.Length); // 2
    }

    public void ExplainConcatenation()
    {
        string firstName = "Ahmed";
        string lastName = "Ali";
        int age = 20;

        // Using +
        string result1 = firstName + " " + lastName;

        // Using Concat
        string result2 = string.Concat(
            firstName, " ", lastName
        );

        // Using Format
        string result3 = string.Format(
            "{0} {1} is {2} years old",
            firstName, lastName, age
        );

        // String Interpolation
        string result4 =
            $"{firstName} {lastName} is {age} years old";

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);
    }

    public void ExplainComparison()
    {
        string x = "Hello";
        string y = "hello";
       // equals in string compare value
        Console.WriteLine(x == y); // False

        Console.WriteLine(x.Equals(y)); // False

        Console.WriteLine(
            string.Equals(
                x,
                y,
                StringComparison.OrdinalIgnoreCase
            )
        ); // True

       
    }

    public void ExplainNullAndEmpty()
    {
        string? a = null;
        string b = "";
        string c = "   ";
        string d = "Hello";

        Console.WriteLine(string.IsNullOrEmpty(a)); // True
        Console.WriteLine(string.IsNullOrEmpty(b)); // True
        Console.WriteLine(string.IsNullOrEmpty(c)); // False
        Console.WriteLine(string.IsNullOrEmpty(d)); // False

        Console.WriteLine(string.IsNullOrWhiteSpace(a)); // True
        Console.WriteLine(string.IsNullOrWhiteSpace(b)); // True
        Console.WriteLine(string.IsNullOrWhiteSpace(c)); // True
        Console.WriteLine(string.IsNullOrWhiteSpace(d)); // False

        string result = a ?? "Default Value";

        Console.WriteLine(result);
    }

  

    public void ExplainConversion()
    {
        string text = "Hello";

        char[] letters = text.ToCharArray();

        foreach (char letter in letters)
        {
            Console.WriteLine(letter);
        }

        int number = 100;

        string result = number.ToString();

        Console.WriteLine(result.GetType());
    }

    public void ExplainEscapeCharacters()
    {
        string text = "Hello\nWorld";
        string tab = "Name:\tAhmed";
        string quote = "He said \"Hello\"";

        string path1 = "C:\\Users\\Ahmed";

        // Verbatim String
        string path2 = @"C:\Users\Ahmed";

        // Raw String Literal (C# 11+)
        string json = """
            {
                "name": "Ahmed",
                "age": 20
            }
            """;

        Console.WriteLine(text);
        Console.WriteLine(tab);
        Console.WriteLine(quote);
        Console.WriteLine(path1);
        Console.WriteLine(path2);
        Console.WriteLine(json);
    }

    public void ExplainStringBuilder()
    {
        StringBuilder builder = new StringBuilder("Hello");

        builder.Append(" World");
        builder.AppendLine("!");
        builder.Append("Welcome to C#");

        Console.WriteLine(builder.ToString());

        builder.Replace("World", "Ahmed");

        Console.WriteLine(builder.ToString());

        builder.Clear();

        Console.WriteLine(builder.Length); // 0
    }

    public void Run()
    {
        ExplainDeclaration();
        ExplainLengthAndIndex();
        ExplainImmutability();
        ExplainCaseMethods();
        Console.WriteLine(" ExplainTrimMethods()");
        ExplainTrimMethods();
        ExplainSearchingMethods();
        ExplainSubstring();
        ExplainModificationMethods();
        ExplainSplitAndJoin();
        ExplainConcatenation();
        ExplainComparison();
        ExplainNullAndEmpty();
    
        ExplainConversion();
        ExplainEscapeCharacters();
        ExplainStringBuilder();
    }
}
