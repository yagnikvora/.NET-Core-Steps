# 📘 ASP.NET Core MVC AddressBook - Display Data from Controllers

This guide explains how to display data in List pages using controller action methods and models for **Country**, **State**, and **City** tables.

---

## ✅ 1. Controller Actions

### 📁 Add Methods in `CountryController.cs`
```csharp
public IActionResult AddEditCountry(int? CountryID)
{
    var model = new CountryModel();

    if (CountryID != null)
    {
        // Load existing data
        model = countries.Find(c => c.CountryID == CountryID);
    }

    return View(model);
}

[HttpPost]
public IActionResult SaveCountry(StateModel model)
{
    if (ModelState.IsValid)
    {
        // Save to database
    }

    return RedirectToAction("CountryList");
}

}
```

### 📁 Add Methods in  `StateController.cs`

```csharp
public IActionResult AddEditState(int? StateID)
{
    var model = new StateModel();
    if (StateID != null)
    {
        // Load existing data
        model = states.Find(s  => s.StateID == StateID);
    }

    return View(model);
}

[HttpPost]
public IActionResult SaveState(StateModel model)
{
    if (ModelState.IsValid)
    {
        // Save to database
    }

    return RedirectToAction("StateList");
}
```

### 📁 Add Methods in `CityController.cs`
```csharp
 public IActionResult AddEditCity(int? CityID)
 {
     var model = new CityModel();

     if (CityID != null)
     {
         // Load existing data
         model = cities.Find(c => c.CityID == CityID);
     }

     return View(model);
 }

 [HttpPost]
 public IActionResult SaveCity(CityModel model)
 {
     if (ModelState.IsValid)
     {
         // Save to database
     }

     return RedirectToAction("CityList");
 }
```

---

## ✅ 3. Views

### 📄 `Views/Country/AddEditCountry.cshtml`
```cshtml
@model AddressBook.Areas.Country.Models.CountryModel

<h2>@(Model.CountryID == 0 ? "Add Country" : "Edit Country")</h2>

<form asp-controller="Country" asp-action="SaveCountry">
    @Html.HiddenFor(m => m.CountryID)
    <div class="form-group row my-2">
        <label class="col-2" asp-for="CountryName">Country Name<span class="text-danger">*</span></label>
        <input asp-for="CountryName" class="form-control col" maxlength="4" />
        <span asp-validation-for="CountryName" class="text-danger"></span>
    </div>
    
    <div style="margin-left:190px">
        <button type="submit" class=" btn @((Model?.CountryID > 0) ?  "btn-warning" :  "btn-primary")">@((Model?.CountryID > 0) ? "Edit" : "Add")</button>
        <button type="reset" class="btn btn-secondary">Reset</button>
        <a class="btn btn-success" asp-controller="Country" asp-action="CountryList">Back</a>
    </div>
</form>

```

### 📄 `Views/State/AddEditState.cshtml`
```cshtml
@model AddressBook.Areas.State.Models.StateModel

<h2>@(Model.StateID == 0 ? "Add State" : "Edit State")</h2>

<form asp-controller="State" asp-action="SaveState">
    @Html.HiddenFor(m => m.StateID)

    <div class="form-group row my-2">
        <label class="col-2" asp-for="StateName">State Name<span class="text-danger">*</span></label>
        <input asp-for="StateName" class="form-control col" maxlength="4" />
        <span asp-validation-for="StateName" class="text-danger"></span>
    </div>

    <div class="form-group row my-2">
        <label class="col-2" asp-for="CountryID">Country <span class="text-danger">*</span></label>
        <select class="form-control col" asp-for="CountryID">
            <option value="" selected disabled>Select Country</option>
            <option value="">India</option>
            <option value="">America</option>
            <option value="">England</option>
        </select>
        <span asp-validation-for="CountryID" class="text-danger"></span>
    </div>
    
    <div style="margin-left:190px">
        <button type="submit" class=" btn @((Model?.StateID > 0) ?  "btn-warning" :  "btn-primary")">@((Model?.StateID > 0) ? "Edit" : "Add")</button>
        <button type="reset" class="btn btn-secondary">Reset</button>
        <a class="btn btn-success" asp-controller="State" asp-action="StateList">Back</a>
    </div>
</form>

```

### 📄 `Views/City/AddEditCity.cshtml`
```cshtml
@model AddressBook.Areas.City.Models.CityModel

<h2>@(Model.CityID == 0 ? "Add City" : "Edit City")</h2>

<form asp-controller="City" asp-action="SaveCity">
    @Html.HiddenFor(m => m.CityID)
    <div class="form-group row my-2">
        <label class="col-2" asp-for="CityName">Bill Number<span class="text-danger">*</span></label>
        <input asp-for="CityName" class="form-control col" maxlength="4" />
        <span asp-validation-for="CityName" class="text-danger"></span>
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="CountryID">Country <span class="text-danger">*</span></label>
        <select class="form-control col" asp-for="CountryID" >
            <option value="" selected disabled>Select Country</option>
            <option value="">India</option>
            <option value="">America</option>
            <option value="">England</option>
        </select>
        <span asp-validation-for="CountryID" class="text-danger"></span>
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="StateID">State <span class="text-danger">*</span></label>
        <select class="form-control col" asp-for="StateID" >
            <option value="" selected disabled>Select State</option>
            <option value="">Gujarat</option>
            <option value="">Washington</option>
            <option value="">London</option>
        </select>
        <span asp-validation-for="StateID" class="text-danger"></span>
    </div>
    <div style="margin-left:190px">
        <button type="submit" class=" btn @((Model?.CityID > 0) ?  "btn-warning" :  "btn-primary")">@((Model?.CityID > 0) ? "Edit" : "Add")</button>
        <button type="reset" class="btn btn-secondary">Reset</button>
        <a class="btn btn-success" asp-controller="City" asp-action="CityList">Back</a>
    </div>
</form>

```


