### Step 1: Create `UrlEncryptor` Class
Create a new folder named `Helper` and add the `UrlEncryptor` class inside it. The class contains two methods: `Encrypt()` and `Decrypt()`.

```csharp
public static class UrlEncryptor
{
    private static readonly string EncryptionKey = "pjsGLNYrMqU6wny4"; // Change this key

    // Method to encrypt a string
    public static string Encrypt(string text)
    {
        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = new byte[16]; // Initialize the IV to 0s

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(text);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    // Method to decrypt an encrypted string
    public static string Decrypt(string encryptedText)
    {
        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = new byte[16]; // Initialize the IV to 0s

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }
    }
}
```

### Step 2: Encrypt URL Parameter
When displaying data, you can encrypt URL parameters (e.g., `CityID` or `ProductID`) before including them in a link. This is done by calling `UrlEncryptor.Encrypt()`.

```csharp
@using System.Data
@using AddressBook.Helper
@model DataTable

<a class="btn btn-info" asp-area="LOC_City" asp-controller="City" asp-action="AddEditCity">Add City</a>
<p class="text-danger bg-danger-subtle mt-3">@TempData["ErrorMessage"]</p>
<a as></a>
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
                    <a asp-area="LOC_City" asp-controller="City" asp-action="AddEditCity" asp-route-CityID="@UrlEncryptor.Encrypt(@country["CityID"].ToString())">
                        <button type="submit" class="btn btn-warning">
                            <i class="bx bx-edit"></i>
                        </button>
                    </a>
                </td>
                <td>
                    <form method="post" asp-area="LOC_City" asp-controller="City" asp-action="CityDelete">
                        <input type="hidden" name="CityID" value="@UrlEncryptor.Encrypt(@country["CityID"].ToString())" />
                        <button onclick=" return confirm('Sure!! Are you want to delete @country["CityName"]')" type="submit" class="btn btn-danger">
                            <i class="bx bxs-trash"></i>
                        </button>
                    </form>
                </td>
            </tr>
        }
    </tbody>
</table>
```

### Step 3: Decrypt URL Parameter
When receiving the `CityID` parameter in your action method, decrypt it using `UrlEncryptor.Decrypt()`.

```csharp
#region Delete
public IActionResult CityDelete(string CityID)
{
    int decryptedCityID = Convert.ToInt32(UrlEncryptor.Decrypt(CityID.ToString()));

    try
    {
        string connectionString = this._configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_City_Delete";
        command.Parameters.Add("@CityID", SqlDbType.Int).Value = decryptedCityID;
        command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = ex.Message;
        Console.WriteLine(ex.ToString());
    }
    return RedirectToAction("CityList");
}
#endregion

  #region Add
  public IActionResult AddEditCity(string? CityID)
 {
     string connectionString = this._configuration.GetConnectionString("ConnectionString");
     int? decryptedCityID = 0;

     // Decrypt only if CityID is not null or empty
     if (!string.IsNullOrEmpty(CityID))
     {
         string decryptedCityIDString = UrlEncryptor.Decrypt(CityID); // Decrypt the encrypted CityID
         decryptedCityID = int.Parse(decryptedCityIDString); // Convert decrypted string to integer
     }
     CountryDropDown();
     StateDropDown();
     #region CityByID

     SqlConnection connection = new SqlConnection(connectionString);
     connection.Open();
     SqlCommand command = connection.CreateCommand();
     command.CommandType = CommandType.StoredProcedure;
     command.CommandText = "PR_City_SelectByPK";
     command.Parameters.AddWithValue("@CityID", decryptedCityID);
     SqlDataReader reader = command.ExecuteReader();
     DataTable table = new DataTable();
     table.Load(reader);
     CityModel stateModel = new CityModel();

     foreach (DataRow dataRow in table.Rows)
     {
         stateModel.CityID = Convert.ToInt32(@dataRow["CityID"]);
         stateModel.CountryID = Convert.ToInt32(@dataRow["CountryID"]);
         stateModel.CityName = @dataRow["CityName"].ToString();
         stateModel.StateID = Convert.ToInt32(@dataRow["StateID"]);
         stateModel.StateName = @dataRow["StateName"].ToString();
         stateModel.CountryName = @dataRow["CountryName"].ToString();
     }
     #endregion

     return View("AddEditCity", stateModel);
 }
  #endregion
```

