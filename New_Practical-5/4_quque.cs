using System;
using System.Collections;
using System.Collections.Generic;

static void printArrayqueue(Queue queue)
{
    Console.WriteLine("--------------------------------------------------------------------");
    foreach (var item in queue)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("--------------------------------------------------------------------");
}

Queue queue = new Queue();
Console.WriteLine("Press 1 To Adds an item into the queue");
Console.WriteLine("Press 2 To Returns an item from the beginning of the queue and removes it from the queue.");
Console.WriteLine("Press 3 To Returns an first item from the queue without removing it.");
Console.WriteLine("Press 4 To Checks whether an item is in the queue or not");
Console.WriteLine("Press 5 To Removes all the items from the queue");
while (true)
{
    Console.WriteLine("Enter Your Choice : ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            queue.Enqueue(n);
            printArrayqueue(queue);
            break;
        case 2:
            Console.WriteLine("Beginning Element : " + queue.Dequeue());
            printArrayqueue(queue);
            break;
        case 3:
            Console.WriteLine("Element At Top : " + queue.Peek());
            printArrayqueue(queue);
            break;
        case 4:
            Console.Write("Enter Number To Check : ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (queue.Contains(num))
            {
                Console.WriteLine("Yes It Exist");
            }
            else
            {
                Console.WriteLine("Not It Does Not Exist");
            }
            printArrayqueue(queue);
            break;
        case 5:
            queue.Clear();
            printArrayqueue(queue);
            break;
    }
}


