using System.Reflection.Metadata.Ecma335;

public class Vehicle
{
    private string _Name;
    public string Name { get {return _Name;} set{_Name = value;}}
    public int Passengers;
    public string Color;
    public bool Engine;
    public int Miles;

    public Vehicle(string name, int passengers, string color, bool engine)
    {
        Name = name;
        Passengers = passengers;
        Color = color;
        Engine = engine;
        Miles = 0;
    }

    public Vehicle(string name, string color)
    {
        Name = name;
        Passengers = 1;
        Color = color;
        Engine = true;
        Miles = 0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Passengers: {Passengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Engine: {Engine}");
        Console.WriteLine($"Miles: {Miles}");
    }

    public virtual void Travel(int distance)
    {
        Console.WriteLine("Driving...");
        Miles += distance;
    }
}
