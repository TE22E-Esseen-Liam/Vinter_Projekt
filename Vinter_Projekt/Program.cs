using System;

class Program
{
    static void Main()
    {
        int ironmanHP = 100;
        int thanosHP = 100;

        while (ironmanHP > 0 && thanosHP > 0)
        {
            DisplayStats("Ironman", ironmanHP);
            DisplayStats("Thanos", thanosHP);

            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();

            int idmg = GenerateRandomDamage();
            int tdmg = GenerateRandomDamage();

            ironmanHP -= idmg;
            thanosHP -= tdmg;

            Console.Clear();
        }

        DisplayResult(ironmanHP, thanosHP);

        Console.WriteLine("Press any key to exit game");
        Console.ReadKey();
    }

    static void DisplayStats(string character, int hp)
    {
        Console.WriteLine($"{character} {hp}HP");
    }

    static int GenerateRandomDamage()
    {
        Random generator = new Random();
        return generator.Next(5, 15);
    }
