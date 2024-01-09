// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

Vehicle Truck = new("Ford V8", 3, "Gray", true);
Truck.PrintInfo();

Vehicle CompactCar = new("Honda Civic", 7, "Blue", true);
CompactCar.PrintInfo();

Vehicle StockCar1 = new("TSLA", "Red");
StockCar1.PrintInfo();

Vehicle StockCar2 = new("TM", "BLack");
StockCar2.PrintInfo();

List<Vehicle> vehicleList = [Truck, CompactCar, StockCar1, StockCar2];

foreach (Vehicle entry in vehicleList)
{
    entry.PrintInfo();
}

Truck.Travel(100);
Truck.PrintInfo();
