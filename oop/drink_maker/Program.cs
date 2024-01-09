// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Soda RootBeer = new("RootBeer", "Brown", 38.8, 50, false);

Coffee Cuban = new("Cafe Bustelo", "Black", 175, 15, "Dark", "Cuban");

Wine WhiteWine = new("Kettmeir Pinot Grigio", "White", 30, 81, "White Wine", "Place", 2055);

List<Drink> drinks = new([RootBeer, Cuban, WhiteWine]);

foreach (Drink entry in drinks)
{
    entry.ShowDrink();
}