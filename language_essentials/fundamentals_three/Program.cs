// See https://aka.ms/new-console-template for more information

// Function 1

static void PrintList(List<string> MyList)
{
    for (int i = 0; i < MyList.Count; i++)
    {
        Console.WriteLine(MyList[i]);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

// Function 2

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        sum += IntList[i];
    }
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

// Function 3

static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    for (int i = 1; i < IntList.Count; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    }
    return max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
Console.WriteLine("Max:" + string.Join("", FindMax(TestIntList2)));

// Function 4

static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] = IntList[i] * IntList[i];
    }
    return IntList;
}

List<int> TestIntList3 = new List<int>() {1,2,3,4,5};

// You should get back [1,4,9,16,25], think about how you will show that this worked
List<int> squaredList = SquareValues(TestIntList3);
Console.WriteLine("New List" + " " + string.Join(", ", squaredList));

// Function 5

static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
Console.WriteLine("Here is the modified array:" + " " + string.Join(",", NonNegatives(TestIntArray)));

// Function 6

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

// Function 7

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    bool keyExist = false;
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        if (entry.Key == SearchTerm)
        {
            keyExist = true;
        } 
    }
    return keyExist;
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

// Function 8

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> People = new();

    for (int i = 0; i < Names.Count; i++)
    {
        People.Add($"{Names[i]}", Numbers[i]);
    }

    foreach(KeyValuePair<string, int> entry in People)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
    return People;
}

List<string> Names = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> Numbers = new List<int>() {6,12,7,10};

GenerateDictionary(Names, Numbers);


// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here














