// Lesson 23: Encapsulation and Abstraction
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Protect invariants and expose behavior instead of raw state.

var account = new Account();\naccount.Deposit(50);\nConsole.WriteLine(account.Balance);\n\nclass Account\n{ private decimal _balance; public decimal Balance => _balance; public void Deposit(decimal amount) { if (amount > 0) _balance += amount; } }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
