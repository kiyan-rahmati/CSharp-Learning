// LESSON 07 - Methods (functions)
//
// A method is a named, reusable block of code. Benefits: no repetition, easier testing, readability.
// Syntax:  accessModifier returnType Name(parameters) { body }
// With top-level statements, methods defined here are "local functions" and can be used anywhere in the file.

// ---------- Calling methods ----------
SayHello();                              // no parameters, no return value
SayHelloTo("Kiyan");                     // one parameter
int total = Add(3, 4);                   // returns a value
Console.WriteLine($"Add = {total}");

// ---------- Optional parameters and named arguments ----------
Console.WriteLine(Power(2));             // exponent defaults to 2 -> 4
Console.WriteLine(Power(2, 10));         // 1024
Console.WriteLine(Power(exponent: 3, baseNumber: 2));   // named arguments, any order -> 8

// ---------- Overloading: same name, different parameters ----------
Console.WriteLine(Describe(5));          // int version
Console.WriteLine(Describe("text"));     // string version
Console.WriteLine(Describe(5, 6));       // two-int version

// ---------- Returning multiple values with tuples ----------
var (min, max) = MinMax(new[] { 4, 9, 1, 7 });
Console.WriteLine($"min={min}, max={max}");

// ---------- out parameters ----------
if (TryDivide(10, 2, out double quotient))
    Console.WriteLine($"10/2 = {quotient}");
if (!TryDivide(1, 0, out _))             // _ discards a value we don't need
    Console.WriteLine("Cannot divide by zero");

// ---------- ref: pass a variable by reference (method can modify the caller's variable) ----------
int x = 5;
DoubleIt(ref x);
Console.WriteLine($"x after DoubleIt = {x}");     // 10

// Without ref, value types are COPIED, so changes inside are lost:
int y = 5;
DoubleCopy(y);
Console.WriteLine($"y after DoubleCopy = {y}"); // still 5

// ---------- params: variable number of arguments ----------
Console.WriteLine(Sum(1, 2, 3, 4, 5));   // 15
Console.WriteLine(Sum());                // 0

// ---------- Expression-bodied methods ----------
Console.WriteLine(Square(9));

// ---------- Recursion: a method that calls itself (needs a base case!) ----------
Console.WriteLine(Factorial(5));         // 120
Console.WriteLine(Fibonacci(10));        // 55

// ================= Method definitions =================
void SayHello() => Console.WriteLine("Hello!");

void SayHelloTo(string name)
{
    Console.WriteLine($"Hello, {name}!");
}

int Add(int a, int b)
{
    return a + b;                        // 'return' ends the method and sends back a value
}

int Power(int baseNumber, int exponent = 2)    // optional parameters must come last
{
    int result = 1;
    for (int i = 0; i < exponent; i++) result *= baseNumber;
    return result;
}

string Describe(int n) => $"int {n}";
string Describe(string s) => $"string '{s}'";
string Describe(int a, int b) => $"two ints {a},{b}";

(int Min, int Max) MinMax(int[] values)
{
    int lo = values[0], hi = values[0];
    foreach (int v in values)
    {
        if (v < lo) lo = v;
        if (v > hi) hi = v;
    }
    return (lo, hi);
}

bool TryDivide(double a, double b, out double result)
{
    if (b == 0) { result = 0; return false; }   // out parameters MUST be assigned before returning
    result = a / b;
    return true;
}

void DoubleIt(ref int number) => number *= 2;
void DoubleCopy(int number) => number *= 2;

int Sum(params int[] numbers)
{
    int s = 0;
    foreach (int n in numbers) s += n;
    return s;
}

int Square(int n) => n * n;              // => is the "expression-bodied" shorthand

long Factorial(int n)
{
    if (n <= 1) return 1;                // base case stops the recursion
    return n * Factorial(n - 1);         // recursive case
}

int Fibonacci(int n) => n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
