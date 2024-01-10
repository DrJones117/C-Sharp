
class Horse : Vehicle, INeedFuel
{

    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Horse(string name, int passengers, string color) : base(name, passengers, color, false)
    {
        FuelType = "Hay";
        FuelTotal = 20;
    }

    public void GiveFuel(int amount)
    {
        FuelTotal += amount;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine(FuelType);
        Console.WriteLine(FuelTotal);
    }
}