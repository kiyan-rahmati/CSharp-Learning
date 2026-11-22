// LESSON 13 - Exception handling
//
// An EXCEPTION is an object that signals "something went wrong at runtime".
// If nobody handles it, the program crashes. try/catch lets you recover gracefully.

// ---------- Basic try / catch ----------
try
{
    int zero = 0;
    Console.WriteLine(10 / zero);               // throws DivideByZeroException
    Console.WriteLine("never printed");         // skipped once an exception is thrown
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

// ---------- Multiple catch blocks: MOST SPECIFIC first ----------
try
{
    string text = "abc";
    int number = int.Parse(text);               // FormatException
}
catch (FormatException ex)
{
    Console.WriteLine($"Bad format: {ex.Message}");
}
catch (OverflowException)
{
    Console.WriteLine("Number too large");
}
catch (Exception ex)                            // catch-all: keep it last
{
    Console.WriteLine($"Unexpected: {ex.GetType().Name}");
}
finally
{
    // finally ALWAYS runs: success, exception, or even return. Use for cleanup.
    Console.WriteLine("finally block executed");
}

// ---------- Exception filters (when) ----------
try
{
    throw new InvalidOperationException("code=404");
}
catch (InvalidOperationException ex) when (ex.Message.Contains("404"))
{
    Console.WriteLine("Handled only the 404 case");
}

// ---------- Throwing your own exceptions ----------
try
{
    Withdraw(balance: 50m, amount: 80m);
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Custom exception: {ex.Message} (missing {ex.Missing})");
}

// ---------- Re-throwing ----------
try
{
    try
    {
        throw new IOException("disk problem");
    }
    catch (IOException)
    {
        Console.WriteLine("Logging the error, then re-throwing...");
        throw;                                  // 'throw;' preserves the original stack trace ('throw ex;' would reset it)
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Outer caught: {ex.Message}");
}

// ---------- Wrapping with InnerException ----------
try
{
    try { _ = int.Parse("x"); }
    catch (FormatException inner)
    {
        throw new InvalidOperationException("Config value invalid", inner);
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"{ex.Message} <- caused by: {ex.InnerException?.GetType().Name}");
}

// ---------- using: guaranteed cleanup ----------
try
{
    using var reader = new StringReader("line1\nline2");
    Console.WriteLine(reader.ReadLine());
}   // reader is disposed here automatically (try/finally under the hood)
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// ---------- Avoid exceptions for normal flow: prefer TryParse ----------
if (!int.TryParse("12x", out int result))
    Console.WriteLine("Invalid number (no exception needed)");

// ---------- Common exceptions you will meet ----------
// NullReferenceException, IndexOutOfRangeException, ArgumentException, ArgumentNullException,
// InvalidOperationException, FormatException, KeyNotFoundException, FileNotFoundException,
// DivideByZeroException, OverflowException, InvalidCastException, NotImplementedException

void Withdraw(decimal balance, decimal amount)
{
    if (amount > balance)
        throw new InsufficientFundsException(amount - balance);
    Console.WriteLine("OK");
}

// A custom exception: inherit from Exception, name it with the "Exception" suffix.
class InsufficientFundsException : Exception
{
    public decimal Missing { get; }

    public InsufficientFundsException(decimal missing)
        : base($"Not enough money.")
    {
        Missing = missing;
    }
}
