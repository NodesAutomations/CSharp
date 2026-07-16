# Sqlite

## Overview
- It's a lightweight, fast, self-contained database engine that is widely used in applications, including mobile apps, embedded systems, and small-scale web applications.
- It is a serverless database that stores data in a single file, making it easy to deploy and manage.


## How to create Database
- Download [SQLite Browser](https://sqlitebrowser.org/) to create a database file and tables using GUI.
- you can also view existing database files and their contents using SQLite Browser.

## Sample Code
- You'll need to install `System.Data.SQLite.Core` and `Dapper` NuGet packages to work with SQLite in C#.

```csharp
public class SqliteDataAccess
{
    public static List<Client> LoadClients()
    {
        using (IDbConnection cnn= new SQLiteConnection(Config.ConnectionString))
        {
            // Implementation for loading clients from the database
            var output  = cnn.Query<Client>("SELECT * FROM Clients").ToList();
            return output;
        }
    }

    public static void SaveClient(Client client)
    {
        using (IDbConnection cnn = new SQLiteConnection(Config.ConnectionString))
        {
            cnn.Execute("INSERT INTO Clients (Id, Name, FullName, Address, HourlyRate) VALUES (@Id, @Name, @FullName, @Address, @HourlyRate)", client);
        }
    }
}
```