// LESSON 03 - Operators and type conversion

// ---------- Arithmetic ----------
int a = 17, b = 5;
Console.WriteLine(a + b);        // 22  addition
Console.WriteLine(a - b);        // 12  subtraction
Console.WriteLine(a * b);        // 85  multiplication
Console.WriteLine(a / b);        // 3   INTEGER division: the fraction is dropped!
Console.WriteLine(a % b);        // 2   remainder (modulo)
Console.WriteLine((double)a / b);// 3.4 cast one side to double to get real division

// ---------- Increment / decrement ----------
int i = 5;
i++;                              // i = i + 1  -> 6
i--;                              // i = i - 1  -> 5
int x = i++;                      // postfix: x gets the OLD value (5), then i becomes 6
int y = ++i;                      // prefix: i becomes 7 first, then y gets 7
Console.WriteLine($"x={x}, y={y}, i={i}");

// ---------- Compound assignment ----------
int n = 10;
n += 5;   // n = n + 5  -> 15
n -= 3;   // 12
n *= 2;   // 24
n /= 4;   // 6
n %= 4;   // 2
Console.WriteLine(n);

// ---------- Comparison (result is bool) ----------
Console.WriteLine(5 == 5);       // equal
Console.WriteLine(5 != 4);       // not equal
Console.WriteLine(5 > 3);        // greater than
Console.WriteLine(5 <= 5);       // less or equal

// ---------- Logical ----------
bool t = true, f = false;
Console.WriteLine(t && f);       // AND: both must be true -> false
Console.WriteLine(t || f);       // OR: at least one true -> true
Console.WriteLine(!t);           // NOT -> false
// && and || SHORT-CIRCUIT: the right side is skipped if the result is already known.

// ---------- Ternary operator: condition ? valueIfTrue : valueIfFalse ----------
int score = 72;
string result = score >= 50 ? "Pass" : "Fail";
Console.WriteLine(result);

// ---------- Null operators ----------
string? maybeNull = null;
Console.WriteLine(maybeNull ?? "default");      // ?? : use right side if left is null
maybeNull ??= "assigned";                       // ??= : assign only if currently null
Console.WriteLine(maybeNull);
Console.WriteLine(maybeNull?.Length);           // ?. : returns null instead of crashing if object is null

// ---------- Operator precedence ----------
// * / % are evaluated before + -. Use parentheses to be clear.
Console.WriteLine(2 + 3 * 4);    // 14
Console.WriteLine((2 + 3) * 4);  // 20

// ---------- Implicit conversion (safe, automatic) ----------
int small = 100;
long bigger = small;             // int -> long never loses data
double dbl = small;              // int -> double fine

// ---------- Explicit conversion (cast, may lose data) ----------
double pi = 3.99;
int truncated = (int)pi;         // 3  (the fraction is CUT OFF, not rounded)
Console.WriteLine(truncated);
Console.WriteLine(Math.Round(pi));   // 4

// ---------- Converting text to numbers ----------
int parsed = int.Parse("123");           // throws FormatException if the text is invalid
Console.WriteLine(parsed + 1);

if (int.TryParse("abc", out int value))  // TryParse never throws: it returns true/false
    Console.WriteLine($"OK {value}");
else
    Console.WriteLine("Not a valid number");

// ---------- Convert class and ToString ----------
string text = 42.ToString();             // "42"
double fromString = Convert.ToDouble("3.5");
Console.WriteLine(text + fromString);

// ---------- Bitwise (advanced, for flags/low-level work) ----------
Console.WriteLine(5 & 3);   // AND = 1  (101 & 011 = 001)
Console.WriteLine(5 | 3);   // OR  = 7
Console.WriteLine(5 ^ 3);   // XOR = 6
Console.WriteLine(1 << 3);  // shift left = 8
