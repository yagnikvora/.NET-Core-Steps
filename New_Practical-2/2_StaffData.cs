class Staff
{
    public String Name;
    public String Designation;
    public String Department;
    public int Experience;
    public int Salary;

    public Staff(String Name, String Designation,String Department,int Experience, int Salary)
    {
        this.Name = Name;
        this.Designation = Designation;
        this.Department = Department;
        this.Experience = Experience;
        this.Salary = Salary;
    }

    public void displayData()
    {
        if (Designation == "HOD")
        {
            Console.WriteLine("Name : " + Name + " Salary : " + Salary);
        }
    }
}

Staff s1 = new Staff("Yagnik", "HOD","CE",3,100000);
Staff s2 = new Staff("Umang", "Admin","CE",2,90000);
Staff s3 = new Staff("Bhagyesh", "TA","CE",1,40000);
Staff s4 = new Staff("Ronak", "Faculty","ME",4,10000);
Staff s5 = new Staff("Vansh", "Faculty","CE",6,70000);
s1.displayData();
s2.displayData();
s3.displayData();
s4.displayData();
s5.displayData();


