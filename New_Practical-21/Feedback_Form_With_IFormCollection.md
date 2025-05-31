
# Feedback Form Using IFormCollection - ASP.NET Core MVC

This file demonstrates how to create an Feedback Form using **IFormCollection** in ASP.NET Core MVC.

---

## Step 1: Create Controller FeedbackController.cs


```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace YourNamespace.Controllers
{
    public class FeedbackController : Controller
    {
        // Display form
        public IActionResult Index()
        {
            return View();
        }

        // Handle form post using FormCollection
        [HttpPost]
        public IActionResult SubmitFeedback(FormCollection form)
        {
            ViewBag.Id = form["Id"];
            ViewBag.Name = form["Name"];
            ViewBag.Email = form["Email"];
            ViewBag.Subject = form["Subject"];
            ViewBag.Observation = form["Observation"];

            return View("FeedbackDetails");
        }
    }
}

```
---

## Step 2: View (`Index.cshtml`)

```html
@{
    ViewData["Title"] = "Feedback Form";
}

<h2 class="text-primary">Feedback Form</h2>

<form asp-action="SubmitFeedback" method="post" class="mt-4">
    <div class="form-group row my-2">
        <label for="Id" class="col-2 fw-bold">ID</label>
        <input type="number" class="form-control col" name="Id" required />
    </div>
    <div class="form-group row my-2">
        <label class="col-2 fw-bold" for="Name">Name</label>
        <input type="text" class="form-control col" name="Name" required />
    </div>
    <div class="form-group row my-2">
        <label class="col-2 fw-bold" for="Email">Email</label>
        <input type="email" class="form-control col" name="Email" required />
    </div>
    <div class="form-group row my-2">
        <label class="col-2 fw-bold" for="Subject">Subject</label>
        <input type="text" class="form-control col" name="Subject" required />
    </div>
    <div class="form-group row my-2">
        <label class="col-2 fw-bold" for="Observation">Observation</label>
        <textarea class="form-control col" name="Observation" rows="3" required></textarea>
    </div>
    <button type="submit" class="btn btn-primary mt-2">Submit</button>
</form>

```
## Step 3: View (`FeedbackDetails.cshtml`) for display the data
```csharp
@{
    ViewData["Title"] = "Feedback Details";
}

<h2 class="text-success">Feedback Submitted</h2>

<table class="table table-bordered mt-4">
    <tr>
        <th>ID</th>
        <td>@ViewBag.Id</td>
    </tr>
    <tr>
        <th>Name</th>
        <td>@ViewBag.Name</td>
    </tr>
    <tr>
        <th>Email</th>
        <td>@ViewBag.Email</td>
    </tr>
    <tr>
        <th>Subject</th>
        <td>@ViewBag.Subject</td>
    </tr>
    <tr>
        <th>Observation</th>
        <td>@ViewBag.Observation</td>
    </tr>
</table>

```
## Step 4: Add Route in _Layout.cshtml
```csharp
<li>
    <a asp-controller="Home" asp-action="FeedBackForm">
        <i class="bi bi-circle"></i><span>FeedBack form</span>
    </a>
</li>

```

