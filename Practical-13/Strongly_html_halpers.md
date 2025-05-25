
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
@model YourProjectName.Models.StudentModel
@{
    ViewBag.Title = "Student Registration";
}


<div class="">
    <div class="d-flex align-items-center mb-4 text-primary">
        <h2 class="mb-0 me-3">🎓 Student Registration Form</h2>
        <h5 class="mb-0 mt-2 text-muted">Using Strongly HTML Helpers</h5>
    </div>
    <form asp-action="RegisterStrongly" method="post" class="row g-3 bg-light p-4 rounded shadow">
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
        var s = ViewBag.StudentData as YourProjectName.Models.StudentModel;
        <div class="card mt-5 shadow-sm">
            <div class="card-header bg-success text-white">📋 Submitted Student Info</div>
            <div class="card-body mt-2">
                <ul class="list-group">
                    <li class="list-group-item"><strong>Name:</strong> @s.StudentName</li>
                    <li class="list-group-item"><strong>Branch:</strong> @s.Branch</li>
                    <li class="list-group-item"><strong>Semester:</strong> @s.Semester</li>
                    <li class="list-group-item"><strong>Birthdate:</strong> @s.Birthdate.ToShortDateString()</li>
                    <li class="list-group-item"><strong>Mobile:</strong> @s.Mobile</li>
                    <li class="list-group-item"><strong>Email:</strong> @s.Email</li>
                    <li class="list-group-item"><strong>Address:</strong> @s.Address</li>
                    <li class="list-group-item"><strong>City:</strong> @s.City</li>
                    <li class="list-group-item"><strong>Hobbies:</strong> @string.Join(", ", s.Hobbies)</li>
                    <li class="list-group-item"><strong>Gender:</strong> @s.Gender</li>
                </ul>
            </div>
        </div>
    }
</div>
````

