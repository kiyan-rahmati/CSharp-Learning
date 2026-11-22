// LESSON 02 - Variables and data types
//
// A variable is a named box in memory that holds a value of a specific TYPE.
// C# is statically typed: the type is fixed at compile time.

// ---------- Integers (whole numbers) ----------
byte  smallNumber = 255;                 // 0 .. 255 (8 bits, unsigned)
short shortNumber = -32000;              // -32,768 .. 32,767 (16 bits)
int   age = 21;                          // about -2.1 billion .. 2.1 billion (32 bits) <- the default choice
long  population = 8_000_000_000L;       // 64 bits; the L suffix marks a long literal; _ is a digit separator
Console.WriteLine($"{smallNumber}, {shortNumber}, {age}, {population}");

// ---------- Floating-point (decimals) ----------
float   f = 3.14f;                       // 32-bit, ~7 digits precision, needs f suffix
double  d = 3.14159265358979;            // 64-bit, ~15 digits precision <- default for decimals
decimal price = 19.99m;                  // 128-bit, exact base-10 math, needs m suffix <- USE FOR MONEY
Console.WriteLine($"{f}, {d}, {price}");

// Why decimal for money? double stores binary approximations:
Console.WriteLine(0.1 + 0.2);            // 0.30000000000000004 (double)
Console.WriteLine(0.1m + 0.2m);          // 0.3 (decimal, exact)

// ---------- Text ----------
char letter = 'A';                       // ONE character, single quotes
string name = "Kiyan";                   // text, double quotes
Console.WriteLine($"{letter} {name}");

// ---------- Boolean ----------
bool isStudent = true;                   // only true or false
bool hasJob = false;
Console.WriteLine($"{isStudent} {hasJob}");

// ---------- var: let the compiler infer the type ----------
var city = "Rasht";                      // inferred as string
var count = 10;                          // inferred as int
// count = "ten";                        // ERROR: it's still an int, var is NOT dynamic typing
Console.WriteLine($"{city} {count}");

// ---------- const and readonly ----------
const double Pi = 3.14159;               // value fixed at compile time, can never change
// Pi = 3;                               // ERROR
Console.WriteLine(Pi);

// ---------- Default values ----------
int    defaultInt  = default;            // 0
bool   defaultBool = default;            // false
string? defaultStr = default;            // null (string is a reference type)
Console.WriteLine($"{defaultInt} {defaultBool} {defaultStr ?? "null"}");

// ---------- Min/Max values of types ----------
Console.WriteLine($"int range: {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"double max: {double.MaxValue}");

// ---------- Overflow ----------
int big = int.MaxValue;
unchecked { big = big + 1; }             // wraps around silently to a negative number
Console.WriteLine($"Overflow result: {big}");
// checked { big = int.MaxValue; big++; } // would throw OverflowException instead

// ---------- Naming rules ----------
// - letters, digits, underscore; cannot start with a digit; cannot be a keyword
// - Convention: camelCase for local variables (userName), PascalCase for constants/types (MaxSize)

// ---------- Value types vs reference types ----------
// Value types (int, double, bool, char, struct, enum) store the value itself.
// Reference types (string, arrays, classes) store a reference (address) to the object on the heap.
int a = 5;
int b = a;      // b gets a COPY
b = 10;
Console.WriteLine($"a={a}, b={b}");      // a=5, b=10

int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;                       // arr2 points to the SAME array
arr2[0] = 99;
Console.WriteLine($"arr1[0]={arr1[0]}"); // 99, because both variables refer to one array
