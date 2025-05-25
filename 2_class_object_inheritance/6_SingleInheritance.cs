
class Account_Details
{
    public string AccountHolderName;
    public double Principal;
    public double Rate;
    public int Time;

    public void GetAccountInfo()
    {
        Console.Write("Enter Account Holder Name: ");
        AccountHolderName = Console.ReadLine();

        Console.Write("Enter Principal Amount: ");
        Principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest (% per annum): ");
        Rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time (in years): ");
        Time = Convert.ToInt32(Console.ReadLine());
    }
}

class Interest : Account_Details
{
    public void CalculateInterest()
    {
        double interest = (Principal * Rate * Time) / 100;
        Console.WriteLine("\n----- Account Summary -----");
        Console.WriteLine("Account Holder: " + AccountHolderName);
        Console.WriteLine("Principal Amount: " + Principal);
        Console.WriteLine("Rate of Interest: " + Rate + "%");
        Console.WriteLine("Time Period: " + Time + " years");
        Console.WriteLine("Total Interest: " + interest);
    }
}

Interest interest = new Interest();
interest.GetAccountInfo();
interest.CalculateInterest();

