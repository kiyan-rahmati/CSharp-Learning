// ============================================================
// Lesson 05: Loops & Iteration
// CSharp Learning Journey
// ============================================================
//
// In this lesson, we learn how to repeat instructions using loops.
//
// Topics:
// 1. For Loop
// 2. While Loop
// 3. Increment & Decrement
// 4. Break & Continue
// 5. Nested Loops
// 6. Factorial
// 7. Star Patterns
//
// ============================================================
// 01 - FOR LOOP
// ============================================================
//
// A for loop is used when we want to repeat code
// a specific number of times or within a defined range.
//
// Syntax:
// for (initialization; condition; increment/decrement)
//
// Example: Print numbers from 1 to 5.

/*
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
*/

// Output:
// 1
// 2
// 3
// 4
// 5


// ============================================================
// 02 - INCREMENT & DECREMENT OPERATORS
// ============================================================
//
// i++  -> i = i + 1
// i--  -> i = i - 1
//
// i += 2 -> i = i + 2
// i -= 2 -> i = i - 2
//
// These operators are commonly used to control loop counters.

/*
int i = 1;

i++;
i += 2;
i--;
i -= 2;

Console.WriteLine(i);
*/


// ============================================================
// 03 - PRINT EVEN NUMBERS
// ============================================================
//
// Even numbers are divisible by 2.
//
// Instead of increasing the counter by 1,
// we increase it by 2 to print only even numbers.

/*
for (int i = 2; i <= 20; i += 2)
{
    Console.WriteLine(i);
}
*/

// Output:
// 2, 4, 6, 8, 10, 12, 14, 16, 18, 20


// ============================================================
// 04 - REVERSE COUNTING
// ============================================================
//
// We can use a for loop to count backwards.
// The counter decreases using i--.

/*
for (int i = 7; i >= 3; i--)
{
    Console.WriteLine(i);
}
*/

// Output:
// 7
// 6
// 5
// 4
// 3


// ============================================================
// 05 - WHILE LOOP
// ============================================================
//
// A while loop repeats code as long as its condition is true.
//
// Important:
// Make sure the condition eventually becomes false.
// Otherwise, the loop may run forever.

/*
int number = 1;

while (number <= 5)
{
    Console.WriteLine(number);
    number++;
}
*/

// Output:
// 1
// 2
// 3
// 4
// 5


// ============================================================
// 06 - BREAK
// ============================================================
//
// The break statement immediately terminates the loop.
//
// In this example, the loop stops when i reaches 5.

/*
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        break;
    }

    Console.WriteLine(i);
}
*/

// Output:
// 1
// 2
// 3
// 4


// ============================================================
// 07 - CONTINUE
// ============================================================
//
// The continue statement skips the current iteration
// and moves to the next iteration of the loop.
//
// In this example, number 3 will not be printed.

/*
for (int i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        continue;
    }

    Console.WriteLine(i);
}
*/

// Output:
// 1
// 2
// 4
// 5


// ============================================================
// 08 - NESTED LOOPS
// ============================================================
//
// A nested loop is a loop inside another loop.
//
// The inner loop executes completely during every iteration
// of the outer loop.
//
// In this example:
// - The outer loop runs 3 times.
// - The inner loop runs 2 times per outer iteration.
// - Total executions: 3 * 2 = 6.

/*
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 2; j++)
    {
        Console.WriteLine($"i: {i}, j: {j}");
    }
}
*/


// ============================================================
// 09 - MULTIPLICATION TABLE
// ============================================================
//
// Nested loops can be used to create multiplication tables.
//
// The outer loop controls the rows.
// The inner loop controls the columns.
//
// Console.Write keeps numbers on the same line.
// Console.WriteLine moves to the next line.

/*
for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= 5; j++)
    {
        Console.Write($"{i * j,4}");
    }

    Console.WriteLine();
}
*/


// ============================================================
// 10 - FACTORIAL USING WHILE
// ============================================================
//
// Factorial is the product of all positive integers
// from a number down to 1.
//
// Example:
// 5! = 5 * 4 * 3 * 2 * 1 = 120
//
// The variable f stores the multiplication result.
// It starts from 1 because multiplying by 0 always gives 0.
//
// The while loop decreases i until it reaches 0.

/*
int i = 5;
int f = 1;

while (i > 0)
{
    f *= i;
    i--;
}

Console.WriteLine(f);
*/

// Output:
// 120


// ============================================================
// 11 - STAR PATTERN (ASCENDING)
// ============================================================
//
// Nested loops can be used to create patterns.
//
// The outer loop controls the number of rows.
// The inner loop controls how many stars are printed.
//
// Each new row contains one additional star.

/*
for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}
*/

// Output:
// *
// **
// ***
// ****
// *****


// ============================================================
// 12 - STAR PATTERN (DESCENDING)
// ============================================================
//
// This pattern starts with 5 stars.
// Each new row contains one fewer star.
//
// The outer loop decreases i.
// The inner loop prints stars based on the current value of i.

/*
for (int i = 5; i >= 1; i--)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}
*/

// Output:
// *****
// ****
// ***
// **
// *


/*
==============================================================
LESSON 05 SUMMARY
==============================================================

In this lesson, we learned:

- for loops
- while loops
- loop counters
- increment and decrement operators
- break
- continue
- nested loops
- multiplication tables
- factorial calculations
- star patterns

==============================================================
*/

Console.WriteLine("CSharp Learning Journey - Lesson 05");
Console.WriteLine("Loops & Iteration");