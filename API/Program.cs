using Infrastructure.Data;
// This lets us use the StoreContext class (your database context).

using Microsoft.EntityFrameworkCore;
// This lets us use Entity Framework Core features (like connecting to SQL Server).

var builder = WebApplication.CreateBuilder(args);
// This creates the application builder.
// It sets up configuration, services, logging, etc.


// Add services to the container.
// (Services are things your app can use through dependency injection.)

builder.Services.AddControllers();
// This tells the app to use controllers (like ProductsController).
// Without this, your API controllers won’t work.

builder.Services.AddDbContext<StoreContext>(opt =>
{
    // This registers your database context (StoreContext)
    // so it can be injected into controllers.

    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
    // This tells EF Core to use SQL Server.
    // It gets the connection string named "DefaultConnection"
    // from appsettings.json.
});

var app = builder.Build();
// This builds the app using everything configured above.

app.MapControllers();
// This connects your controllers to the routing system.
// It enables routes like: api/products

app.Run();
// This starts the application.
// The API is now running and ready to receive requests.










// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();
