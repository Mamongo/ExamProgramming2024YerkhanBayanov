using System;
using Utilities;

class Program
{
    static void Main()
    {
        string input1 = "Yerkhan Bayanov";
        string input2 = "The lord of the rings";

        int longWordsCount1 = StringUtilities.LongWordsCount(input1);
        Console.WriteLine("Long words count: " + longWordsCount1);

        string spinalCase1 = StringUtilities.ToSpinalCase(input1);
        Console.WriteLine("Spinal case: " + spinalCase1);

        string pascalCase1 = input1.ToPascalCase();
        Console.WriteLine("Pascal case: " + pascalCase1);

        int longWordsCount2 = StringUtilities.LongWordsCount(input2);
        Console.WriteLine("Long words count: " + longWordsCount2);

        string spinalCase2 = StringUtilities.ToSpinalCase(input2);
        Console.WriteLine("Spinal case: " + spinalCase2);

        string pascalCase2 = input2.ToPascalCase();
        Console.WriteLine("Pascal case: " + pascalCase2);
    }
}