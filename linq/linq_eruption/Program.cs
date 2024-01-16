// See https://aka.ms/new-console-template for more information


List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// First Query
Eruption first = eruptions.FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine($"First Item: {first}");

// Second Query
Eruption second = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (second != null)
{
    Console.WriteLine($"Second Item: {second}");
}
else
{
    Console.WriteLine("No Hawaiian is Eruption is found");
}

// Third Query
Eruption third = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (third != null)
{
    Console.WriteLine($"Third Item: {third}");
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
}

// Fourth Query
Eruption fourth = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
Console.WriteLine($"Single Item{fourth}");

// Five Query 
IEnumerable<Eruption> five = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(five, "Eruptions over 2000m.");

// Sixth Query
IEnumerable<Eruption> sixth = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(sixth, "Eruptions that start with an 'L' ");

// Seventh Query
int seventh = eruptions.Max(e => e.ElevationInMeters);
Eruption volcano = eruptions.FirstOrDefault(e => e.ElevationInMeters == seventh);
Console.WriteLine($"The Max Elevation {volcano}");

// Eight Query 
IEnumerable<string> eigth = eruptions.OrderBy(e => e.Volcano).Select(e => e.Volcano);
stringPrint(eigth, "Alphabetical Order");

// Ninth Query
int ninth = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine(ninth);

// Tenth Query
bool tenth = eruptions.Any(e => e.Year == 2000);
Console.WriteLine($"Any Eruptions in 2000: {tenth}");

// Eleventh Query
IEnumerable<Eruption> eleventh = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(eleventh, "First Three Stratovolcano");

// Twelfth Query
IEnumerable<Eruption> twelfth = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(twelfth, "Before 1000 BC");

// Thirteenth Query 
IEnumerable<string> thirteenth = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
stringPrint(thirteenth, "Before 1000 CE Name");

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


static void stringPrint(IEnumerable<string> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (string item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


