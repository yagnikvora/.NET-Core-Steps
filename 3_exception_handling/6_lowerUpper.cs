
String oldString = "Yagnik";
String newString = "";
foreach (char c in oldString)
{
    if (Char.IsUpper(c))
    {
        newString += c.ToString().ToLower();
    }
    else
    {
        newString += c.ToString().ToUpper();
    }
}
Console.WriteLine("Result = "+newString);
