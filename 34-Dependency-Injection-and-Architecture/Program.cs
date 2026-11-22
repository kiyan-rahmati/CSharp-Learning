// Lesson 34: Dependency Injection and Architecture
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Separate application responsibilities and inject dependencies.

IMessageSender sender = new ConsoleMessageSender();\nvar service = new WelcomeService(sender);\nservice.SendWelcome();\n\ninterface IMessageSender { void Send(string message); }\nclass ConsoleMessageSender : IMessageSender { public void Send(string message) => Console.WriteLine(message); }\nclass WelcomeService(IMessageSender sender) { public void SendWelcome() => sender.Send("Welcome!"); }

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
