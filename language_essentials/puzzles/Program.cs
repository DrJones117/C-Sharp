// See https://aka.ms/new-console-template for more information

// Coin Flip
using System.Reflection;

static string CoinFlip()
{
    Random rand = new Random();
    int coin = rand.Next(1,3);
    if (coin == 1)
    {
        return "Heads";
    }
    else
    {
        return "Tails";
    }
}

Console.WriteLine(CoinFlip());

// Dice Roll
static int DiceRoll()
{
    Random rand = new Random();
    int die = rand.Next(1,7);
    return die;
}

Console.WriteLine(DiceRoll());

// Stat Roll
static List<int> StatRoll(int number)
{
    List<int> StatList = new List<int>();

    for (int i = 0; i < number + 1; i++)
    {
        int result = DiceRoll();
        StatList.Add(result);
    }
    return StatList;
}

Console.WriteLine(string.Join(", ", StatRoll(4)));

// Roll Until

static string RollUntil(int number)
{
    int count = 0;
    if (number < 7 && number > 0)
    {
        for (int i = 0; true; i++)
        {
            int result = DiceRoll();
            if (result == number)
            {
                count += 1;
                return $"Rolled a {result} after {count} tries.";
            }
            else
            {
                count += 1;
                continue;
            }
        }
    }
    else
    {
        return "The number input needs to be between six and one.";
    }
}

Console.WriteLine(RollUntil(6));

