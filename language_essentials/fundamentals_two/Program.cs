// See https://aka.ms/new-console-template for more information

// ===== Three Basic Arrays =====
using System.Text.Json.Serialization;

int[] numArr = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];


string[] strArr = ["Tim", "Martin", "Nikki", "Sara"];


bool[] boolArr = new bool[10];
for (int i = 0; i < boolArr.Length; i++)
{
    if (i == 0) 
    {
        boolArr[i] = true;
    }
    else if (boolArr[i - 1] == true)
    {
        boolArr[i] = false;
    }
    else 
    {
        boolArr[i] = true;
    }
}
// ==============================

// ===== List of Flavors =====

List<string> flavors = new List<string>(["Chocolate", "Vanilla", "Strawberry", "Mint Chocolate Chip", "Phish"]);
Console.WriteLine(flavors.Count);

Console.WriteLine(flavors[2]);

flavors.Remove(flavors[2]);
Console.WriteLine(flavors.Count);

// ===========================

// ===== User Dictionary =====
Random rand = new();

Dictionary<string,string> users = new();

for (int i = 0; i < strArr.Length; i++)
{
    users.Add($"{strArr[i]}", $"{flavors[rand.Next(0, flavors.Count - 1)]}");
}

foreach(KeyValuePair<string,string> entry in users)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
