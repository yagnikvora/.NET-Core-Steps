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

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8">

                <div class="card shadow-sm border-0 mb-4">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">Student Details</h4>
                    </div>
                    <div class="card-body">
                        <p class="mb-2"><strong>Name:</strong> @Model.Name</p>
                        <p class="mb-0"><strong>Enrollment No:</strong> @Model.EnrollmentNo</p>
                    </div>
                </div>

                <div class="card shadow-sm border-0">
                    <div class="card-header bg-success text-white">
                        <h5 class="mb-0">Semester-wise SPI</h5>
                    </div>
                    <div class="card-body p-0">
                        <table class="table table-hover table-striped mb-0">
                            <thead class="table-dark">
                                <tr>
                                    <th scope="col">Semester</th>
                                    <th scope="col">SPI</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var item in Model.SemesterSPI)
                                {
                                    <tr>
                                        <td>@item.Key</td>
                                        <td>@item.Value</td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>


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

    <div class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8">

                <div class="card shadow-sm border-0 mb-4">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0">Student Details</h4>
                    </div>
                    <div class="card-body">
                        <p class="mb-2"><strong>Name:</strong> @student.Name</p>
                        <p class="mb-0"><strong>Enrollment No:</strong> @student.EnrollmentNo</p>
                    </div>
                </div>

                <div class="card shadow-sm border-0">
                    <div class="card-header bg-success text-white">
                        <h5 class="mb-0">Semester-wise SPI</h5>
                    </div>
                    <div class="card-body p-0">
                        <table class="table table-hover table-striped mb-0">
                            <thead class="table-dark">
                                <tr>
                                    <th scope="col">Semester</th>
                                    <th scope="col">SPI</th>
                                </tr>
                            </thead>
                            <tbody>
                                 @foreach (var item in student.SemesterSPI)
                                {
                                    <tr>
                                           <td>@item.Key</td>
                                            <td>@item.Value</td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>

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
