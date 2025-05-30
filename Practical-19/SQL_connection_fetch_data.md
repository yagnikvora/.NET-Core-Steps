# Establishing SQL Connection & Displaying Data in ASP.NET Core MVC

**Prerequisite**: Ensure SQL Server is installed and the `SelectAll` stored procedure is created if you dont create stored procedure then check out Practical 10.



## Step 1: Add Static Data to SQL Server

Insert static data into your SQL Server database in tables.

## Step 2: Configure the Connection String in `appsettings.json`

### For Windows Users:

Add the connection string for your SQL Server database in the `appsettings.json` file as shown below:

```json
"ConnectionStrings": {
    "ConnectionString": "Data Source=SQL Server Name;Initial Catalog=DatabaseName;Integrated Security=true;"
}
```

**Example:**

```json
"ConnectionStrings": {
    "ConnectionString": "Data Source=LAPTOP-LBMAFD6U\\SQLEXPRESS;Initial Catalog=StudentMaster;Integrated Security=true;"
}
```

### For Mac Users:

For Mac users, the connection string should include the user ID and password:

```json
"ConnectionStrings": {
    "ConnectionString": "Data Source=SQL Server Name;Initial Catalog=DatabaseName;User id=userID; password=Password;"
}
```

**Example:**

```json
"ConnectionStrings": {
    "ConnectionString": "Data Source=localhost;Initial Catalog=Practice;User id=SA; password=MyStrongPass123;"
}
```

## Step 3: Set Up the Configuration Variable in the Controller

In your controller, declare a configuration variable and initialize it using the constructor. This will allow you to access the connection string from the configuration.

```csharp
private IConfiguration configuration;

public CountryController(IConfiguration _configuration)
{
    configuration = _configuration;
}
```

## Step 4: Install the `System.Data.SqlClient` Package

Install the `System.Data.SqlClient` package from the NuGet Package Manager to enable SQL Server connectivity.

- Navigate to **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**.
- Ensure the project is not running during the installation.

## Step 5: Write Logic to Fetch Data in the List Page Action Method

In the action method for your list page, add the following logic to fetch data from the SQL Server database:

```csharp
string connectionString = this.Configuration.GetConnectionString("ConnectionString");
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();
SqlCommand command = connection.CreateCommand();
command.CommandType = CommandType.StoredProcedure;
command.CommandText = "PR_Country_SelectAll";
SqlDataReader reader = command.ExecuteReader();
DataTable table = new DataTable();
table.Load(reader);
return View(table);
```

## Step 6: Display the Data in the View

In your view page, import the `DataTable` and use a `foreach` loop to iterate through the data and display it:

```csharp

@using System.Data
@model DataTable

<a class="btn btn-info" asp-area="LOC_Country" asp-controller="Country" asp-action="AddEditCountry">Add Country</a>
<a as></a>
<table class="table mt-3">
    <thead>
        <tr>
            <th>Country ID</th> 
            <th>Country Name</th>
            <th colspan="2">Actions</th>
        </tr>
    </thead>
    <tbody>
        @foreach (DataRow country in Model.Rows)
        {
            <tr>
                <td>@country["CountryID"]</td> 
                <td>@country["CountryName"]</td>
                <td>
                    <a asp-area="LOC_Country" asp-controller="Country" asp-action="AddEditCountry" asp-route-id="@country["CountryID"]">
                        <button type="submit" class="btn btn-warning">
                            <i class="bx bx-edit"></i>
                        </button>
                    </a>
                </td>
                <td>
                    <form method="post" asp-area="LOC_Country" asp-controller="Country" asp-action="CountryDelete">
                        <input type="hidden" name="CountryID" value="@country["CountryID"]" />
                        <button onclick=" return confirm('Sure!! Are you want to delete @country["CountryName"]')" type="submit" class="btn btn-danger">
                            <i class="bx bxs-trash"></i>
                        </button>
                    </form>
                </td>
            </tr>
        }
    </tbody>
</table>
```
