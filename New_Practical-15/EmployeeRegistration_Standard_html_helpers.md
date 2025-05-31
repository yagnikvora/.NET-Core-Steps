
# 👨‍💼 Employee Registration Form (Standard HTML Helpers) - ASP.NET Core MVC

This project demonstrates how to create an Employee Registration Form using **Standard HTML Helpers** (not strongly typed) in ASP.NET Core MVC. The submitted form data is displayed on the same page below the form using `ViewBag`.

---

## 📁 Step 1: Model (Optional ViewModel)

Although the form uses `IFormCollection`, a model can be used to structure data:

```csharp
public class Employee
{
    public string EmployeeName { get; set; }
    public string Department { get; set; }
    public string Designation { get; set; }
    public DateTime Birthdate { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public List<string> Skills { get; set; }
    public string Gender { get; set; }
}
```

---

## 📂 Step 2: Controller

```csharp
public class EmployeeController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(IFormCollection form)
    {
        ViewBag.Employee = form;
        return View();
    }
}
```

---

## 📝 Step 3: View (`Register.cshtml`)

```html
@{
    ViewBag.Title = "Employee Registration";
}


<div class="">
    <div class="d-flex align-items-center text-primary mb-4">
        <h2 class="me-3 mb-0">👨‍💼 Employee Registration Form</h2>
        <h5 class="text-muted mb-0">Using Standard HTML Helpers</h5>
    </div>

    <form method="post" class="row g-3 bg-light p-4 rounded shadow">
        <div class="col-md-6">
            @Html.Label("EmployeeName")
            @Html.TextBox("EmployeeName", null, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.Label("Department")
            @Html.TextBox("Department", null, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.Label("Designation")
            @Html.TextBox("Designation", null, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.Label("Birthdate")
            @Html.TextBox("Birthdate", null, new { @class = "form-control", type = "date" })
        </div>
        <div class="col-md-6">
            @Html.Label("Mobile")
            @Html.TextBox("Mobile", null, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.Label("Email")
            @Html.TextBox("Email", null, new { @class = "form-control", type = "email" })
        </div>
        <div class="col-12">
            @Html.Label("Address")
            @Html.TextArea("Address", null, new { @class = "form-control", rows = 2 })
        </div>
        <div class="col-md-6">
            @Html.Label("City")
            @Html.TextBox("City", null, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            <label>Skills</label><br />
            @foreach (var skill in new[] { "C#", "JavaScript", "SQL" })
            {
                <div class="form-check form-check-inline">
                    <input type="checkbox" name="Skills" value="@skill" class="form-check-input" />
                    <label class="form-check-label">@skill</label>
                </div>
            }
        </div>
        <div class="col-md-12">
            <label>Gender</label><br />
            <div class="form-check form-check-inline">
                <input type="radio" name="Gender" value="Male" class="form-check-input" />
                <label class="form-check-label">Male</label>
            </div>
            <div class="form-check form-check-inline">
                <input type="radio" name="Gender" value="Female" class="form-check-input" />
                <label class="form-check-label">Female</label>
            </div>
        </div>
        <div class="col-12">
            <button type="submit" class="btn btn-primary">Submit</button>
        </div>
    </form>

    @if (ViewBag.Employee != null)
    {
        var e = ViewBag.Employee;
        <div class="card mt-5 shadow-sm">
            <div class="card-header bg-success text-white">📋 Submitted Student Info</div>
            <div class="card-body">
                <ul class="list-group">
                    <li class="list-group-item"><strong>Name:</strong> @e["EmployeeName"]</li>
                    <li class="list-group-item"><strong>Department:</strong> @e["Department"]</li>
                    <li class="list-group-item"><strong>Designation:</strong> @e["Designation"]</li>
                    <li class="list-group-item"><strong>Birthdate:</strong> @e["Birthdate"]</li>
                    <li class="list-group-item"><strong>Mobile:</strong> @e["Mobile"]</li>
                    <li class="list-group-item"><strong>Email:</strong> @e["Email"]</li>
                    <li class="list-group-item"><strong>Address:</strong> @e["Address"]</li>
                    <li class="list-group-item"><strong>City:</strong> @e["City"]</li>
                    <li class="list-group-item"><strong>Gender:</strong> @e["Gender"]</li>
                    <li class="list-group-item"><strong>Skills:</strong> @string.Join(", ", @e["Skills"])</li>
                </ul>
            </div>
        </div>
    }
</div>

```

