# Deleting a Data Entry in ASP.NET Core MVC

**Prerequisite**: Ensure the Delete Procedure is set up in your database if you dont have then check practical-10.


## Step 1: Implement the `CountryDelete` Action Method in the Controller

Add the following code in your controller to handle the deletion of a Country. This method connects to the database, executes the delete procedure, and then redirects to the Country list page.

```csharp
public IActionResult CountryDelete(int CountryID)
{
    try
    {
        string connectionString = this._configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_Country_Delete";
        command.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
        command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = ex.Message;
        Console.WriteLine(ex.ToString());
    }
    return RedirectToAction("CountryList");
}
```

## Step 2: Add a Delete Link on the List Page

In the list page, add a delete link/button that calls the `CountryDelete` action method. This link will pass the `CountryID` to the method to identify which Country to delete.

```html
<form method="post" asp-area="LOC_Country" asp-controller="Country" asp-action="CountryDelete">
    <input type="hidden" name="CountryID" value="@country["CountryID"]" />
    <button onclick=" return confirm('Sure!! Are you want to delete @country["CountryName"]')" type="submit" class="btn btn-danger">
        <i class="bx bxs-trash"></i>
    </button>
</form>
```

Another way to add a delete link is to use an anchor tag with a `href` attribute that points to the `CountryDelete` action method. This method will be called when the user clicks the link.

```html
<a href="/Country/CountryDelete?CountryID=@dataRow["CountryID"]" class="btn btn-outline-danger btn-xs">f
  <i class="bi bi-x"></i>
</a>

```

using the `asp-route-` attribute:

```html
<a asp-controller="Country" asp-action="CountryDelete" asp-route-CountryID="@dataRow["CountryID"]" class="btn btn-outline-danger btn-xs">
  <i class="bi bi-x"></i>
</a>
```

## Step 3: Test the Delete Operation

Display Error Message in View Page
```csharp
<p class="text-danger bg-danger-subtle mt-3">@TempData["ErrorMessage"]</p>
```
Ensure that the delete functionality works by testing it in the application. Check that the Country is removed from the database and that the list page updates accordingly.
