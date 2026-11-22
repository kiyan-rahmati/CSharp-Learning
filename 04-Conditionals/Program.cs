// LESSON 04 - Conditionals: making decisions

// ---------- if / else if / else ----------
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade A");
}
else if (score >= 80)          // checked only if the previous conditions were false
{
    Console.WriteLine("Grade B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade C");
}
else                           // runs if nothing above matched
{
    Console.WriteLine("Grade F");
}

// A single statement may skip the braces, but braces are safer.
if (score > 50) Console.WriteLine("Passed");

// ---------- Combining conditions ----------
int age = 20;
bool hasTicket = true;
if (age >= 18 && hasTicket)
    Console.WriteLine("Welcome in");

// ---------- switch statement ----------
// Best when comparing ONE value against many constants.
int day = 3;
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;                 // break is REQUIRED: C# does not allow falling through
    case 2:
        Console.WriteLine("Tuesday");
        break;
    case 6:
    case 7:                    // several cases sharing one body
        Console.WriteLine("Weekend");
        break;
    default:                   // runs when nothing matches
        Console.WriteLine("Midweek day");
        break;
}

// ---------- switch expression (C# 8+): returns a value ----------
string dayName = day switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    _ => "Other"               // _ is the discard: matches anything else
};
Console.WriteLine(dayName);

// ---------- Pattern matching in switch expressions ----------
int temperature = 28;
string feel = temperature switch
{
    < 0 => "Freezing",
    >= 0 and < 15 => "Cold",
    >= 15 and < 25 => "Pleasant",
    >= 25 => "Hot"
};
Console.WriteLine(feel);

// ---------- 'is' pattern ----------
object obj = "hello";
if (obj is string text && text.Length > 3)   // test the type AND capture it in one step
    Console.WriteLine($"String of length {text.Length}");

if (obj is not null)
    Console.WriteLine("Not null");

// ---------- Nested conditions vs early exit ----------
// Prefer simple, flat conditions. Complex nesting is hard to read.
string? input = "42";
if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int number))
{
    Console.WriteLine($"Parsed {number}");
}
