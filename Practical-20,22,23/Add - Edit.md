# Add-Edit Operation in ASP.NET Core MVC

**Prerequisite**: Procedures for Insert, Update, and Select by Primary Key Operations if you dont have then check Practical - 10


## Step 1: Implement Logic for Insert-Update Operations in the `CountrySave` Action Method

```csharp
[HttpPost]
public IActionResult SaveCountry(CountryModel model)
{
    if (model.CountryID < 0)
    {
        ModelState.AddModelError("CountryID", "A valid Country is required.");
    }

    if (ModelState.IsValid)
    {
        string connectionString = this._configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        if (model.CountryID == 0)
        {
            command.CommandText = "PR_Country_Insert";
        }
        else
        {
            command.CommandText = "PR_Country_Update";
            command.Parameters.Add("@CountryID", SqlDbType.Int).Value = model.CountryID;
        }
        command.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = model.CountryName;
        command.ExecuteNonQuery();
        return RedirectToAction("CountryList");
    }

    return View("AddEditCountry", model);

}

```

## Step 2: Verify Insert Operation

## Step 3: Update Operation (Two Parts)

### Part 1: Fetch and Populate Existing Data in the Text Fields

To retrieve the existing Country data and display it in the form for editing, update the `AddEditCountry` method:

```csharp
public IActionResult AddEditCountry(int CountryID)
{
    string connectionString = this._configuration.GetConnectionString("ConnectionString");


    #region CountryByID

    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    SqlCommand command = connection.CreateCommand();
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "PR_Country_SelectByPK";
    command.Parameters.AddWithValue("@CountryID", CountryID);
    SqlDataReader reader = command.ExecuteReader();
    DataTable table = new DataTable();
    table.Load(reader);
    CountryModel CountryModel = new CountryModel();

    foreach (DataRow dataRow in table.Rows)
    {
        CountryModel.CountryID = Convert.ToInt32(@dataRow["CountryID"]);
        CountryModel.CountryName = @dataRow["CountryName"].ToString();
    }
    #endregion

    return View("AddEditCountry", CountryModel);
}
```

### Part 2: Update the Country Data in the Database

The logic for updating the Country data has already been implemented in the `CountrySave` method.

## Step 4: Add Edit Button with Link in the List Page

```csharp
<a class="btn btn-info" asp-area="LOC_Country" asp-controller="Country" asp-action="AddEditCountry">Add Country</a>
```

## Step 5: Verify Update Operation and do same for State and City table
