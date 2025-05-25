# 📄 Resume Upload and Display in ASP.NET Core MVC

This guide walks you through creating a resume upload form in **ASP.NET Core MVC** that allows the user to upload a resume and display the **PDF inline** on the same page.

---

## ✅ Step 1: Create the Model

```csharp
public class ResumeUploadModel
{
    public IFormFile ResumeFile { get; set; }
    public string UploadedFilePath { get; set; }
}
```

---

## ✅ Step 2: Create the Controller

```csharp
public class ResumeController : Controller
{
    private readonly IWebHostEnvironment _env;

    public ResumeController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(ResumeUploadModel model)
    {
        if (model.ResumeFile != null && model.ResumeFile.Length > 0)
        {
            // Check file extension
            var ext = Path.GetExtension(model.ResumeFile.FileName).ToLower();
            if (ext != ".pdf")
            {
                ModelState.AddModelError("ResumeFile", "Only PDF files are allowed.");
                return View(model);
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "resumes");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Path.GetFileName(model.ResumeFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.ResumeFile.CopyToAsync(stream);
            }

            model.UploadedFilePath = "/resumes/" + fileName;
        }

        return View(model);
    }
}
```

---

## ✅ Step 3: Create the View (`Upload.cshtml`)

```razor
@model ResumeUploadModel
@{
    ViewData["Title"] = "Upload Resume";
}

<div class="container mt-5">
    <h2 class="mb-4">📄 Upload Your Resume</h2>

    <form asp-action="Upload" method="post" enctype="multipart/form-data" class="bg-light p-4 shadow rounded">
        <div class="mb-3">
            <label asp-for="ResumeFile" class="form-label">Select Resume (PDF only)</label>
            <input asp-for="ResumeFile" class="form-control" type="file" accept=".pdf" />
        </div>
        <button type="submit" class="btn btn-primary">Upload</button>
    </form>

    @if (!string.IsNullOrEmpty(Model?.UploadedFilePath))
    {
        <div class="mt-4">
            <h5>📝 Preview:</h5>
            <iframe src="@Model.UploadedFilePath" width="100%" height="600px" class="border rounded shadow"></iframe>
        </div>
    }
</div>
```

---

## ✅ Step 4: Enable Static Files

In `Program.cs` (or `Startup.cs`), make sure this line exists:

```csharp
app.UseStaticFiles(); // Required to serve uploaded resumes
```

---

## ✅ Step 5: Create the Resume Folder

Make sure `wwwroot/resumes/` folder exists. You can also let the app create it automatically as in the controller.

---

## 🎯 Final Output

- User selects a PDF resume file and uploads it
- The uploaded PDF is shown below the form on the same page
- Only PDF files are accepted

---