# 📘 AddressBook Project Setup with Areas in ASP.NET Core MVC

This document provides step-by-step instructions to create an ASP.NET Core MVC project with Areas for `Country`, `State`, and `City` entities.

---

## ✅ 1. Create New ASP.NET Core MVC Project

1. Open Visual Studio
2. Go to **File** → **New** → **Project**
3. Select **ASP.NET Core Web App (Model-View-Controller)**
4. Name your project: `AddressBook`
5. Choose **.NET 8** or later
6. Click **Create**

---

## ✅ 2. Create Areas: LOC_Country, LOC_State, LOC_City

### 📁 Folder Structure:

```
Areas
│
├── LOC_Country
│   └── Controllers
│   └── Models
│   └── Views
│       └── Country
│
├── LOC_State
│   └── Controllers
│   └── Models
│   └── Views
│       └── State
│
├── LOC_City
    └── Controllers
    └── Models
    └── Views
        └── City
```

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

### 📁 `Areas/LOC_Country/Models/CountryModel.cs`

```csharp
public class CountryModel
{
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}
```

Repeat similarly for:
- `StateModel` in `Areas/LOC_State/Models/`
- `CityModel` in `Areas/LOC_City/Models/`

---

## ✅ 5. Create Controllers

### 📁 `Areas/LOC_Country/Controllers/CountryController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using AddressBook.Areas.LOC_Country.Models;

namespace AddressBook.Areas.LOC_Country.Controllers
{
    [Area("Country")]
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```

Repeat similarly for `StateController` and `CityController`.

---

## ✅ 6. Create Views

### 📄 `Areas/LOC_Country/Views/Country/Index.cshtml`

```html
@{
    ViewData["Title"] = "Countries";
}

<h2>Country List</h2>
```

Repeat similarly for State and City.

---

## ✅ 7. Run Application

Visit these URLs:
- `/LOC_Country/Country/Index`
- `/LOC_State/State/Index`
- `/LOC_City/City/Index`


