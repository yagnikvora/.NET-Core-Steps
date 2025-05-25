
class Distance
{
    public double D1;
    public double D2;
    public double D3;

    public Distance()
    {
        D1 = 100;
        D2 = 120;
    }

    public double calculateDistance()
    {
        D3 = D2 + D1;
        return D3;
    }
}

Distance d = new Distance();
Console.WriteLine("Total Distance : " + d.calculateDistance());
