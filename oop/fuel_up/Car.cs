
class Car : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Car(string name, int passengers, string color, string fuelType) : base(name, passengers, color, true)
    {
        FuelType = fuelType;
        FuelTotal = 20;
    }

    public void GiveFuel(int amount)
    {
        Console.WriteLine($"Fuel up for {amount}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine(FuelType);
        Console.WriteLine(FuelTotal);
    }
}