﻿
Console.Write("Enter a string : ");
string str = Console.ReadLine();

List<String> wordList = str.Split(" ").ToList();
string longestWord = "";

foreach (String word in wordList)
{
    if (longestWord.Length < word.Length)
    {
        longestWord = word;
    }
}
Console.WriteLine("Longest word is : " + longestWord);

