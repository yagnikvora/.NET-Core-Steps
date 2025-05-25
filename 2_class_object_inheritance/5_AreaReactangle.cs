
class Area
{
    public double length;
    public double breath;

    public double area;

    public Area(double length, double breath)
    {
        this.length = length;
        this.breath = breath;
        this.area = this.breath * this.length;
    }

    public void displayData()
    {
        Console.WriteLine("Length : " + length + " Breath : " + breath + " Area : " + area);
    }
}

Area a = new Area(100, 200);
a.displayData();

