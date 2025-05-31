# 📘 ASP.NET Core MVC AddressBook - Display Data from Controllers

This guide explains how to display data in List pages using controller action methods and models for **Country**, **State**, and **City** tables.

---

## ✅ 1. Models

### 📁 `Areas/Country/Models/CountryModel.cs`
```csharp
public class CountryModel
{
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}
```

### 📁 `Areas/State/Models/StateModel.cs`
```csharp
public class StateModel
{
    public int StateID { get; set; }
    public string StateName { get; set; }
    public string CountryName { get; set; }
}
```

### 📁 `Areas/City/Models/CityModel.cs`
```csharp
public class CityModel
{
    public int CityID { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; }
    public string CountryName { get; set; }
}
```

---

## ✅ 2. Controller Actions

### 📁 `CountryController.cs`
```csharp
[Area("Country")]
public class CountryController : Controller
{
    List<CountryModel> countries = new List<CountryModel>
    {
        new CountryModel { CountryID = 1, CountryName = "India" },
        new CountryModel { CountryID = 2, CountryName = "USA" },
        new CountryModel { CountryID = 3, CountryName = "Germany" }
    };
    public IActionResult CountryList()
    {

        return View(countries);
    }
}
```

### 📁 `StateController.cs`
```csharp
[Area("State")]
public class StateController : Controller
{
    List<StateModel> states = new List<StateModel>
    {
        new StateModel { StateID = 1, StateName = "Gujarat", CountryName = "India" },
        new StateModel { StateID = 2, StateName = "California", CountryName = "USA" },
        new StateModel { StateID = 3, StateName = "Bavaria", CountryName = "Germany" }
    };
    public IActionResult StateList()
    {
        return View(states);
    }
}
```

### 📁 `CityController.cs`
```csharp
[Area("City")]
public class CityController : Controller
{
    List<CityModel> cities = new List<CityModel>
    {
        new CityModel { CityID = 1, CityName = "Ahmedabad", StateName = "Gujarat", CountryName = "India" },
        new CityModel { CityID = 2, CityName = "Los Angeles", StateName = "California", CountryName = "USA" },
        new CityModel { CityID = 3, CityName = "Munich", StateName = "Bavaria", CountryName = "Germany" }
    };
    public IActionResult CityList()
    {
        return View(cities);
    }
}
```

---

## ✅ 3. Views

### 📄 `Views/Country/CountryList.cshtml`
```cshtml
@model IEnumerable<AddressBook.Areas.Country.Models.CountryModel>

<h2>Country List</h2>
<table class="table">
    <thead><tr><th>ID</th><th>Name</th></tr></thead>
    <tbody>
        @foreach (var item in Model)
        {
            <tr><td>@item.CountryID</td><td>@item.CountryName</td></tr>
        }
    </tbody>
</table>
```

### 📄 `Views/State/StateList.cshtml`
```cshtml
@model IEnumerable<AddressBook.Areas.State.Models.StateModel>

<h2>State List</h2>
<table class="table">
    <thead><tr><th>ID</th><th>Name</th><th>Country</th></tr></thead>
    <tbody>
        @foreach (var item in Model)
        {
            <tr><td>@item.StateID</td><td>@item.StateName</td><td>@item.CountryName</td></tr>
        }
    </tbody>
</table>
```

### 📄 `Views/City/CityList.cshtml`
```cshtml
@model IEnumerable<AddressBook.Areas.City.Models.CityModel>

<h2>City List</h2>
<table class="table">
    <thead><tr><th>ID</th><th>Name</th><th>State</th><th>Country</th></tr></thead>
    <tbody>
        @foreach (var item in Model)
        {
            <tr>
                <td>@item.CityID</td>
                <td>@item.CityName</td>
                <td>@item.StateName</td>
                <td>@item.CountryName</td>
            </tr>
        }
    </tbody>
</table>
```


