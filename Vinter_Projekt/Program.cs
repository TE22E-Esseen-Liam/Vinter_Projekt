using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            PlayGame();

            Console.WriteLine("Press [R] to restart game or press any other button to exit");
            if (Console.ReadKey().Key != ConsoleKey.R)
            {
                break;
            }

            Console.Clear();
        }
    }

    static void PlayGame()
    {
        int batmanHP = 100;
        int jokerHP = 100;

        while (batmanHP > 0 && jokerHP > 0)
        {
            DisplayStats("batman", batmanHP);
            DisplayStats("Thanos", jokerHP);

            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();

            int batmanDamage = GenerateRandomDamage();
            int jokerDamage = GenerateRandomDamage();

            batmanHP -= jokerDamage;
            jokerHP -= batmanDamage;

            Console.Clear();
        }

        DisplayResult(batmanHP, jokerHP);
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

    static void DisplayResult(int batmanHP, int jokerHP)
    {
        if (batmanHP <= 0)
        {
            Console.WriteLine("You lost to The Joker");
        }
        else if (jokerHP <= 0)
        {
            Console.WriteLine("You lost to The Dark Knight");
        }
        else
        {
            Console.WriteLine("It's a draw... try again");
        }
    }
}