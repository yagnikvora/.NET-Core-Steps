using System;
using System.Collections.Generic;
static void printDictionary(Dictionary<int, string> dict)
{
    Console.WriteLine("--------------------------------------------------------------------");
    if (dict.Count == 0)
    {
        Console.WriteLine("Dictionary is empty.");
    }
    else
    {
        foreach (var pair in dict)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }
    }
    Console.WriteLine("--------------------------------------------------------------------");
}


Dictionary<int, string> dictionary = new Dictionary<int, string>();

Console.WriteLine("Press 1 To Add a key-value pair");
Console.WriteLine("Press 2 To Remove a key-value pair by key");
Console.WriteLine("Press 3 To Check if a key exists");
Console.WriteLine("Press 4 To Check if a value exists");
Console.WriteLine("Press 5 To Clear all entries in the dictionary");

while (true)
{
    Console.WriteLine("\nEnter Your Choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Enter Key (int): ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Value (string): ");
            string value = Console.ReadLine();
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                Console.WriteLine("Pair added successfully.");
            }
            else
            {
                Console.WriteLine("Key already exists. Use a different key.");
            }
            printDictionary(dictionary);
            break;

        case 2:
            Console.Write("Enter Key to Remove: ");
            int removeKey = Convert.ToInt32(Console.ReadLine());
            if (dictionary.Remove(removeKey))
            {
                Console.WriteLine("Key removed successfully.");
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
            printDictionary(dictionary);
            break;

        case 3:
            Console.Write("Enter Key to Check: ");
            int checkKey = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(dictionary.ContainsKey(checkKey) ? "Key exists." : "Key does not exist.");
            printDictionary(dictionary);
            break;

        case 4:
            Console.Write("Enter Value to Check: ");
            string checkValue = Console.ReadLine();
            Console.WriteLine(dictionary.ContainsValue(checkValue) ? "Value exists." : "Value does not exist.");
            printDictionary(dictionary);
            break;

        case 5:
            dictionary.Clear();
            Console.WriteLine("All entries cleared.");
            printDictionary(dictionary);
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}


