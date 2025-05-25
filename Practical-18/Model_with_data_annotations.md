# 🛡️ AddressBook Models with Data Annotations

This document includes model definitions for **Country**, **State**, and **City** with validation attributes using **Data Annotations** in ASP.NET Core MVC.

---

## 🌍 CountryModel

```csharp
public class CountryModel
{
    public int CountryID { get; set; }

    [Required(ErrorMessage = "Country Name is required")]
    [StringLength(100, ErrorMessage = "Country Name can't exceed 100 characters")]
    public string CountryName { get; set; }
}
```

---

## 🗺️ StateModel

```csharp
public class StateModel
{
    public int StateID { get; set; }

    [Required(ErrorMessage = "State Name is required")]
    [StringLength(100, ErrorMessage = "State Name can't exceed 100 characters")]
    public string StateName { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public int CountryID { get; set; }

    // For display purposes
    public string CountryName { get; set; }
}
```

---

## 🏙️ CityModel

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

    // For display purposes
    public string StateName { get; set; }
    public string CountryName { get; set; }
}
```

---

## ✅ Summary

- `Required`: Ensures fields are not left empty.
- `StringLength`: Limits the maximum length of input.
- Use these annotations to validate inputs both on server and client-side with Razor pages.
