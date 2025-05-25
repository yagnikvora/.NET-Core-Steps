
Console.WriteLine("Enter Number : ");
int num = Convert.ToInt32(Console.ReadLine());
try
{
    int ans = num / 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}