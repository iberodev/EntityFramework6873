# EntityFramework6873

This is a Sample project created with ASP.NET Core 1.0.1 and EF Core 1.0.1
to show the issue with [the argument null problem] (https://github.com/aspnet/EntityFramework/issues/6873)

# Instructions to reproduce
* Clone this repository 
```
git clone https://github.com/iberodev/EntityFramework6873.git
```

* Restore all the dependencies
```
cd EntityFramework6873
dotnet restore
``

* Go to the main project
```
cd EntityFramework6873/src/BulkDeleteAndCreate
```
* Run the web app with IIS or Kestrel (recommended). It will run on http://localhost:5000/
```
dotnet run
```

* View the log on console