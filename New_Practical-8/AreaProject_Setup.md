# 📘 DashboardController Project Setup with Areas in ASP.NET Core MVC

This document provides step-by-step instructions to create an ASP.NET Core MVC project with Areas for `Admin`, `Manager`, and `Employee` entities.

---

## ✅ 1. Create New ASP.NET Core MVC Project

1. Open Visual Studio
2. Go to **File** → **New** → **Project**
3. Select **ASP.NET Core Web App (Model-View-Controller)**
4. Name your project: `AdminUserProject`
5. Choose **.NET 8** or later
6. Click **Create**

---

## ✅ 2. Create Areas: Admin, Manager, Employee

### 📁 Folder Structure:

```
Areas
│
├── Aadmin
│   └── Controllers
│   └── Models
│   └── Views
│       └── Dashboard
│           └── Index
│
├── Manager
│   └── Controllers
│   └── Models
│   └── Views
│       └── Dashboard
│           └── Index
│
├── Employee
│   └── Controllers
│   └── Models
│   └── Views
│       └── Dashboard
│           └── Index
```

1. To create area right click on your project name 
2. Now you can see menu in this click on Add 
3. Now click on New Scaffold Item.. after click one window will open 
4. In that select MVC area and click on Add button 
5. Now give the name of your area and click on Add button

---

## ✅ 3. Enable Area Routing

Edit `Program.cs`:

```csharp
app.UseRouting();

app.MapControllerRoute(
    name : "areas",
    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

```

---

## ✅ 4. Create Models

### 📁 `Areas/Admin/Models/DashboardModel.cs`

```csharp
public class DashboardModel
{
    public int AdminID { get; set; }
    public string AdminName { get; set; }
}
```

Repeat similarly for:
- `DashboardModel` in `Areas/Manager/Models/`
- `DashboardModel` in `Areas/Employee/Models/`

---

## ✅ 5. Create Controllers

### 📁 `Areas/Admin/Controllers/DashboardController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using DashboardController.Areas.Admin.Models;

namespace DashboardController.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```

Repeat similarly for `Manager` and `Employee`.

---

## ✅ 6. Create Views

### 📄 `Areas/Admin/Views/Admin/Index.cshtml`

```html
@{
    ViewData["Title"] = "Admin Dashboard";
}

<h2>Admin Dashboard</h2>
```

Repeat similarly for Manager and Employee.

---

## ✅ 7. Run Application

Visit these URLs:
- `/Admin/Dashboard/Index`
- `/Manager/Dashboard/Index`
- `/Employee/Dashboard/Index` 


