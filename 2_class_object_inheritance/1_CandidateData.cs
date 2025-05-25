
class Candidate
{
    public int id;
    public String Name;
    public int Age;
    public double Height;
    public double Weight;


    public void getCandidate()
    {
        Console.WriteLine("Enter Id : ");
        id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Name : ");
        Name = (Console.ReadLine());
        Console.WriteLine("Enter Age : ");
        Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Height : ");
        Height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Weight : ");
        Weight = Convert.ToDouble(Console.ReadLine());

    }
    public void displayCandidate()
    {
        Console.WriteLine("Id : " + id);
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("Age : " + Age);
        Console.WriteLine("Height : " + Height);
        Console.WriteLine("Weight : " + Weight);
    }
}

Candidate c = new Candidate();
c.getCandidate();
c.displayCandidate();
