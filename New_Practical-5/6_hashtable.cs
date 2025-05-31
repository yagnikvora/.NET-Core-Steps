using System;
using System.Collections;
static void printHashtable(Hashtable table)
{
    Console.WriteLine("--------------------------------------------------------------------");
    if (table.Count == 0)
    {
        Console.WriteLine("Hashtable is empty.");
    }
    else
    {
        foreach (DictionaryEntry entry in table)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }
    Console.WriteLine("--------------------------------------------------------------------");
}


Hashtable hashtable = new Hashtable();

Console.WriteLine("Press 1 To Add a key-value pair");
Console.WriteLine("Press 2 To Remove a key-value pair by key");
Console.WriteLine("Press 3 To Check if a key exists");
Console.WriteLine("Press 4 To Check if a value exists");
Console.WriteLine("Press 5 To Clear all entries in the hashtable");

while (true)
{
    Console.WriteLine("\nEnter Your Choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Enter Key: ");
            var key = Console.ReadLine();
            Console.Write("Enter Value: ");
            var value = Console.ReadLine();
            if (!hashtable.ContainsKey(key))
            {
                hashtable.Add(key, value);
                Console.WriteLine("Pair added successfully.");
            }
            else
            {
                Console.WriteLine("Key already exists. Use a different key.");
            }
            printHashtable(hashtable);
            break;

        case 2:
            Console.Write("Enter Key to Remove: ");
            var removeKey = Console.ReadLine();
            if (hashtable.ContainsKey(removeKey))
            {
                hashtable.Remove(removeKey);
                Console.WriteLine("Key removed successfully.");
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
            printHashtable(hashtable);
            break;

        case 3:
            Console.Write("Enter Key to Check: ");
            var checkKey = Console.ReadLine();
            Console.WriteLine(hashtable.ContainsKey(checkKey) ? "Key exists." : "Key does not exist.");
            printHashtable(hashtable);
            break;

        case 4:
            Console.Write("Enter Value to Check: ");
            var checkValue = Console.ReadLine();
            Console.WriteLine(hashtable.ContainsValue(checkValue) ? "Value exists." : "Value does not exist.");
            printHashtable(hashtable);
            break;

        case 5:
            hashtable.Clear();
            Console.WriteLine("All entries cleared.");
            printHashtable(hashtable);
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}


