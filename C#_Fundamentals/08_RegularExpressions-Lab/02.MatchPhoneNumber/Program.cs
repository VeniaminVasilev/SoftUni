﻿using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"( |\+359)( |-)2\2\d{3}\2\d{4}\b";
            string phones = Console.ReadLine();
            MatchCollection phoneMatches = Regex.Matches(phones, regex);

            var matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}