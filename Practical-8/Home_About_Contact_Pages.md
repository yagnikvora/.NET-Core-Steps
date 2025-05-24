
# ASP.NET Core MVC: Home, About, Contact Us Pages with Bootstrap

This guide provides full implementation of `Home`, `About`, and `Contact Us` views in an ASP.NET Core MVC project using **Bootstrap 5** and **conventional routing**.

---

## 1. HomeController.cs

Place in `Controllers/HomeController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
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
}
```

---

## 2. Views

### ➤ Views/Home/Index.cshtml

```html
@{
    ViewData["Title"] = "Home";
}
<div class="container mt-5">
    <div class="jumbotron text-center">
        <h1 class="display-4 text-primary">Welcome to Our Website!</h1>
        <p class="lead">Explore our services, learn more about us, or get in touch.</p>
        <hr class="my-4">
        <a class="btn btn-outline-primary btn-lg" href="/Home/About">Learn More</a>
    </div>
</div>
```

---

### ➤ Views/Home/About.cshtml

```html
@{
    ViewData["Title"] = "About Us";
}
<div class="container mt-5">
    <div class="card shadow-sm">
        <div class="card-body">
            <h2 class="text-success">About Our Company</h2>
            <p>We are a passionate team committed to delivering high-quality web solutions for businesses of all sizes.</p>

            <h4 class="mt-4">Our Mission</h4>
            <p>To provide reliable, scalable, and user-friendly software products that drive success.</p>

            <h4>Why Choose Us?</h4>
            <ul class="list-group list-group-flush">
                <li class="list-group-item">✔ Experienced Developers</li>
                <li class="list-group-item">✔ Customer-Centric Approach</li>
                <li class="list-group-item">✔ Timely Delivery</li>
            </ul>
        </div>
    </div>
</div>
```

---

### ➤ Views/Home/ContactUs.cshtml

```html
@{
    ViewData["Title"] = "Contact Us";
}
@{
    ViewData["Title"] = "Contact Us";
}
<div class="container mt-5">
    <div class="card shadow-sm">
        <div class="card-body">
            <h2 class="text-info">Get in Touch</h2>
            <p class="h4">Hello, @ViewBag.VisitorName! If you have any questions, feel free to reach out using the form below.</p>

            <form>
                <div class="mb-3">
                    <label for="name" class="form-label">Your Name</label>
                    <input type="text" class="form-control" id="name" placeholder="John Doe">
                </div>
                <div class="mb-3">
                    <label for="email" class="form-label">Email Address</label>
                    <input type="email" class="form-control" id="email" placeholder="john@example.com">
                </div>
                <div class="mb-3">
                    <label for="message" class="form-label">Your Message</label>
                    <textarea class="form-control" id="message" rows="4" placeholder="Write your message here..."></textarea>
                </div>
                <button type="submit" class="btn btn-info">Send Message</button>
            </form>

            <hr class="my-4">

            <h5>Contact Details</h5>
            <p><strong>Email:</strong> support@example.com</p>
            <p><strong>Phone:</strong> +1 (123) 456-7890</p>
            <p><strong>Address:</strong> 123 Main Street, Your City, Country</p>
        </div>
    </div>
</div>

```

---

## 3. Routing (Program.cs)

Ensure you have the following conventional route in `Program.cs`:

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

## 4. HomeController.cs for Add attribute routing in above practical along with optional parameters and apply ignore route templates functionality.

Place in `Controllers/HomeController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact-us")]
        [Route("contact-us/{name?}")]
        public IActionResult ContactUs(string? name)
        {
            ViewBag.VisitorName = name ?? "Guest";
            return View();
        }
    }
}
```