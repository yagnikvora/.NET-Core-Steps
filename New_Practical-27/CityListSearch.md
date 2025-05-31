
# City List - jQuery Search Feature (Client-Side Filtering)

This guide shows how to implement a live city name search in your Razor View using **only jQuery**, without modifying the controller or database.

---

## 🔧 Step 1: Add Search Input in the View

Place this input **above the table** in your Razor View:

```html
<input type="text" id="searchBox" class="form-control mb-3" placeholder="Search City Name..." />
```

---

## 🧠 Step 2: Add jQuery Script for Filtering

Place this script **at the bottom** of your Razor View using `@section Scripts`:

```html
@section Scripts {
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#searchBox').on('keyup', function () {
                var value = $(this).val().toLowerCase();
                $('table tbody tr').filter(function () {
                    $(this).toggle($(this).find('td:eq(1)').text().toLowerCase().indexOf(value) > -1);
                });
            });
        });
    </script>
}
```

- `td:eq(1)` targets the **City Name** column (2nd column in the table).
- It toggles rows based on whether the city name contains the typed value.

