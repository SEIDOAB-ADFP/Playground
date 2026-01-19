namespace Playground.Lesson06;

public static class RecursionExercisesAnswers
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
        if (number < 0) return;
        
        // Recursive case: count up to number - 1 first
        CountUpRecursive(number - 1);
        
        // Action case: print current number (after recursive call)
        Console.Write($"{number} ");
    }

    // ==================== Exercise 2: Count Vowels ====================
    public static int CountVowelsRecursive(string text, int index = 0)
    {
        // Base case: reached end of string
        if (index >= text.Length)
            return 0;
        
        // Action: check if current character is a vowel
        char currentChar = char.ToLower(text[index]);
        int count = (currentChar == 'a' || currentChar == 'e' || 
                     currentChar == 'i' || currentChar == 'o' || 
                     currentChar == 'u') ? 1 : 0;
        
        // Recursive case: add current count to vowels in remaining string
        return count + CountVowelsRecursive(text, index + 1);
    }

    // ==================== Exercise 3: Is Palindrome ====================
    public static bool IsPalindromeRecursive(string text)
    {
        // Base case: empty or single character is a palindrome
        if (text.Length <= 1)
            return true;
        
        // Action: compare first and last characters
        if (text[0] != text[^1])
            return false;
        
        // Recursive case: check if middle portion is palindrome
        return IsPalindromeRecursive(text[1..^1]);
    }

    // Alternative version with start and end indices
    public static bool IsPalindromeRecursive(string text, int start, int end)
    {
        // Base case: pointers have met or crossed
        if (start >= end)
            return true;
        
        // Action: compare characters at start and end
        if (text[start] != text[end])
            return false;
        
        // Recursive case: check inner substring
        return IsPalindromeRecursive(text, start + 1, end - 1);
    }

    // ==================== Exercise 4: Sum of Digits ====================
    public static int SumOfDigitsRecursive(int number)
    {
        // Handle negative numbers
        number = Math.Abs(number);
        
        // Base case: no more digits (single digit)
        if (number < 10)
            return number;
        
        // Action: extract last digit using modulo
        int lastDigit = number % 10;
        
        // Recursive case: add last digit to sum of remaining digits
        return lastDigit + SumOfDigitsRecursive(number / 10);
    }

    // ==================== Exercise 5: Find Maximum ====================
    public static int FindMaxRecursive(int[] array, int index = 0)
    {
        // Base case: reached last element
        if (index == array.Length - 1)
            return array[index];
        
        // Recursive case: get max of remaining elements
        int maxOfRest = FindMaxRecursive(array, index + 1);
        
        // Action: compare current element with max of rest
        return Math.Max(array[index], maxOfRest);
    }

    // Alternative version without default parameter
    public static int FindMaxRecursive(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array cannot be null or empty");
        
        return FindMaxRecursiveHelper(array, 0);
    }

    private static int FindMaxRecursiveHelper(int[] array, int index)
    {
        if (index == array.Length - 1)
            return array[index];
        
        int maxOfRest = FindMaxRecursiveHelper(array, index + 1);
        return Math.Max(array[index], maxOfRest);
    }

    // ==================== Exercise 6: Count Occurrences ====================
    public static int CountOccurrencesRecursive(int[] array, int target, int index = 0)
    {
        // Base case: reached end of array
        if (index >= array.Length)
            return 0;
        
        // Action: check if current element matches target
        int count = (array[index] == target) ? 1 : 0;
        
        // Recursive case: add current count to occurrences in remaining array
        return count + CountOccurrencesRecursive(array, target, index + 1);
    }

    // ==================== Exercise 7: GCD (Euclidean Algorithm) ====================
    public static int GCDRecursive(int a, int b)
    {
        // Base case: when b is 0, GCD is a
        if (b == 0)
            return a;
        
        // Recursive case: GCD(a, b) = GCD(b, a % b)
        return GCDRecursive(b, a % b);
    }
}
