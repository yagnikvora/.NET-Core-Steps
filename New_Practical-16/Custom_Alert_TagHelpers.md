
# ASP.NET Core MVC Custom Alert Tag Helpers

This guide demonstrates how to create **Custom Tag Helpers** in ASP.NET Core MVC for displaying alerts (Success, Warning, Info).

---

## 📁 Folder Structure

```
YourProject/
├── TagHelpers/
│   └── AlertTagHelper.cs
├── Views/
│   ├── _ViewImports.cshtml
│   └── YourViews.cshtml
```

---

## ✅ Step-by-Step Implementation

### 1. Create `TagHelpers` Folder and Add `AlertTagHelper.cs`

```csharp
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace YourNamespace.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {
        public string Type { get; set; } = "info";
        public string Message { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var alertClass = Type switch
            {
                "success" => "alert-success",
                "warning" => "alert-warning",
                "info" => "alert-info",
                _ => "alert-secondary"
            };

            output.TagName = "div";
            output.Attributes.SetAttribute("class", $"alert {alertClass} alert-dismissible fade show");
            output.Content.SetHtmlContent($@"
                {Message}
                <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>
            ");
        }
    }
}
```

---

### 2. Register Tag Helper in `_ViewImports.cshtml`

```cshtml
@addTagHelper *, YourProjectAssemblyName
```

> Replace `YourProjectAssemblyName` with the actual assembly name of your project (usually the project name).

---

### 3. Use Custom Alert Tag in Views

```csharp
<alert type="success" message="Operation completed successfully."></alert>
// <alert type="warning" message="Please check your input."></alert>
// <alert type="info" message="This is some information."></alert>
```
This will render as

```csharp
<div class="alert alert-success alert-dismissible fade show">
    Operation completed successfully.
    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close" fdprocessedid="5gmqkl"></button>
</div>
```

> You can place these in any view where you want to display alerts.
