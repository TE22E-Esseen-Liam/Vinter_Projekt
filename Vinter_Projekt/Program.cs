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
