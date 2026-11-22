// Lesson 28: Delegates and Events
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Represent callable behavior and publish notifications.

Action<string> notify = message => Console.WriteLine(message);\nnotify("A notification was received.");

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
