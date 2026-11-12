
using System;

namespace ArraysLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =====================================
            // 1. ONE DIMENSIONAL ARRAY (1D)
            // =====================================

            // Declaration
            int[] grades = new int[5];

            // Initialization
            int[] numbers = { 90, 85, 70, 95, 80 };

            // Access elements
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[3]);

            // Modify element
            numbers[0] = 100;

            // Array Length
            Console.WriteLine("Length: " + numbers.Length);

            // For loop
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // Foreach loop
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Reassign Array
            grades = new int[] { 90, 85, 70, 95, 80 };


            // =====================================
            // 2. ARRAY METHODS
            // =====================================

            int[] nums = { 50, 10, 40, 20, 30 };

            // Sort - Ascending
            Array.Sort(nums);

            // Reverse
            Array.Reverse(nums);

            // IndexOf
            int index = Array.IndexOf(nums, 30);
            Console.WriteLine("Index: " + index);

            // LastIndexOf
            int[] repeated = { 10, 20, 30, 20, 50 };
            int lastIndex = Array.LastIndexOf(repeated, 20);
            Console.WriteLine("Last Index: " + lastIndex);

            // Clear
            int[] clearArray = { 10, 20, 30, 40, 50 };
            Array.Clear(clearArray, 1, 2);

            // Copy
            int[] source = { 10, 20, 30, 40, 50 };
            int[] destination = new int[5];

            Array.Copy(source, destination, source.Length);

            // Resize
            int[] resizeArray = { 10, 20, 30 };
            Array.Resize(ref resizeArray, 5);

            // Exists
            bool exists = Array.Exists(resizeArray, n => n > 20);
            Console.WriteLine("Exists: " + exists);

            // Find
            int found = Array.Find(resizeArray, n => n > 20);
            Console.WriteLine("Found: " + found);

            // FindAll
            int[] foundAll = Array.FindAll(
                resizeArray, n => n > 0);

            // ForEach
            Array.ForEach(resizeArray,
                n => Console.WriteLine(n));

            // ConvertAll
            string[] stringNumbers = Array.ConvertAll(
                resizeArray, n => n.ToString());

            // Empty
            int[] emptyArray = Array.Empty<int>();


            // =====================================
            // 3. TWO DIMENSIONAL ARRAY (2D)
            // =====================================

            int[,] grades2D =
            {
                { 90, 85, 80 },
                { 70, 95, 88 }
            };

            // Total elements
            Console.WriteLine("Length: " + grades2D.Length);

            // Number of dimensions
            Console.WriteLine("Rank: " + grades2D.Rank);

            // Number of rows
            Console.WriteLine("Rows: " + grades2D.GetLength(0));

            // Number of columns
            Console.WriteLine("Columns: " + grades2D.GetLength(1));

            // Access element
            Console.WriteLine(grades2D[0, 1]);

            // Modify element
            grades2D[0, 1] = 100;

            // Print 2D Array
            for (int row = 0; row < grades2D.GetLength(0); row++)
            {
                for (int col = 0; col < grades2D.GetLength(1); col++)
                {
                    Console.Write(grades2D[row, col] + " ");
                }

                Console.WriteLine();
            }


            // =====================================
            // 4. JAGGED ARRAY
            // =====================================

            int[][] jaggedGrades =
            {
                new int[] { 90, 80 },
                new int[] { 70, 95, 88 },
                new int[] { 70, 95, 88, 80, 50, 30, 20 }
            };

            // Number of rows
            Console.WriteLine("Rows: " + jaggedGrades.Length);

            // Access element
            Console.WriteLine(jaggedGrades[0][1]);

            // Modify element
            jaggedGrades[1][0] = 100;

            // Print Jagged Array
            for (int row = 0; row < jaggedGrades.Length; row++)
            {
                for (int col = 0; col < jaggedGrades[row].Length; col++)
                {
                    Console.Write(jaggedGrades[row][col] + " ");
                }

                Console.WriteLine();
            }


            // =====================================
            // 5. THREE DIMENSIONAL ARRAY (3D)
            // =====================================

            int[,,] numbers3D = new int[2, 3, 4];

            numbers3D[0, 1, 2] = 100;

            Console.WriteLine(numbers3D[0, 1, 2]);

            Console.WriteLine("Dimensions: " + numbers3D.Rank);


            // =====================================
            // 6. ARRAY REFERENCE TYPE
            // =====================================

            int[] arr1 = { 10, 20, 30 };

            int[] arr2 = arr1;

            arr2[0] = 100;

            // Both reference the same array
            Console.WriteLine(arr1[0]); // 100


            // =====================================
            // 7. CLONE VS COPY
            // =====================================

            int[] original = { 10, 20, 30 };

            // Clone
            int[] clone = (int[])original.Clone();

            // Copy
            int[] copy = new int[original.Length];

            Array.Copy(original, copy, original.Length);

            clone[0] = 100;
            copy[1] = 200;

            Console.WriteLine("Original:");
            foreach (int item in original)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Clone:");
            foreach (int item in clone)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Copy:");
            foreach (int item in copy)
            {
                Console.WriteLine(item);
            }


            // =====================================
            // 8. ARRAY EMPTY
            // =====================================

            int[] empty = Array.Empty<int>();

            Console.WriteLine("Empty Length: " + empty.Length);


            Console.ReadKey();
        }
    }
}
