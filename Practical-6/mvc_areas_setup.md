# Adding Areas: Admin and User with Navigation

This guide explains how to add Areas in ASP.NET Core MVC for better organization.

---

## What is an Area?
**Areas** allow you to separate parts of your app (e.g., Admin, User) into sections with their own controllers and views.

---

## Step-by-Step: Add Areas

### 1. Create Folder: `Areas`
Right-click on the project > Add > New Folder > Name it **Areas**

### 2. Add Subfolders: `Admin`, `User`
Each should contain:
- Controllers
- Views

Example structure:
```
Areas
├── Admin
│   ├── Controllers
│   └── Views
└── User
    ├── Controllers
    └── Views
```

---

## Add Controller to User Area
Create `HomeController.cs` in `Areas/User/Controllers/`
```csharp
[Area("User")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
    public IActionResult ContactUs() => View();
}
```

---

## Add Views for User
In `Areas/User/Views/Home/` add:
- `Index.cshtml`
- `About.cshtml`
- `ContactUs.cshtml`

---

## Configure Routing
Update `Program.cs` or `Startup.cs`:
```csharp
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
```

---

## Add Navigation Between Areas
Edit `_Layout.cshtml`:
```html
<a asp-area="User" asp-controller="Home" asp-action="Index">User Home</a>
<a asp-area="Admin" asp-controller="Home" asp-action="Index">Admin Home</a>
```
