using System;
using Utilities;

class Program
{
    static void Main()
    {

        string input = "The lord of the rings";

        int longWordsCount = StringUtilities.LongWordsCount(input);
        Console.WriteLine("Long words count: " + longWordsCount);

        string spinalCase = StringUtilities.ToSpinalCase(input);
        Console.WriteLine("Spinal case: " + spinalCase);

        string pascalCase = input.ToPascalCase();
        Console.WriteLine("Pascal case: " + pascalCase);
    }
}