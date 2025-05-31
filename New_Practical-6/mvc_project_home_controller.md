# Creating Project, Adding Home Controller and Views

This guide shows how to create a controller, add views, and set up basic navigation.

---

## Add Home Controller

### 1. Right-click on **Controllers** folder > Add > Controller
- Choose **MVC Controller - Empty**
- Name it **HomeController.cs**

### 2. Add Action Methods
```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }
}
```

---

## Add Views

### 1. Right-click on **Views** > Add Folder > Name it **Home**

### 2. Inside `Views/Home`, add 3 views:
- `Index.cshtml`
- `About.cshtml`
- `ContactUs.cshtml`

Each view can have simple HTML like:
```html
<h2>Welcome to Home Page</h2>
```

---

## Add Navigation
Edit the layout file (`Views/Shared/_Layout.cshtml`) and add navigation links:
```html
<ul class="navbar-nav">
    <li class="nav-item">
        <a class="nav-link" asp-controller="Home" asp-action="Index">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" asp-controller="Home" asp-action="About">About</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" asp-controller="Home" asp-action="ContactUs">Contact Us</a>
    </li>
</ul>
```
