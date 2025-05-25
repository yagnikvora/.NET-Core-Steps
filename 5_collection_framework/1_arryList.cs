using System;
using System.Collections;
using System.Collections.Generic;

static void printArrayList(ArrayList arrayList)
{
    Console.WriteLine("--------------------------------------------------------------------");
    foreach (var item in arrayList)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("--------------------------------------------------------------------");
}


ArrayList arrayList = new ArrayList();
Console.WriteLine("Press 1 To To Add new student in list");
Console.WriteLine("Press 2 To Remove Student with specified index");
Console.WriteLine("Press 3 To Remove student with specified range.");
Console.WriteLine("Press 4 To clear all the student from the list");
while (true)
{
    Console.WriteLine("Enter Your Choice : ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Name Of Student : ");
            String name = Convert.ToString(Console.ReadLine());
            arrayList.Add(name);
            printArrayList(arrayList);
            break;
        case 2:
            printArrayList(arrayList);
            Console.WriteLine("Enter Index To Remove Student : ");
            int index = Convert.ToInt32(Console.ReadLine());
            arrayList.RemoveAt(index);
            printArrayList(arrayList);
            break;
        case 3:
            printArrayList(arrayList);
            Console.WriteLine("Enter Starting Range : ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ending Range : ");
            int end = Convert.ToInt32(Console.ReadLine());
            arrayList.RemoveRange(start, end);
            printArrayList(arrayList);
            break;
        case 4:
            arrayList.Clear();
            printArrayList(arrayList);
            break;
    }
}


