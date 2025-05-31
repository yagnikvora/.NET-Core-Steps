
# ASP.NET Core MVC Custom Alert Tag Helpers

This guide demonstrates how to create **Custom Tag Helpers** in ASP.NET Core MVC for sending mail.

---

## 📁 Folder Structure

```
YourProject/
├── TagHelpers/
│   └── EmailTagHelper.cs
├── Views/
│   ├── _ViewImports.cshtml
│   └── YourViews.cshtml
```

---

## ✅ Step-by-Step Implementation

### 1. Create `TagHelpers` Folder and Add `EmailTagHelper.cs`

```csharp
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace YourNamespace.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; } = "";
        public string DisplayText { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{Address}");
            output.Content.SetContent(string.IsNullOrEmpty(DisplayText) ? Address : DisplayText);
        }
    }
}
```

---

### 2. Register Tag Helper in `_ViewImports.cshtml`

```csharp
@addTagHelper *, YourProjectAssemblyName
```

> Replace `YourProjectAssemblyName` with the actual assembly name of your project (usually the project name).

---

### 3. Use Custom Alert Tag in Views

```csharp
<email address="owner@example.com" display-text="Contact Project Owner"></email>
```

This will render as 

```csharp
<a href="mailto:owner@example.com">Contact Project Owner</a>

```

```

> You can place these in any view where you want to display alerts.
