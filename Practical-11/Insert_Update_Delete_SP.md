# Stored Procedures for Country, State, and City (Insert, Update, Delete)

## Country Table

### Insert
```sql
CREATE PROCEDURE [dbo].[PR_Country_Insert]
    @CountryName NVARCHAR(100)
AS
BEGIN
    INSERT INTO [dbo].[Country] ([CountryName])
    VALUES (@CountryName);
END

```

### Update
```sql
CREATE PROCEDURE [dbo].[PR_Country_Update]
    @CountryID INT,
    @CountryName NVARCHAR(100)
AS
BEGIN
    UPDATE [dbo].[Country]
    SET [CountryName] = @CountryName
    WHERE [CountryID] = @CountryID;
END

```
### Delete
```sql
CREATE PROCEDURE [dbo].[PR_Country_Delete]
    @CountryID INT
AS
BEGIN
    DELETE FROM [dbo].[Country]
    WHERE [CountryID] = @CountryID;
END
```

## State Table

### Insert
```sql
CREATE PROCEDURE [dbo].[PR_State_Insert]
    @StateName NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    INSERT INTO [dbo].[State] ([StateName], [CountryID])
    VALUES (@StateName, @CountryID);
END

```

### Update
```sql
CREATE PROCEDURE [dbo].[PR_State_Update]
    @StateID INT,
    @StateName NVARCHAR(100),
    @CountryID INT
AS
BEGIN
    UPDATE [dbo].[State]
    SET [StateName] = @StateName,
        [CountryID] = @CountryID
    WHERE [StateID] = @StateID;
END

```
### Delete
```sql
CREATE PROCEDURE [dbo].[PR_State_Delete]
    @StateID INT
AS
BEGIN
    DELETE FROM [dbo].[State]
    WHERE [StateID] = @StateID;
END
```

## City Table

### Insert
```sql
CREATE PROCEDURE [dbo].[PR_City_Insert]
    @CityName NVARCHAR(100),
    @StateID INT
AS
BEGIN
    INSERT INTO [dbo].[City] ([CityName], [StateID])
    VALUES (@CityName, @StateID);
END

```

### Update
```sql
CREATE PROCEDURE [dbo].[PR_City_Update]
    @CityID INT,
    @CityName NVARCHAR(100),
    @StateID INT
AS
BEGIN
    UPDATE [dbo].[City]
    SET [CityName] = @CityName,
        [StateID] = @StateID
    WHERE [CityID] = @CityID;
END

```
### Delete
```sql
CREATE PROCEDURE [dbo].[PR_City_Delete]
    @CityID INT
AS
BEGIN
    DELETE FROM [dbo].[City]
    WHERE [CityID] = @CityID;
END
```