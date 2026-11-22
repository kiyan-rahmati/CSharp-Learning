// LESSON 08 - Strings
//
// string is a sequence of characters. Strings are IMMUTABLE: every "change" produces a NEW string.

string text = "  Hello, C# World!  ";

// ---------- Basic properties ----------
Console.WriteLine(text.Length);              // number of characters (including spaces)
Console.WriteLine(text[2]);                  // 'H' (indexing like an array, read-only)

// ---------- Case and whitespace ----------
Console.WriteLine(text.ToUpper());
Console.WriteLine(text.ToLower());
Console.WriteLine(text.Trim());              // removes leading/trailing spaces
Console.WriteLine(text.TrimStart() + "|");
Console.WriteLine(text.TrimEnd() + "|");

string s = text.Trim();

// ---------- Searching ----------
Console.WriteLine(s.Contains("C#"));         // true
Console.WriteLine(s.StartsWith("Hello"));    // true
Console.WriteLine(s.EndsWith("!"));          // true
Console.WriteLine(s.IndexOf("C#"));          // 7 (position, or -1 if missing)
Console.WriteLine(s.LastIndexOf('l'));

// ---------- Extracting and modifying ----------
Console.WriteLine(s.Substring(7, 2));        // "C#"  (start index, length)
Console.WriteLine(s.Substring(7));           // from index 7 to the end
Console.WriteLine(s[7..9]);                  // range syntax, same as above
Console.WriteLine(s.Replace("World", "Developers"));
Console.WriteLine(s.Remove(5));              // remove everything from index 5
Console.WriteLine(s.Insert(5, "!!!"));
Console.WriteLine(s.PadLeft(25, '*'));       // pad to total width 25
Console.WriteLine("7".PadLeft(3, '0'));      // "007"

// ---------- Split and Join ----------
string csv = "ali,sara,reza";
string[] parts = csv.Split(',');             // ["ali","sara","reza"]
Console.WriteLine(parts.Length);
Console.WriteLine(string.Join(" - ", parts));
string[] words = "one  two   three".Split(' ', StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine(words.Length);             // 3

// ---------- Comparing ----------
string a = "apple", b = "APPLE";
Console.WriteLine(a == b);                                       // false (case-sensitive)
Console.WriteLine(a.Equals(b, StringComparison.OrdinalIgnoreCase)); // true
Console.WriteLine(string.Compare("a", "b"));                     // negative: "a" sorts before "b"

// ---------- Checking for empty ----------
string? empty = "";
string? blank = "   ";
Console.WriteLine(string.IsNullOrEmpty(empty));       // true
Console.WriteLine(string.IsNullOrWhiteSpace(blank));  // true  <- best for user input

// ---------- Building strings ----------
// Concatenation with + inside loops is slow (a new string every time).
// StringBuilder modifies one buffer, so use it for many appends.
var sb = new System.Text.StringBuilder();
for (int i = 1; i <= 5; i++)
{
    sb.Append(i).Append(',');
}
sb.Length--;                                 // remove the trailing comma
Console.WriteLine(sb.ToString());            // 1,2,3,4,5

// ---------- Formatting ----------
double price = 1234.5678;
Console.WriteLine($"{price:F2}");            // 1234.57  (2 decimals)
Console.WriteLine($"{price:N2}");            // 1,234.57 (thousands separators; depends on culture)
Console.WriteLine($"{0.256:P1}");            // 25.6%
Console.WriteLine($"{42,6}|{"left",-8}|");    // alignment: width 6 right, width 8 left
Console.WriteLine($"{DateTime.Now:yyyy-MM-dd}");

// ---------- Characters ----------
char c = 'g';
Console.WriteLine(char.IsLetter(c));
Console.WriteLine(char.IsDigit('7'));
Console.WriteLine(char.ToUpper(c));
Console.WriteLine((int)c);                   // the character's numeric code: 103

// ---------- Raw string literal (C# 11): multi-line text, no escaping ----------
string json = """
    {
        "name": "Kiyan",
        "quote": "no \ escaping needed"
    }
    """;
Console.WriteLine(json);

// ---------- Palindrome example ----------
string word = "Level";
string cleaned = word.ToLower();
bool isPalindrome = cleaned.SequenceEqual(cleaned.Reverse());   // LINQ on a string (Lesson 15)
Console.WriteLine($"{word} palindrome? {isPalindrome}");
