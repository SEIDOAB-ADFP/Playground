using System.Collections.Immutable;

namespace Playground.Lesson06;

public static class RecursionBasics
{
    public static void RunExamples()
    {
        Console.WriteLine("\n=== Count Down Examples ===");
        Console.WriteLine("\nCount Down Iterative:");
        Counters.CountDownIterative(10);

        Console.WriteLine("\n\nCount Down Recursive:");
        Counters.CountDownRecursive(10);

        Console.WriteLine("\n\n=== Factorial Examples ===");
        Console.WriteLine($"\nFactorial of 5 (iterative): {MathOperations.FactorialIterative(5)}");
        Console.WriteLine($"Factorial of 5 (recursive): {MathOperations.FactorialRecursive(5)}");

        Console.WriteLine("\n\n=== Sum Examples ===");
        Console.WriteLine($"\nSum 1 to 10 (iterative): {MathOperations.SumIterative(10)}");
        Console.WriteLine($"Sum 1 to 10 (recursive): {MathOperations.SumRecursive(10)}");

        Console.WriteLine("\n\n=== Fibonacci Examples ===");
        Console.WriteLine($"\nFibonacci(7) iterative: {MathOperations.FibonacciIterative(7)}");
        Console.WriteLine($"Fibonacci(7) recursive: {MathOperations.FibonacciRecursive(7)}");

        Console.WriteLine("\n\n=== String Space Count Examples ===");
        string sampleString = "This is a sample string with spaces.";
        Console.WriteLine($"\nCount spaces (iterative): {StringOperations.CountSpaceIterative(sampleString)}");
        Console.WriteLine($"Count spaces (recursive): {StringOperations.CountSpaceRecursive(sampleString)}");
    }

    public class Counters
    {
        public static void CountDownIterative(int number)
        {
            for (int i = number; i >= 0; i--)
            {
                Console.Write($"{i,3}");
            }
        }
        public static void CountDownRecursive(int number)
        {
            //base case
            if (number < 0) return;

            //action case
            Console.Write($"{number,3}");

            //recursive case
            CountDownRecursive(number - 1);

            //action case
            //Console.Write($"{number,3}");

        }
    }

    public class MathOperations
    {
        // Factorial: n! = n * (n-1) * (n-2) * ... * 1
        // Example: 5! = 5 * 4 * 3 * 2 * 1 = 120
        public static long FactorialIterative(long number)
        {
            var factor = number;
            for (long i = number - 1; i > 0; i--)
            {
                //action case
                factor *= i;
            }

            return factor;
        }
        public static long FactorialRecursive(long number)
        {
            //base case, Viewpoint A
            if (number <= 0) return 1;

            //action case and recursive case, Viewpoint B
            var factor = number * FactorialRecursive(number - 1);

            // Viewpoint C
            return factor;
        }

        // Sum from 1 to n
        // Example: Sum(5) = 1 + 2 + 3 + 4 + 5 = 15
        public static int SumIterative(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static int SumRecursive(int n)
        {
            // Base case: Sum(0) = 0
            if (n <= 0) return 0;

            // Recursive case: Sum(n) = n + Sum(n-1)
            return n + SumRecursive(n - 1);
        }

        // Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21...
        // Each number is the sum of the two preceding ones
        public static int FibonacciIterative(int n)
        {
            if (n <= 1) return n;
            
            int prev = 0, current = 1;
            for (int i = 2; i <= n; i++)
            {
                int next = prev + current;
                prev = current;
                current = next;
            }
            return current;
        }

        public static int FibonacciRecursive(int n)
        {
            // Base cases: Fib(0) = 0, Fib(1) = 1
            if (n <= 1) return n;

            // Recursive case: Fib(n) = Fib(n-1) + Fib(n-2)
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
    }

    public class StringOperations
    {
        public static int CountSpaceIterative(string myString)
        {
            int count = 0;
            foreach (var c in myString)
            {
                if (c == ' ')
                    count++;
            }
            return count;
        }

        public static int CountSpaceRecursive(string mystring, int idx = 0)
        {
            //base case
            if (idx >= mystring.Length)
                return 0;

            //action
            //var sum = mystring[idx] == ' ' ? 1 : 0;
            var sum = 0;
            if (mystring[idx] == ' ')
                sum = 1;

            //recursive case
            return sum + CountSpaceRecursive(mystring, idx + 1);
        }
    }
}
