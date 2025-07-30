using BookStoreApi.Extensions.Mapper;
using BookStoreApi.Model.Db;
using BookStoreApi.Modules.Books.Repostories.Implementations;
using BookStoreApi.Modules.Books.Repostories.Interfaces;
using BookStoreApi.Modules.Books.Services.Implementations;
using BookStoreApi.Modules.Books.Services.Interfaces;
using BookStoreApi.Modules.Orders.Repostories.Implementations;
using BookStoreApi.Modules.Orders.Repostories.Interfaces;
using BookStoreApi.Modules.Orders.Services.Implementations;
using BookStoreApi.Modules.Orders.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddAutoMapper(config => config.ApplyAutoMapperConfiguration());

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

// docker secrets
const string passPath = "/run/secrets/bookstore-db-pass";
const string userPath = "/run/secrets/bookstore-db-user";
const string dbNamePath = "/run/secrets/bookstore-db-name";

string? connectionString;

if (File.Exists(passPath) && File.Exists(userPath) && File.Exists(dbNamePath))
{
    var dbPass = File.ReadAllText(passPath);
    var dbUser = File.ReadAllText(userPath);
    var dbName = File.ReadAllText(dbNamePath);
    connectionString = $"server=bookstore-db;database={dbName};user={dbUser};password={dbPass}";
}
else
{
    // From user secrets
    connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
}

_ = builder.Services.AddDbContext<BookStoreContext>(options =>
{
    _ = options
        .UseMySql(connectionString, new MySqlServerVersion(new Version(9, 4, 0)));
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
    _ = app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "OPENAPI"));
}

using (IServiceScope scope = app.Services.CreateScope())
{
    BookStoreContext dbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
