using System;
using System.Collections.Generic;
class Program
{

    //Create a list
    static List<string> gameResults = new List<string>();

    //start of the game
    static void Start()
    {
        //Welcome message
        Console.Clear();
        Console.WriteLine("Welcome to Batman vs Joker");
        Console.WriteLine("");

        //get players name
        string playerName;
        Console.WriteLine("Enter your name:");
        playerName = Console.ReadLine();

        Console.WriteLine($"Hello {playerName}!");


        //Start as Batman or Joker
        for(int i=0; i<1; i++)
        {
        Console.WriteLine("Press [S] to start as the Batman or [A] to start as The Joker");
        }
        //get players choice
        ConsoleKeyInfo key = Console.ReadKey();
        while (key.Key != ConsoleKey.S && key.Key != ConsoleKey.A)
        {
            Console.Clear();
            Console.WriteLine("Invalid Choice! Please press [S] to start as Batman or [A] to start as Joker");
            key = Console.ReadKey();
        }

        Console.Clear();  //if press A, S play game
        PlayGame(key.Key, playerName);
    }

    //Method to handle game
    static void Main()
    {
        while (true) 
        {

            //Start the game
            Start();

            //Restart or exit
            Console.WriteLine("Press [R] to restart the game or press any other button to exit");
            if (Console.ReadKey().Key != ConsoleKey.R)
            {
break;                   //Break the loop
            }

            Console.Clear();
        }
    }

    //Play actual game
    static void PlayGame(ConsoleKey playerKey, string playerName)
    {
        int player1HP = 1000;  //Batman HP
        int player2HP = 1000;  //Joker HP

        bool doubleDamage = false;  //True or false for Double Damage

        //When more than 0 health display stats and how to continue
        while (player1HP > 0 && player2HP > 0)
        {
            DisplayStats("The Batman", player1HP);
            DisplayStats("The Joker", player2HP);

            //wait for player to press ENTER
            Console.WriteLine("Press [ENTER] to continue");
            Console.ReadLine();

            //Random Damage
            int player1Damage = GenerateRandomDamage();
            int player2Damage = GenerateRandomDamage();

            //Deal double damage for Joker
            if (doubleDamage)
            {
                player2Damage *= 2; // Double damage for Player 2
                Console.WriteLine("The Joker used poison and does double damage!");
                Console.WriteLine("");
                doubleDamage = false;
            }

            //Damage ability
            int player2Ability = GenerateRandomDamage();
            int player1GadgetAttack = GenerateRandomDamage();

            // Check if Batman uses his Gadget Attack
            if (player1GadgetAttack > 120)
            {
            int gadgetDamage = GenerateRandomDamage();
            player2HP -= gadgetDamage;

            Console.WriteLine("The Batman uses his Gadget Attack and deals additional damage!");
            Console.WriteLine("");
            Console.WriteLine($"The Joker takes {gadgetDamage} extra damage!");

            Console.ReadLine();
            }

            //Health left
            player1HP -= player2Damage;
            player2HP -= player1Damage;

            Console.Clear();

            // Display damage taken in each round
            Console.WriteLine("");
            Console.WriteLine($"The Batman takes {player2Damage} damage!");
            Console.WriteLine($"The Joker takes {player1Damage} damage!");
            Console.WriteLine("");


            //Check if joker does extra damage
            if (player2Ability > 150)
            {
                doubleDamage = true;
                Console.WriteLine("");
                Console.WriteLine("The Joker is preparing for a double damage attack!");
                Console.WriteLine("");
            }
        }
         //Display results of game
         DisplayResult(player1HP, player2HP, playerName);
    }

    //Display players stats
    static void DisplayStats(string player, int hp)
    {
        Console.WriteLine($"{player} {hp}HP");
    }

    //Random damage between 5, 200
    static int GenerateRandomDamage()
    {
        Random generator = new Random();
        return generator.Next(5, 200);
    }

    //Display the final result of the game
    static void DisplayResult(int player1HP, int player2HP, string playerName)
    {
        Console.Clear();

        if (player1HP <= 0)
        {
            Console.WriteLine($"{playerName} lost to The Joker... unfortunately the Joker was to powerful");
        }
        else if (player2HP <= 0)
        {
            Console.WriteLine($"{playerName} lost to Batman... Unlucky");
        }
        else
        {
            Console.WriteLine($"It's a draw... try again");
        }
    }

    static void DisplayResults()
    {
         
         Console.WriteLine("Game Results: ");
         Console.Clear();

         foreach (var result in gameResults)
         {
            Console.WriteLine(result);
         }
    }
}
