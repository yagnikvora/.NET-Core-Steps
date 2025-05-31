# 🚦 ASP.NET Core MVC AddressBook - Attribute Routing

This file explains how to implement Attribute Routing for the `Country`, `State`, and `City` pages in an ASP.NET Core MVC project using Areas.

---

## ✅ Enable Area Support in `Program.cs` or `Startup.cs`

Make sure routing supports areas and this code must be above the default app.MapControllerRoute():

```csharp
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

```

---

## ✅ Add Attribute Routing to Controllers

---

### 📁 `Areas/Country/Controllers/CountryController.cs`

```csharp
[Area("Country")]
[Route("Country/[controller]/[action]")]
public class CountryController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        // Return Country list
    }

    [Route("AddEdit/{id?}")]
    public IActionResult AddEdit(int? id)
    {
        // Load Country data for Add or Edit
    }

    [HttpPost]
    [Route("Save")]
    public IActionResult Save(CountryModel model)
    {
        // Save logic
    }
}
```

---

### 📁 `Areas/State/Controllers/StateController.cs`

```csharp
[Area("State")]
[Route("State/[controller]/[action]")]
public class StateController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        // Return State list
    }

    [Route("AddEdit/{id?}")]
    public IActionResult AddEdit(int? id)
    {
        // Load State data
    }

    [HttpPost]
    [Route("Save")]
    public IActionResult Save(StateModel model)
    {
        // Save logic
    }
}
```

---

### 📁 `Areas/City/Controllers/CityController.cs`

```csharp
[Area("City")]
[Route("City/[controller]/[action]")]
public class CityController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        // Return City list
    }

    [Route("AddEdit/{id?}")]
    public IActionResult AddEdit(int? id)
    {
        // Load City data
    }

    [HttpPost]
    [Route("Save")]
    public IActionResult Save(CityModel model)
    {
        // Save logic
    }
}
```
