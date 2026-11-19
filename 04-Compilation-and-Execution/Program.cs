// ============================================================
// Lesson 04: Conditions & Decision Making
// CSharp Learning Journey
// ============================================================
//
// In this lesson, we learn how to make decisions in C#
// using conditions and logical operators.
//
// Topics:
// 1. Boolean Data Type
// 2. Comparison Operators
// 3. If / Else
// 4. Else If
// 5. Logical Operators
// 6. Nested If
//
// ============================================================
// 01 - BOOLEAN
// ============================================================
//
// A bool variable can store only two values:
// true or false.
//
// Comparison operations return a boolean result.

/*
int age = 18;

bool result = age == 18;

Console.WriteLine(result);
*/

// Output:
// True


// ============================================================
// 02 - COMPARISON OPERATORS
// ============================================================
//
// ==  Equal to
// !=  Not equal to
// >   Greater than
// <   Less than
// >=  Greater than or equal to
// <=  Less than or equal to
//
// These operators compare two values
// and return true or false.

/*
int age = 18;

Console.WriteLine(age == 18);  // True
Console.WriteLine(age != 18);  // False
Console.WriteLine(age > 10);    // True
Console.WriteLine(age < 20);    // True
Console.WriteLine(age >= 18);  // True
Console.WriteLine(age <= 18);  // True
*/


// ============================================================
// 03 - IF / ELSE
// ============================================================
//
// The if statement executes a block of code
// if its condition is true.
//
// The else statement executes when the if condition is false.

/*
int age = 18;

if (age >= 20)
{
    Console.WriteLine("You are an adult.");
}
else
{
    Console.WriteLine("You are not old enough.");
}
*/


// ============================================================
// 04 - ELSE IF
// ============================================================
//
// else if allows us to check multiple conditions.
//
// The conditions are checked from top to bottom.
// The first true condition will be executed.

/*
int score = 8;

if (score >= 18)
{
    Console.WriteLine("Nice job!");
}
else if (score >= 10)
{
    Console.WriteLine("Passed");
}
else
{
    Console.WriteLine("Failed");
}
*/

// Output:
// Failed


// ============================================================
// 05 - LOGICAL OPERATORS
// ============================================================
//
// &&  AND -> Both conditions must be true.
// ||  OR  -> At least one condition must be true.
// !   NOT -> Reverses a boolean value.
//
// Example of AND:
//
// true && true   = true
// true && false  = false
//
// Example of OR:
//
// true || false  = true
// false || false = false
//
// Example of NOT:
//
// !true  = false
// !false = true

/*
bool isLoggedIn = true;
bool hasPermission = false;

Console.WriteLine(isLoggedIn && hasPermission); // False
Console.WriteLine(isLoggedIn || hasPermission); // True
Console.WriteLine(!isLoggedIn);                // False
*/


// ============================================================
// 06 - USING AND (&&)
// ============================================================
//
// Both conditions must be true.
//
// Example:
// A user must be at least 18 years old
// AND have a valid ID.

/*
int age = 20;
bool hasID = true;

if (age >= 18 && hasID)
{
    Console.WriteLine("Access granted.");
}
else
{
    Console.WriteLine("Access denied.");
}
*/


// ============================================================
// 07 - USING OR (||)
// ============================================================
//
// At least one condition must be true.
//
// Example:
// A user can enter if they have a student card
// OR a staff card.

/*
bool hasStudentCard = false;
bool hasStaffCard = true;

if (hasStudentCard || hasStaffCard)
{
    Console.WriteLine("Entry allowed.");
}
else
{
    Console.WriteLine("Entry denied.");
}
*/


// ============================================================
// 08 - NESTED IF
// ============================================================
//
// A nested if is an if statement inside another if statement.
//
// The inner condition is checked only
// when the outer condition is true.

/*
int age = 22;
bool hasLicense = true;

if (age >= 18)
{
    if (hasLicense)
    {
        Console.WriteLine("You can drive.");
    }
    else
    {
        Console.WriteLine("You need a driving license.");
    }
}
else
{
    Console.WriteLine("You are too young to drive.");
}
*/


// ============================================================
// 09 - PRACTICAL EXAMPLE: SCORE SYSTEM
// ============================================================
//
// This program evaluates a student's score.
//
// 18 - 20 : Excellent
// 10 - 17 : Passed
// 0 - 9   : Failed

/*
int score = 8;

if (score >= 18)
{
    Console.WriteLine("Excellent!");
}
else if (score >= 10)
{
    Console.WriteLine("Passed.");
}
else
{
    Console.WriteLine("Failed.");
}
*/


// ============================================================
// LESSON 04 SUMMARY
// ============================================================
//
// In this lesson, we learned:
//
// - bool
// - true and false
// - Comparison operators
// - if
// - else
// - else if
// - Logical operators
// - AND (&&)
// - OR (||)
// - NOT (!)
// - Nested if
//
// Conditions allow programs to make decisions
// based on different situations.
//
// ============================================================
