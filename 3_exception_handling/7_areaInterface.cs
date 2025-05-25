interface Shape
{
    double Circle(int r);
    double Tringle(int b, int h);
    double Square(int l);
}

class Area : Shape
{
    public double Circle(int r)
    {
        return Math.PI * r * r;
    }

    public double Tringle(int b, int h)
    {
        return b * h * 0.5;
    }
    public double Square(int l)
    {
        return l * l;
    }

}
Area a = new Area();
Console.WriteLine("Enter Radius : ");
int r = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Area Of Circle : " + a.Circle(r));
Console.WriteLine("Enter Height : ");
int h = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Breath : ");
int b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Area Of Tringle : " + a.Tringle(h, b));
Console.WriteLine("Enter Length : ");
int l = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Area Of Square : " + a.Square(l));
