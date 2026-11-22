// Lesson 20: Stacks and Queues
// Runnable learning example. Read, predict, run, then modify the code.
// Focus: Understand LIFO/FIFO and use built-in collection types.

var stack = new Stack<string>();\nstack.Push("first"); stack.Push("second");\nConsole.WriteLine(stack.Pop());\nvar queue = new Queue<string>();\nqueue.Enqueue("A"); queue.Enqueue("B");\nConsole.WriteLine(queue.Dequeue());

Console.WriteLine();
Console.WriteLine("Next step: complete the practice task in Notes.md.");
