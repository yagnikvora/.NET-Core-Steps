
# Student Form Using Bind Arrteibutes - ASP.NET Core MVC

This file demonstrates how to create an Student Form using **Bind** in ASP.NET Core MVC.


## Step 1: Create Student Model (`Srudent.cs`)

```csharp
public class Student
{
    public int Id { get; set; }              // Should not be updated via form
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }     // Should not be updated via form
}
```
---

## Step 2: Add Two Mwthods in (`HomeController.cs`)


```csharp
 // GET: /Student/Create
public IActionResult Create()
{
    return View();
}

// POST: /Student/Create
[HttpPost]
public IActionResult Create([Bind("Name,Email")] Student student)
{
    // Id and Password won't be bound due to selective [Bind]
    ViewBag.Name = student.Name;
    ViewBag.Email = student.Email;
    ViewBag.Id = student.Id;               // Default value (0)
    ViewBag.Password = student.Password;   // Null

    return View("StudentDetails");
}

```
---

## Step 2: View (`Create.cshtml`)

```html
@model AdminTheme.Models.Student

@{
    ViewData["Title"] = "Create Student";
}

<h2>Create Student</h2>

<form asp-action="StudentBindForm" method="post">
    <div class="form-group row my-2">
        <label class="col-2" asp-for="Name"></label>
        <input asp-for="Name" class="form-control col" />
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="Email"></label>
        <input asp-for="Email" class="form-control col" />
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="Password"></label>
        <input asp-for="Password" class="form-control col" type="password" />
    </div>
    <button type="submit" class="btn btn-primary mt-2">Submit</button>
</form>


```
## Step 4: View (`StudentDetails.cshtml`) for display the data
```csharp
@{
    ViewData["Title"] = "Student Details";
}

<h2>Submitted Data</h2>

<table class="table table-bordered">
    <tr>
        <th>ID</th>
        <td>@ViewBag.Id</td>
    </tr>
    <tr>
        <th>Name</th>
        <td>@ViewBag.Name</td>
    </tr>
    <tr>
        <th>Email</th>
        <td>@ViewBag.Email</td>
    </tr>
    <tr>
        <th>Password</th>
        <td>@ViewBag.Password</td>
    </tr>
</table>

<p class="text-danger">Note: ID and Password were excluded from model binding via the [Bind] attribute.</p>

```
## Step 4: Add Route in _Layout.cshtml
```csharp
<li>
    <a asp-controller="Home" asp-action="StudentBindForm">
        <i class="bi bi-circle"></i><span>Student Bind Form</span>
    </a>
</li>

```

