

class Area
{
    public double findArea(double l)
    {
        return l * l;
    }

    public double findArea(double l, double b)
    {
        return l * b;
    }

    public double findArea(int r)
    {
        return Math.PI * r * r;
    }
}

Area a = new Area();
Console.WriteLine("Enter Length : ");
double l = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter Breath : ");
double b = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter Radius : ");
int r = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Area Of Square : " + (a.findArea(l)));
Console.WriteLine("Area Of Reactangle : " + (a.findArea(l, b)));
Console.WriteLine("Area Of Circle : " + (a.findArea(r)));
