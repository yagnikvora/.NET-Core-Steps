
int[] arr = new int[5];
for (int i = 0; i < arr.Length; i++)

{
    Console.WriteLine("Enter Number : ");
    arr[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Enter Index Of Number You Want : ");
int index = Convert.ToInt32(Console.ReadLine());
try
{
    Console.WriteLine("Your Element : " + arr[index]);   
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

