
# 🎓 Student Registration Form – ASP.NET Core MVC (Strongly Typed HTML Helpers)

This project demonstrates how to create a **Student Registration Form** using **strongly typed HTML helpers** in **ASP.NET Core MVC** with Bootstrap styling.

---

## 1. Model – `Student.cs`

````csharp
public class Student
{
    public string StudentName { get; set; }
    public string Branch { get; set; }
    public string Semester { get; set; }
    public DateTime Birthdate { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public List<string> Hobbies { get; set; }
    public string Gender { get; set; }
}
````

---

## 2. Controller – `StudentController.cs`

````csharp
public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View(new Student());
    }

    [HttpPost]
    public IActionResult Register(Student student)
    {
        ViewBag.StudentData = student;
        return View(student);
    }
}
````

---

## 3. View – `Register.cshtml`

````html
@model YourNamespace.Models.Student
@{
    ViewBag.Title = "Student Registration";
}


<div class="container mt-4">
    <h2 class="mb-4">Student Registration Form</h2>

    <form asp-action="Register" method="post" class="row g-3">
        <div class="col-md-6">
            @Html.LabelFor(m => m.StudentName)
            @Html.TextBoxFor(m => m.StudentName, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Branch)
            @Html.TextBoxFor(m => m.Branch, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Semester)
            @Html.TextBoxFor(m => m.Semester, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Birthdate)
            @Html.TextBoxFor(m => m.Birthdate, "{0:yyyy-MM-dd}", new { @class = "form-control", type = "date" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Mobile)
            @Html.TextBoxFor(m => m.Mobile, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Email)
            @Html.TextBoxFor(m => m.Email, new { @class = "form-control", type = "email" })
        </div>
        <div class="col-12">
            @Html.LabelFor(m => m.Address)
            @Html.TextAreaFor(m => m.Address, new { @class = "form-control", rows = 2 })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.City)
            @Html.TextBoxFor(m => m.City, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label>Hobbies</label><br />
            @foreach (var hobby in new[] { "Reading", "Sports", "Music" })
            {
                <div class="form-check form-check-inline">
                    <input type="checkbox" name="Hobbies" value="@hobby" class="form-check-input" />
                    <label class="form-check-label">@hobby</label>
                </div>
            }
        </div>
        <div class="col-md-12">
            <label>Gender</label><br />
            <div class="form-check form-check-inline">
                @Html.RadioButtonFor(m => m.Gender, "Male", new { @class = "form-check-input" })
                <label class="form-check-label">Male</label>
            </div>
            <div class="form-check form-check-inline">
                @Html.RadioButtonFor(m => m.Gender, "Female", new { @class = "form-check-input" })
                <label class="form-check-label">Female</label>
            </div>
        </div>
        <div class="col-12">
            <button type="submit" class="btn btn-primary">Submit</button>
        </div>
    </form>

    @if (ViewBag.StudentData != null)
    {
        var s = ViewBag.StudentData as YourNamespace.Models.Student;
        <div class="mt-4 alert alert-success">
            <h5>Submitted Data</h5>
            <p><strong>Name:</strong> @s.StudentName</p>
            <p><strong>Branch:</strong> @s.Branch</p>
            <p><strong>Semester:</strong> @s.Semester</p>
            <p><strong>Birthdate:</strong> @s.Birthdate.ToShortDateString()</p>
            <p><strong>Mobile:</strong> @s.Mobile</p>
            <p><strong>Email:</strong> @s.Email</p>
            <p><strong>Address:</strong> @s.Address</p>
            <p><strong>City:</strong> @s.City</p>
            <p><strong>Gender:</strong> @s.Gender</p>
            <p><strong>Hobbies:</strong> @string.Join(", ", s.Hobbies ?? new List<string>())</p>
        </div>
    }
</div>
````

