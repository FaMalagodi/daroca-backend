# daroca-backend
A backend using c# that use SQL server like database, this is a small part of the code, you need use dotnet, after used, go to terminal and use...

```bash
dotnet new webapi
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
dotnet ef
dotnet ef migrations add InitialCreate
dotnet ef database update

