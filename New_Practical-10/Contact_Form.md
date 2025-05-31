
# ASP.NET Core MVC: Get Contact Info. and display in same page



## 1. Create Contact Model

### ➤ Models/ContactModel.cs

```csharp
public class ContactModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
```
## 2. Create Contact Controller

### ➤ Controllers/ContactController.cs

```csharp
public class ContactController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ContactModel contact)
    {
        return View(contact); // Return same view with submitted data
    }
}

```
## 3. Create Index View

### ➤ Views/Contact/Index.cshtml

```csharp
@model YourProjectName.Models.ContactModel
@{
    ViewData["Title"] = "Contact Us";
}

<div class="container mt-4">
    <h2 class="text-primary mb-4">Contact Us</h2>

    <form method="post" class="mb-5">
        <div class="mb-3">
            <label asp-for="Name" class="form-label">Name</label>
            <input asp-for="Name" class="form-control" required />
        </div>

        <div class="mb-3">
            <label asp-for="Email" class="form-label">Email</label>
            <input asp-for="Email" class="form-control" type="email" required />
        </div>

        <div class="mb-3">
            <label asp-for="Message" class="form-label">Message</label>
            <textarea asp-for="Message" class="form-control" rows="4" required></textarea>
        </div>

        <button type="submit" class="btn btn-primary">Submit</button>
    </form>

    @if (Model?.Name != null)
    {
        <div class="alert alert-success">
            <h5>Submitted Data</h5>
            <p><strong>Name:</strong> @Model.Name</p>
            <p><strong>Email:</strong> @Model.Email</p>
            <p><strong>Message:</strong> @Model.Message</p>
        </div>
    }
</div>

```

---

## 4. Routing (Program.cs)

Ensure you have the following conventional route in `Program.cs`:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");
```
