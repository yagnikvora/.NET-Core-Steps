# Razor Syntax Overview in ASP.NET MVC
This project demonstrates Razor syntax and basic ASP.NET MVC functionality with three tasks:

---

## 1) Print Table of 5 using Razor

### Controller: `Controllers/HomeController.cs`
```csharp
public class HomeController : Controller
{
    public ActionResult TableOfFive()
    {
        return View();
    }
}
```

**View File: `Views/Home/TableOfFive.cshtml`**
```csharp
@{
    ViewBag.Title = "Table of 5";
}
<html>
<body>
    <h2>Table of 5</h2>
    <ul>
        @for (int i = 1; i <= 10; i++)
        {
            <li>5 x @i = @(5 * i)</li>
        }
    </ul>
</body>
</html>
```

---

## 2) Display Student Details with Semester-wise SPI

### Model: `Models/Student.cs`
```csharp
public class Student
{
    public string Name { get; set; }
    public string EnrollmentNo { get; set; }
    public Dictionary<string, double> SemesterSPI { get; set; }
}
```

### Controller: `Controllers/HomeController.cs`
```csharp
public class HomeController : Controller
{
    public ActionResult StudentSPI()
    {
        var student = new Student
        {
            Name = "John Doe",
            EnrollmentNo = "123456",
            SemesterSPI = new Dictionary<string, double>
            {
                {"Semester 1", 8.5},
                {"Semester 2", 8.8},
                {"Semester 3", 9.0},
                {"Semester 4", 8.7}
            }
        };
        return View(student);
    }
}
```

### View: `Views/Home/StudentSPI.cshtml`
```csharp
@model YourNamespace.Models.Student
@{
    ViewBag.Title = "Student SPI";
}
<html>
<body>
    <h2>Student Details</h2>
    <p><strong>Name:</strong> @Model.Name</p>
    <p><strong>Enrollment No:</strong> @Model.EnrollmentNo</p>
    <h3>Semester-wise SPI</h3>
    <table border="1">
        <tr>
            <th>Semester</th>
            <th>SPI</th>
        </tr>
        @foreach (var item in Model.SemesterSPI)
        {
            <tr>
                <td>@item.Key</td>
                <td>@item.Value</td>
            </tr>
        }
    </table>
</body>
</html>

```

---

## 3) Display SPI Table using ViewBag and `foreach`

### Controller: `Controllers/HomeController.cs`
```csharp
public class HomeController : Controller
{
    public ActionResult StudentSPI()
    {
        var student = new Student
        {
            Name = "John Doe",
            EnrollmentNo = "123456",
            SemesterSPI = new Dictionary<string, double>
            {
                {"Semester 1", 8.5},
                {"Semester 2", 8.8},
                {"Semester 3", 9.0},
                {"Semester 4", 8.7}
            }
        };
        ViewBag.Student = student;
        return View();
    }
}
```

### View: `Views/Home/StudentSPI.cshtml`
```csharp
@{
    ViewBag.Title = "Student SPI";
    var student = ViewBag.Student;
}
<html>
<body>
    <h2>Student Details</h2>
    <p><strong>Name:</strong> @student.Name</p>
    <p><strong>Enrollment No:</strong> @student.EnrollmentNo</p>
    <h3>Semester-wise SPI</h3>
    <table border="1">
        <tr>
            <th>Semester</th>
            <th>SPI</th>
        </tr>
        @foreach (var item in student.SemesterSPI)
        {
            <tr>
                <td>@item.Key</td>
                <td>@item.Value</td>
            </tr>
        }
    </table>
</body>
</html>
```

---

## How to Run

1. Create a new ASP.NET MVC project.
2. Add `Student.cs` in the `Models` folder.
3. Add the actions to `HomeController`.
4. Create two Views: `TableOfFive.cshtml` and `StudentSPI.cshtml`.
5. Run the application and navigate to `/Home/TableOfFive` and `/Home/StudentSPI`.

---

✅ **Done!** This showcases basic Razor syntax and ViewBag usage in MVC.
