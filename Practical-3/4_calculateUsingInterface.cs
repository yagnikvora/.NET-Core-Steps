



interface Calculate
{
    int addition(int a, int b);
    int subtraction(int a, int b);
}

class Result : Calculate
{
    public int addition(int a, int b)
    {
        return a + b;
    }

    public int subtraction(int a, int b)
    {
        return a - b;
    }
}
Result r = new Result();
Console.WriteLine("Enter First Number : ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Second Number : ");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Addition Of " + num1 + " and " + num2 + " is " + r.addition(num1, num2));
Console.WriteLine("Subtraction Of " + num1 + " and " + num2 + " is " + r.subtraction(num1, num2));
