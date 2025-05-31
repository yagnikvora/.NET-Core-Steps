
# ASP.NET Core MVC Layout Page with Header and Footer

This guide shows how to set up a master layout page with header and footer partial views in an ASP.NET Core MVC project.

## 📁 Project Structure

```
Views/
│
├── Shared/
│   ├── _Layout.cshtml
│   ├── _Header.cshtml
│   ├── _Footer.cshtml
├── Home/
│   └── Index.cshtml

```

## ✅ Steps

### 1. Create Layout Page: `_Layout.cshtml`

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>@ViewData["Title"] - My MVC App</title>
    <link rel="stylesheet" href="~/css/site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    //All remaining links are as it is
</head>
<body>
    <div class="container">
        @Html.Partial("_Header")

        <main role="main" class="py-4">
            @RenderBody()
        </main>

        @Html.Partial("_Footer")
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    //All remaining scripts are as it is
    <script src="~/js/site.js"></script>
</body>
</html>
```

### 2. Create `_Header.cshtml` in Shared Folder

```html
<header class="bg-light py-3 mb-4 border-bottom">
    <div class="container d-flex flex-wrap justify-content-center">
        <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
            <span class="fs-4">My MVC App</span>
        </a>
        <ul class="nav nav-pills">
            <li class="nav-item"><a href="/" class="nav-link active">Home</a></li>
            <li class="nav-item"><a href="/About" class="nav-link">About</a></li>
            <li class="nav-item"><a href="/Contact" class="nav-link">Contact</a></li>
        </ul>
    </div>
</header>
```

### 3. Create `_Footer.cshtml` in Shared Folder

```html
<footer class="bg-light text-center text-lg-start mt-4 py-3 border-top">
    <div class="text-center p-3">
        © @DateTime.Now.Year - My MVC App
    </div>
</footer>
```

### 4. Reference Layout in Views

```cshtml
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<h2>Welcome to Home Page</h2>
```