class OddNumberException : Exception
{
    public OddNumberException(String message) : base(message) { }

}


Console.WriteLine("Enter Number : ");
int num = Convert.ToInt32(Console.ReadLine());
try
{
    if (num % 2 == 0)
    {
        Console.WriteLine("Even Number : " + num);
    }
    else
    {
        throw new OddNumberException("Not Even Number");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
