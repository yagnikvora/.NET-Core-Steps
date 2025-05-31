
class Furniture
{
    public String Material;
    public double Price;

}
class Table : Furniture
{
    public double Height;
    public double SurfaceArea;

    public Table(String Material, double Price, double Height, double SurfaceArea)
    {
        this.Material = Material;
        this.Price = Price;
        this.Height = Height;
        this.SurfaceArea = SurfaceArea;
    }

    public void displayData()
    {
        Console.WriteLine("Material Type : " + Material);
        Console.WriteLine("Price : " + Price);
        Console.WriteLine("Height : " + Height);
        Console.WriteLine("Surface Area : " + SurfaceArea);
    }
}

Table t = new Table("Material", 50000, 120, 1200);
t.displayData();

