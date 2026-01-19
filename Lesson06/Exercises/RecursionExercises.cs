namespace Playground.Lesson06;

public static class RecursionExercises
{
    public static void RunExamples()
    {
        Console.WriteLine("=== Exercise 1: Count Up ===");
        CountUpRecursive(5);
        
        Console.WriteLine("\n\n=== Exercise 2: Count Vowels ===");
        string text = "Hello World";
        Console.WriteLine($"Text: '{text}'");
        Console.WriteLine($"Vowel count: {CountVowelsRecursive(text)}");
        
        Console.WriteLine("\n\n=== Exercise 3: Is Palindrome ===");
        Console.WriteLine($"'racecar' is palindrome: {IsPalindromeRecursive("racecar")}");
        Console.WriteLine($"'hello' is palindrome: {IsPalindromeRecursive("hello")}");
        Console.WriteLine($"'A man a plan a canal Panama' is palindrome: {IsPalindromeRecursive("AmanaplanacanalPanama")}");
        
        Console.WriteLine("\n\n=== Exercise 4: Sum of Digits ===");
        Console.WriteLine($"Sum of digits in 1234: {SumOfDigitsRecursive(1234)}");
        Console.WriteLine($"Sum of digits in 9876: {SumOfDigitsRecursive(9876)}");
        
        Console.WriteLine("\n\n=== Exercise 5: Find Maximum ===");
        int[] numbers = { 3, 7, 2, 9, 1 };
        Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"Maximum: {FindMaxRecursive(numbers)}");
        
        Console.WriteLine("\n\n=== Exercise 6: Count Occurrences ===");
        int[] array = { 1, 2, 3, 2, 4, 2 };
        Console.WriteLine($"Array: [{string.Join(", ", array)}]");
        Console.WriteLine($"Occurrences of 2: {CountOccurrencesRecursive(array, 2)}");
        Console.WriteLine($"Occurrences of 5: {CountOccurrencesRecursive(array, 5)}");
        
        Console.WriteLine("\n\n=== Exercise 7: GCD ===");
        Console.WriteLine($"GCD(48, 18) = {GCDRecursive(48, 18)}");
        Console.WriteLine($"GCD(100, 35) = {GCDRecursive(100, 35)}");
        Console.WriteLine($"GCD(17, 19) = {GCDRecursive(17, 19)}");
    }

    // ==================== Exercise 1: Count Up ====================
    public static void CountUpRecursive(int number)
    {
        // Base case: negative numbers, stop recursion
        
        // Recursive case: count up to number - 1 first
        
        // Action case: print current number (after recursive call)
    }

    // ==================== Exercise 2: Count Vowels ====================
    public static int CountVowelsRecursive(string text, int index = 0)
    {
        // Base case: reached end of string
        
        // Action: check if current character is a vowel
        
        // Recursive case: add current count to vowels in remaining string
        return 0; // placeholder
    }

    // ==================== Exercise 3: Is Palindrome ====================
    public static bool IsPalindromeRecursive(string text)
    {
        // Base case: empty or single character is a palindrome
        
        // Action: compare first and last characters
        
        // Recursive case: check if middle portion is palindrome
        return false; // placeholder
    }

    // ==================== Exercise 4: Sum of Digits ====================
    public static int SumOfDigitsRecursive(int number)
    {
        // Handle negative numbers
        
        // Base case: no more digits (single digit)
        
        // Action: extract last digit using modulo
        
        // Recursive case: add last digit to sum of remaining digits
        return 0; // placeholder
    }

    // ==================== Exercise 5: Find Maximum ====================
    public static int FindMaxRecursive(int[] array, int index = 0)
    {
        // Base case: reached last element
        
        // Recursive case: get max of remaining elements
        
        // Action: compare current element with max of rest
        return  0; // placeholder
    }


    // ==================== Exercise 6: Count Occurrences ====================
    public static int CountOccurrencesRecursive(int[] array, int target, int index = 0)
    {
        // Base case: reached end of array
        
        // Action: check if current element matches target
        
        // Recursive case: add current count to occurrences in remaining array
        return 0; // placeholder
    }

    // ==================== Exercise 7: GCD (Euclidean Algorithm) ====================
    public static int GCDRecursive(int a, int b)
    {
        // Base case: when b is 0, GCD is a
        
        // Recursive case: GCD(a, b) = GCD(b, a % b)
        return 0; // placeholder
    }
}
