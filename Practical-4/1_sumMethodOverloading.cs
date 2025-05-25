
class Sum
{
    public int sum(int a, int b)
    {
        return a + b;
    }

    public double sum(double a, double b)
    {
        return a + b;
    }
}

Sum s = new Sum();
Console.WriteLine("Enter Integer Number : ");
int a = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter Integer Number : ");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter Double Number : ");
double c = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter Double Number : ");
double d = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Addition Of " + a + " And " + b + " Is " + (s.sum(a, b)));
Console.WriteLine("Addition Of " + c + " And " + d + " Is " + (s.sum(c, d)));

