public class Coffee : Drink
{
    public string RoastValue { get;set;}
    public string TypeOfBeans { get;set; }

    public Coffee(string name, string color, double temperature, int calories, string roastValue, string typeOfBeans) : base(name, color, temperature, false, calories)
    {
        RoastValue = roastValue;
        TypeOfBeans = typeOfBeans;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast Value: {RoastValue}");
        Console.WriteLine($"Bean Type: {TypeOfBeans}");
        Console.WriteLine("===============");
        Console.WriteLine(" ");
    }
}