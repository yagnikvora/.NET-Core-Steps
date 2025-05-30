
# City CRUD Operations in ASP.NET Core MVC

This markdown document explains the full CRUD (Create, Read, Update, Delete) operation for the **City** module in an ASP.NET Core MVC project. It includes Model, Controller, Views (Add/Edit, List), and stored procedure interaction.

---

## 1. City Model

```csharp
public class CityModel
{
    public int CityID { get; set; }

    [Required(ErrorMessage = "City Name is required")]
    [StringLength(100, ErrorMessage = "City Name can't exceed 100 characters")]
    public string CityName { get; set; }

    [Required(ErrorMessage = "State is required")]
    public int StateID { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public int CountryID { get; set; }

    public string StateName { get; set; }
    public string CountryName { get; set; }
}
```

---

## 2. City Controller

### Get All Cities
```csharp
public IActionResult CityList()
{
    string connectionString = this._configuration.GetConnectionString("ConnectionString");
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    SqlCommand command = connection.CreateCommand();
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "PR_City_SelectAll";
    SqlDataReader reader = command.ExecuteReader();
    DataTable table = new DataTable();
    table.Load(reader);
    return View(table);
}
```

### Add or Edit City
```csharp
public IActionResult AddEditCity(string? CityID)
{
    int? decryptedCityID = 0;
    if (!string.IsNullOrEmpty(CityID))
    {
        decryptedCityID = int.Parse(UrlEncryptor.Decrypt(CityID));
    }
    CountryDropDown();
    StateDropDown();

    SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
    connection.Open();
    SqlCommand command = new SqlCommand("PR_City_SelectByPK", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.AddWithValue("@CityID", decryptedCityID);
    SqlDataReader reader = command.ExecuteReader();
    DataTable table = new DataTable();
    table.Load(reader);

    CityModel stateModel = new CityModel();
    foreach (DataRow dataRow in table.Rows)
    {
        stateModel.CityID = Convert.ToInt32(dataRow["CityID"]);
        stateModel.CityName = dataRow["CityName"].ToString();
        stateModel.StateID = Convert.ToInt32(dataRow["StateID"]);
        stateModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
        stateModel.StateName = dataRow["StateName"].ToString();
        stateModel.CountryName = dataRow["CountryName"].ToString();
    }
    return View("AddEditCity", stateModel);
}
```

### Save (Insert/Update) City
```csharp
[HttpPost]
public IActionResult SaveCity(CityModel model)
{
    ModelState.Remove("CityID");
    ModelState.Remove("CountryName");
    ModelState.Remove("StateName");

    if (ModelState.IsValid)
    {
        SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = model.CityID == 0 ? "PR_City_Insert" : "PR_City_Update";

        if (model.CityID != 0)
        {
            command.Parameters.AddWithValue("@CityID", model.CityID);
        }

        command.Parameters.AddWithValue("@CityName", model.CityName);
        command.Parameters.AddWithValue("@CountryID", model.CountryID);
        command.Parameters.AddWithValue("@StateID", model.StateID);

        command.ExecuteNonQuery();
        return RedirectToAction("CityList");
    }

    CountryDropDown();
    StateDropDown();
    return View("AddEditCity", model);
}
```

### Delete City
```csharp
public IActionResult CityDelete(string CityID)
{
    int decryptedCityID = Convert.ToInt32(UrlEncryptor.Decrypt(CityID));
    try
    {
        SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
        connection.Open();
        SqlCommand command = new SqlCommand("PR_City_Delete", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CityID", decryptedCityID);
        command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = ex.Message;
    }
    return RedirectToAction("CityList");
}
```

### Country and State Dropdown
```csharp
public void CountryDropDown()
{
    string connectionString = this._configuration.GetConnectionString("ConnectionString");
    SqlConnection connection1 = new SqlConnection(connectionString);
    connection1.Open();
    SqlCommand command1 = connection1.CreateCommand();
    command1.CommandType = System.Data.CommandType.StoredProcedure;
    command1.CommandText = "PR_Country_DropDown";
    SqlDataReader reader1 = command1.ExecuteReader();
    DataTable dataTable1 = new DataTable();
    dataTable1.Load(reader1);
    List<CountryDropDownModel> countryList = new List<CountryDropDownModel>();
    foreach (DataRow data in dataTable1.Rows)
    {
        CountryDropDownModel countryDropDownModel = new CountryDropDownModel();
        countryDropDownModel.CountryID = Convert.ToInt32(data["CountryID"]);
        countryDropDownModel.CountryName = data["CountryName"].ToString();
        countryList.Add(countryDropDownModel);
    }
    ViewBag.CountryList = countryList;
}

public void StateDropDown()
{
    string connectionString = this._configuration.GetConnectionString("ConnectionString");
    SqlConnection connection1 = new SqlConnection(connectionString);
    connection1.Open();
    SqlCommand command1 = connection1.CreateCommand();
    command1.CommandType = System.Data.CommandType.StoredProcedure;
    command1.CommandText = "PR_State_DropDown";
    SqlDataReader reader1 = command1.ExecuteReader();
    DataTable dataTable1 = new DataTable();
    dataTable1.Load(reader1);
    List<StateDropDownModel> stateListList = new List<StateDropDownModel>();
    foreach (DataRow data in dataTable1.Rows)
    {
        StateDropDownModel stateListDropDownModel = new StateDropDownModel();
        stateListDropDownModel.StateID = Convert.ToInt32(data["StateID"]);
        stateListDropDownModel.StateName = data["StateName"].ToString();
        stateListList.Add(stateListDropDownModel);
    }
    ViewBag.StateList = stateListList;
}
```
---
### Excel Import function

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

## 3. AddEditCity.cshtml View

```csharp
@model AddressBook.Areas.City.Models.CityModel
<h2>@(Model.CityID == 0 ? "Add City" : "Edit City")</h2>
<form asp-controller="City" asp-action="SaveCity">
    @Html.HiddenFor(m => m.CityID)
    <div class="form-group row my-2">
        <label class="col-2" asp-for="CityName">City Name<span class="text-danger">*</span></label>
        <input asp-for="CityName" class="form-control col" />
        <span asp-validation-for="CityName" class="text-danger"></span>
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="CountryID">Country <span class="text-danger">*</span></label>
        <select class="form-control col" asp-for="CountryID">
            <option value="" selected disabled>Select Country</option>
            @foreach (var country in ViewBag.CountryList)
            {
                <option value="@country.CountryID">@country.CountryName</option>
            }
        </select>
        <span asp-validation-for="CountryID" class="text-danger"></span>
    </div>
    <div class="form-group row my-2">
        <label class="col-2" asp-for="StateID">State <span class="text-danger">*</span></label>
        <select class="form-control col" asp-for="StateID">
            <option value="" selected disabled>Select State</option>
            @foreach (var state in ViewBag.StateList)
            {
                <option value="@state.StateID">@state.StateName</option>
            }
        </select>
        <span asp-validation-for="StateID" class="text-danger"></span>
    </div>
    <div style="margin-left:190px">
        <button type="submit" class="btn @(Model?.CityID > 0 ? "btn-warning" : "btn-primary")">
            @(Model?.CityID > 0 ? "Edit" : "Add")
        </button>
        <button type="reset" class="btn btn-secondary">Reset</button>
        <a class="btn btn-success" asp-controller="City" asp-action="CityList">Back</a>
    </div>
</form>
```

---

## 4. CityList.cshtml View

```csharp
@using System.Data
@using AddressBook.Helper
@model DataTable

<div class="row">
    <a class="btn btn-info col-2" asp-controller="City" asp-action="AddEditCity">Add City</a>
    <div class="col-1"></div>
    <a asp-controller="City" asp-action="ExportToExcel" class="btn btn-success col-2">Export to Excel</a>
</div>
<p class="text-danger bg-danger-subtle mt-3">@TempData["ErrorMessage"]</p>
<input type="text" id="searchBox" class="form-control mb-3" placeholder="Search City Name..." />

<table class="table mt-3">
    <thead>
        <tr>
            <th>City ID</th>
            <th>City Name</th>
            <th>State Name</th>
            <th>Country Name</th>
            <th colspan="2">Actions</th>
        </tr>
    </thead>
    <tbody>
        @foreach (DataRow country in Model.Rows)
        {
            <tr>
                <td>@country["CityID"]</td>
                <td>@country["CityName"]</td>
                <td>@country["StateName"]</td>
                <td>@country["CountryName"]</td>
                <td>
                    <a asp-controller="City" asp-action="AddEditCity" asp-route-CityID="@UrlEncryptor.Encrypt(country["CityID"].ToString())">
                        <button type="submit" class="btn btn-warning">
                            <i class="bx bx-edit"></i>
                        </button>
                    </a>
                </td>
                <td>
                    <form method="post" asp-controller="City" asp-action="CityDelete">
                        <input type="hidden" name="CityID" value="@UrlEncryptor.Encrypt(country["CityID"].ToString())" />
                        <button onclick="return confirm('Sure!! Are you want to delete @country["CityName"]')" type="submit" class="btn btn-danger">
                            <i class="bx bxs-trash"></i>
                        </button>
                    </form>
                </td>
            </tr>
        }
    </tbody>
</table>

@section Scripts {
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

---

This completes the **City CRUD Operation** using ASP.NET Core MVC with SQL Server stored procedures. Share and explain each section with juniors using this guide.
