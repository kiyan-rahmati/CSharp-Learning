# Lesson 16 - Delegates, Lambdas, Events

## Delegates
A delegate variable holds a method. Think "a variable whose value is a function".

```csharp
Func<int, int, int> add = (a, b) => a + b;   // returns int
Action<string> print = s => Console.WriteLine(s); // returns void
Func<int, bool> test = n => n > 0;
```
Rule: in `Func<A, B, R>` the **last** type is the return type.

## Lambdas
`(parameters) => expression` or `(parameters) => { statements; }`. The compiler infers parameter types.

## Closures
A lambda can use local variables from where it was written; it captures the **variable** (not a snapshot). Careful in loops:
```csharp
var actions = new List<Action>();
for (int i = 0; i < 3; i++) { int copy = i; actions.Add(() => Console.WriteLine(copy)); }
```
Copying into `copy` avoids surprising results with older loop semantics (`foreach` variables are per-iteration since C# 5; `for` variables are shared).

## Events
```csharp
public event EventHandler<MyArgs>? Something;   // declare (publisher)
Something?.Invoke(this, new MyArgs());          // raise
obj.Something += Handler;                       // subscribe
obj.Something -= Handler;                       // unsubscribe
```
An `event` is a delegate with restrictions: outsiders can only `+=` / `-=`, not call or overwrite it. That protects the publisher.

## `yield return`
Creates an iterator: a method that produces a sequence lazily, one item at a time, remembering its position.

## Run it
```bash
dotnet run --project 16-Delegates-Events-Lambdas
```

## Exercises
1. Write `static int[] Transform(int[] data, Func<int,int> f)` and call it to double and to square.
2. Write `Action<string>` that prints text in upper case and subscribe two different actions to a multicast delegate.
3. Create a `Timer`-like class with an event `Tick` raised 3 times; subscribe and print each tick number.
4. Write an iterator `IEnumerable<int> Evens(int max)` using `yield return`.

<details><summary>Solutions</summary>

```csharp
int[] Transform(int[] data, Func<int,int> f) => data.Select(f).ToArray();
Transform(new[]{1,2,3}, x => x * 2);

IEnumerable<int> Evens(int max)
{
    for (int i = 0; i <= max; i += 2) yield return i;
}

class Ticker
{
    public event Action<int>? Tick;
    public void Run() { for (int i = 1; i <= 3; i++) Tick?.Invoke(i); }
}
```
</details>
