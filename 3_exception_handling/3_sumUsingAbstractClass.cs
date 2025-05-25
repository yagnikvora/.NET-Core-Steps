abstract class Sum
{
    public abstract int sumOfTwo(int a, int b);
    public abstract int sumOfThree(int a, int b, int c);
}

class Result : Sum
{
    public override int sumOfTwo(int a, int b)
    {
        return a + b;
    }

    public override int sumOfThree(int a, int b, int c)
    {
        return a + b + c;
    }
}

Result r = new Result();
Console.WriteLine("Enter First Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Second Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sum Of " + num1 + " and " + num2 + " is " + r.sumOfTwo(num1, num2));
Console.WriteLine("Enter Third Number : ");
int num3 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sum Of " + num1 + "," + num2 + " and " + num3 + " is " + r.sumOfThree(num1, num2, num3));
