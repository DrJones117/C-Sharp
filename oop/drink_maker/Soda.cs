public class Soda : Drink
{
    public bool IsDiet { get;set;}

    public Soda(string name, string color, double temperature, int calories, bool isDiet) : base(name, color, temperature, true, calories)
    {
        IsDiet = isDiet;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Diet?: {IsDiet}");
        Console.WriteLine("===============");
        Console.WriteLine(" ");
    }
}