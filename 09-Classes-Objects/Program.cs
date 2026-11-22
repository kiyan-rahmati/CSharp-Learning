// LESSON 09 - Classes and objects (intro to OOP)
//
// A CLASS is a blueprint. An OBJECT is one concrete thing built from that blueprint.
// Example: the class "Car" describes cars in general; myCar and yourCar are objects.
// A class bundles DATA (fields/properties) and BEHAVIOR (methods).

var car1 = new Car("Peugeot", "206", 2012);    // 'new' creates an object and runs the constructor
var car2 = new Car("Toyota", "Corolla", 2020);

car1.Describe();
car2.Describe();

car1.Drive(120);
car1.Drive(35.5);
Console.WriteLine($"Car 1 odometer: {car1.Kilometers} km");

// Objects are REFERENCE types: car3 points to the SAME object as car1.
Car car3 = car1;
car3.Drive(10);
Console.WriteLine($"Car 1 odometer after car3 drove: {car1.Kilometers} km");   // 165.5

// Static members belong to the CLASS, not to any object.
Console.WriteLine($"Cars created so far: {Car.TotalCreated}");

// Object initializer: set properties right after creation (class needs a parameterless constructor)
var book = new Book { Title = "Clean Code", Author = "Robert C. Martin", Pages = 464 };
Console.WriteLine(book);

// null = "no object". Using members of null crashes with NullReferenceException.
Car? nothing = null;
Console.WriteLine(nothing?.Brand ?? "no car");   // safe access with ?.

// ================= Type definitions (must come AFTER top-level statements) =================

class Car
{
    // FIELDS: variables that belong to each object (convention: private, _camelCase)
    private readonly string _vin;          // readonly: can only be set in the constructor

    // PROPERTIES: controlled access to data (see Lesson 10)
    public string Brand { get; }
    public string Model { get; }
    public int Year { get; }
    public double Kilometers { get; private set; }   // anyone can read, only the class can set

    // STATIC field: shared by ALL cars
    public static int TotalCreated { get; private set; }

    // CONSTRUCTOR: special method with the class name, no return type. It prepares a new object.
    public Car(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
        _vin = Guid.NewGuid().ToString();   // unique ID
        TotalCreated++;
    }

    // METHODS: behavior
    public void Describe()
    {
        Console.WriteLine($"{Year} {Brand} {Model} (VIN {_vin[..8]}...)");
    }

    public void Drive(double km)
    {
        if (km <= 0) return;               // guard clause: ignore invalid input
        Kilometers += km;
    }
}

class Book
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int Pages { get; set; }

    // Override ToString so printing the object gives readable text
    public override string ToString() => $"{Title} by {Author} ({Pages} pages)";
}
