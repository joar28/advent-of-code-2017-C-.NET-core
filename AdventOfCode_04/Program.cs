using System;
using System.Collections.Generic;

class AdventOfCode_04
{
    static void Main(string[] args)
    {
        // Tests
        Console.WriteLine(ValidPassword("aa bb cc dd ee") == true);
        Console.WriteLine(ValidPassword("aa bb cc dd aa") == false);
        Console.WriteLine(ValidPassword("aa bb cc dd aaa") == true);

        var ValidPasswords = 0;

        string input = System.IO.File.ReadAllText(@"input.txt");
        foreach(var passwords in input.Split('\r'))
        {
            if (ValidPassword(passwords.Trim('\n'))) ValidPasswords++;
            
        }
        Console.WriteLine($"There are {ValidPasswords} valid passwords.");
    }
    static bool ValidPassword(string Passwords)
    {        
        // Hack
        var uniquePassDict = new Dictionary<string, int>();
        foreach(var pass in Passwords.Split(' '))
        {
            uniquePassDict.TryAdd(pass, 1);
        }

        return uniquePassDict.Count == Passwords.Split(' ').Length;
    }
}
