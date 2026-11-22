// LESSON 05 - Loops: repeating work

// ---------- for: use when you know how many times ----------
// for (initializer; condition; iterator)
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"for: {i}");
}

// ---------- while: use when you repeat UNTIL a condition changes ----------
int countdown = 3;
while (countdown > 0)            // condition is checked BEFORE each pass
{
    Console.WriteLine($"while: {countdown}");
    countdown--;                 // forgetting this = infinite loop!
}

// ---------- do-while: always runs at least once ----------
int tries = 0;
do
{
    tries++;
    Console.WriteLine($"do-while attempt {tries}");
} while (tries < 2);             // condition is checked AFTER each pass

// ---------- foreach: iterate over every item in a collection ----------
string[] languages = { "C#", "JavaScript", "PHP" };
foreach (string lang in languages)
{
    Console.WriteLine($"foreach: {lang}");   // you cannot modify the collection while inside
}

// ---------- break and continue ----------
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0) continue;    // skip the rest of THIS iteration, go to the next
    if (i > 7) break;            // leave the loop completely
    Console.WriteLine($"odd: {i}");
}

// ---------- Nested loops: multiplication table ----------
for (int row = 1; row <= 3; row++)
{
    for (int col = 1; col <= 3; col++)
    {
        Console.Write($"{row * col}\t");
    }
    Console.WriteLine();
}

// ---------- Accumulator pattern: sum of 1..100 ----------
int sum = 0;
for (int i = 1; i <= 100; i++) sum += i;
Console.WriteLine($"Sum 1..100 = {sum}");     // 5050

// ---------- Looping backwards ----------
for (int i = 3; i >= 1; i--) Console.Write(i + " ");
Console.WriteLine();

// ---------- Practical example: find first prime above 50 ----------
int candidate = 51;
while (true)                    // intentional infinite loop, exited with break
{
    bool isPrime = candidate > 1;
    for (int d = 2; d * d <= candidate; d++)   // only need to test up to the square root
    {
        if (candidate % d == 0) { isPrime = false; break; }
    }
    if (isPrime) break;
    candidate++;
}
Console.WriteLine($"First prime > 50: {candidate}");   // 53
