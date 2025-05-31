
interface Gross
{
    void Gross_sal();
}

class Employee
{
    protected string Name;

    public void basic_sal()
    {
        Console.Write("Enter Employee Name: ");
        Name = Console.ReadLine();
    }
}

class Salary : Employee, Gross
{
    private double HRA, TA, DA, GrossSalary;

    public void Disp_sal()
    {
        Console.Write("Enter HRA: ");
        HRA = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter TA: ");
        TA = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter DA: ");
        DA = Convert.ToDouble(Console.ReadLine());
    }

    public void Gross_sal()
    {
        GrossSalary =  HRA + TA + DA;

        Console.WriteLine("\n----- Salary Details -----");
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("HRA: " + HRA);
        Console.WriteLine("TA: " + TA);
        Console.WriteLine("DA: " + DA);
        Console.WriteLine("Gross Salary: " + GrossSalary);
    }
}

Salary emp = new Salary();
emp.basic_sal();     
emp.Disp_sal();      
emp.Gross_sal();     
