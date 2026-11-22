// LESSON 15 - LINQ (Language Integrated Query)
//
// LINQ gives you a uniform, readable way to filter, transform, sort, group, and aggregate ANY collection.
// Works on anything that implements IEnumerable<T> (arrays, lists, dictionaries, strings...).
// Requires `using System.Linq;` (added automatically by ImplicitUsings).
//
// Key concepts:
//  - LINQ methods do NOT change the original collection; they return a new result.
//  - DEFERRED EXECUTION: a query like Where(...) is not run until you iterate it or call ToList()/Count()/First()...

var numbers = new List<int> { 5, 12, 8, 3, 20, 15, 8, 1 };

// ---------- Filtering: Where ----------
var even = numbers.Where(n => n % 2 == 0);            // n => ... is a lambda (an inline function)
Console.WriteLine(string.Join(", ", even));            // 12, 8, 20, 8

// ---------- Transforming: Select ----------
var squares = numbers.Select(n => n * n);
Console.WriteLine(string.Join(", ", squares));

// ---------- Sorting ----------
Console.WriteLine(string.Join(", ", numbers.OrderBy(n => n)));
Console.WriteLine(string.Join(", ", numbers.OrderByDescending(n => n)));

// ---------- Aggregates ----------
Console.WriteLine(numbers.Count());                    // 8
Console.WriteLine(numbers.Sum());                      // 72
Console.WriteLine(numbers.Average());                  // 9
Console.WriteLine(numbers.Max());
Console.WriteLine(numbers.Min());
Console.WriteLine(numbers.Count(n => n > 10));         // how many are > 10 -> 3

// ---------- Element operators ----------
Console.WriteLine(numbers.First());                    // first item (throws if empty)
Console.WriteLine(numbers.FirstOrDefault(n => n > 100)); // 0, the default, when nothing matches
Console.WriteLine(numbers.Any(n => n > 15));           // is there at least one?
Console.WriteLine(numbers.All(n => n > 0));            // do ALL satisfy?
Console.WriteLine(numbers.Contains(8));

// ---------- Distinct, Take, Skip (paging!) ----------
Console.WriteLine(string.Join(", ", numbers.Distinct()));
Console.WriteLine(string.Join(", ", numbers.Take(3)));           // first 3
Console.WriteLine(string.Join(", ", numbers.Skip(2).Take(3)));   // page 2 with page size 3 (skip 2 here for demo)

// ---------- Chaining ----------
var result = numbers
    .Where(n => n > 5)
    .Distinct()
    .OrderBy(n => n)
    .Select(n => $"#{n}")
    .ToList();                                          // ToList() forces execution now
Console.WriteLine(string.Join(" ", result));

// ---------- Working with objects ----------
var students = new List<Student>
{
    new("Ali", "Math", 17.5),
    new("Sara", "Math", 19.0),
    new("Reza", "Physics", 14.0),
    new("Mina", "Physics", 16.5),
    new("Omid", "Chemistry", 12.0)
};

// Filter + sort + project to an anonymous type
var top = students
    .Where(s => s.Grade >= 15)
    .OrderByDescending(s => s.Grade)
    .Select(s => new { s.Name, s.Grade });
foreach (var s in top) Console.WriteLine($"{s.Name}: {s.Grade}");

// ---------- GroupBy ----------
var byCourse = students.GroupBy(s => s.Course);
foreach (var g in byCourse)
{
    Console.WriteLine($"{g.Key}: {g.Count()} students, average {g.Average(s => s.Grade):F2}");
}

// ---------- ToDictionary ----------
var gradeByName = students.ToDictionary(s => s.Name, s => s.Grade);
Console.WriteLine(gradeByName["Sara"]);

// ---------- Joins ----------
var courses = new List<Course> { new("Math", "Dr. Karimi"), new("Physics", "Dr. Ahmadi") };
var joined = students.Join(courses,
                           s => s.Course,                 // key from students
                           c => c.Name,                   // key from courses
                           (s, c) => $"{s.Name} studies {c.Name} with {c.Teacher}");
foreach (var line in joined) Console.WriteLine(line);

// ---------- Query syntax (SQL-like alternative) ----------
var query = from s in students
            where s.Grade > 15
            orderby s.Name
            select s.Name;
Console.WriteLine(string.Join(", ", query));

// ---------- Deferred execution demo ----------
var list = new List<int> { 1, 2, 3 };
var query2 = list.Where(n => n > 1);        // NOT executed yet
list.Add(10);                                // modify the source...
Console.WriteLine(string.Join(", ", query2));// ...and the query sees it: 2, 3, 10

// ================= Types =================
record Student(string Name, string Course, double Grade);
record Course(string Name, string Teacher);
