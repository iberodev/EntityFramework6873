# EntityFramework6873

This is a Sample project created with ASP.NET Core 1.0.1 and EF Core 1.0.1
to show the issue with [the bulk delete and create problem] (https://github.com/aspnet/EntityFramework/issues/6873)

# Instructions to reproduce
* Clone this repository 
```
git clone https://github.com/iberodev/EntityFramework6873.git
```

* Restore all the dependencies
```
cd EntityFramework6873
dotnet restore
```

* Go to the main project
```
cd EntityFramework6873/src/BulkDeleteAndCreate
```
* Run the web app with IIS or Kestrel (recommended). It will run on http://localhost:5000/
```
dotnet run
```

## Update solution
As per [my answer here] (https://github.com/aspnet/EntityFramework/issues/6873#issuecomment-256524763) it seems 
that the alternate key was causing the issue and the problem is gone when using an index to enforce uniqueness rather
than the alternate key.

```
//entityBuilder.HasAlternateKey(t => new { t.UserId, t.GroupId });
entityBuilder.HasIndex(t => new { t.UserId, t.GroupId });
```