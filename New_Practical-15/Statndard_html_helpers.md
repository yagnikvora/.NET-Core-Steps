
# 🎓 ASP.NET Core MVC - Student Registration Form

This project demonstrates how to create a **Student Registration Form** using **Standard HTML Helpers** (not strongly typed) in **ASP.NET Core MVC**, styled with **Bootstrap 5**. The submitted data is shown below the form on the same page.



## 📁 Folder Structure

```
Controllers/
  └── StudentController.cs

Models/
  └── Student.cs

Views/
  └── Student/
      └── Register.cshtml
```

---

## ✅ Steps to Implement

### 1. Model: `Student.cs`

```csharp
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
```

---

### 2. Controller: `StudentController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(IFormCollection form)
    {
        Student student = new Student
        {
            StudentName = form["StudentName"],
            Branch = form["Branch"],
            Semester = form["Semester"],
            Birthdate = Convert.ToDateTime(form["Birthdate"]),
            Mobile = form["Mobile"],
            Email = form["Email"],
            Address = form["Address"],
            City = form["City"],
            Hobbies = form["Hobbies"].ToList(),
            Gender = form["Gender"]
        };

        ViewBag.Student = student;
        return View();
    }
}
```

> ⚠️ Replace `YourNamespace` with your actual project namespace.

---

### 3. View: `Register.cshtml`

> 📌 Add Bootstrap via CDN in your layout or directly in this view.

```cshtml
@{
    ViewData["Title"] = "Student Registration";
    var student = ViewBag.Student as YourNamespace.Models.Student;
}


<div class="container mt-5">
    <h2 class="mb-4 text-primary">🎓 Student Registration Form</h2>
    <form method="post" class="row g-3 bg-light p-4 rounded shadow">
        <div class="col-md-6">
            <label class="form-label">Name</label>
            @Html.TextBox("StudentName", "", new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Branch</label>
            @Html.TextBox("Branch", "", new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Semester</label>
            @Html.TextBox("Semester", "", new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Birthdate</label>
            @Html.TextBox("Birthdate", "", new { @type = "date", @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Mobile</label>
            @Html.TextBox("Mobile", "", new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Email</label>
            @Html.TextBox("Email", "", new { @type = "email", @class = "form-control" })
        </div>
        <div class="col-12">
            <label class="form-label">Address</label>
            @Html.TextArea("Address", "", new { @class = "form-control", rows = 2 })
        </div>
        <div class="col-md-6">
            <label class="form-label">City</label>
            @Html.TextBox("City", "", new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label class="form-label">Hobbies</label><br />
            <div class="form-check form-check-inline">
                @Html.CheckBox("Hobbies", false, new { @value = "Reading", @class = "form-check-input" })
                <label class="form-check-label">Reading</label>
            </div>
            <div class="form-check form-check-inline">
                @Html.CheckBox("Hobbies", false, new { @value = "Sports", @class = "form-check-input" })
                <label class="form-check-label">Sports</label>
            </div>
            <div class="form-check form-check-inline">
                @Html.CheckBox("Hobbies", false, new { @value = "Music", @class = "form-check-input" })
                <label class="form-check-label">Music</label>
            </div>
        </div>
        <div class="col-md-6">
            <label class="form-label">Gender</label><br />
            <div class="form-check form-check-inline">
                @Html.RadioButton("Gender", "Male", false, new { @class = "form-check-input" })
                <label class="form-check-label">Male</label>
            </div>
            <div class="form-check form-check-inline">
                @Html.RadioButton("Gender", "Female", false, new { @class = "form-check-input" })
                <label class="form-check-label">Female</label>
            </div>
        </div>
        <div class="col-12">
            <input type="submit" value="Submit" class="btn btn-success" />
        </div>
    </form>

    @if (student != null)
    {
        <div class="card mt-5 shadow-sm">
            <div class="card-header bg-success text-white">📋 Submitted Student Info</div>
            <div class="card-body">
                <ul class="list-group">
                    <li class="list-group-item"><strong>Name:</strong> @student.StudentName</li>
                    <li class="list-group-item"><strong>Branch:</strong> @student.Branch</li>
                    <li class="list-group-item"><strong>Semester:</strong> @student.Semester</li>
                    <li class="list-group-item"><strong>Birthdate:</strong> @student.Birthdate.ToShortDateString()</li>
                    <li class="list-group-item"><strong>Mobile:</strong> @student.Mobile</li>
                    <li class="list-group-item"><strong>Email:</strong> @student.Email</li>
                    <li class="list-group-item"><strong>Address:</strong> @student.Address</li>
                    <li class="list-group-item"><strong>City:</strong> @student.City</li>
                    <li class="list-group-item"><strong>Hobbies:</strong> @string.Join(", ", student.Hobbies)</li>
                    <li class="list-group-item"><strong>Gender:</strong> @student.Gender</li>
                </ul>
            </div>
        </div>
    }
</div>
```
