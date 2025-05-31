
# AddressBook Database Setup with Naming Conventions

This creates the `AddressBook` database with `Country`, `State`, and `City` tables, inserts sample data, and creates stored procedures using naming conventions.

---

## 📌 1. Create Database

```sql
CREATE DATABASE AddressBook;
GO

USE AddressBook;
GO
```

---

## 📌 2. Create Tables

```sql
CREATE TABLE Country (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    CountryName NVARCHAR(100) NOT NULL
);

CREATE TABLE State (
    StateID INT PRIMARY KEY IDENTITY(1,1),
    StateName NVARCHAR(100) NOT NULL,
    CountryID INT FOREIGN KEY REFERENCES Country(CountryID)
);

CREATE TABLE City (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    CityName NVARCHAR(100) NOT NULL,
    StateID INT FOREIGN KEY REFERENCES State(StateID),
    CountryID INT FOREIGN KEY REFERENCES Country(CountryID)
);

```

---

## 📌 3. Insert Sample Data

```sql
INSERT INTO Country (CountryName) VALUES ('India'), ('USA');

INSERT INTO State (StateName, CountryID) VALUES 
    ('Gujarat', 1), ('Maharashtra', 1),
    ('California', 2), ('Texas', 2);

INSERT INTO City (CityName, StateID) VALUES 
    ('Ahmedabad', 1,1), ('Surat', 1,1),
    ('Mumbai', 2,1), ('Pune', 2,1),
    ('Los Angeles', 3,2), ('San Francisco', 3,2),
    ('Houston', 4,2), ('Dallas', 4,2);

```

---

## 📌 4. Stored Procedures

### ➤ Country

```sql
CREATE PROCEDURE [dbo].[PR_Country_SelectAll]
AS
BEGIN
    SELECT * FROM [dbo].[Country];
END


CREATE PROCEDURE [dbo].[PR_Country_SelectByPK]
    @CountryID INT
AS
BEGIN
    SELECT * FROM [dbo].[Country] WHERE [CountryID] = @CountryID;
END

```

### ➤ State

```sql

CREATE PROCEDURE [dbo].[PR_State_SelectAll]
AS
BEGIN
    SELECT 
        [dbo].[State].[StateID], 
        [dbo].[State].[StateName], 
        [dbo].[State].[CountryID], 
        [dbo].[Country].[CountryName]
    FROM [dbo].[State]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID];
END

CREATE PROCEDURE [dbo].[PR_State_SelectByPK]
    @StateID INT
AS
BEGIN
    SELECT 
        [dbo].[State].[StateID], 
        [dbo].[State].[StateName], 
        [dbo].[State].[CountryID], 
        [dbo].[Country].[CountryName]
    FROM [dbo].[State]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID]
    WHERE [dbo].[State].[StateID] = @StateID;
END

```

### ➤ City

```sql
CREATE PROCEDURE [dbo].[PR_City_SelectAll]
AS
BEGIN
    SELECT 
        [dbo].[City].[CityID], 
        [dbo].[City].[CityName], 
        [dbo].[City].[StateID], 
        [dbo].[State].[StateName], 
        [dbo].[State].[CountryID], 
        [dbo].[Country].[CountryName]
    FROM [dbo].[City]
    INNER JOIN [dbo].[State] ON [dbo].[City].[StateID] = [dbo].[State].[StateID]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID];
END

CREATE PROCEDURE [dbo].[PR_City_SelectByPK]
    @CityID INT
AS
BEGIN
    SELECT 
        [dbo].[City].[CityID], 
        [dbo].[City].[CityName], 
        [dbo].[City].[StateID], 
        [dbo].[State].[StateName], 
        [dbo].[State].[CountryID], 
        [dbo].[Country].[CountryName]
    FROM [dbo].[City]
    INNER JOIN [dbo].[State] ON [dbo].[City].[StateID] = [dbo].[State].[StateID]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID]
    WHERE [dbo].[City].[CityID] = @CityID;
END

```
### ➤ CityGet All Records by City Name

```sql
CREATE PROCEDURE [dbo].[PR_City_SelectByCityName]
    @CityName NVARCHAR(100)
AS
BEGIN
    SELECT 
        [dbo].[City].[CityID],
        [dbo].[City].[CityName],
        [dbo].[State].[StateID],
        [dbo].[State].[StateName],
        [dbo].[Country].[CountryID],
        [dbo].[Country].[CountryName]
    FROM [dbo].[City]
    INNER JOIN [dbo].[State] ON [dbo].[City].[StateID] = [dbo].[State].[StateID]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID]
    WHERE [dbo].[City].[CityName] = @CityName;
END

```
### ➤  Get All Cities by State Name

```sql
CREATE PROCEDURE [dbo].[PR_City_SelectByStateName]
    @StateName NVARCHAR(100)
AS
BEGIN
    SELECT 
        [dbo].[City].[CityID],
        [dbo].[City].[CityName],
        [dbo].[State].[StateID],
        [dbo].[State].[StateName]
    FROM [dbo].[City]
    INNER JOIN [dbo].[State] ON [dbo].[City].[StateID] = [dbo].[State].[StateID]
    WHERE [dbo].[State].[StateName] = @StateName;
END

```
### ➤ Get All States by Country Name With City Count

```sql
CREATE PROCEDURE [dbo].[PR_State_SelectByCountryNameWithCityCount]
    @CountryName NVARCHAR(100)
AS
BEGIN
    SELECT 
        [dbo].[State].[StateID],
        [dbo].[State].[StateName],
        COUNT([dbo].[City].[CityID]) AS TotalCities
    FROM [dbo].[State]
    INNER JOIN [dbo].[Country] ON [dbo].[State].[CountryID] = [dbo].[Country].[CountryID]
    LEFT JOIN [dbo].[City] ON [dbo].[State].[StateID] = [dbo].[City].[StateID]
    WHERE [dbo].[Country].[CountryName] = @CountryName
    GROUP BY [dbo].[State].[StateID], [dbo].[State].[StateName];
END
GO

```