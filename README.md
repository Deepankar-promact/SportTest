# Setup
Change connection string in SportTest.Web > appsettings.json.
```
"ConnectionStrings": {
    "SportTestConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=SportTest;Integrated Security=True;MultipleActiveResultSets=true"
  }
```

# Run
To execute the project run directly from the Visual Studio or execute the following commands in the project directory:

```
dotnet restore
dotnet build
dotnet ef database update
cd SportTest.Web
dotnet run
```

