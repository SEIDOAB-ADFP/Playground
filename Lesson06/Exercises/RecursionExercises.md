# Recursion Exercises

## Key Concepts from RecursionBasics.cs and FileSystemChallange.cs

### Recursion Pattern Structure:
1. **Base Case** - The stopping condition (when to stop recursing)
2. **Action Case** - The work done at each level
3. **Recursive Case** - The call to itself with simpler/smaller input

### Three Key Viewpoints (from FactorialRecursive):
- **Viewpoint A**: Base case - check if we should stop
- **Viewpoint B**: Action + Recursive call - do work and recurse
- **Viewpoint C**: Return result back up the call stack

### Patterns Observed:
- **Linear Recursion**: One recursive call (CountDown, Factorial, Sum, CountSpace)
- **Multiple Recursion**: Multiple recursive calls (Fibonacci - two calls)
- **Tree/Directory Recursion**: Iterate and recurse (FileSystem traversal)
- **Index-based Recursion**: Pass index to process arrays/strings (CountSpaceRecursive)
- **Accumulator Pattern**: Count/sum during recursion (CountDirectories)

---

## Easy Exercises

### Exercise 1: Count Up
**Difficulty**: ⭐

Write a recursive function `CountUpRecursive(int number)` that counts from 0 to the given number.

**Example**: `CountUpRecursive(5)` should print: `0 1 2 3 4 5`

**Hint**: Think about when to print - before or after the recursive call?

<details>
<summary>Solution Skeleton</summary>

```csharp
public static void CountUpRecursive(int number)
{
    // Base case: ?
    if (number < 0) return;
    
    // Recursive case: ?
    
    // Action case: ?
}
```
</details>

---

### Exercise 2: Count Vowels in a String
**Difficulty**: ⭐⭐

Write a recursive function `CountVowelsRecursive(string text, int index = 0)` that counts the number of vowels (a, e, i, o, u) in a string.

**Example**: `CountVowelsRecursive("Hello World")` should return `3`

**Hint**: Similar to CountSpaceRecursive - check if current character is a vowel, then recurse for the rest.

<details>
<summary>Solution Skeleton</summary>

```csharp
public static int CountVowelsRecursive(string text, int index = 0)
{
    // Base case: reached end of string?
    
    // Action: is current char a vowel?
    
    // Recursive case: count vowels in remaining string
}
```
</details>

---

### Exercise 3: Is Palindrome
**Difficulty**: ⭐⭐

Write a recursive function `IsPalindromeRecursive(string text)` that checks if a string is a palindrome (reads the same forwards and backwards).

**Example**: 
- `IsPalindromeRecursive("racecar")` → `true`
- `IsPalindromeRecursive("hello")` → `false`

**Hint**: Compare first and last character, then recurse on the middle portion.

<details>
<summary>Solution Skeleton</summary>

```csharp
public static bool IsPalindromeRecursive(string text)
{
    // Base case: empty or single character?
    
    // Action: compare first and last characters
    
    // Recursive case: check middle portion
}
```
</details>

---

### Exercise 4: Sum of Digits
**Difficulty**: ⭐⭐

Write a recursive function `SumOfDigitsRecursive(int number)` that returns the sum of all digits in a number.

**Example**: `SumOfDigitsRecursive(1234)` should return `10` (1+2+3+4)

**Hint**: Use modulo (%) to get last digit, divide by 10 to get remaining digits.

<details>
<summary>Solution Skeleton</summary>

```csharp
public static int SumOfDigitsRecursive(int number)
{
    // Base case: no more digits?
    
    // Action: extract last digit
    
    // Recursive case: add last digit to sum of remaining digits
}
```
</details>

---

### Exercise 5: Find Maximum in Array
**Difficulty**: ⭐⭐

Write a recursive function `FindMaxRecursive(int[] array, int index = 0)` that finds the maximum value in an array.

**Example**: `FindMaxRecursive([3, 7, 2, 9, 1])` should return `9`

**Hint**: Compare current element with max of remaining elements.

<details>
<summary>Solution Skeleton</summary>

```csharp
public static int FindMaxRecursive(int[] array, int index = 0)
{
    // Base case: reached last element?
    
    // Recursive case: max of remaining elements
    
    // Action: compare current element with max of rest
}
```
</details>

---

### Exercise 6: Count Occurrences
**Difficulty**: ⭐⭐

Write a recursive function `CountOccurrencesRecursive(int[] array, int target, int index = 0)` that counts how many times a target value appears in an array.

**Example**: `CountOccurrencesRecursive([1, 2, 3, 2, 4, 2], 2)` should return `3`

**Hint**: Similar to CountSpaceRecursive but for array elements.

---

### Exercise 7: Greatest Common Divisor (GCD)
**Difficulty**: ⭐⭐⭐

Write a recursive function `GCDRecursive(int a, int b)` using Euclidean algorithm.

**Example**: `GCDRecursive(48, 18)` should return `6`

**Hint**: GCD(a, b) = GCD(b, a % b), base case when b = 0.

---


## Tips for Success

1. **Always identify the base case first** - what's the simplest input?
2. **Trust the recursion** - assume the recursive call works for smaller inputs
3. **Trace small examples** - manually trace with small inputs (n=0, n=1, n=2)
4. **Watch the call stack** - understand what happens at each level
5. **Consider space complexity** - recursion uses stack space
6. **Tail recursion** - when possible, make the recursive call the last operation

## Common Pitfalls

❌ Forgetting the base case → infinite recursion (stack overflow)
❌ Wrong base case → wrong results or stack overflow
❌ Not making progress toward base case → infinite recursion
❌ Modifying parameters incorrectly → wrong results
❌ Not handling edge cases (empty string, null, negative numbers)

## Testing Your Solutions

For each exercise, test with:
- **Boundary cases**: empty input, single element, zero
- **Small cases**: 1-3 elements
- **Typical cases**: normal sized input
- **Edge cases**: negative numbers, special characters, etc.
