
# ASP.NET Core MVC: Static CRUD Operations for Employee

This tutorial walks you through creating a static (in-memory) CRUD system using a `List<Employee>` collection in ASP.NET Core MVC.

---

## 1. Create ASP.NET Core MVC Project

---

## 2. Create Employee Model

### ➤ Models/EmployeeModel.cs

```csharp
public class EmployeeModel
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}
```
## 3. Create Employee Controller

### ➤ Controllers/EmployeeController.cs

```csharp
public class EmployeeController : Controller
{
    private static List<EmployeeModel> employeeList = new List<EmployeeModel>
    {
        new EmployeeModel { EmployeeId = 1, Name = "John Doe", Designation = "Manager", Department = "Sales", Salary = 50000 },
        new EmployeeModel { EmployeeId = 2, Name = "Jane Smith", Designation = "Developer", Department = "IT", Salary = 60000 },
    };

    public IActionResult Index()
    {
        return View(employeeList);
    }

    public IActionResult Create()
    {
        return View("Create", new EmployeeModel());
    }

    [HttpPost]
    public IActionResult Create(EmployeeModel employee)
    {
        employee.EmployeeId = employeeList.Max(e => e.EmployeeId) + 1;
        employeeList.Add(employee);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var emp = employeeList.FirstOrDefault(e => e.EmployeeId == id);
        if (emp == null)
            return NotFound();

        return View("Create", emp);
    }

    [HttpPost]
    public IActionResult Edit(EmployeeModel employee)
    {
        var emp = employeeList.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
        if (emp != null)
        {
            emp.Name = employee.Name;
            emp.Designation = employee.Designation;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;
        }
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        var emp = employeeList.FirstOrDefault(e => e.EmployeeId == id);
        return View(emp);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var emp = employeeList.FirstOrDefault(e => e.EmployeeId == id);
        if (emp != null)
            employeeList.Remove(emp);
        return RedirectToAction("Index");
    }

}
```
## 4. Create Required Views

### ➤ Views/Employee/Create.cshtml

```csharp
@model YourProjectName.Models.EmployeeModel

@{
    bool isEdit = Model.EmployeeId != 0;
    ViewData["Title"] = isEdit ? "Edit Employee" : "Add Employee";
}

<div class="container mt-4">
    <h2 class="text-info">@ViewData["Title"]</h2>
    <form asp-action="@(isEdit ? "Edit" : "Create")" method="post">
        <input type="hidden" asp-for="EmployeeId" />

        <div class="mb-3">
            <label asp-for="Name" class="form-label"></label>
            <input asp-for="Name" class="form-control" required />
        </div>

        <div class="mb-3">
            <label asp-for="Designation" class="form-label"></label>
            <input asp-for="Designation" class="form-control" required />
        </div>

        <div class="mb-3">
            <label asp-for="Department" class="form-label"></label>
            <input asp-for="Department" class="form-control" required />
        </div>

        <div class="mb-3">
            <label asp-for="Salary" class="form-label"></label>
            <input asp-for="Salary" class="form-control" type="number" step="0.01" min="0" required />
        </div>

        <button type="submit" class="btn btn-primary">Save</button>
        <a href="/Employee" class="btn btn-secondary">Cancel</a>
    </form>
</div>

```

---

### ➤ Views/Employee/Delete.cshtml

```csharp
@model YourProjectName.Models.EmployeeModel
@{
    ViewData["Title"] = "Delete Employee";
}
<div class="container mt-4">
    <h2 class="text-danger">Confirm Delete</h2>
    <div class="alert alert-warning">Are you sure you want to delete <strong>@Model.Name</strong>?</div>
    <form method="post">
        <input type="hidden" asp-for="EmployeeId" />
        <button type="submit" class="btn btn-danger">Yes, Delete</button>
        <a href="/Employee" class="btn btn-secondary">Cancel</a>
    </form>
</div>

```

---

### ➤ Views/Home/Index.cshtml

```csharp
@model List<YourProjectName.Models.EmployeeModel>
@{
    ViewData["Title"] = "Employee List";
}
<div class="container mt-5">
    <h2 class="text-primary">Employee List</h2>
    <a href="/Employee/Create" class="btn btn-success mb-3">Add Employee</a>
    <table class="table table-bordered table-striped">
        <thead class="table-dark">
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Designation</th>
                <th>Department</th>
                <th>Salary</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var emp in Model)
            {
                <tr>
                    <td>@emp.EmployeeId</td>
                    <td>@emp.Name</td>
                    <td>@emp.Designation</td>
                    <td>@emp.Department</td>
                    <td>@emp.Salary</td>
                    <td>
                        <a class="btn btn-sm btn-warning" href="/Employee/Edit/@emp.EmployeeId">Edit</a>
                        <a class="btn btn-sm btn-danger" href="/Employee/Delete/@emp.EmployeeId">Delete</a>
                    </td>
                </tr>
            }
        </tbody>
    </table>
</div>

```

---

## 5. Routing (Program.cs)

Ensure you have the following conventional route in `Program.cs`:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");
```
