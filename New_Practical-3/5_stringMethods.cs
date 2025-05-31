
String s = "Yagnik Vora";

Console.WriteLine("Length Of Stinrg Is : " + s.Length);
Console.WriteLine("Substring : " + s.Substring(1));
Console.WriteLine("Contains: " + s.Contains("Yagnik"));
Console.WriteLine("Replaced : " + s.Replace("Yagnik", "yagnik"));
Console.WriteLine("Index of 'Yagnik': " + s.IndexOf("Yagnik"));
Console.WriteLine("Upper Case Conversion: " + s.ToUpper());
Console.WriteLine("Lower Case Conversion: " + s.ToLower());
Console.WriteLine("Formate String : " + string.Format("Hii ! I'm {0}", s));
