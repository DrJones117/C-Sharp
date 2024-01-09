public class Wine : Drink
{
    public string TypeOf { get;set; }
    public string Region { get;set; }
    public int Year { get;set; }

    public Wine(string name, string color, double temperature, int calories, string typeOf, string region, int year) : base(name, color, temperature, false, calories)
    {
        TypeOf = typeOf;
        Region = region;
        Year = year;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Wine Type: {TypeOf}");
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine("===============");
        Console.WriteLine(" ");
    }
}