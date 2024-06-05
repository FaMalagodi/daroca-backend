public class Customer
{
   
    public required int CustomerId { get; set;}

    public required string Name { get; set;}

    //public string Email { get; set;}

    public required decimal Latitude {get; set;}

    public required decimal Longitude {get; set;}

    public required string City { get; set;}

    public required string State { get; set;}
}


// não se coloca hard-code
//app-setting são de produção, dos usuarios
//app-setting.Development é para os testes

// entity framework = spring boot

// dotnet new webapi
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer