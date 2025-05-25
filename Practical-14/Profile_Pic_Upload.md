# 📄 Resume Upload and Display in ASP.NET Core MVC

This guide walks you through creating a profile picture upload form in **ASP.NET Core MVC** that allows the user to upload a Picture and display the **Imange inline** on the same page.

---

## ✅ Step 1: Create the Model

```csharp
public class ProfilePictureModel
{
    public IFormFile ProfileImage { get; set; }
    public string ImagePath { get; set; }
}
```

---

## ✅ Step 2: Create the Controller

```csharp
public class ProfileController : Controller
{
    private readonly IWebHostEnvironment _env;

    public ProfileController(IWebHostEnvironment env)
    {
        _env = env;
    }


    public IActionResult ProfileUpload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProfileUpload(ProfilePictureModel model)
    {
        if (model.ProfileImage != null && model.ProfileImage.Length > 0)
        {
            var ext = Path.GetExtension(model.ProfileImage.FileName).ToLower();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(ext))
            {
                ModelState.AddModelError("ProfileImage", "Only JPG, JPEG, and PNG files are allowed.");
                return View(model);
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "profilepics");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + ext;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.ProfileImage.CopyToAsync(stream);
            }

            model.ImagePath = "/profilepics/" + fileName;
        }

        return View(model);
    }
}
```

---

## ✅ Step 3: Create the View (`ProfileUpload.cshtml`)

```razor
@model ProfilePictureModel
@{
    ViewData["Title"] = "Upload Profile Picture";
}

<div class="container mt-5">
    <h2 class="mb-4">🖼️ Upload Your Profile Picture</h2>

    <form asp-action="ProfileUpload" method="post" enctype="multipart/form-data" class="bg-light p-4 shadow rounded">
        <div class="mb-3">
            <label asp-for="ProfileImage" class="form-label">Select Image (JPG, PNG)</label>
            <input asp-for="ProfileImage" type="file" class="form-control" accept=".jpg,.jpeg,.png" />
        </div>
        <button type="submit" class="btn btn-primary">Upload</button>
    </form>

    @if (!string.IsNullOrEmpty(Model?.ImagePath))
    {
        <div class="mt-4">
            <h5>👤 Preview:</h5>
            <img src="@Model.ImagePath" class="img-thumbnail rounded-circle shadow" width="200" />
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
