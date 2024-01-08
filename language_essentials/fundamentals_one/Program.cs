// See https://aka.ms/new-console-template for more information

// First Loop
Console.WriteLine("Loop that prints the values between 1-255");

for(int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

// Second Loop 
Console.WriteLine("Loop that prints 5 random values between 10-20");

Random rand = new Random();
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine(rand.Next(10,21));
}

// Third Loop
Console.WriteLine("Modified the Loop above to add the generated nnumbers together");

int sum = 0;
for(int i = 1; i <= 5; i++)
{
    sum += rand.Next(10,21);
    if (i == 5) 
    {
        Console.WriteLine(sum);
    }
}

// Fourth Loop
Console.WriteLine("Loop that prints the values of 1-100 that are divisible by 3 or 5. (not both)");

for (int i = 1; i < 101; i++)
{
    if (i % 3 == 0 && i % 5 != 0)
    {
        Console.WriteLine(i);
    }
    else if (i % 3 != 0 && i % 5 == 0)
    {
        Console.WriteLine(i);
    }
}

// Fifth Loop
Console.WriteLine("Modified the Loop above to print 'Fizz' for multiples of 3 and 'Buzz' for multiples of 5");

for (int i = 1; i < 101; i++)
{
    if (i % 3 == 0 && i % 5 != 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 3 != 0 && i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

// Sixth Loop
Console.WriteLine("Modified the Loop above to also print 'FizzBuzz' for numbers that are multiples of 3 and 5");

for (int i = 1; i < 101; i++)
{
    if (i % 3 == 0 && i % 5 != 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 3 != 0 && i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}


