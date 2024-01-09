using System;

class Program
{
    static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Batman vs Joker");
        Console.WriteLine("");

        for(int i=0; i<1; i++)
        {
        Console.WriteLine("Press [S] to start as the Weak Batman or [A] to start as The powerful Joker");
        }

        ConsoleKeyInfo key = Console.ReadKey();
        while (key.Key != ConsoleKey.S && key.Key != ConsoleKey.A)
        {
            Console.Clear();
            key = Console.ReadKey();
        }

        Console.Clear();
        PlayGame(key.Key);
    }

    static void Main()
    {
        while (true)
        {
            Start();

            Console.WriteLine("Press [R] to restart the game or press any other button to exit");
            if (Console.ReadKey().Key != ConsoleKey.R)
            {
break;
            }

            Console.Clear();
        }
    }

    static void PlayGame(ConsoleKey playerKey)
    {
        int player1HP = 1000;
        int player2HP = 1000;

        bool doubleDamage = false;

        while (player1HP > 0 && player2HP > 0)
        {
            DisplayStats("The weak Batman", player1HP);
            DisplayStats("The powerful Joker", player2HP);

            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();

            int player1Damage = GenerateRandomDamage();
            int player2Damage = GenerateRandomDamage();

            if (doubleDamage)
            {
                player2Damage *= 2; // Double damage for Player 2
                Console.WriteLine("The powerful Joker deals double damage!");
                Console.WriteLine("");
                doubleDamage = false;
            }

            int player2Ability = GenerateRandomDamage();

            int player1GadgetAttack = GenerateRandomDamage();

            // Check if Batman uses his Gadget Attack
            if (player1GadgetAttack > 120)
            {
            int gadgetDamage = GenerateRandomDamage();
            player2HP -= gadgetDamage;

            Console.WriteLine("The weak Batman uses his Gadget Attack and deals additional damage!");
            Console.WriteLine("");
            Console.WriteLine($"The powerful Joker takes {gadgetDamage} extra damage!");

            DisplayStats("The weak Batman", player1HP);
            DisplayStats("The powerful Joker", player2HP);
  
            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();
            }

            player1HP -= player2Damage;
            player2HP -= player1Damage;

            Console.Clear();

            // Display damage taken in each round
            Console.WriteLine("");
            Console.WriteLine($"The weak Batman takes {player2Damage} damage!");
            Console.WriteLine($"The powerful Joker takes {player1Damage} damage!");
            Console.WriteLine("");

            if (player2Ability > 150)
            {
                doubleDamage = true;
                Console.WriteLine("");
                Console.WriteLine("The powerful Joker is preparing for a double damage attack!");
                Console.WriteLine("");
            }
        }

         DisplayResult(player1HP, player2HP);
    }

    static void DisplayStats(string player, int hp)
    {
        Console.WriteLine($"{player} {hp}HP");
    }

    static int GenerateRandomDamage()
    {
        Random generator = new Random();
        return generator.Next(5, 200);
    }

    static void DisplayResult(int player1HP, int player2HP)
    {
        Console.Clear();

        if (player1HP <= 0)
        {
            Console.WriteLine("Batman lost to The powerful Joker... unfortunately the Joker was to powerful");
        }
        else if (player2HP <= 0)
        {
            Console.WriteLine("The Joker lost to Batman... Unlucky");
        }
        else
        {
            Console.WriteLine("It's a draw... try again");
        }
    }
}