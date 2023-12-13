using System;

class Program
{
    static void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to My Combat Game");
            Console.WriteLine("Press [S] to play");

            if (Console.ReadKey().Key != ConsoleKey.S)
            

            Console.Clear();
        }
    }

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
        int batmanHP = 1000;
        int jokerHP = 1000;

         bool doubleDamage = false;

        while (batmanHP > 0 && jokerHP > 0)
        {
            DisplayStats("Batman", batmanHP);
            DisplayStats("Joker", jokerHP);

            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();

            int batmanDamage = GenerateRandomDamage();
            int jokerDamage = GenerateRandomDamage();
            
            if (doubleDamage)
            {
                jokerDamage *= 2; // Double damage for Joker
                Console.WriteLine("Joker deals double damage!");
                doubleDamage = false;
            }

            int jokerAbility = GenerateRandomDamage();

            batmanHP -= jokerDamage;
            jokerHP -= batmanDamage;

                // Display damage taken in each round
            Console.WriteLine($"Batman takes {jokerDamage} damage!");
            Console.WriteLine($"Joker takes {batmanDamage} damage!");

        if (jokerAbility > 150)
        {
            doubleDamage = true;
            Console.WriteLine("Joker is preparing for a double damage attack!");
        }
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
        return generator.Next(5, 200);

    }

    

    static void DisplayResult(int batmanHP, int jokerHP)
    {
        if (batmanHP <= 0)
        {
            Console.WriteLine("You lost to The Joker");
        }
        else if (jokerHP <= 0)
        {
            Console.WriteLine("You lost to Batman");
        }
        else
        {
            Console.WriteLine("It's a draw... try again");
        }
    }
}