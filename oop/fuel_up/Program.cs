// See https://aka.ms/new-console-template for more information

Car Suv = new("Doug", 5, "Blue", "Gas");
Horse Clidesdale = new("Paul", 2, "Brown");
Bicycle BMX = new("Chad", 1, "Black");

// Vehicle randVehicle = new("George", 2, "Yellow", true);
// Can't create an instance of "Vehicle" since fit is abstract.

List<Vehicle> VehicleList = new([])
{
    Suv,
    Clidesdale,
    BMX
};

List<INeedFuel> FuelList = new([]);

foreach (Vehicle entry in VehicleList)
{
    if (entry is INeedFuel)
    {
        FuelList.Add((INeedFuel)entry);
    }
}

foreach (INeedFuel entry in FuelList)
{
    entry.GiveFuel(10);
}

foreach (INeedFuel entry in FuelList)
{
    Console.WriteLine($"Name: {entry.Name} Fuel Total: {entry.FuelTotal}");
}