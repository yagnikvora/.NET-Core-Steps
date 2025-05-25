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

## ✅ 2. Create Areas: Country, State, City

### 📁 Folder Structure:

```
Areas
│
├── Country
│   └── Controllers
│   └── Models
│   └── Views
│       └── Country
│
├── State
│   └── Controllers
│   └── Models
│   └── Views
│       └── State
│
├── City
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name : "areas",
    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
```

---

## ✅ 4. Create Models

### 📁 `Areas/Country/Models/CountryModel.cs`

```csharp
public class CountryModel
{
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}
```

Repeat similarly for:
- `StateModel` in `Areas/State/Models/`
- `CityModel` in `Areas/City/Models/`

---

## ✅ 5. Create Controllers

### 📁 `Areas/Country/Controllers/CountryController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using AddressBook.Areas.Country.Models;

namespace AddressBook.Areas.Country.Controllers
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

### 📄 `Areas/Country/Views/Country/Index.cshtml`

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
- `/Country/Country/Index`
- `/State/State/Index`
- `/City/City/Index`


