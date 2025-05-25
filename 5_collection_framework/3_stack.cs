using System;
using System.Collections;
using System.Collections.Generic;

static void printArraystack(Stack stack)
{
    Console.WriteLine("--------------------------------------------------------------------");
    foreach (var item in stack)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("--------------------------------------------------------------------");
}

Stack stack = new Stack();
Console.WriteLine("Press 1 - To Add new item in stack");
Console.WriteLine("Press 2 - To Remove item from the stack");
Console.WriteLine("Press 3 To Return the top item from the stack.");
Console.WriteLine("Press 4 To Checks whether an item exists in the stack or not.");
Console.WriteLine("Press 5 To clear items from stack");
while (true)
{
    Console.WriteLine("Enter Your Choice : ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            stack.Push(n);
            printArraystack(stack);
            break;
        case 2:
            stack.Pop();
            printArraystack(stack);
            break;
        case 3:
            stack.Peek();
            printArraystack(stack);
            break;
        case 4:
            Console.Write("Enter Number To Check : ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (stack.Contains(num))
            {
                Console.WriteLine("Yes It Exist");
            }
            else
            {
                Console.WriteLine("Yes It Exist");
            }
            printArraystack(stack);
            break;
        case 5:
            stack.Clear();
            printArraystack(stack);
            break;
    }
}

