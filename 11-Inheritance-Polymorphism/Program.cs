// LESSON 11 - Inheritance and polymorphism
//
// INHERITANCE: a class (child/derived) reuses and extends another class (parent/base).
// It models an "is-a" relationship: a Dog IS an Animal.
// POLYMORPHISM: code written for the parent type works with any child, and each child
// can respond differently to the same call.

var dog = new Dog("Rex");
var cat = new Cat("Tom");

dog.Eat();                 // inherited from Animal
dog.MakeSound();           // overridden in Dog
cat.MakeSound();           // overridden in Cat

// A variable of the PARENT type can hold ANY child object:
Animal[] zoo = { dog, cat, new Animal("Generic") };

foreach (Animal a in zoo)
{
    // The correct override runs depending on the REAL object type (runtime dispatch).
    a.MakeSound();
}

// Type checks and casting
Animal pet = new Dog("Buddy");
if (pet is Dog d)                       // safe check + cast
{
    d.Fetch();
}
Dog? maybeDog = pet as Dog;             // 'as' returns null if the cast is impossible
Console.WriteLine(maybeDog is not null);
Cat? maybeCat = pet as Cat;
Console.WriteLine(maybeCat is null);    // true: a Dog is not a Cat

// 'new' hiding vs 'override'
Animal hidden = new Cat("Kitty");
Console.WriteLine(hidden.Describe());   // uses Animal.Describe (NOT virtual, so no polymorphism)

// Constructor order: base constructor runs FIRST, then the derived one.
var puppy = new Puppy("Bit");

// sealed class cannot be inherited; sealed override stops further overriding.
Console.WriteLine(puppy);

// ================= Types =================

class Animal
{
    public string Name { get; }

    public Animal(string name)
    {
        Name = name;
        Console.WriteLine($"[Animal ctor] {name}");
    }

    public void Eat() => Console.WriteLine($"{Name} is eating.");

    // 'virtual' = children MAY replace this behavior
    public virtual void MakeSound() => Console.WriteLine($"{Name} makes a sound.");

    // Not virtual: children cannot truly override it
    public string Describe() => $"Animal named {Name}";

    public override string ToString() => $"{GetType().Name}({Name})";
}

class Dog : Animal                       // ': Animal' means Dog inherits from Animal
{
    public Dog(string name) : base(name) { }   // pass arguments to the parent constructor

    public override void MakeSound() => Console.WriteLine($"{Name}: Woof!");

    public void Fetch() => Console.WriteLine($"{Name} fetches the ball.");
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void MakeSound()
    {
        base.MakeSound();                // call the parent's version first
        Console.WriteLine($"{Name}: Meow!");
    }
}

class Puppy : Dog
{
    public Puppy(string name) : base(name)
    {
        Console.WriteLine("[Puppy ctor]");
    }

    // C# supports SINGLE inheritance for classes (one parent). Use interfaces for more (Lesson 12).
    public sealed override void MakeSound() => Console.WriteLine($"{Name}: Yip!");
}
