# 💼 Job Inquiry Form (ASP.NET Core MVC)

This form collects job inquiry details using **Strongly Typed HTML Helpers** and **Bootstrap 5** styling. It also displays a **thank-you message** on the same page after successful form submission.


## 🧾 Model: `JobInquiry.cs`

```csharp
public class JobInquiry
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Position { get; set; }

    public string Message { get; set; }
}
```

---

## 🧩 Controller: `JobInquiryController.cs`

```csharp
public class JobInquiryController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(JobInquiry model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Submitted = true;
            ModelState.Clear(); // Reset form
            return View();
        }

        return View(model);
    }
}
```

---

## 🖥️ View: `Create.cshtml`

```razor
@model YourNamespace.Models.JobInquiry
@{
    ViewData["Title"] = "💼 Job Inquiry Form";
}

<div class="">
    <div class="d-flex align-items-center mb-4 text-success">
        <h2 class="mb-0 me-3">💼 Job Inquiry Form</h2>
        <h5 class="mb-0 mt-2 text-muted">Using Strongly Typed HTML Helpers</h5>
    </div>

    <form asp-action="Create" method="post" class="row g-3 bg-light p-4 rounded shadow">
        <div class="col-md-6">
            @Html.LabelFor(m => m.FullName)
            @Html.TextBoxFor(m => m.FullName, new { @class = "form-control" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Email)
            @Html.TextBoxFor(m => m.Email, new { @class = "form-control", type = "email" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Phone)
            @Html.TextBoxFor(m => m.Phone, new { @class = "form-control", type = "tel" })
        </div>
        <div class="col-md-6">
            @Html.LabelFor(m => m.Position)
            @Html.TextBoxFor(m => m.Position, new { @class = "form-control" })
        </div>
        <div class="col-12">
            @Html.LabelFor(m => m.Message)
            @Html.TextAreaFor(m => m.Message, new { @class = "form-control", rows = 3 })
        </div>
        <div class="col-12">
            <button type="submit" class="btn btn-success">Submit Inquiry</button>
        </div>
    </form>

    @if (ViewBag.Submitted != null && ViewBag.Submitted == true)
    {
        <div class="alert alert-success mt-4 shadow-sm">
            <h4 class="alert-heading">✅ Thank You!</h4>
            <p>Your job inquiry has been submitted successfully.</p>
            <hr />
            <p class="mb-0">We'll contact you soon regarding your interest.</p>
        </div>
    }
</div>

@section Scripts {
    @await Html.PartialAsync("_ValidationScriptsPartial")
}
```
