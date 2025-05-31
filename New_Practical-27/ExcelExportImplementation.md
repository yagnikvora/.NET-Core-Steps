
# 📤 Excel Export Functionality in ASP.NET Core MVC

This guide helps you implement **Excel Export functionality** in an ASP.NET Core MVC project using the `ClosedXML` library.

---

## 📦 Step 1: Install Required Package

Use NuGet Package Manager Console:

```bash
Install-Package ClosedXML
```

---

## 💼 Step 2: Controller Method to Export Data

Add the following method in your `CityController`:

```csharp

public IActionResult ExportToExcel()
{
    DataTable dt = new DataTable();

    string connectionString = _configuration.GetConnectionString("ConnectionString");
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = new SqlCommand("PR_City_SelectAll", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
    }

    using (XLWorkbook wb = new XLWorkbook())
    {
        wb.Worksheets.Add(dt, "CityList");

        using (MemoryStream stream = new MemoryStream())
        {
            wb.SaveAs(stream);
            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "CityList.xlsx");
        }
    }
}

```

---

## 🧩 Step 3: Add Export Button in the View

Place this button at the top of your view:

```html
<a asp-controller="City" asp-action="ExportToExcel" class="btn btn-success mb-3">
    Export to Excel
</a>
```

---

## ✅ Output

- Clicking the **Export to Excel** button generates and downloads an `.xlsx` file.
- Sheet name is "CityList", and it contains all records from the database.
